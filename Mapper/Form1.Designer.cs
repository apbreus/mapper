namespace Mapper
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
            this.docContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.formatContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatBoldContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatItalicsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatUnderlineContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.underlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testProgressBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOpacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twentfivePercent = new System.Windows.Forms.ToolStripMenuItem();
            this.fiftyPercent = new System.Windows.Forms.ToolStripMenuItem();
            this.seventyfivePercent = new System.Windows.Forms.ToolStripMenuItem();
            this.onehundredPercent = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStrip = new System.Windows.Forms.ToolStrip();
            this.fileToolStrip = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripInButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripOutButton = new System.Windows.Forms.ToolStripButton();
            this.docContextMenuStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.formatToolStrip.SuspendLayout();
            this.fileToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // docContextMenuStrip
            // 
            this.docContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatContextMenuItem});
            this.docContextMenuStrip.Name = "docContextMenuStrip";
            this.docContextMenuStrip.Size = new System.Drawing.Size(120, 26);
            // 
            // formatContextMenuItem
            // 
            this.formatContextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatBoldContextMenuItem,
            this.formatItalicsContextMenuItem,
            this.formatUnderlineContextMenuItem});
            this.formatContextMenuItem.Name = "formatContextMenuItem";
            this.formatContextMenuItem.Size = new System.Drawing.Size(119, 22);
            this.formatContextMenuItem.Text = "Format";
            // 
            // formatBoldContextMenuItem
            // 
            this.formatBoldContextMenuItem.Name = "formatBoldContextMenuItem";
            this.formatBoldContextMenuItem.Size = new System.Drawing.Size(130, 22);
            this.formatBoldContextMenuItem.Text = "&Bold";
            this.formatBoldContextMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
            // 
            // formatItalicsContextMenuItem
            // 
            this.formatItalicsContextMenuItem.Name = "formatItalicsContextMenuItem";
            this.formatItalicsContextMenuItem.Size = new System.Drawing.Size(130, 22);
            this.formatItalicsContextMenuItem.Text = "&Italics";
            this.formatItalicsContextMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
            // 
            // formatUnderlineContextMenuItem
            // 
            this.formatUnderlineContextMenuItem.Name = "formatUnderlineContextMenuItem";
            this.formatUnderlineContextMenuItem.Size = new System.Drawing.Size(130, 22);
            this.formatUnderlineContextMenuItem.Text = "&Underline";
            this.formatUnderlineContextMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainMenuStrip.Size = new System.Drawing.Size(152, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.fileMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.fileMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.fileMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boldToolStripMenuItem,
            this.italicsToolStripMenuItem,
            this.underlineToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.formatToolStripMenuItem.Text = "Fo&rmat";
            // 
            // boldToolStripMenuItem
            // 
            this.boldToolStripMenuItem.CheckOnClick = true;
            this.boldToolStripMenuItem.Image = global::Mapper.Properties.Resources.Bold;
            this.boldToolStripMenuItem.Name = "boldToolStripMenuItem";
            this.boldToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.boldToolStripMenuItem.Text = "&Bold";
            this.boldToolStripMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
            // 
            // italicsToolStripMenuItem
            // 
            this.italicsToolStripMenuItem.CheckOnClick = true;
            this.italicsToolStripMenuItem.Image = global::Mapper.Properties.Resources.Italics;
            this.italicsToolStripMenuItem.Name = "italicsToolStripMenuItem";
            this.italicsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.italicsToolStripMenuItem.Text = "&Italics";
            this.italicsToolStripMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
            // 
            // underlineToolStripMenuItem
            // 
            this.underlineToolStripMenuItem.CheckOnClick = true;
            this.underlineToolStripMenuItem.Image = global::Mapper.Properties.Resources.Underline;
            this.underlineToolStripMenuItem.Name = "underlineToolStripMenuItem";
            this.underlineToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.underlineToolStripMenuItem.Text = "&Underline";
            this.underlineToolStripMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testProgressBarToolStripMenuItem,
            this.changeOpacityToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "O&ptions";
            // 
            // testProgressBarToolStripMenuItem
            // 
            this.testProgressBarToolStripMenuItem.Name = "testProgressBarToolStripMenuItem";
            this.testProgressBarToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.testProgressBarToolStripMenuItem.Text = "&Test Progress Bar";
            // 
            // changeOpacityToolStripMenuItem
            // 
            this.changeOpacityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.twentfivePercent,
            this.fiftyPercent,
            this.seventyfivePercent,
            this.onehundredPercent});
            this.changeOpacityToolStripMenuItem.Name = "changeOpacityToolStripMenuItem";
            this.changeOpacityToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.changeOpacityToolStripMenuItem.Text = "&Change Opacity";
            // 
            // twentfivePercent
            // 
            this.twentfivePercent.CheckOnClick = true;
            this.twentfivePercent.Name = "twentfivePercent";
            this.twentfivePercent.Size = new System.Drawing.Size(114, 22);
            this.twentfivePercent.Tag = ".25";
            this.twentfivePercent.Text = "&25%";
            this.twentfivePercent.Click += new System.EventHandler(this.changeOpacityToolStripMenuItem_Click);
            // 
            // fiftyPercent
            // 
            this.fiftyPercent.CheckOnClick = true;
            this.fiftyPercent.Name = "fiftyPercent";
            this.fiftyPercent.Size = new System.Drawing.Size(114, 22);
            this.fiftyPercent.Tag = ".50";
            this.fiftyPercent.Text = "&50%";
            this.fiftyPercent.Click += new System.EventHandler(this.changeOpacityToolStripMenuItem_Click);
            // 
            // seventyfivePercent
            // 
            this.seventyfivePercent.CheckOnClick = true;
            this.seventyfivePercent.Name = "seventyfivePercent";
            this.seventyfivePercent.Size = new System.Drawing.Size(114, 22);
            this.seventyfivePercent.Tag = ".75";
            this.seventyfivePercent.Text = "&75%";
            this.seventyfivePercent.Click += new System.EventHandler(this.changeOpacityToolStripMenuItem_Click);
            // 
            // onehundredPercent
            // 
            this.onehundredPercent.CheckOnClick = true;
            this.onehundredPercent.Name = "onehundredPercent";
            this.onehundredPercent.Size = new System.Drawing.Size(114, 22);
            this.onehundredPercent.Tag = "1";
            this.onehundredPercent.Text = "&100%";
            this.onehundredPercent.Click += new System.EventHandler(this.changeOpacityToolStripMenuItem_Click);
            // 
            // formatToolStrip
            // 
            this.formatToolStrip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.formatToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.formatToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripInButton,
            this.toolStripOutButton});
            this.formatToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.formatToolStrip.Location = new System.Drawing.Point(58, 25);
            this.formatToolStrip.Name = "formatToolStrip";
            this.formatToolStrip.Size = new System.Drawing.Size(89, 25);
            this.formatToolStrip.TabIndex = 2;
            this.formatToolStrip.Text = "toolStrip1";
            this.formatToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.formatToolStrip_ItemClicked);
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.fileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton});
            this.fileToolStrip.Location = new System.Drawing.Point(0, 25);
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.Size = new System.Drawing.Size(58, 25);
            this.fileToolStrip.TabIndex = 5;
            this.fileToolStrip.Text = "toolStrip1";
            this.fileToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fileToolStrip_ItemClicked);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.AddExtension = false;
            // 
            // PictureBox
            // 
            this.PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBox.Location = new System.Drawing.Point(0, 53);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(542, 336);
            this.PictureBox.TabIndex = 6;
            this.PictureBox.TabStop = false;
            this.PictureBox.WaitOnLoad = true;
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Location = new System.Drawing.Point(0, 392);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(542, 24);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripInButton
            // 
            this.toolStripInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripInButton.Name = "toolStripInButton";
            this.toolStripInButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripInButton.Text = "+";
            this.toolStripInButton.Click += new System.EventHandler(this.toolStripInButton_Click);
            // 
            // toolStripOutButton
            // 
            this.toolStripOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripOutButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOutButton.Image")));
            this.toolStripOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOutButton.Name = "toolStripOutButton";
            this.toolStripOutButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripOutButton.Text = "-";
            this.toolStripOutButton.Click += new System.EventHandler(this.toolStripOutButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 416);
            this.Controls.Add(this.fileToolStrip);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.formatToolStrip);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.docContextMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.formatToolStrip.ResumeLayout(false);
            this.formatToolStrip.PerformLayout();
            this.fileToolStrip.ResumeLayout(false);
            this.fileToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip docContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem formatContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formatBoldContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formatItalicsContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formatUnderlineContextMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem boldToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem italicsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem underlineToolStripMenuItem;
        private System.Windows.Forms.ToolStrip formatToolStrip;
        private System.Windows.Forms.ToolStrip fileToolStrip;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testProgressBarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeOpacityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem twentfivePercent;
		private System.Windows.Forms.ToolStripMenuItem fiftyPercent;
		private System.Windows.Forms.ToolStripMenuItem seventyfivePercent;
		private System.Windows.Forms.ToolStripMenuItem onehundredPercent;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripButton toolStripInButton;
        private System.Windows.Forms.ToolStripButton toolStripOutButton;

	}
}

