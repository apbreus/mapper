using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.XPath; 


namespace Mapper
{
    public partial class MainForm : Form
    {
        private List<AreaListItem> areaList;
        private List<HotspotListItem> hotspotList;
        private List<int> hotspotTreeSelectedNodeIndexList;
        private List<int> areaTreeSelectedNodeIndexList;
        private string mapFileName;
        private string imageFileName;
        private string boardNo;
        private string resourceFileName;
        private int imageWidth;
        private int imageHeight;
        private double ratio;
        private Image image;
        private Brush areaBrush;
        private Brush selectedAreaBrush;


        public MainForm()
        {
            InitializeComponent();
            areaList = new List<AreaListItem>();
            hotspotList = new List<HotspotListItem>();
            hotspotTreeSelectedNodeIndexList = new List<int>();
            areaTreeSelectedNodeIndexList = new List<int>();
            ratio = 1.0;
            areaBrush = new SolidBrush(Color.FromArgb(50, 76, 253, 153));
            selectedAreaBrush = new SolidBrush(Color.FromArgb(200, 255, 0, 0));
        }
        private void fileToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            manipulateFile(((ToolStripItem)e.ClickedItem).Text);
        }
        private void allToolStripButton_Click(object sender, EventArgs e)
        {
            drawAll();
        }
        private void x1ToolStripButton_Click(object sender, EventArgs e)
        {
            drawX1();
        }
        private void inToolStripButton_Click(object sender, EventArgs e)
        {
            drawIn();
        }
        private void outToolStripButton_Click(object sender, EventArgs e)
        {
            drawOut();
        }       




