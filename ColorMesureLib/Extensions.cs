namespace ColorMesure.Extensions
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

            var c = ColorTranslator.FromHtml(hex);
            return c;
        }

        public static Color FromCmyk(this CMYK cmyk)
        {
            var rawRGB = new byte[]
            {
                (byte)(255 * (1 - cmyk.C) * (1 - cmyk.K)), // R
                (byte)(255 * (1 - cmyk.M) * (1 - cmyk.K)), // G
                (byte)(255 * (1 - cmyk.Y) * (1 - cmyk.K))  // B
            };

            return Color.FromArgb(rawRGB[0], rawRGB[1], rawRGB[2]);
        }
    }
}

