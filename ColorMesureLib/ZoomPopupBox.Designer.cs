namespace ColorMesure
{
    partial class ZoomPopupBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.zoomPic = new System.Windows.Forms.PictureBox();
            this.zoomInfoLbl = new System.Windows.Forms.Label();
            this.zoomFactorTbar = new System.Windows.Forms.TrackBar();
            this._rootLayout = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.zoomPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomFactorTbar)).BeginInit();
            this._rootLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoomPic
            // 
            this.zoomPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomPic.BackColor = System.Drawing.Color.White;
            this.zoomPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoomPic.Location = new System.Drawing.Point(3, 3);
            this.zoomPic.Name = "zoomPic";
            this.zoomPic.Size = new System.Drawing.Size(218, 205);
            this.zoomPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.zoomPic.TabIndex = 0;
            this.zoomPic.TabStop = false;
            this.zoomPic.Paint += new System.Windows.Forms.PaintEventHandler(this.ZoomPic_Paint);
            // 
            // zoomInfoLbl
            // 
            this.zoomInfoLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zoomInfoLbl.AutoSize = true;
            this.zoomInfoLbl.Location = new System.Drawing.Point(227, 227);
            this.zoomInfoLbl.Name = "zoomInfoLbl";
            this.zoomInfoLbl.Size = new System.Drawing.Size(22, 17);
            this.zoomInfoLbl.TabIndex = 1;
            this.zoomInfoLbl.Text = "x3";
            // 
            // zoomFactorTbar
            // 
            this.zoomFactorTbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomFactorTbar.LargeChange = 1;
            this.zoomFactorTbar.Location = new System.Drawing.Point(3, 214);
            this.zoomFactorTbar.Maximum = 6;
            this.zoomFactorTbar.Minimum = 2;
            this.zoomFactorTbar.Name = "zoomFactorTbar";
            this.zoomFactorTbar.Size = new System.Drawing.Size(218, 44);
            this.zoomFactorTbar.TabIndex = 2;
            this.zoomFactorTbar.Value = 3;
            this.zoomFactorTbar.ValueChanged += new System.EventHandler(this.zoomFactorTbar_ValueChanged);
            // 
            // _rootLayout
            // 
            this._rootLayout.ColumnCount = 2;
            this._rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._rootLayout.Controls.Add(this.zoomFactorTbar, 0, 1);
            this._rootLayout.Controls.Add(this.zoomPic, 0, 0);
            this._rootLayout.Controls.Add(this.zoomInfoLbl, 1, 1);
            this._rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rootLayout.Location = new System.Drawing.Point(0, 0);
            this._rootLayout.Margin = new System.Windows.Forms.Padding(0);
            this._rootLayout.Name = "_rootLayout";
            this._rootLayout.RowCount = 2;
            this._rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this._rootLayout.Size = new System.Drawing.Size(252, 261);
            this._rootLayout.TabIndex = 3;
            // 
            // ZoomPopupBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this._rootLayout);
            this.MinimumSize = new System.Drawing.Size(56, 106);
            this.Name = "ZoomPopupBox";
            this.Size = new System.Drawing.Size(252, 261);
            ((System.ComponentModel.ISupportInitialize)(this.zoomPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomFactorTbar)).EndInit();
            this._rootLayout.ResumeLayout(false);
            this._rootLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox zoomPic;
        private System.Windows.Forms.Label zoomInfoLbl;
        private System.Windows.Forms.TrackBar zoomFactorTbar;
        private System.Windows.Forms.TableLayoutPanel _rootLayout;
    }
}
