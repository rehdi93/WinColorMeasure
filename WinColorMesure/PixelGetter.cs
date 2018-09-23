using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinColorMeasure
{
    using static InterOp.Win32;

    public class GDIPixelGetter
    {

        public Bitmap GetDesktopImage(Rectangle bounds)
        {
            return InternalGetDesktopImg(bounds);
        }

        public Color GetPixelColor(int x, int y)
        {
            var win32Color = GetWin32ColorAtPoint(x, y);
            return ColorTranslator.FromWin32(win32Color);
        }

        public Color GetPixelColor(Point pos)
        {
            return GetPixelColor(pos.X, pos.Y);
        }

        public Color GetPixelColor()
        {
            var cursorPos = GetCursorPosition();
            var win32Color = GetWin32ColorAtPoint(cursorPos.X, cursorPos.Y);
            return ColorTranslator.FromWin32(win32Color);
        }

        public Stream GetDesktopImageStream(Rectangle bounds)
        {
            var bm = InternalGetDesktopImg(bounds);
            var mem = new MemoryStream();
            bm.Save(mem, ImageFormat.Bmp);

            return mem;
        }

        private Bitmap InternalGetDesktopImg(Rectangle srcBounds)
        {
            var bitmap = new Bitmap(srcBounds.Width, srcBounds.Height, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CopyFromScreen(srcBounds.Location, Point.Empty, srcBounds.Size);
            }

            return bitmap;
        }

        private int GetWin32ColorAtPoint(int x, int y)
        {
            var desktop = IntPtr.Zero;
            return GetWin32ColorAtPoint(x, y, desktop);
        }
        
        private int GetWin32ColorAtPoint(int x, int y, IntPtr handle)
        {
            IntPtr hdc = GetDC(handle);
            uint win32color = GetPixel(hdc, x, y);
            ReleaseDC(handle, hdc);

            return (int)win32color;
        }

        int PhysicalToLogical(int pixel, float dpi)
        {
            return (int) (pixel * 96f / dpi);
        }

        int LogicalToPhysical(int pixel, float dpi)
        {
            return (int) (pixel * dpi / 96f);
        }
    }

}
