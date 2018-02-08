namespace PictureBox_Zoom
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.zoomPopupBox1 = new ColorMesure.ZoomPopupBox();
            this.imageBoxZoom = new ColorMesure.ImageBoxZoom();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(16, 453);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(139, 28);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.Text = "Load image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(272, 453);
            this.btnSelectColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(211, 28);
            this.btnSelectColor.TabIndex = 5;
            this.btnSelectColor.Text = "Background color...";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Visible = false;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // zoomPopupBox1
            // 
            this.zoomPopupBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zoomPopupBox1.Image = null;
            this.zoomPopupBox1.Location = new System.Drawing.Point(494, 17);
            this.zoomPopupBox1.MaximumZoom = 6;
            this.zoomPopupBox1.MinimumSize = new System.Drawing.Size(56, 106);
            this.zoomPopupBox1.MinimumZoom = 2;
            this.zoomPopupBox1.Name = "zoomPopupBox1";
            this.zoomPopupBox1.Size = new System.Drawing.Size(161, 181);
            this.zoomPopupBox1.TabIndex = 8;
            this.zoomPopupBox1.ZoomFactor = 3;
            // 
            // imageBoxZoom
            // 
            this.imageBoxZoom.AutoScroll = true;
            this.imageBoxZoom.BackColor = System.Drawing.Color.LightGray;
            this.imageBoxZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxZoom.Image = null;
            this.imageBoxZoom.Location = new System.Drawing.Point(11, 17);
            this.imageBoxZoom.MaximumZoom = 6;
            this.imageBoxZoom.MinimumZoom = 2;
            this.imageBoxZoom.Name = "imageBoxZoom";
            this.imageBoxZoom.ShowZoomPopup = true;
            this.imageBoxZoom.Size = new System.Drawing.Size(471, 422);
            this.imageBoxZoom.TabIndex = 6;
            this.imageBoxZoom.ZoomFactor = 3;
            this.imageBoxZoom.ZoomPopupAltPosition = System.Drawing.ContentAlignment.BottomCenter;
            this.imageBoxZoom.ZoomPopupPosition = System.Drawing.ContentAlignment.TopRight;
            this.imageBoxZoom.ZoomPopupSize = 150;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 492);
            this.Controls.Add(this.zoomPopupBox1);
            this.Controls.Add(this.imageBoxZoom);
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.btnLoadImage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PictureBox Zoom Example";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnSelectColor;
        private ColorMesure.ImageBoxZoom imageBoxZoom;
        private ColorMesure.ZoomPopupBox zoomPopupBox1;
    }
}

