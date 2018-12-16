using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WinColorMeasure
{
    using static InterOp.Win32;

    public class GDIPixelGetter
    {
        public Bitmap GetDesktopImage(Rectangle bounds)
        {
            var bitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            }

            return bitmap;
        }

        public Color GetPixelColor(Point pos)
        {
            var win32color = GetWin32ColorAtPoint(pos.X, pos.Y);
            return ColorTranslator.FromWin32(win32color);
        }

        public Color GetPixelColor()
        {
            var cursorPos = GetCursorPosition();
            return GetPixelColor(cursorPos);
        }


        private int GetWin32ColorAtPoint(int x, int y)
        {
            var desktopDC = IntPtr.Zero;
            return GetWin32ColorAtPoint(x, y, desktopDC);
        }
        
        private int GetWin32ColorAtPoint(int x, int y, IntPtr handle)
        {
            IntPtr hdc = GetDC(handle);
            uint win32color = GetPixel(hdc, x, y);
            ReleaseDC(handle, hdc);

            return (int)win32color;
        }

    }

}
