namespace WinColorMeasure.Extensions
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public static class ColorExtentions
    {
        public static string ToHexString(this Color c)
        {
            return $"#{c.R:X2}{c.G:X2}{c.B:X2}";
        }

        public static Color HexStringToColor(this string hex)
        {
            if (!hex.StartsWith("#"))
            {
                return Color.Empty;
            }

            return ColorTranslator.FromHtml(hex);
        }

        public static Color ToColor(this CMYK cmyk)
        {
            return Color.FromArgb(Convert(cmyk.C), Convert(cmyk.M), Convert(cmyk.Y));

            // ----
            byte Convert(float v)
            {
                return (byte)(255 * (1 - v) * (1 - cmyk.K));
            }
        }
    }
}

