using ColorMesure;
using System.Drawing;

namespace WinColorMesure
{
    class ColorPresenter : ColorPresenterBase
    {
        public static CMYK RGB_to_Cmyk(Color color)
        {
            float[] raw = RGB_to_Cmyk(color.R, color.G, color.B);
            return new CMYK(raw);
        }

        public static Color Cmyk_to_RGB(CMYK cmyk)
        {
            byte[] raw = Cmyk_to_RGB(cmyk.C, cmyk.M, cmyk.Y, cmyk.K);
            return Color.FromArgb(raw[0], raw[1], raw[2]);
        }
    }
}
