using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ColorMesure.InterOp
{
    sealed class Win32
    {
        /// <summary>
        /// Retrieves a handle to a device context (DC) for the client area of a specified window or for 
        /// the entire screen. You can use the returned handle in subsequent GDI functions to draw in the DC.
        /// </summary>
        /// <param name="hwnd">A handle to the window whose DC is to be retrieved.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        /// <summary>
        /// Releases a device context (DC), freeing it for use by other applications.
        /// </summary>
        /// <param name="hwnd">A handle to the window whose DC is to be released.</param>
        /// <param name="hdc">A handle to the DC to be released.</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        /// <summary>
        /// Retrieves the red, green, blue (RGB) color value of the pixel at the specified coordinates.
        /// </summary>
        /// <param name="hdc">A handle to the device context</param>
        /// <param name="nXPos">The x-coordinate, in logical units, of the pixel to be examined.</param>
        /// <param name="nYPos">The y-coordinate, in logical units, of the pixel to be examined.</param>
        /// <returns>COLORREF</returns>
        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        /// <summary>
        /// Returns a handle to the desktop window. The desktop window covers the entire screen, 
        /// it's the area on top of which other windows are painted.
        /// </summary>
        /// <returns>HWND</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        public static Point GetCursorPosition()
        {
            POINT pt;
            if (GetCursorPos(out pt))
            {
                return new Point(pt.X, pt.Y);
            }
            
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }
    }
}


