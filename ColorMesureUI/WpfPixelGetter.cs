using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ColorMesure
{
    class WpfPixelGetter : PixelGetter
    {
        public Color GetPixelColor(Point pos)
        {
            byte[] rgb = GetPixelColorBytes((int)pos.X, (int)pos.Y);
            var color = Color.FromRgb(rgb[0], rgb[1], rgb[2]);

            return color;
        }
    }
}
