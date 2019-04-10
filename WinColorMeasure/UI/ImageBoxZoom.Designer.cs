namespace WinColorMeasure.UI
{
    partial class ImageBoxZoom
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
            this.zoomPopupBox = new System.Windows.Forms.PictureBox();
            this.imgBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.zoomPopupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // zoomPopupBox
            // 
            this.zoomPopupBox.BackColor = System.Drawing.Color.White;
            this.zoomPopupBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoomPopupBox.Location = new System.Drawing.Point(0, 0);
            this.zoomPopupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.zoomPopupBox.MinimumSize = new System.Drawing.Size(38, 41);
            this.zoomPopupBox.Name = "zoomPopupBox";
            this.zoomPopupBox.Size = new System.Drawing.Size(76, 82);
            this.zoomPopupBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.zoomPopupBox.TabIndex = 1;
            this.zoomPopupBox.TabStop = false;
            this.zoomPopupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.zoomPopupBox_Paint);
            this.zoomPopupBox.MouseEnter += new System.EventHandler(this.zoomPopupBox_MouseEnter);
            // 
            // imgBox
            // 
            this.imgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBox.Location = new System.Drawing.Point(0, 0);
            this.imgBox.Margin = new System.Windows.Forms.Padding(0);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(256, 215);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgBox.TabIndex = 2;
            this.imgBox.TabStop = false;
            this.imgBox.Click += new System.EventHandler(this.imgBox_Click);
            this.imgBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseDown);
            this.imgBox.MouseLeave += new System.EventHandler(this.imgBox_MouseLeave);
            this.imgBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseMove);
            // 
            // ImageBoxZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.zoomPopupBox);
            this.Controls.Add(this.imgBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ImageBoxZoom";
            this.Size = new System.Drawing.Size(256, 215);
            ((System.ComponentModel.ISupportInitialize)(this.zoomPopupBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox zoomPopupBox;
        private System.Windows.Forms.PictureBox imgBox;
    }
}
