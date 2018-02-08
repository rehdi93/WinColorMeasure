using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ColorMesure
{
    public partial class ZoomPopupBox : ZoomBoxBase
    {


        public ZoomPopupBox()
        {
            InitializeComponent();

        }


        public Image Image
        {
            get => _ZoomedBitmap;
            set
            {
                zoomPic.Image = value;

                if (value != null)
                    _ZoomedBitmap = new Bitmap(value);
            }
        }


        public void SetZoomedImage(Image img, Point centerPt)
        {
            var bm = CreateZoomedBitmap(img, centerPt, zoomPic.Size);
            
            // Draw the bitmap on the zoomPic picturebox
            zoomPic.Image = bm;

            if (bm != null)
                _ZoomedBitmap = bm;

            // Refresh the picZoom picturebox to reflect the changes
            zoomPic.Refresh();
        }


        private void ZoomPic_Paint(object sender, PaintEventArgs e)
        {
            // Draw the 'Cross' cursor in the center of the picBox area
            // mimic-ing the actual cursor position
            var cross = Cursors.Cross;
            var offset = cross.HotSpot;

            int cPos_x = (zoomPic.Width / 2) - offset.X;
            int cPos_y = (zoomPic.Height / 2) - offset.Y;

            cross.Draw(e.Graphics, new Rectangle(cPos_x, cPos_y, 1, 1));
        }

        private void zoomFactorTbar_ValueChanged(object sender, EventArgs e)
        {
            ZoomFactor = zoomFactorTbar.Value;
            zoomInfoLbl.Text = "x" + ZoomFactor;
            OnZoomFactorChanged(ZoomFactor);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            KeepControlSquare(zoomPic);
            base.OnSizeChanged(e);
        }

        protected override void OnCreateControl()
        {
            KeepControlSquare(zoomPic);
            base.OnCreateControl();
        }
        

        private void KeepControlSquare(Control ctrl)
        {
            // use margin to keep ctrl square
            if (ctrl.Width != ctrl.Height)
            {
                int adjust;

                var margin = ctrl.Margin;

                if (ctrl.Width > ctrl.Height)
                {
                    adjust = ctrl.Width - ctrl.Height;

                    margin.Right += adjust / 2;
                    margin.Left += adjust / 2;
                }
                //else if (zoomPic.Width < zoomPic.Height)
                else
                {
                    adjust = ctrl.Height - ctrl.Width;
                    margin.Right -= adjust / 2;
                    margin.Left -= adjust / 2;
                }

                ctrl.Margin = margin;
            }
        }
    }
}
