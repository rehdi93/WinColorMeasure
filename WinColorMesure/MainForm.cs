using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinColorMesure;
using WinColorMesure.Extensions;

namespace WinColorMesure
{
    using Debug = System.Diagnostics.Debug;
    using CultureInfo = System.Globalization.CultureInfo;

    public partial class MainForm : Form
    {
        GDIPixelGetter _pixelGetter;
        Color _currentColor;
        ColorInfoFormat _currentInfoFormat;
        RecentColorsCollection colorHistory = new RecentColorsCollection(5);
        Bitmap _currentDesktopImg;
        Point _lastCursorPos = Point.Empty;


        public MainForm()
        {
            InitializeComponent();

            rgbFormatMenuItem.Tag = ColorInfoFormat.RGB;
            cmykFormatMenuItem.Tag = ColorInfoFormat.CMYK;
            hexFormatMenuItem.Tag = ColorInfoFormat.HEX;

            _pixelGetter = new GDIPixelGetter();

            UpdatePreviewImage();
        }


        void UpdateCurrentColor(Color color)
        {
            if (color == pColor.BackColor) return;

            pColor.BackColor = color;
            _currentColor = color;

            colorInfoLabel.Text = FormatColorInfo(color, _currentInfoFormat, true);

        }


        void UpdatePreviewImage()
        {
            // hide window
            this.Opacity = 0.0;

            // Dispose current desktop bitmap
            _currentDesktopImg?.Dispose();
            imageBoxZoom.Image = null;

            // get new desktop bitmap
            var currentScr = Screen.FromControl(this);
            _currentDesktopImg = _pixelGetter.GetDesktopImage(currentScr.Bounds);

            imageBoxZoom.Image = _currentDesktopImg;

            // re-show window
            this.Opacity = 1.0;

            // update fields
            UpdateCurrentColor(_pixelGetter.GetPixelColor());
        }

        string FormatColorInfo(Color color, ColorInfoFormat format, bool ui)
        {
            //StringBuilder sb = new StringBuilder();
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
                        var cmyk = CMYK.FromColor(color);

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
                        var cmyk = CMYK.FromColor(color);
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
            // clear local
            historyMenuItem.DropDownItems.Clear();

            // construct list of recent colors
            foreach (var c in colorHistory)
            {
                Bitmap bm = new Bitmap(30, 30);
                using (Graphics g = Graphics.FromImage(bm))
                {
                    g.Clear(c);
                }

                var menuItem = new ToolStripMenuItem
                {
                    Image = bm,
                    TextImageRelation = TextImageRelation.Overlay,
                    DropDown = colorContextMenu,
                    Tag = c
                };
                menuItem.DropDownOpened += (s, e) =>
                {
                    var color = (Color)(s as ToolStripItem).Tag;
                    UpdateCurrentColor(color);
                };

                historyMenuItem.DropDownItems.Add(menuItem);
            }
        }


        private void Main_Load(object sender, EventArgs e)
        {
            // populate zoom tsMenuItem
            var zoomRange = Enumerable.Range(imageBoxZoom.MinimumZoom, 
                imageBoxZoom.MaximumZoom - imageBoxZoom.MinimumZoom + 1);
            
            zoomTSComboBox.Items.AddRange(zoomRange.Select(z => "x" + z).ToArray());
            zoomTSComboBox.SelectedItem = "x" + imageBoxZoom.ZoomFactor;

            zoomTSMenuItem.DropDown.RenderMode = ToolStripRenderMode.System;

            // lang
            CultureInfo english = new CultureInfo("en"),
                ptbr = new CultureInfo("pt-br");

            int selected = System.Threading.
                Thread.CurrentThread.CurrentCulture.Name == ptbr.Name ? 1 : 0;

            langTSComboBox.Items.Add(english);
            langTSComboBox.Items.Add(ptbr);
            langTSComboBox.SelectedIndex = selected;
            langTSComboBox.SelectedIndexChanged += langTSComboBox_SelectedIndexChanged;

            historyMenuItem.DropDown.RenderMode = ToolStripRenderMode.System;

        }


        private void ImageBoxZoom_MouseLeave(object sender, EventArgs e)
        {
            statusLabel.Text = "Mouse: {OB}";
        }


        private void ImageBoxZoom_MouseMove(object sender, MouseEventArgs e)
        {
            statusLabel.Text = "Mouse: " + e.Location;
        }

        private void imageBoxZoom_Click(object sender, EventArgs e)
        {
            var color = _pixelGetter.GetPixelColor(MousePosition);
            UpdateCurrentColor(color);
        }


        private void OnCopyColorText_Click(object sender, EventArgs e)
        {
            string colorText = FormatColorInfo(_currentColor, _currentInfoFormat, false);
            Clipboard.SetText(colorText);
            colorHistory.Add(_currentColor);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

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

                colorHistory.Add(_currentColor);
            }
        }

        private void OnOpeningSharedMenu(object sender, CancelEventArgs e)
        {
            if (sender is ContextMenuStrip cm)
            {
                if (cm == colorContextMenu)
                {
                    var color = _pixelGetter.GetPixelColor();
                    UpdateCurrentColor(color);
                }
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

        private void OnSharedDropdown_Opening(object sender, EventArgs e)
        {
            //fileToolStripMenuItem.DropDownItems.Insert(1, copyColorMenuItem);
        }

        private void langTSComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: not working ATM, how to localize at runtime?
            var culture = (CultureInfo)langTSComboBox.SelectedItem;
            var res = new ComponentResourceManager(typeof(MainForm));

            foreach (Control ctrl in Controls)
            {
                res.ApplyResources(ctrl, ctrl.Name, culture);
            }

            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().Show(this);
        }
    }

}
