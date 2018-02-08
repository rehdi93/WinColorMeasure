namespace ColorMesure
{
    using System;

    abstract class ColorPresenterBase
    {
        protected static float[] RGB_to_Cmyk(byte r, byte g, byte b)
        {
            if (r == 0 && g == 0 && b == 0)
            {
                // black
                return new[] { 0f, 0f, 0f, 1f };
            }

            // adust RGB range
            // [0-255] -> [0-1]
            float r_ = r / 255f;
            float g_ = g / 255f;
            float b_ = b / 255f;

            // extract out K [0-1]
            float k = 1 - Math.Max(r_, Math.Max(g_, b_));

            float[] cmyk =
            {
                (1 - r_ - k) / (1 - k), // C
                (1 - g_ - k) / (1 - k), // M
                (1 - b_ - k) / (1 - k), // Y
                k                       // K
            };

            return cmyk;
        }

        protected static byte[] Cmyk_to_RGB(float c, float m, float y, float k)
        {
            return new byte[]
            {
                (byte)(255 * (1 - c) * (1 - k)), // R
                (byte)(255 * (1 - m) * (1 - k)), // G
                (byte)(255 * (1 - y) * (1 - k))  // B
            };
        }
    }
}

