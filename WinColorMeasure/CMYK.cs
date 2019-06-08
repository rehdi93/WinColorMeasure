using System;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace WinColorMeasure
{
    public struct CMYK : IEquatable<CMYK>
    {
        private float _c, _m, _y, _k;

        public const float MinValue = 0.0f;
        public const float MaxValue = 1.0f;


        public CMYK(float c, float m, float y, float k)
        {
            _c = c;
            _m = m;
            _y = y;
            _k = k;
        }

        public CMYK(byte red, byte green, byte blue)
        {
            if (red == 0 && green == 0 && blue == 0)
            {
                // black
                _c = _m = _y = _k = 0;
            }

            // adust RGB range
            // [0-255] -> [0-1]
            float r = red / 255f;
            float g = green / 255f;
            float b = blue / 255f;

            // extract out K [0-1]
            _k = 1 - Math.Max(r, Math.Max(g, b));

            _c = (1 - r - _k) / (1 - _k);
            _m = (1 - g - _k) / (1 - _k);
            _y = (1 - b - _k) / (1 - _k);
        }

        public CMYK(Color c) : this(c.R, c.G, c.B) { }

        public float C
        {
            get => _c;
            set => _c = Clamp(value);
        }

        public float M
        {
            get => _m;
            set => _m = Clamp(value);
        }

        public float Y
        {
            get => _y;
            set => _y = Clamp(value);
        }

        public float K
        {
            get => _k;
            set => _k = Clamp(value);
        }


        private static float Clamp(float nValue)
        {
            return Math.Min(MaxValue, Math.Max(MinValue, nValue));
        }


        public override bool Equals(object obj)
        {
            if (!(obj is CMYK))
            {
                return false;
            }

            return Equals((CMYK)obj);
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
            return $"[C={C:F3}, M={M:F3}, Y={Y:F3}, K={K:F3}]";
        }
        
    }

}