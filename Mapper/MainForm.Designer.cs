using System.Windows.Forms;
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.viewToolStrip = new System.Windows.Forms.ToolStrip();
            this.allToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.x1ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.inToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.outToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fileToolStrip = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hotspotTree = new System.Windows.Forms.TreeView();
            this.linkedImageList = new System.Windows.Forms.ImageList(this.components);
            this.hotspotCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.areaTree = new System.Windows.Forms.TreeView();
            this.areaCountLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mouseModeToolStrip = new System.Windows.Forms.ToolStrip();
            this.selectMouseModeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveMouseModeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.imageSize = new System.Windows.Forms.Label();
            this.picPanel = new System.Windows.Forms.Panel();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.areaTreeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.linkAreaTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delAreaTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotspotTreeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addHotspotTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delHotspotTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStrip.SuspendLayout();
            this.fileToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mouseModeToolStrip.SuspendLayout();
            this.picPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.areaTreeContextMenuStrip.SuspendLayout();
            this.hotspotTreeContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewToolStrip
            // 
            this.viewToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripButton,
            this.x1ToolStripButton,
            this.toolStripSeparator1,
            this.inToolStripButton,
            this.outToolStripButton});
            this.viewToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.viewToolStrip.Location = new System.Drawing.Point(2, 0);
            this.viewToolStrip.Name = "viewToolStrip";
            this.viewToolStrip.Size = new System.Drawing.Size(119, 25);
            this.viewToolStrip.TabIndex = 2;
            this.viewToolStrip.Text = "toolStrip1";
            // 
            // allToolStripButton
            // 
            this.allToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.allToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("allToolStripButton.Image")));
            this.allToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.allToolStripButton.Name = "allToolStripButton";
            this.allToolStripButton.Size = new System.Drawing.Size(28, 22);
            this.allToolStripButton.Text = "Все";
            this.allToolStripButton.ToolTipText = "Показать все";
            this.allToolStripButton.Click += new System.EventHandler(this.allToolStripButton_Click);
            // 
            // x1ToolStripButton
            // 
            this.x1ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.x1ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("x1ToolStripButton.Image")));
            this.x1ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.x1ToolStripButton.Name = "x1ToolStripButton";
            this.x1ToolStripButton.Size = new System.Drawing.Size(27, 22);
            this.x1ToolStripButton.Text = "1:1";
            this.x1ToolStripButton.ToolTipText = "Исходный масштаб";
            this.x1ToolStripButton.Click += new System.EventHandler(this.x1ToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // inToolStripButton
            // 
            this.inToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.inToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inToolStripButton.Name = "inToolStripButton";
            this.inToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.inToolStripButton.Text = "+";
            this.inToolStripButton.ToolTipText = "Увеличить";
            this.inToolStripButton.Click += new System.EventHandler(this.inToolStripButton_Click);
            // 
            // outToolStripButton
            // 
            this.outToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.outToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("outToolStripButton.Image")));
            this.outToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.outToolStripButton.Name = "outToolStripButton";
            this.outToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.outToolStripButton.Text = "-";
            this.outToolStripButton.ToolTipText = "Уменьшить";
            this.outToolStripButton.Click += new System.EventHandler(this.outToolStripButton_Click);
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.fileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton});
            this.fileToolStrip.Location = new System.Drawing.Point(0, 0);
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
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Location = new System.Drawing.Point(0, 28);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.mouseModeToolStrip);
            this.splitContainer.Panel2.Controls.Add(this.imageSize);
            this.splitContainer.Panel2.Controls.Add(this.picPanel);
            this.splitContainer.Panel2.Controls.Add(this.viewToolStrip);
            this.splitContainer.Size = new System.Drawing.Size(769, 327);
            this.splitContainer.SplitterDistance = 278;
            this.splitContainer.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.hotspotTree);
            this.splitContainer1.Panel1.Controls.Add(this.hotspotCountLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.areaTree);
            this.splitContainer1.Panel2.Controls.Add(this.areaCountLabel);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(278, 327);
            this.splitContainer1.SplitterDistance = 134;
            this.splitContainer1.TabIndex = 0;
            // 
            // hotspotTree
            // 
            this.hotspotTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hotspotTree.CausesValidation = false;
            this.hotspotTree.ImageIndex = 0;
            this.hotspotTree.ImageList = this.linkedImageList;
            this.hotspotTree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hotspotTree.LabelEdit = true;
            this.hotspotTree.Location = new System.Drawing.Point(3, 28);
            this.hotspotTree.Name = "hotspotTree";
            this.hotspotTree.SelectedImageIndex = 0;
            this.hotspotTree.Size = new System.Drawing.Size(124, 274);
            this.hotspotTree.TabIndex = 0;
            this.hotspotTree.TabStop = false;
            this.hotspotTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.hotspotTree_AfterLabelEdit);
            this.hotspotTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.hotspotTree_AfterSelect);
            this.hotspotTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hotspotTree_MouseUp);
            // 
            // linkedImageList
            // 
            this.linkedImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("linkedImageList.ImageStream")));
            this.linkedImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.linkedImageList.Images.SetKeyName(0, "none.PNG");
            this.linkedImageList.Images.SetKeyName(1, "unlinked.png");
            this.linkedImageList.Images.SetKeyName(2, "linked.png");
            // 
            // hotspotCountLabel
            // 
            this.hotspotCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hotspotCountLabel.AutoSize = true;
            this.hotspotCountLabel.Location = new System.Drawing.Point(0, 308);
            this.hotspotCountLabel.Name = "hotspotCountLabel";
            this.hotspotCountLabel.Size = new System.Drawing.Size(0, 13);
            this.hotspotCountLabel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hotspots";
            // 
            // areaTree
            // 
            this.areaTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.areaTree.CausesValidation = false;
            this.areaTree.ImageIndex = 0;
            this.areaTree.ImageList = this.linkedImageList;
            this.areaTree.LabelEdit = true;
            this.areaTree.Location = new System.Drawing.Point(3, 28);
            this.areaTree.Name = "areaTree";
            this.areaTree.SelectedImageIndex = 0;
            this.areaTree.Size = new System.Drawing.Size(132, 274);
            this.areaTree.TabIndex = 1;
            this.areaTree.TabStop = false;
            this.areaTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.areaTree_AfterLabelEdit);
            this.areaTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.areaTree_AfterSelect);
            this.areaTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.areaTree_MouseUp);
            // 
            // areaCountLabel
            // 
            this.areaCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.areaCountLabel.AutoSize = true;
            this.areaCountLabel.Location = new System.Drawing.Point(0, 308);
            this.areaCountLabel.Name = "areaCountLabel";
            this.areaCountLabel.Size = new System.Drawing.Size(0, 13);
            this.areaCountLabel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Areas";
            // 
            // mouseModeToolStrip
            // 
            this.mouseModeToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mouseModeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectMouseModeToolStripButton,
            this.moveMouseModeToolStripButton});
            this.mouseModeToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mouseModeToolStrip.Location = new System.Drawing.Point(145, 0);
            this.mouseModeToolStrip.Name = "mouseModeToolStrip";
            this.mouseModeToolStrip.Size = new System.Drawing.Size(58, 25);
            this.mouseModeToolStrip.TabIndex = 11;
            this.mouseModeToolStrip.Text = "toolStrip1";
            this.mouseModeToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mouseModeToolStrip_ItemClicked);
            // 
            // selectMouseModeToolStripButton
            // 
            this.selectMouseModeToolStripButton.Checked = true;
            this.selectMouseModeToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectMouseModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectMouseModeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("selectMouseModeToolStripButton.Image")));
            this.selectMouseModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectMouseModeToolStripButton.Name = "selectMouseModeToolStripButton";
            this.selectMouseModeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.selectMouseModeToolStripButton.Tag = "0";
            this.selectMouseModeToolStripButton.ToolTipText = "Выбор и перемещение областей";
            // 
            // moveMouseModeToolStripButton
            // 
            this.moveMouseModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveMouseModeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("moveMouseModeToolStripButton.Image")));
            this.moveMouseModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveMouseModeToolStripButton.Name = "moveMouseModeToolStripButton";
            this.moveMouseModeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveMouseModeToolStripButton.Tag = "1";
            this.moveMouseModeToolStripButton.ToolTipText = "Создание областей";
            // 
            // imageSize
            // 
            this.imageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imageSize.AutoSize = true;
            this.imageSize.Location = new System.Drawing.Point(3, 308);
            this.imageSize.Name = "imageSize";
            this.imageSize.Size = new System.Drawing.Size(0, 13);
            this.imageSize.TabIndex = 10;
            // 
            // picPanel
            // 
            this.picPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picPanel.AutoScroll = true;
            this.picPanel.Controls.Add(this.picBox);
            this.picPanel.Location = new System.Drawing.Point(3, 28);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(480, 277);
            this.picPanel.TabIndex = 9;
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(3, 3);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(475, 271);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 9;
            this.picBox.TabStop = false;
            this.picBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseClick);
            this.picBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            this.picBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseMove);
            this.picBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseUp);
            // 
            // areaTreeContextMenuStrip
            // 
            this.areaTreeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linkAreaTreeToolStripMenuItem,
            this.delAreaTreeToolStripMenuItem});
            this.areaTreeContextMenuStrip.Name = "areaTreeContextMenuStrip";
            this.areaTreeContextMenuStrip.Size = new System.Drawing.Size(140, 48);
            // 
            // linkAreaTreeToolStripMenuItem
            // 
            this.linkAreaTreeToolStripMenuItem.Name = "linkAreaTreeToolStripMenuItem";
            this.linkAreaTreeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.linkAreaTreeToolStripMenuItem.Text = "Связать...";
            this.linkAreaTreeToolStripMenuItem.Click += new System.EventHandler(this.linkAreaTreeToolStripMenuItem_Click);
            // 
            // delAreaTreeToolStripMenuItem
            // 
            this.delAreaTreeToolStripMenuItem.Name = "delAreaTreeToolStripMenuItem";
            this.delAreaTreeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.delAreaTreeToolStripMenuItem.Text = "Удалить";
            this.delAreaTreeToolStripMenuItem.Click += new System.EventHandler(this.delAreaTreeToolStripMenuItem_Click);
            // 
            // hotspotTreeContextMenuStrip
            // 
            this.hotspotTreeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addHotspotTreeToolStripMenuItem,
            this.delHotspotTreeToolStripMenuItem});
            this.hotspotTreeContextMenuStrip.Name = "hotspotTreeContextMenuStrip";
            this.hotspotTreeContextMenuStrip.Size = new System.Drawing.Size(136, 48);
            // 
            // addHotspotTreeToolStripMenuItem
            // 
            this.addHotspotTreeToolStripMenuItem.Name = "addHotspotTreeToolStripMenuItem";
            this.addHotspotTreeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.addHotspotTreeToolStripMenuItem.Text = "Добавить";
            this.addHotspotTreeToolStripMenuItem.Click += new System.EventHandler(this.addHotspotTreeToolStripMenuItem_Click);
            // 
            // delHotspotTreeToolStripMenuItem
            // 
            this.delHotspotTreeToolStripMenuItem.Name = "delHotspotTreeToolStripMenuItem";
            this.delHotspotTreeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.delHotspotTreeToolStripMenuItem.Text = "Удалить";
            this.delHotspotTreeToolStripMenuItem.Click += new System.EventHandler(this.delHotspotTreeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 356);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.fileToolStrip);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapper";
            this.viewToolStrip.ResumeLayout(false);
            this.viewToolStrip.PerformLayout();
            this.fileToolStrip.ResumeLayout(false);
            this.fileToolStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.mouseModeToolStrip.ResumeLayout(false);
            this.mouseModeToolStrip.PerformLayout();
            this.picPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.areaTreeContextMenuStrip.ResumeLayout(false);
            this.hotspotTreeContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStrip fileToolStrip;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton inToolStripButton;
        private System.Windows.Forms.ToolStripButton outToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripButton allToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton x1ToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label hotspotCountLabel;
        private System.Windows.Forms.Label areaCountLabel;
        private ImageList linkedImageList;
        private Panel picPanel;
        private PictureBox picBox;
        private Label imageSize;
        private ContextMenuStrip areaTreeContextMenuStrip;
        private ToolStripMenuItem linkAreaTreeToolStripMenuItem;
        private ToolStripMenuItem delAreaTreeToolStripMenuItem;
        private TreeView hotspotTree;
        private TreeView areaTree;
        private ContextMenuStrip hotspotTreeContextMenuStrip;
        private ToolStripMenuItem addHotspotTreeToolStripMenuItem;
        private ToolStripMenuItem delHotspotTreeToolStripMenuItem;
        private ToolStrip mouseModeToolStrip;
        private ToolStripButton selectMouseModeToolStripButton;
        private ToolStripButton moveMouseModeToolStripButton;

	}
}

