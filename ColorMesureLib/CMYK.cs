using System;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace ColorMesure
{
    public struct CMYK
    {
        const float Cmyk_min = 0.0f,
                    Cmyk_max = 1.0f;

        private float _c;
        private float _m;
        private float _y;
        private float _k;


        private CMYK(float[] raw)
        {
            if (raw.Length != 4)
            {
                throw new ArgumentException("Invalid array, must have 4 elements");
            }

            _c = raw[0];
            _m = raw[1];
            _y = raw[2];
            _k = raw[3];
        }

        public CMYK(float c, float m, float y, float k)
        {
            _c = c;
            _m = m;
            _y = y;
            _k = k;
        }

        public float C
        {
            get => _c;
            set
            {
                _c = value > Cmyk_min ? Math.Min(value, Cmyk_max) : Cmyk_min;
            }
        }

        public float M
        {
            get => _m;
            set
            {
                _m = value > Cmyk_min ? Math.Min(value, Cmyk_max) : Cmyk_min;
            }
        }

        public float Y
        {
            get => _y;
            set
            {
                _y = value > Cmyk_min ? Math.Min(value, Cmyk_max) : Cmyk_min;
            }
        }

        public float K
        {
            get => _k;
            set
            {
                _k = value > Cmyk_min ? Math.Min(value, Cmyk_max) : Cmyk_min;
            }
        }

        public static CMYK FromRGB(byte r, byte g, byte b)
        {
            if (r == 0 && g == 0 && b == 0)
            {
                // black
                return new CMYK(0f, 0f, 0f, 1f);
            }

            // adust RGB range
            // [0-255] -> [0-1]
            float r_ = r / 255f;
            float g_ = g / 255f;
            float b_ = b / 255f;

            // extract out K [0-1]
            float k = 1 - Math.Max(r_, Math.Max(g_, b_));

            float[] rawValues =
            {
                (1 - r_ - k) / (1 - k), // C
                (1 - g_ - k) / (1 - k), // M
                (1 - b_ - k) / (1 - k), // Y
                k                       // K
            };

            return new CMYK(rawValues);
        }

        public static CMYK FromColor(Color color)
        {
            return FromRGB(color.R, color.G, color.B);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CMYK))
            {
                return false;
            }

            var cMYK = (CMYK)obj;
            return Equals(cMYK);
        }

        public bool Equals(CMYK cmyk)
        {
            return C == cmyk.C &&
                   M == cmyk.M &&
                   Y == cmyk.Y &&
                   K == cmyk.K;
        }

        public override int GetHashCode()
        {
            var hashCode = -492570696;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + C.GetHashCode();
            hashCode = hashCode * -1521134295 + M.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + K.GetHashCode();
            return hashCode;
        }


        public static bool operator ==(CMYK left, CMYK right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CMYK left, CMYK right)
        {
            return !(left == right);
        }


        public override string ToString()
        {
            string info = GetType().Name;
            info += $" [C={C:F3}, M={M:F3}, Y={Y:F3}, K={K:F3}]";

            return info;
        }

        //public string ToString(string format, IFormatProvider formatProvider)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    string baseFmt = " [C={0}, M={1}, Y={2}, K={3}]";

        //    if (format == null)
        //    {
        //        sb.AppendFormat(" [C={0:F3}, M={1:F3}, Y={2:F3}, K={3:F3}]", C, M, Y, K);
        //    }
        //    else
        //    {
        //        formatProvider.
        //        var nfi = new NumberFormatInfo();
        //        var sep = nfi.NumberDecimalSeparator;

        //        sb.AppendFormat(provider, );
        //    }
        //}
    }

}