namespace WinColorMesure
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyColorTSMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomTSComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.formatGbox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rgbRadioButton = new System.Windows.Forms.RadioButton();
            this.cmykRadioButton = new System.Windows.Forms.RadioButton();
            this.hexRadioButton = new System.Windows.Forms.RadioButton();
            this.colorGBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pColor = new System.Windows.Forms.Panel();
            this.colorContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyColorTSMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyColorAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFormatContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rgbFormatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmykFormatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexFormatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorInfoLabel = new System.Windows.Forms.Label();
            this.atualizarPrevBtn = new System.Windows.Forms.Button();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.zoomFactorLabel = new System.Windows.Forms.Label();
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.imageBoxZoom = new WinColorMesure.UI.ImageBoxZoom();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.formatGbox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.colorGBox.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.colorContextMenu.SuspendLayout();
            this.textFormatContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            this.rootLayout.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageMenuItem,
            this.sobreToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshPreviewToolStripMenuItem,
            this.copyColorTSMenuItem1,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.OnSharedDropdown_Opening);
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.OnCopyColorText_Click);
            // 
            // refreshPreviewToolStripMenuItem
            // 
            this.refreshPreviewToolStripMenuItem.Name = "refreshPreviewToolStripMenuItem";
            resources.ApplyResources(this.refreshPreviewToolStripMenuItem, "refreshPreviewToolStripMenuItem");
            this.refreshPreviewToolStripMenuItem.Click += new System.EventHandler(this.atualizarPreviewToolStripMenuItem_Click);
            // 
            // copyColorTSMenuItem1
            // 
            this.copyColorTSMenuItem1.Name = "copyColorTSMenuItem1";
            resources.ApplyResources(this.copyColorTSMenuItem1, "copyColorTSMenuItem1");
            this.copyColorTSMenuItem1.Click += new System.EventHandler(this.OnCopyColorText_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // imageMenuItem
            // 
            this.imageMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historyMenuItem,
            this.zoomTSMenuItem});
            this.imageMenuItem.Name = "imageMenuItem";
            resources.ApplyResources(this.imageMenuItem, "imageMenuItem");
            this.imageMenuItem.DropDownOpening += new System.EventHandler(this.historyMenuItem_DropDownOpening);
            // 
            // historyMenuItem
            // 
            this.historyMenuItem.Name = "historyMenuItem";
            resources.ApplyResources(this.historyMenuItem, "historyMenuItem");
            // 
            // zoomTSMenuItem
            // 
            this.zoomTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomTSComboBox,
            this.toolStripSeparator3});
            this.zoomTSMenuItem.Name = "zoomTSMenuItem";
            resources.ApplyResources(this.zoomTSMenuItem, "zoomTSMenuItem");
            // 
            // zoomTSComboBox
            // 
            this.zoomTSComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            resources.ApplyResources(this.zoomTSComboBox, "zoomTSComboBox");
            this.zoomTSComboBox.Name = "zoomTSComboBox";
            this.zoomTSComboBox.SelectedIndexChanged += new System.EventHandler(this.ZoomTSComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            resources.ApplyResources(this.sobreToolStripMenuItem, "sobreToolStripMenuItem");
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            resources.ApplyResources(this.statusLabel, "statusLabel");
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.groupBox1);
            this.infoPanel.Controls.Add(this.formatGbox);
            this.infoPanel.Controls.Add(this.colorGBox);
            this.infoPanel.Controls.Add(this.atualizarPrevBtn);
            resources.ApplyResources(this.infoPanel, "infoPanel");
            this.infoPanel.Name = "infoPanel";
            // 
            // formatGbox
            // 
            this.formatGbox.Controls.Add(this.flowLayoutPanel1);
            resources.ApplyResources(this.formatGbox, "formatGbox");
            this.formatGbox.Name = "formatGbox";
            this.formatGbox.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rgbRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.cmykRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.hexRadioButton);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // rgbRadioButton
            // 
            resources.ApplyResources(this.rgbRadioButton, "rgbRadioButton");
            this.rgbRadioButton.Checked = true;
            this.rgbRadioButton.Name = "rgbRadioButton";
            this.rgbRadioButton.TabStop = true;
            this.rgbRadioButton.UseVisualStyleBackColor = true;
            this.rgbRadioButton.CheckedChanged += new System.EventHandler(this.OnFormatChanged);
            // 
            // cmykRadioButton
            // 
            resources.ApplyResources(this.cmykRadioButton, "cmykRadioButton");
            this.cmykRadioButton.Name = "cmykRadioButton";
            this.cmykRadioButton.UseVisualStyleBackColor = true;
            this.cmykRadioButton.CheckedChanged += new System.EventHandler(this.OnFormatChanged);
            // 
            // hexRadioButton
            // 
            resources.ApplyResources(this.hexRadioButton, "hexRadioButton");
            this.hexRadioButton.Name = "hexRadioButton";
            this.hexRadioButton.UseVisualStyleBackColor = true;
            this.hexRadioButton.CheckedChanged += new System.EventHandler(this.OnFormatChanged);
            // 
            // colorGBox
            // 
            this.colorGBox.Controls.Add(this.flowLayoutPanel2);
            resources.ApplyResources(this.colorGBox, "colorGBox");
            this.colorGBox.Name = "colorGBox";
            this.colorGBox.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.pColor);
            this.flowLayoutPanel2.Controls.Add(this.colorInfoLabel);
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // pColor
            // 
            this.pColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pColor.ContextMenuStrip = this.colorContextMenu;
            resources.ApplyResources(this.pColor, "pColor");
            this.pColor.Name = "pColor";
            // 
            // colorContextMenu
            // 
            this.colorContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.colorContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyColorTSMenuItem2,
            this.copyColorAsMenuItem});
            this.colorContextMenu.Name = "colorContextMenu";
            this.colorContextMenu.ShowImageMargin = false;
            resources.ApplyResources(this.colorContextMenu, "colorContextMenu");
            this.colorContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnOpeningSharedMenu);
            // 
            // copyColorTSMenuItem2
            // 
            this.copyColorTSMenuItem2.Name = "copyColorTSMenuItem2";
            resources.ApplyResources(this.copyColorTSMenuItem2, "copyColorTSMenuItem2");
            this.copyColorTSMenuItem2.Click += new System.EventHandler(this.OnCopyColorText_Click);
            // 
            // copyColorAsMenuItem
            // 
            this.copyColorAsMenuItem.DropDown = this.textFormatContextMenu;
            this.copyColorAsMenuItem.Name = "copyColorAsMenuItem";
            resources.ApplyResources(this.copyColorAsMenuItem, "copyColorAsMenuItem");
            // 
            // textFormatContextMenu
            // 
            this.textFormatContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.textFormatContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rgbFormatMenuItem,
            this.cmykFormatMenuItem,
            this.hexFormatMenuItem});
            this.textFormatContextMenu.Name = "textFormatContextMenu";
            this.textFormatContextMenu.OwnerItem = this.copyColorAsMenuItem;
            this.textFormatContextMenu.ShowImageMargin = false;
            resources.ApplyResources(this.textFormatContextMenu, "textFormatContextMenu");
            this.textFormatContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnOpeningSharedMenu);
            // 
            // rgbFormatMenuItem
            // 
            this.rgbFormatMenuItem.Name = "rgbFormatMenuItem";
            resources.ApplyResources(this.rgbFormatMenuItem, "rgbFormatMenuItem");
            this.rgbFormatMenuItem.Click += new System.EventHandler(this.ColorTextFormatItems_Click);
            // 
            // cmykFormatMenuItem
            // 
            this.cmykFormatMenuItem.Name = "cmykFormatMenuItem";
            resources.ApplyResources(this.cmykFormatMenuItem, "cmykFormatMenuItem");
            this.cmykFormatMenuItem.Click += new System.EventHandler(this.ColorTextFormatItems_Click);
            // 
            // hexFormatMenuItem
            // 
            this.hexFormatMenuItem.Name = "hexFormatMenuItem";
            resources.ApplyResources(this.hexFormatMenuItem, "hexFormatMenuItem");
            this.hexFormatMenuItem.Click += new System.EventHandler(this.ColorTextFormatItems_Click);
            // 
            // colorInfoLabel
            // 
            resources.ApplyResources(this.colorInfoLabel, "colorInfoLabel");
            this.colorInfoLabel.Name = "colorInfoLabel";
            // 
            // atualizarPrevBtn
            // 
            resources.ApplyResources(this.atualizarPrevBtn, "atualizarPrevBtn");
            this.atualizarPrevBtn.Name = "atualizarPrevBtn";
            this.atualizarPrevBtn.UseVisualStyleBackColor = true;
            this.atualizarPrevBtn.Click += new System.EventHandler(this.atualizarPreviewToolStripMenuItem_Click);
            // 
            // zoomTrackBar
            // 
            resources.ApplyResources(this.zoomTrackBar, "zoomTrackBar");
            this.zoomTrackBar.LargeChange = 1;
            this.zoomTrackBar.Maximum = 6;
            this.zoomTrackBar.Minimum = 2;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Value = 3;
            this.zoomTrackBar.ValueChanged += new System.EventHandler(this.zoomTrackBar_ValueChanged);
            // 
            // zoomFactorLabel
            // 
            resources.ApplyResources(this.zoomFactorLabel, "zoomFactorLabel");
            this.zoomFactorLabel.Name = "zoomFactorLabel";
            // 
            // rootLayout
            // 
            resources.ApplyResources(this.rootLayout, "rootLayout");
            this.rootLayout.Controls.Add(this.imageBoxZoom, 0, 0);
            this.rootLayout.Controls.Add(this.infoPanel, 0, 1);
            this.rootLayout.Name = "rootLayout";
            // 
            // imageBoxZoom
            // 
            resources.ApplyResources(this.imageBoxZoom, "imageBoxZoom");
            this.imageBoxZoom.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.imageBoxZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxZoom.ContextMenuStrip = this.colorContextMenu;
            this.imageBoxZoom.Cursor = System.Windows.Forms.Cursors.Cross;
            this.imageBoxZoom.Image = null;
            this.imageBoxZoom.Name = "imageBoxZoom";
            this.imageBoxZoom.PopupPositionAlt = System.Drawing.ContentAlignment.BottomRight;
            this.imageBoxZoom.PopupSize = 200;
            this.imageBoxZoom.ZoomFactorChanged += new System.EventHandler<int>(this.imageBoxZoom_ZoomFactorChanged);
            this.imageBoxZoom.Click += new System.EventHandler(this.imageBoxZoom_Click);
            this.imageBoxZoom.MouseLeave += new System.EventHandler(this.ImageBoxZoom_MouseLeave);
            this.imageBoxZoom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageBoxZoom_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.zoomTrackBar);
            this.groupBox1.Controls.Add(this.zoomFactorLabel);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rootLayout);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.formatGbox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.colorGBox.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.colorContextMenu.ResumeLayout(false);
            this.textFormatContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            this.rootLayout.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshPreviewToolStripMenuItem;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label colorInfoLabel;
        private System.Windows.Forms.Panel pColor;
        private System.Windows.Forms.Button atualizarPrevBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rgbRadioButton;
        private System.Windows.Forms.RadioButton cmykRadioButton;
        private System.Windows.Forms.RadioButton hexRadioButton;
        private System.Windows.Forms.ToolStripMenuItem imageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip colorContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyColorAsMenuItem;
        private System.Windows.Forms.ContextMenuStrip textFormatContextMenu;
        private System.Windows.Forms.ToolStripMenuItem rgbFormatMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmykFormatMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexFormatMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyMenuItem;
        private System.Windows.Forms.TrackBar zoomTrackBar;
        private System.Windows.Forms.Label zoomFactorLabel;
        private WinColorMesure.UI.ImageBoxZoom imageBoxZoom;
        private System.Windows.Forms.GroupBox formatGbox;
        private System.Windows.Forms.GroupBox colorGBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem zoomTSMenuItem;
        private System.Windows.Forms.ToolStripComboBox zoomTSComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem copyColorTSMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyColorTSMenuItem2;
        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

