using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorMesure
{
    public class ZoomBoxBase : UserControl
    {
        private int _zoomFactor;
        private int _minZoom;
        private int _maxZoom;

        protected Bitmap _ZoomedBitmap;

        public ZoomBoxBase() : this(3)
        { }

        public ZoomBoxBase(int zoomFactor, int minZoom, int maxZoom)
        {
            _zoomFactor = zoomFactor;
            _minZoom = minZoom;
            _maxZoom = maxZoom;
        }

        public ZoomBoxBase(int zoomFactor)
            : this(zoomFactor, 2, 6)
        { }


        public int ZoomFactor
        {
            get { return _zoomFactor; }
            set
            {
                if (value != _zoomFactor)
                {
                    _zoomFactor = value;
                    OnZoomFactorChanged(value);
                }
            }
        }

        public int MinimumZoom
        {
            get { return _minZoom; }
            set { _minZoom = value; }
        }

        public int MaximumZoom
        {
            get { return _maxZoom; }
            set { _maxZoom = value; }
        }

        public event EventHandler<int> ZoomFactorChanged;


        protected void OnZoomFactorChanged(int newFactor)
        {
            ZoomFactorChanged?.Invoke(this, newFactor);
        }

        protected Bitmap CreateZoomedBitmap(Image srcImg, Point cursorPos, Size targetSize)
        {
            return CreateZoomedBitmap(srcImg, cursorPos, targetSize, _zoomFactor);
        }

        protected static Bitmap CreateZoomedBitmap(Image srcImg,Point cursorPos, Size targetSize, int zoomFactor)
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

            //bmGraphics.Clear(Parent.BackColor);

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


    }
}
