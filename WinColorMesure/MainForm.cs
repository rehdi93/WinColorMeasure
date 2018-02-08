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
using ColorMesure;
using ColorMesure.Extensions;

namespace WinColorMesure
{
    using Debug = System.Diagnostics.Debug;

    public partial class MainForm : Form
    {
        GDIPixelGetter _pixelGetter;
        Color _currentColor;
        ColorInfoFormat _currentInfoFormat;
        RecentColorsCollection colorHistory = new RecentColorsCollection(5);
        Bitmap _currentDesktopImg;
        int _zoomFactor;
        Color _zoomCHColor = Color.Black;
        Point _lastCursorPos = Point.Empty;

        // shared TSMenu Items
        ToolStripMenuItem copyColorMenuItem;

        public MainForm()
        {
            InitializeComponent();
            _zoomFactor = zoomTrackBar.Value;

            copyColorMenuItem = new ToolStripMenuItem()
            {
                Text = "Copiar cor",
                ShortcutKeys = (Keys)Shortcut.CtrlC
            };
            copyColorMenuItem.Click += OnCopyColorText_Click;


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

            colorInfoLabel.Text = FormatColorInfoTextUI(color, _currentInfoFormat);

        }


        void UpdatePreviewImage()
        {
            // hide window
            this.Opacity = 0.0;

            // Dispose current desktop bitmap
            _currentDesktopImg?.Dispose();
            imageBoxZoom.Image = null;

            // get new desktop bitmap, adjust size of picImage so the parent panel
            // gives us proper scroll bars
            var currentScr = Screen.FromControl(this);
            _currentDesktopImg = _pixelGetter.GetDesktopImage(currentScr.Bounds);

            //picImage.Size = currentScr.Bounds.Size;
            //picImage.Image = _currentDesktopImg;
            imageBoxZoom.Image = _currentDesktopImg;

            // re-show window
            this.Opacity = 1.0;

            // update fields
            //UpdateZoomedImage(_lastCursorPos);
            UpdateCurrentColor(_pixelGetter.GetPixelColor());
        }

        string FormatColorInfoTextUI(Color color, ColorInfoFormat format)
        {
            //StringBuilder sb = new StringBuilder();
            string infoText = string.Empty;
            const string sep = "\n";

            switch (format)
            {
                case ColorInfoFormat.RGB:
                    infoText += "R: " + color.R + sep;
                    infoText += "G: " + color.G + sep;
                    infoText += "B: " + color.B;
                    break;
                case ColorInfoFormat.CMYK:
                    var cmyk = CMYK.FromColor(color);

                    infoText += "C: " + cmyk.C.ToString("F3") + sep;
                    infoText += "M: " + cmyk.M.ToString("F3") + sep;
                    infoText += "Y: " + cmyk.Y.ToString("F3") + sep;
                    infoText += "K: " + cmyk.K.ToString("F3");
                    break;
                case ColorInfoFormat.HEX:
                    infoText += "Hex: " + color.ToHexString();
                    break;
                default:
                    break;
            }

            return infoText;
        }

        string FormatColorInfo(Color color, ColorInfoFormat format)
        {
            string infoText = string.Empty;

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

            return infoText;
        }

        private void UpdateColorHistory()
        {
            historyMenuItem.DropDownItems.Clear();

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
            zoomTSComboBox.SelectedIndex = zoomTSComboBox.Items.IndexOf("x" + _zoomFactor);
        }
        
        private void ZoomTSComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = zoomTSComboBox.SelectedItem;
            var value = int.Parse((item as string).Substring(1));

            _zoomFactor = value;
            zoomTrackBar.Value = value;
        }

        private void ImageBoxZoom_MouseLeave(object sender, EventArgs e)
        {
            statusLabel.Text = "{OB}";
        }


        private void ImageBoxZoom_MouseMove(object sender, MouseEventArgs e)
        {
            //if (UpdateColorOnMouseMove)
            //{
            //    var color = _pixelGetter.GetPixelColor();
            //    UpdateCurrentColor(color);
            //}

            statusLabel.Text = "Mouse pos: " + e.Location;
        }

        private void imageBoxZoom_Click(object sender, EventArgs e)
        {
            var color = _pixelGetter.GetPixelColor(MousePosition);
            UpdateCurrentColor(color);
        }


        private void OnCopyColorText_Click(object sender, EventArgs e)
        {
            string colorText = FormatColorInfo(_currentColor, _currentInfoFormat);
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

                colorInfoLabel.Text = FormatColorInfoTextUI(_currentColor, _currentInfoFormat);
            }
        }

        private void ColorTextFormatItems_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem ts)
            {
                var format = (ColorInfoFormat)ts.Tag;
                //string dropDownOf = ts.Owner.Tag as string;

                //if (ts.OwnerItem == copyColorAsMenuItem)
                //{
                    var colorText = FormatColorInfo(_currentColor, format);
                    Clipboard.SetText(colorText);
                //}

                colorHistory.Add(_currentColor);
            }
        }

        private void OnOpeningSharedMenu(object sender, CancelEventArgs e)
        {
            if (sender is ContextMenuStrip cm)
            {
                // add shared context menu items
                if (cm == colorContextMenu)
                {
                    colorContextMenu.Items.Insert(0, copyColorMenuItem);

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
            _zoomFactor = zoomTrackBar.Value;
            zoomFactorLabel.Text = "x" + _zoomFactor;

            imageBoxZoom.ZoomFactor = _zoomFactor;
        }

        private void zoomToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var zoomItem = e.ClickedItem as ToolStripMenuItem;
            var value = int.Parse(zoomItem.Text.Substring(1));

            _zoomFactor = value;
            zoomTrackBar.Value = value;
        }

        private void OnSharedDropdown_Opening(object sender, EventArgs e)
        {
            fileToolStripMenuItem.DropDownItems.Insert(1, copyColorMenuItem);
        }
        
    }

}
