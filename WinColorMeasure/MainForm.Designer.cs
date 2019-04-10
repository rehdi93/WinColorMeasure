namespace WinColorMeasure
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
            this.colorDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomTSComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.zoomGbox = new System.Windows.Forms.GroupBox();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.zoomFactorLabel = new System.Windows.Forms.Label();
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
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.imageBoxZoom = new WinColorMeasure.UI.ImageBoxZoom();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.zoomGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            this.formatGbox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.colorGBox.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.colorContextMenu.SuspendLayout();
            this.textFormatContextMenu.SuspendLayout();
            this.rootLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshPreviewToolStripMenuItem,
            this.copyColorTSMenuItem1,
            this.colorDialogToolStripMenuItem,
            this.toolStripSeparator1,
            this.sobreToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.OnCopyColorText_Click);
            // 
            // refreshPreviewToolStripMenuItem
            // 
            resources.ApplyResources(this.refreshPreviewToolStripMenuItem, "refreshPreviewToolStripMenuItem");
            this.refreshPreviewToolStripMenuItem.Name = "refreshPreviewToolStripMenuItem";
            this.refreshPreviewToolStripMenuItem.Click += new System.EventHandler(this.atualizarPreviewToolStripMenuItem_Click);
            // 
            // copyColorTSMenuItem1
            // 
            resources.ApplyResources(this.copyColorTSMenuItem1, "copyColorTSMenuItem1");
            this.copyColorTSMenuItem1.Name = "copyColorTSMenuItem1";
            this.copyColorTSMenuItem1.Click += new System.EventHandler(this.OnCopyColorText_Click);
            // 
            // colorDialogToolStripMenuItem
            // 
            resources.ApplyResources(this.colorDialogToolStripMenuItem, "colorDialogToolStripMenuItem");
            this.colorDialogToolStripMenuItem.Name = "colorDialogToolStripMenuItem";
            this.colorDialogToolStripMenuItem.Click += new System.EventHandler(this.colorDialogToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // sobreToolStripMenuItem
            // 
            resources.ApplyResources(this.sobreToolStripMenuItem, "sobreToolStripMenuItem");
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // imageMenuItem
            // 
            resources.ApplyResources(this.imageMenuItem, "imageMenuItem");
            this.imageMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historyMenuItem,
            this.zoomTSMenuItem});
            this.imageMenuItem.Name = "imageMenuItem";
            this.imageMenuItem.DropDownOpening += new System.EventHandler(this.historyMenuItem_DropDownOpening);
            // 
            // historyMenuItem
            // 
            resources.ApplyResources(this.historyMenuItem, "historyMenuItem");
            this.historyMenuItem.Name = "historyMenuItem";
            // 
            // zoomTSMenuItem
            // 
            resources.ApplyResources(this.zoomTSMenuItem, "zoomTSMenuItem");
            this.zoomTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomTSComboBox,
            this.toolStripSeparator3});
            this.zoomTSMenuItem.Name = "zoomTSMenuItem";
            // 
            // zoomTSComboBox
            // 
            resources.ApplyResources(this.zoomTSComboBox, "zoomTSComboBox");
            this.zoomTSComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.zoomTSComboBox.Name = "zoomTSComboBox";
            this.zoomTSComboBox.SelectedIndexChanged += new System.EventHandler(this.ZoomTSComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // statusLabel
            // 
            resources.ApplyResources(this.statusLabel, "statusLabel");
            this.statusLabel.Name = "statusLabel";
            // 
            // infoPanel
            // 
            resources.ApplyResources(this.infoPanel, "infoPanel");
            this.infoPanel.Controls.Add(this.zoomGbox);
            this.infoPanel.Controls.Add(this.formatGbox);
            this.infoPanel.Controls.Add(this.colorGBox);
            this.infoPanel.Controls.Add(this.atualizarPrevBtn);
            this.infoPanel.Name = "infoPanel";
            // 
            // zoomGbox
            // 
            resources.ApplyResources(this.zoomGbox, "zoomGbox");
            this.zoomGbox.Controls.Add(this.zoomTrackBar);
            this.zoomGbox.Controls.Add(this.zoomFactorLabel);
            this.zoomGbox.Name = "zoomGbox";
            this.zoomGbox.TabStop = false;
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
            // formatGbox
            // 
            resources.ApplyResources(this.formatGbox, "formatGbox");
            this.formatGbox.Controls.Add(this.flowLayoutPanel1);
            this.formatGbox.Name = "formatGbox";
            this.formatGbox.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.rgbRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.cmykRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.hexRadioButton);
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
            resources.ApplyResources(this.colorGBox, "colorGBox");
            this.colorGBox.Controls.Add(this.flowLayoutPanel2);
            this.colorGBox.Name = "colorGBox";
            this.colorGBox.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.pColor);
            this.flowLayoutPanel2.Controls.Add(this.colorInfoLabel);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // pColor
            // 
            resources.ApplyResources(this.pColor, "pColor");
            this.pColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pColor.ContextMenuStrip = this.colorContextMenu;
            this.pColor.Name = "pColor";
            // 
            // colorContextMenu
            // 
            resources.ApplyResources(this.colorContextMenu, "colorContextMenu");
            this.colorContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.colorContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyColorTSMenuItem2,
            this.copyColorAsMenuItem});
            this.colorContextMenu.Name = "colorContextMenu";
            this.colorContextMenu.ShowImageMargin = false;
            // 
            // copyColorTSMenuItem2
            // 
            resources.ApplyResources(this.copyColorTSMenuItem2, "copyColorTSMenuItem2");
            this.copyColorTSMenuItem2.Name = "copyColorTSMenuItem2";
            this.copyColorTSMenuItem2.Click += new System.EventHandler(this.OnCopyColorText_Click);
            // 
            // copyColorAsMenuItem
            // 
            resources.ApplyResources(this.copyColorAsMenuItem, "copyColorAsMenuItem");
            this.copyColorAsMenuItem.DropDown = this.textFormatContextMenu;
            this.copyColorAsMenuItem.Name = "copyColorAsMenuItem";
            // 
            // textFormatContextMenu
            // 
            resources.ApplyResources(this.textFormatContextMenu, "textFormatContextMenu");
            this.textFormatContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.textFormatContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rgbFormatMenuItem,
            this.cmykFormatMenuItem,
            this.hexFormatMenuItem});
            this.textFormatContextMenu.Name = "textFormatContextMenu";
            this.textFormatContextMenu.OwnerItem = this.copyColorAsMenuItem;
            this.textFormatContextMenu.ShowImageMargin = false;
            // 
            // rgbFormatMenuItem
            // 
            resources.ApplyResources(this.rgbFormatMenuItem, "rgbFormatMenuItem");
            this.rgbFormatMenuItem.Name = "rgbFormatMenuItem";
            this.rgbFormatMenuItem.Click += new System.EventHandler(this.ColorTextFormatItems_Click);
            // 
            // cmykFormatMenuItem
            // 
            resources.ApplyResources(this.cmykFormatMenuItem, "cmykFormatMenuItem");
            this.cmykFormatMenuItem.Name = "cmykFormatMenuItem";
            this.cmykFormatMenuItem.Click += new System.EventHandler(this.ColorTextFormatItems_Click);
            // 
            // hexFormatMenuItem
            // 
            resources.ApplyResources(this.hexFormatMenuItem, "hexFormatMenuItem");
            this.hexFormatMenuItem.Name = "hexFormatMenuItem";
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
            this.imageBoxZoom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageBoxZoom_MouseClick);
            this.imageBoxZoom.MouseLeave += new System.EventHandler(this.ImageBoxZoom_MouseLeave);
            this.imageBoxZoom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageBoxZoom_MouseMove);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
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
            this.Name = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.zoomGbox.ResumeLayout(false);
            this.zoomGbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            this.formatGbox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.colorGBox.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.colorContextMenu.ResumeLayout(false);
            this.textFormatContextMenu.ResumeLayout(false);
            this.rootLayout.ResumeLayout(false);
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
        private WinColorMeasure.UI.ImageBoxZoom imageBoxZoom;
        private System.Windows.Forms.GroupBox formatGbox;
        private System.Windows.Forms.GroupBox colorGBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem zoomTSMenuItem;
        private System.Windows.Forms.ToolStripComboBox zoomTSComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem copyColorTSMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyColorTSMenuItem2;
        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.GroupBox zoomGbox;
        private System.Windows.Forms.ToolStripMenuItem colorDialogToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