        //areaTree
        private void areaTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            areaTree.SelectedNode = null;
        }
        private void areaTree_MouseUp(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            TreeNode node = areaTree.GetNodeAt(p);
            if (node != null)
            {
                if (node.Level == 0)
                {
                    int areaI = (int)node.Tag;
                    if (e.Button == MouseButtons.Right)
                    {
                        if (areaTreeSelectedNodeIndexList.Count == 1)
                        {
                            if (areaTreeSelectedNodeIndexList.Contains(areaI))
                            {
                                //контекстное меню
                                linkAreaTreeToolStripMenuItem.Enabled = true;
                                delAreaTreeToolStripMenuItem.Enabled = true;
                                areaTreeContextMenuStrip.Show(areaTree, p);
                            }                        
                        }
                        else if (areaTreeSelectedNodeIndexList.Contains(areaI))
                        {
                            //контекстное меню
                            linkAreaTreeToolStripMenuItem.Enabled = false;
                            delAreaTreeToolStripMenuItem.Enabled = true;
                            areaTreeContextMenuStrip.Show(areaTree, p);
                        }
                    }
                    else
                    {
                        //выбор узлов
                        clearAreaTree();
                        if (Control.ModifierKeys == Keys.Shift)
                        {
                            //выбор диапазона узлов
                            int startI = areaI;
                            int endI = areaI;
                            if (areaTreeSelectedNodeIndexList.Count > 0)
                            {
                                areaTreeSelectedNodeIndexList.Sort();
                                endI = areaTreeSelectedNodeIndexList[0];
                                if (areaI > endI)
                                {
                                    startI = endI;
                                    endI = areaI;
                                }
                                areaTreeSelectedNodeIndexList = new List<int>();
                            }
                            for(int i = startI;i < endI + 1; i++)
                            {
                                areaTree.Nodes[i].BackColor = SystemColors.Highlight;
                                areaTree.Nodes[i].ForeColor = SystemColors.HighlightText;
                                areaTreeSelectedNodeIndexList.Add(i);
                            }
                        }
                        else if (Control.ModifierKeys == Keys.Control)
                        {
                            //выбор нескольких узлов 
                            foreach (int i in areaTreeSelectedNodeIndexList)
                            {
                                if (i != areaI)
                                {
                                    areaTree.Nodes[i].BackColor = SystemColors.Highlight;
                                    areaTree.Nodes[i].ForeColor = SystemColors.HighlightText;
                                }
                            }
                            if (!areaTreeSelectedNodeIndexList.Remove(areaI))
                            {
                                areaTree.Nodes[areaI].BackColor = SystemColors.Highlight;
                                areaTree.Nodes[areaI].ForeColor = SystemColors.HighlightText;
                                areaTreeSelectedNodeIndexList.Add(areaI);
                            }
                        }
                        else
                        {
                            //выбор одного узла
                            areaTree.Nodes[areaI].BackColor = SystemColors.Highlight;
                            areaTree.Nodes[areaI].ForeColor = SystemColors.HighlightText;
                            areaTreeSelectedNodeIndexList = new List<int>();
                            areaTreeSelectedNodeIndexList.Add(areaI);
                            //очистка деревьев и рисунка
                            clearHotspotTree();
                            drawImage();
                            //выбор горячей точки, связанной с областью
                            selectHotspotTreeNode(node);
                            //выделение прямоугольника области
                            drawSelectedAreaRect(areaI);
                        }
                    }
                }
            }
        }
        private void linkAreaTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (areaTreeSelectedNodeIndexList.Count == 1)
            {
                int areaI = areaTreeSelectedNodeIndexList[0];
                if (areaI >= 0 && areaI < areaList.Count)
                {
                    clearHotspotTree();
                    clearAreaTree();
                    drawImage();
                    LinkForm dialog = new LinkForm(hotspotList);
                    dialog.Text = "Область " + areaList[areaI].title + " связать с";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        int hotspotI = dialog.hotspotI;
                        if (hotspotI >= 0 && hotspotI < hotspotList.Count)
                        {
                            areaList[areaI].id = hotspotList[hotspotI].id;
                            updateLinkedInfo();
                            fillHotspotTree();
                            fillAreaTree();
                            drawImage();
                        }
                    }
                    dialog.Dispose();
                }
            }
        }
        private void delAreaTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (areaTreeSelectedNodeIndexList.Count > 0)
            {
                foreach (int i in areaTreeSelectedNodeIndexList)
                {
                    foreach (AreaListItem area in areaList)
                    {
                        if (i == area.i)
                        {
                            areaList.Remove(area);
                            break;
                        }
                    }
                }
                areaTreeSelectedNodeIndexList = new List<int>();
                updateLinkedInfo();
                fillHotspotTree();
                fillAreaTree();
                drawImage();
            }
        }
        private void areaTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!e.CancelEdit && (e.Label != null))
            {
                if (e.Node.Level == 0)
                {
                    areaList[(int)e.Node.Tag].title = e.Label;
                }
                else
                {
                    TreeNode node = e.Node.Parent;
                    int i = (int)node.Tag;
                    switch ((int)e.Node.Tag)
                    {
                        case 1: //alt
                            areaList[i].alt = e.Label;
                            break;
                        case 2: //coords
                            areaList[i].coords = e.Label;
                            string[] coords = e.Label.Split(',');
                            areaList[i].x = Convert.ToInt32(coords[0]);
                            areaList[i].y = Convert.ToInt32(coords[1]);
                            areaList[i].w = Convert.ToInt32(coords[2]) - areaList[i].x;
                            areaList[i].h = Convert.ToInt32(coords[3]) - areaList[i].y;
                            areaList[i].rect = new Rectangle(
                                (int)(areaList[i].x),
                                (int)(areaList[i].y),
                                (int)(areaList[i].w),
                                (int)(areaList[i].h)
                            );
                            drawImage();
                            drawSelectedAreaRect(i);
                            break;
                        case 3:  //id
                            areaList[i].id = e.Label;
                            updateLinkedInfo();
                            if (areaList[i].linked)
                            {
                                node.ImageIndex = (int)LinkedType.linked;
                                node.SelectedImageIndex = (int)LinkedType.linked;
                            }
                            else
                            {
                                node.ImageIndex = (int)LinkedType.unlinked;
                                node.SelectedImageIndex = (int)LinkedType.unlinked;
                            }
                            fillHotspotTree();
                            drawImage();
                            break;
                    }
                }
            }
        }




        //hotspotTree
        private void hotspotTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            hotspotTree.SelectedNode = null;
        }
        private void hotspotTree_MouseUp(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            TreeNode node = hotspotTree.GetNodeAt(p);
            if (node != null)
            {
                if (node.Level == 0)
                {
                    int hotspotI = (int)node.Tag;
                    if (e.Button == MouseButtons.Right)
                    {
                        if (hotspotTreeSelectedNodeIndexList.Contains(hotspotI))
                        {
                            //контекстное меню
                            addHotspotTreeToolStripMenuItem.Enabled = false;
                            delHotspotTreeToolStripMenuItem.Enabled = true;
                            hotspotTreeContextMenuStrip.Show(hotspotTree, p);
                        }
                    }
                    else
                    {
                        //выбор узлов
                        clearHotspotTree();
                        if (Control.ModifierKeys == Keys.Shift)
                        {
                            //выбор диапазона узлов
                            int startI = hotspotI;
                            int endI = hotspotI;
                            if (hotspotTreeSelectedNodeIndexList.Count > 0)
                            {
                                hotspotTreeSelectedNodeIndexList.Sort();
                                endI = hotspotTreeSelectedNodeIndexList[0];
                                if (hotspotI > endI)
                                {
                                    startI = endI;
                                    endI = hotspotI;
                                }
                                hotspotTreeSelectedNodeIndexList = new List<int>();
                            }
                            for(int i = startI;i < endI + 1; i++)
                            {
                                hotspotTree.Nodes[i].BackColor = SystemColors.Highlight;
                                hotspotTree.Nodes[i].ForeColor = SystemColors.HighlightText;
                                hotspotTreeSelectedNodeIndexList.Add(i);
                            }
                        }
                        else if (Control.ModifierKeys == Keys.Control)
                        {
                            //выбор нескольких узлов 
                            foreach (int i in hotspotTreeSelectedNodeIndexList)
                            {
                                if (i != hotspotI)
                                {
                                    hotspotTree.Nodes[i].BackColor = SystemColors.Highlight;
                                    hotspotTree.Nodes[i].ForeColor = SystemColors.HighlightText;
                                }
                            }
                            if (!hotspotTreeSelectedNodeIndexList.Remove(hotspotI))
                            {
                                hotspotTree.Nodes[hotspotI].BackColor = SystemColors.Highlight;
                                hotspotTree.Nodes[hotspotI].ForeColor = SystemColors.HighlightText;
                                hotspotTreeSelectedNodeIndexList.Add(hotspotI);
                            }
                        }
                        else
                        {
                            //выбор одного узла
                            hotspotTree.Nodes[hotspotI].BackColor = SystemColors.Highlight;
                            hotspotTree.Nodes[hotspotI].ForeColor = SystemColors.HighlightText;
                            hotspotTreeSelectedNodeIndexList = new List<int>();
                            hotspotTreeSelectedNodeIndexList.Add(hotspotI);
                            //очистка деревьев и рисунка
                            clearAreaTree();
                            drawImage();
                            //выбор областей, связанных с выбранной горячей точкой
                            selectAreaTreeNodes(node);
                        }
                    }
                }
            }
            else
            {
                //контекстное меню
                addHotspotTreeToolStripMenuItem.Enabled = true;
                delHotspotTreeToolStripMenuItem.Enabled = false;
                hotspotTreeContextMenuStrip.Show(hotspotTree, p);
            }
        }
        private void addHotspotTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotspotListItem hotspot = new HotspotListItem();
            hotspot.title = "new_hotspot";
            hotspot.id = Guid.NewGuid().ToString().Replace("-", "");
            hotspotList.Add(hotspot);
            hotspotList.Sort();
            for (int i = 0; i < hotspotList.Count; i++)
            {
                hotspotList[i].i = i;
            }
            fillHotspotTree();
            clearAreaTree();
            drawImage();
        }
        private void delHotspotTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hotspotTreeSelectedNodeIndexList.Count > 0)
            {
                foreach (int i in hotspotTreeSelectedNodeIndexList)
                {
                    foreach (HotspotListItem hotspot in hotspotList)
                    {
                        if (i == hotspot.i)
                        {
                            hotspotList.Remove(hotspot);
                            break;
                        }
                    }
                }
                hotspotTreeSelectedNodeIndexList = new List<int>();
                updateLinkedInfo();
                fillHotspotTree();
                fillAreaTree();
                drawImage();
            }
        }
         private void hotspotTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!e.CancelEdit && (e.Label != null))
            {
                if (e.Node.Level == 0)
                {
                    hotspotList[(int)e.Node.Tag].title = e.Label;
                }
                else
                {
                    TreeNode node = e.Node.Parent;
                    int i = (int)node.Tag;
                    hotspotList[i].id = e.Label;
                    updateLinkedInfo();
                    if (hotspotList[i].linked)
                    {
                        node.ImageIndex = (int)LinkedType.linked;
                        node.SelectedImageIndex = (int)LinkedType.linked;
                    }
                    else
                    {
                        node.ImageIndex = (int)LinkedType.unlinked;
                        node.SelectedImageIndex = (int)LinkedType.unlinked;
                    }
                    fillAreaTree();
                    drawImage();
                }
            }
        }





        private void picBox_MouseClick(object sender, MouseEventArgs e)
        {
            clearHotspotTree();
            clearAreaTree();
            drawImage();
            selectArea(new Point((int)(e.X / ratio), (int)(e.Y / ratio)));
        }

 

    }
}