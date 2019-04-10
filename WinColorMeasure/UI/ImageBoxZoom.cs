using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WinColorMeasure.UI
{
    using Debug = System.Diagnostics.Debug;

    public partial class ImageBoxZoom : UserControl
    {
        private ContentAlignment _zoomPopupPos = ContentAlignment.TopRight;
        private ContentAlignment _altZoomPos;
        private bool _scrollVisible;
        private int _zoomFactor = 3;
        private int _minZoom = 2;
        private int _maxZoom = 6;

        protected Bitmap _ZoomedBitmap;


        public ImageBoxZoom()
        {
            InitializeComponent();

            _altZoomPos = GetDefaultAltPos(_zoomPopupPos);
        }


        #region Public Api

        [Category("Zoom")]
        [DefaultValue(ContentAlignment.TopRight)]
        public ContentAlignment PopupPosition
        {
            get => _zoomPopupPos;
            set
            {
                if (value != _zoomPopupPos)
                {
                    SetZoomBoxAlignment(value);
                }
            }
        }

        [Category("Zoom")]
        public ContentAlignment PopupPositionAlt
        {
            get => _altZoomPos;
            set
            {
                if (value == _zoomPopupPos)
                {
                    _altZoomPos = GetDefaultAltPos(value);
                }
                else
                {
                    _altZoomPos = value;
                }
            }
        }

        [Category("Zoom")]
        [DefaultValue(3)]
        public int ZoomFactor
        {
            get => _zoomFactor;
            set => SetZoomFactor(value);
        }

        [Category("Zoom")]
        [DefaultValue(2)]
        public int MinimumZoom
        {
            get => _minZoom;
            set
            {
                if (value != _minZoom)
                {
                    _minZoom = value;
                    SetZoomFactor(_zoomFactor);
                }
            }
        }

        [Category("Zoom")]
        [DefaultValue(6)]
        public int MaximumZoom
        {
            get => _maxZoom;
            set
            {
                if (value != _maxZoom)
                {
                    _maxZoom = value;
                    SetZoomFactor(_zoomFactor);
                }
            }
        }

        [Category("Zoom")]
        [DefaultValue(true)]
        public bool ShowPopup
        {
            get => zoomPopupBox.Visible;
            set => zoomPopupBox.Visible = value;
        }

        [Category("Zoom")]
        [DefaultValue(150)]
        public int PopupSize
        {
            get => zoomPopupBox.Width;
            set
            {
                // the zoomPopup must remain square
                zoomPopupBox.Width = value;
                zoomPopupBox.Height = value;

                RefreshZoomBoxAlignment();
            }
        }

        [Category("Appearance")]
        public Image Image
        {
            get { return this.imgBox.Image; }
            set
            {
                if (value != null)
                {
                    var gu = default(GraphicsUnit);
                    var szImg = Rectangle.Round(value.GetBounds(ref gu)).Size;
                    SetImgBoxSize(szImg);
                }

                this.imgBox.Image = value;
            }
        }

        [Browsable(false)]
        public Image ZoomedImage
        {
            get
            {
                return _ZoomedBitmap;
            }
        }

        [Category("Zoom")]
        [DefaultValue(true)]
        public bool UpdateOnMouseMove { get; set; } = true;


        [Category("Zoom")]
        public event EventHandler<int> ZoomFactorChanged;

        [Category("Zoom")]
        public event EventHandler PopupBoundsChanged;

        #endregion

        #region Overrides

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpdateZoomedImage(e.Location);
            }

            base.OnMouseClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (UpdateOnMouseMove)
                UpdateZoomedImage(e.Location);

            base.OnMouseMove(e);
        }

        protected override void OnCreateControl()
        {
            RefreshZoomBoxAlignment();
            base.OnCreateControl();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RefreshZoomBoxAlignment();
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);

            if (se.Type == ScrollEventType.ThumbTrack) {
                zoomPopupBox.Hide();
            } else {
                zoomPopupBox.Show();
                RefreshZoomBoxAlignment();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            RefreshZoomBoxAlignment();
        }

        #endregion

        #region Implementation

        protected static Bitmap CreateZoomedBitmap(Image srcImg, Point cursorPos, Size targetSize, int zoomFactor)
        {
            if (srcImg == null) return null;

            // Calculate the width and height of the portion of the image we want
            // to show in the Zoombox. This value changes when the zoom factor is changed.
            Size zoom = new Size(targetSize.Width / zoomFactor, targetSize.Height / zoomFactor);

            // Calculate the horizontal and vertical midpoints for correct centering of the new image
            Point midpoint = new Point(zoom.Width / 2, zoom.Height / 2);

            // Create a new temporary bitmap to fit inside the picZoom picturebox
            Bitmap tempBitmap = new Bitmap(zoom.Width, zoom.Height,
                                           PixelFormat.Format24bppRgb);

            // Create a temporary Graphics object to work on the bitmap
            Graphics bmGraphics = Graphics.FromImage(tempBitmap);

            // Set the interpolation mode
            bmGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw the portion of the main image onto the bitmap
            // The target rectangle is already known now.
            // Here the mouse position of the cursor on the main image is used to
            // cut out a portion of the main image.
            bmGraphics.DrawImage(srcImg,
                                 new Rectangle(0, 0, zoom.Width, zoom.Height),
                                 new Rectangle(cursorPos.X - midpoint.X, cursorPos.Y - midpoint.Y,
                                 zoom.Width, zoom.Height), GraphicsUnit.Pixel);

            // Dispose of the Graphics object
            bmGraphics.Dispose();

            return tempBitmap;
        }

        protected void OnZoomFactorChanged(int newFactor)
        {
            ZoomFactorChanged?.Invoke(this, newFactor);
        }

        protected void OnPopupBoundsChanged()
        {
            PopupBoundsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void RefreshZoomBoxAlignment() => SetZoomBoxAlignment(_zoomPopupPos);

        private void SetZoomBoxAlignment(ContentAlignment alignment)
        {
            // if new alignment is the current altPos, set the
            // altPos to the old current value
            if (_altZoomPos == alignment)
                _altZoomPos = _zoomPopupPos;

            _zoomPopupPos = alignment;

            Debug.Assert(_zoomPopupPos != _altZoomPos, "zoomPos cannot equal altPos");

            
            if (!this.Created) return;

            // set positioning and anchors
            Rectangle area = new Rectangle(new Point(3, 3), zoomPopupBox.Size);
            int rbOffset = _scrollVisible ? 25 : 5;
            AnchorStyles anchor = AnchorStyles.Top | AnchorStyles.Left;

            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                    //anchor = AnchorStyles.Top | AnchorStyles.Left;
                    break;
                case ContentAlignment.TopCenter:
                    area.Offset(Width / 2 - area.Width / 2, 0);
                    anchor = AnchorStyles.Top;
                    break;
                case ContentAlignment.TopRight:
                    area.Offset(Width - area.Right - rbOffset, 0);
                    anchor = AnchorStyles.Top | AnchorStyles.Right;
                    break;
                case ContentAlignment.MiddleLeft:
                    area.Offset(0, Height / 2 - area.Height / 2);
                    anchor = AnchorStyles.Left;
                    break;
                case ContentAlignment.MiddleCenter:
                    area.Offset(Width / 2 - area.Width / 2, Height / 2 - area.Height / 2);
                    anchor = AnchorStyles.None;
                    break;
                case ContentAlignment.MiddleRight:
                    area.Offset(Width - area.Right - rbOffset, Height / 2 - area.Height / 2);
                    anchor = AnchorStyles.Right;
                    break;
                case ContentAlignment.BottomLeft:
                    area.Offset(0, Height - area.Bottom - rbOffset);
                    anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                    break;
                case ContentAlignment.BottomCenter:
                    area.Offset(Width / 2 - area.Width / 2, Height - area.Bottom - rbOffset);
                    anchor = AnchorStyles.Bottom;
                    break;
                case ContentAlignment.BottomRight:
                    area.Offset(Width - area.Right - rbOffset, Height - area.Bottom - rbOffset);
                    anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                    break;
                default:
                    break;
            }

            if (zoomPopupBox.Bounds != area)
            {
                zoomPopupBox.Bounds = area;
                zoomPopupBox.Anchor = anchor;
                OnPopupBoundsChanged();
            }
        }

        private Bitmap CreateZoomedBitmap(Point centerPt, Size tgtSize)
        {
            return CreateZoomedBitmap(imgBox.Image, centerPt, tgtSize, _zoomFactor);
        }

        private static ContentAlignment GetDefaultAltPos(ContentAlignment alignment)
        {
            ContentAlignment altAlign;

            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                    altAlign = ContentAlignment.BottomLeft;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                    altAlign = ContentAlignment.BottomCenter;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                    altAlign = ContentAlignment.BottomRight;
                    break;
                case ContentAlignment.BottomLeft:
                    altAlign = ContentAlignment.TopLeft;
                    break;
                case ContentAlignment.BottomCenter:
                    altAlign = ContentAlignment.TopCenter;
                    break;
                case ContentAlignment.BottomRight:
                    altAlign = ContentAlignment.TopRight;
                    break;
                default:
                    goto case ContentAlignment.TopLeft;
            }

            return altAlign;
        }

        private void SetImgBoxSize(Size szImg)
        {
            if (szImg.Width <= Width && szImg.Height <= Height)
            {
                imgBox.Dock = DockStyle.Fill;
                imgBox.SizeMode = PictureBoxSizeMode.Normal;

                _scrollVisible = false;
            }
            else if (szImg.Width > Width || szImg.Height > Height)
            {
                imgBox.Dock = DockStyle.None;
                imgBox.SizeMode = PictureBoxSizeMode.AutoSize;
                imgBox.Size = szImg;

                _scrollVisible = true;
            }

            // re-align zoombox
            RefreshZoomBoxAlignment();
        }

        private void UpdateZoomedImage(Point cursorPos)
        {
            _ZoomedBitmap = CreateZoomedBitmap(cursorPos, zoomPopupBox.Size);

            if (!zoomPopupBox.Visible) return;

            zoomPopupBox.Image = _ZoomedBitmap;

            // Refresh to reflect the changes
            zoomPopupBox.Refresh();
        }

        private void SetZoomFactor(int value)
        {
            int nz = value;
            
            // ensure value is within the allowed range
            if (_minZoom > 0)
            {
                nz = Math.Max(_minZoom, value);
            }

            if (_maxZoom > 0)
            {
                nz = Math.Min(_maxZoom, value);
            }

            if (nz != _zoomFactor)
            {
                _zoomFactor = nz;
                OnZoomFactorChanged(nz);
            }
        }

        #endregion
        
        #region Child event handlers

        private void zoomPopupBox_Paint(object sender, PaintEventArgs e)
        {
            var pb = (Control)sender;

            // Draw the 'Cross' cursor in the center of the zoom area
            // mimic-ing the actual cursor position
            var offset = Cursors.Cross.HotSpot;

            int cPos_x = (pb.Width / 2)  - offset.X;
            int cPos_y = (pb.Height / 2) - offset.Y;

            Cursors.Cross.Draw(e.Graphics, new Rectangle(cPos_x, cPos_y, 1, 1));
        }

        private void zoomPopupBox_MouseEnter(object sender, EventArgs e)
        {
            // Set the zoomBox position to its alt
            if (!DesignMode)
                SetZoomBoxAlignment(_altZoomPos);
        }



        private void imgBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void imgBox_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void imgBox_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void imgBox_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        #endregion

        #region Designer hidden Stuff
        [Browsable(false)]
        public override Image BackgroundImage
        { get => base.BackgroundImage; set => base.BackgroundImage = value; }

        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        { get => base.BackgroundImageLayout; set => base.BackgroundImageLayout = value; }
        #endregion

    }
}
