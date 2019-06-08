using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinColorMeasure.Extensions;

namespace WinColorMeasure
{

    public partial class MainForm : Form
    {
        Color _currentColor;
        Bitmap currentBitmap;
        ColorInfoFormat _currentInfoFormat;
        Queue<Color> colorHistory = new Queue<Color>(10);


        public MainForm()
        {
            InitializeComponent();

            rgbFormatMenuItem.Tag = ColorInfoFormat.RGB;
            cmykFormatMenuItem.Tag = ColorInfoFormat.CMYK;
            hexFormatMenuItem.Tag = ColorInfoFormat.HEX;

            UpdatePreviewImage();
        }
        

        Bitmap GetDesktopImage(Rectangle bounds)
        {
            var bm = new Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (var g = Graphics.FromImage(bm))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            }

            return bm;
        }
        Bitmap GetDesktopImage() => GetDesktopImage(SystemInformation.VirtualScreen);

        Color GetPixel()
        {
            var mpos = imageBoxZoom.PointToClient(MousePosition);
            var scrollPos = imageBoxZoom.AutoScrollPosition;

            // offset scroll position
            mpos.X -= scrollPos.X;
            mpos.Y -= scrollPos.Y;

            return currentBitmap.GetPixel(mpos.X, mpos.Y);
        }

        void UpdateCurrentColor(Color color)
        {
            if (color == pColor.BackColor) return;

            pColor.BackColor = _currentColor = color;
            colorInfoLabel.Text = FormatColorInfo(color, _currentInfoFormat, true);
        }


        void UpdatePreviewImage()
        {
            // hide window
            this.Opacity = 0.0;

            // Dispose current desktop bitmap
            imageBoxZoom.Image?.Dispose();

            // get new desktop bitmap
            imageBoxZoom.Image = currentBitmap = GetDesktopImage();

            // re-show window
            this.Opacity = 1.0;

            // update fields
            var color = GetPixel();
            UpdateCurrentColor(color);
        }

        static string FormatColorInfo(Color color, ColorInfoFormat format, bool ui)
        {
            string infoText = string.Empty;

            if (ui)
            {
                switch (format)
                {
                    case ColorInfoFormat.RGB:
                        infoText = $"R: {color.R}\n" +
                                   $"G: {color.G}\n" +
                                   $"B: {color.B}";
                        break;
                    case ColorInfoFormat.CMYK:
                        var cmyk = new CMYK(color);

                        infoText = $"C: {cmyk.C:F3}\n" +
                                   $"M: {cmyk.M:F3}\n" +
                                   $"Y: {cmyk.Y:F3}\n" +
                                   $"K: {cmyk.K:F3}";
                        break;
                    case ColorInfoFormat.HEX:
                        infoText += "Hex: " + color.ToHexString();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (format)
                {
                    case ColorInfoFormat.RGB:
                        infoText = $"{color.R} {color.G} {color.B}";
                        break;
                    case ColorInfoFormat.CMYK:
                        var cmyk = new CMYK(color);
                        infoText = $"{cmyk.C:F3} {cmyk.M:F3} {cmyk.Y:F3} {cmyk.K:F3}";
                        break;
                    case ColorInfoFormat.HEX:
                        infoText = color.ToHexString();
                        break;
                    default:
                        break;
                }
            }

            return infoText;
        }

        private void UpdateColorHistory()
        {
            historyMenuItem.DropDownItems.Clear();

            // construct list of recent colors
            foreach (var c in colorHistory)
            {
                Bitmap bm = new Bitmap(40, 40);
                using (var g = Graphics.FromImage(bm)) { g.Clear(c); }

                var menuItem = new ToolStripMenuItem
                {
                    Image = bm,
                    TextImageRelation = TextImageRelation.Overlay,
                    DropDown = colorContextMenu,
                    Tag = c
                };
                menuItem.DropDownOpened += (s, e) =>
                {
                    var color = (Color)((ToolStripItem)s).Tag;
                    UpdateCurrentColor(color);
                };

                historyMenuItem.DropDownItems.Add(menuItem);
            }

            historyMenuItem.Enabled = historyMenuItem.DropDownItems.Count > 0;
        }

        void AddRecent(Color color)
        {
            if (colorHistory.Count == 10)
            {
                colorHistory.Dequeue();
            }

            colorHistory.Enqueue(color);
        }

        protected override void OnLoad(EventArgs e)
        {
            // populate zoom tsMenuItem
            var zoomRange = Enumerable.Range(imageBoxZoom.MinimumZoom, 
                imageBoxZoom.MaximumZoom - imageBoxZoom.MinimumZoom + 1);
            
            zoomTSComboBox.Items.AddRange(zoomRange.Select(z => "x" + z).ToArray());
            zoomTSComboBox.SelectedItem = "x" + imageBoxZoom.ZoomFactor;
        }


        private void ImageBoxZoom_MouseLeave(object sender, EventArgs e)
        {
            statusLabel.Text = string.Format(Properties.Strings.MousePos, "{OB}");
        }


        private void ImageBoxZoom_MouseMove(object sender, MouseEventArgs e)
        {
            statusLabel.Text = string.Format(Properties.Strings.MousePos, e.Location);
        }

        private void imageBoxZoom_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                case MouseButtons.Right:
                    var color = GetPixel();
                    UpdateCurrentColor(color);
                    AddRecent(color);
                    break;
            }
        }


        private void OnCopyColorText_Click(object sender, EventArgs e)
        {
            string colorText = FormatColorInfo(_currentColor, _currentInfoFormat, false);
            Clipboard.SetText(colorText);
            statusLabel.Text = string.Format(Properties.Strings.ColorCopied, _currentInfoFormat);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e) { Close(); }

        private void atualizarPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePreviewImage();
        }

        private void OnFormatChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                if (rgbRadioButton.Checked)
                    _currentInfoFormat = ColorInfoFormat.RGB;
                else if (hexRadioButton.Checked)
                    _currentInfoFormat = ColorInfoFormat.HEX;
                else if (cmykRadioButton.Checked)
                    _currentInfoFormat = ColorInfoFormat.CMYK;

                colorInfoLabel.Text = FormatColorInfo(_currentColor, _currentInfoFormat, true);
            }
        }

        private void ColorTextFormatItems_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem ts)
            {
                var format = (ColorInfoFormat)ts.Tag;
                var colorText = FormatColorInfo(_currentColor, format, false);
                Clipboard.SetText(colorText);
            }
        }

        private void historyMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateColorHistory();
        }

        private void zoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            imageBoxZoom.ZoomFactor = zoomTrackBar.Value;
        }

        private void ZoomTSComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = zoomTSComboBox.SelectedItem;
            var value = int.Parse((item as string).Substring(1));

            imageBoxZoom.ZoomFactor = value;
        }

        private void imageBoxZoom_ZoomFactorChanged(object sender, int e)
        {
            string zoomText = "x" + e;

            zoomFactorLabel.Text = zoomText;

            zoomTrackBar.Value = e;
            zoomTSComboBox.SelectedItem = zoomText;
        }
        
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutBox();
            aboutBox.Show(this);
        }

        private void colorDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.CustomColors = colorHistory.Select(c => ColorTranslator.ToWin32(c)).ToArray();

            var result = colorDialog.ShowDialog(this);

            if (result == DialogResult.OK)
                UpdateCurrentColor(colorDialog.Color);
        }

    }

}
