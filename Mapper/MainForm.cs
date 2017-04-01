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
        private List<int> selectedHotspotList;
        private List<int> selectedAreaList;
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
        private MouseMode mouseMode;
        private Point initialMousePoint;
        private AreaListItem newArea;
        private bool coordsChanged;
        private int newAreaIndex;
        private int newHotspotIndex;

        public MainForm()
        {
            InitializeComponent();
            areaList = new List<AreaListItem>();
            hotspotList = new List<HotspotListItem>();
            selectedHotspotList = new List<int>();
            selectedAreaList = new List<int>();
            ratio = 1.0;
            areaBrush = new SolidBrush(Color.FromArgb(50, 76, 253, 153));
            selectedAreaBrush = new SolidBrush(Color.FromArgb(200, 255, 0, 0));
            mouseMode = 0;
            initialMousePoint = new Point();
            newArea = new AreaListItem();
            coordsChanged = false;
            newAreaIndex = 0;
            newHotspotIndex = 0;
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








        //hotspotTree
        private void hotspotTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //выбор узлов
            TreeNode node = hotspotTree.SelectedNode;
            int hotspotI = (int)node.Tag;
            if (Control.ModifierKeys == Keys.Shift && node.Level == 0)
            {
                //выбор диапазона узлов
                int startI = hotspotI;
                int endI = hotspotI;
                if (selectedHotspotList.Count > 0)
                {
                    selectedHotspotList.Sort();
                    endI = selectedHotspotList[0];
                    if (hotspotI > endI)
                    {
                        startI = endI;
                        endI = hotspotI;
                    }
                    selectedHotspotList = new List<int>();
                }
                for (int i = startI; i < endI + 1; i++)
                {
                    selectedHotspotList.Add(i);
                }
                hotspotTree.SelectedNode = hotspotTree.Nodes[hotspotList[endI].i];
            }
            else if (Control.ModifierKeys == Keys.Control && node.Level == 0)
            {
                //выбор нескольких узлов 
                hotspotTree.SelectedNode = null; 
                if (!selectedHotspotList.Remove(hotspotI))
                {
                    selectedHotspotList.Add(hotspotI);
                }
            }
            else
            {
                //выбор одного узла
                selectedHotspotList = new List<int>();
                if (node.Level == 0)
                {
                    selectedHotspotList.Add(hotspotI);
                }
            }
            selectedAreaList = fillSelectedAreaTreeNodesList(selectedHotspotList);
            selectHotspotTreeNodes();
            selectAreaTreeNodes();
            selectAreas();
            drawImage();
        }
        private void hotspotTree_MouseUp(object sender, MouseEventArgs e)
        {          
            Point p = new Point(e.X, e.Y);
            TreeNode node = hotspotTree.GetNodeAt(p);
            if (node != null)
            {
                int hotspotI = (int)node.Tag;
                if (e.Button == MouseButtons.Right)
                {
                    if (selectedHotspotList.Contains(hotspotI) && node.Level == 0)
                    {
                        //контекстное меню
                        addHotspotTreeToolStripMenuItem.Enabled = false;
                        delHotspotTreeToolStripMenuItem.Enabled = true;
                        hotspotTreeContextMenuStrip.Show(hotspotTree, p);
                    }
                }
            }
            else
            {
                if (e.Button == MouseButtons.Right && image != null)
                {
                    //контекстное меню
                    addHotspotTreeToolStripMenuItem.Enabled = true;
                    delHotspotTreeToolStripMenuItem.Enabled = false;
                    hotspotTreeContextMenuStrip.Show(hotspotTree, p);
                }
            }
        }
        private void addHotspotTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotspotListItem hotspot = new HotspotListItem();
            hotspot.title = String.Format("_hotspot{0}", newHotspotIndex++);
            hotspot.id = Guid.NewGuid().ToString().Replace("-", "");
            hotspotList.Add(hotspot);
            hotspotList.Sort();
            for (int i = 0; i < hotspotList.Count; i++)
            {
                hotspotList[i].i = i;
            }
            selectedHotspotList = new List<int>();
            selectedAreaList = new List<int>();
            updateLinkedInfo();
            fillHotspotTree();
            fillAreaTree();
            drawImage();
        }
        private void delHotspotTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedHotspotList.Count > 0)
            {
                foreach (int i in selectedHotspotList)
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
                selectedHotspotList = new List<int>();
                selectedAreaList = new List<int>();
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
                    selectedHotspotList = new List<int>();
                    selectedAreaList = new List<int>();
                    updateLinkedInfo();
                    fillHotspotTree();
                    fillAreaTree();
                    drawImage();
                }
            }
        }




         //areaTree
         private void areaTree_AfterSelect(object sender, TreeViewEventArgs e)
         {
             //выбор узлов
             TreeNode node = areaTree.SelectedNode;
             int areaI = (int)node.Tag;
             if (Control.ModifierKeys == Keys.Shift && node.Level == 0)
             {
                 //выбор диапазона узлов
                 int startI = areaI;
                 int endI = areaI;
                 if (selectedAreaList.Count > 0)
                 {
                     selectedAreaList.Sort();
                     endI = selectedAreaList[0];
                     if (areaI > endI)
                     {
                         startI = endI;
                         endI = areaI;
                     }
                     selectedAreaList = new List<int>();
                 }
                 for (int i = startI; i < endI + 1; i++)
                 {
                     selectedAreaList.Add(i);
                 }
                 areaTree.SelectedNode = areaTree.Nodes[areaList[endI].i];
             }
             else if (Control.ModifierKeys == Keys.Control && node.Level == 0)
             {
                 //выбор нескольких узлов 
                 areaTree.SelectedNode = null; 
                 if (!selectedAreaList.Remove(areaI))
                 {
                     selectedAreaList.Add(areaI);
                 }
             }
             else
             {
                 //выбор одного узла
                 selectedAreaList = new List<int>();
                 if (node.Level == 0)
                 {
                    selectedAreaList.Add(areaI);
                 }
             }
             selectedHotspotList = fillSelectedHotspotTreeNodesList(selectedAreaList);
             selectHotspotTreeNodes();
             selectAreaTreeNodes();
             selectAreas();
             drawImage();
         }
         private void areaTree_MouseUp(object sender, MouseEventArgs e)
         {
             Point p = new Point(e.X, e.Y);
             TreeNode node = areaTree.GetNodeAt(p);
             if (node != null)
             {
                 int areaI = (int)node.Tag;
                 if (e.Button == MouseButtons.Right)
                 {
                     if (selectedAreaList.Count == 1)
                     {
                         if (selectedAreaList.Contains(areaI) && node.Level == 0)
                         {
                             //контекстное меню
                             linkAreaTreeToolStripMenuItem.Enabled = true;
                             delAreaTreeToolStripMenuItem.Enabled = true;
                             areaTreeContextMenuStrip.Show(areaTree, p);
                         }
                     }
                     else if (selectedAreaList.Contains(areaI) && node.Level == 0)
                     {
                         //контекстное меню
                         linkAreaTreeToolStripMenuItem.Enabled = false;
                         delAreaTreeToolStripMenuItem.Enabled = true;
                         areaTreeContextMenuStrip.Show(areaTree, p);
                     }
                 }
             }
         }
         private void linkAreaTreeToolStripMenuItem_Click(object sender, EventArgs e)
         {
             if (selectedAreaList.Count == 1)
             {
                 int areaI = selectedAreaList[0];
                 if (areaI >= 0 && areaI < areaList.Count)
                 {
                     LinkForm dialog = new LinkForm(hotspotList);
                     dialog.Text = "Область " + areaList[areaI].title + " связать с";
                     if (dialog.ShowDialog() == DialogResult.OK)
                     {
                         int hotspotI = dialog.hotspotI;
                         if (hotspotI >= 0 && hotspotI < hotspotList.Count)
                         {
                             areaList[areaI].id = hotspotList[hotspotI].id;
                             selectedHotspotList = new List<int>();
                             selectedAreaList = new List<int>();
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
             if (selectedAreaList.Count > 0)
             {
                 foreach (int i in selectedAreaList)
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
                 selectedHotspotList = new List<int>();
                 selectedAreaList = new List<int>();
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
                             selectedHotspotList = new List<int>();
                             selectedAreaList = new List<int>();
                             updateLinkedInfo();
                             fillHotspotTree();
                             fillAreaTree();
                             drawImage();
                             break;
                     }
                 }
             }
         }

         //keyboard
         protected override void OnKeyDown(KeyEventArgs e)
         {
             if (image != null && mouseMode == MouseMode.select && e.Modifiers == (Keys.Control | Keys.Shift))
             {
                 if (e.KeyCode == Keys.Up)
                 {
                     changeSelectedAreasCoords(0, (int)(-1 / ratio));
                     drawImage();
                 }
                 else if (e.KeyCode == Keys.Down)
                 {
                     changeSelectedAreasCoords(0, (int)(1 / ratio));
                     drawImage();
                 }
                 else if (e.KeyCode == Keys.Right)
                 {
                     changeSelectedAreasCoords((int)(1 / ratio), 0);
                     drawImage();
                 }
                 else if (e.KeyCode == Keys.Left)
                 {
                     changeSelectedAreasCoords((int)(-1 / ratio), 0);
                     drawImage();
                 }
             }
             else
             {
                 base.OnKeyDown(e);
             }
         }

        
         //mouseMode
         private void mouseModeToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
         {
             mouseMode = (MouseMode)Convert.ToInt32(e.ClickedItem.Tag);
             foreach (ToolStripButton btn in mouseModeToolStrip.Items)
             {
                 btn.Checked = false;
             }
             ToolStripButton b = (ToolStripButton)e.ClickedItem;
             b.Checked = true;
         }
        
        
        //picBox
        private void picBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (mouseMode == MouseMode.select)
            {
                AreaListItem area = findArea(new Point((int)(e.X / ratio), (int)(e.Y / ratio)));
                if (area != null)
                {
                    int areaI = area.i;
                    if (e.Button == MouseButtons.Left)
                    {
                        //выбор областей
                        if (Control.ModifierKeys == Keys.Shift)
                        {
                            //выбор диапазона областей
                            int startI = areaI;
                            int endI = areaI;
                            if (selectedAreaList.Count > 0)
                            {
                                selectedAreaList.Sort();
                                endI = selectedAreaList[0];
                                if (areaI > endI)
                                {
                                    startI = endI;
                                    endI = areaI;
                                }
                                selectedAreaList = new List<int>();
                            }
                            for (int i = startI; i < endI + 1; i++)
                            {
                                selectedAreaList.Add(i);
                            }
                        }
                        else if (Control.ModifierKeys == Keys.Control)
                        {
                            //выбор нескольких областей 
                            if (!selectedAreaList.Remove(areaI))
                            {
                                selectedAreaList.Add(areaI);
                            }
                        }
                        else
                        {
                            //выбор одной области
                            selectedAreaList = new List<int>();
                            selectedAreaList.Add(areaI);
                        }
                        selectedHotspotList = fillSelectedHotspotTreeNodesList(selectedAreaList);
                        selectHotspotTreeNodes();
                        selectAreaTreeNodes();
                        selectAreas();
                        drawImage();
                    }
                    else
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            if (selectedAreaList.Count == 1)
                            {
                                if (selectedAreaList.Contains(areaI))
                                {
                                    //контекстное меню
                                    linkAreaTreeToolStripMenuItem.Enabled = true;
                                    delAreaTreeToolStripMenuItem.Enabled = true;
                                    areaTreeContextMenuStrip.Show(picBox, new Point(e.X, e.Y));
                                }
                            }
                            else if (selectedAreaList.Contains(areaI))
                            {
                                //контекстное меню
                                linkAreaTreeToolStripMenuItem.Enabled = false;
                                delAreaTreeToolStripMenuItem.Enabled = true;
                                areaTreeContextMenuStrip.Show(picBox, new Point(e.X, e.Y));
                            }
                        }
                    }
                }
            }
        }
        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseMode == MouseMode.select && e.Button == MouseButtons.Left)
            {
                initialMousePoint = new Point((int)(e.X / ratio), (int)(e.Y / ratio));
            }
            else if (mouseMode == MouseMode.rect && e.Button == MouseButtons.Left)
            {
                initialMousePoint = new Point((int)(e.X / ratio), (int)(e.Y / ratio)); 
                newArea = new AreaListItem();
                newArea.title = String.Format("_area{0}", newAreaIndex++);
                newArea.alt = ("alt: none");
                newArea.id = ("id: none");
                newArea.x = initialMousePoint.X;
                newArea.y = initialMousePoint.Y;
                newArea.w = 1;
                newArea.h = 1;
                newArea.rect = new Rectangle(newArea.x, newArea.y, newArea.w, newArea.h);
                newArea.coords = String.Format("{0},{1},{2},{3}", newArea.x, newArea.y, newArea.w, newArea.h);
                areaList.Add(newArea);
                areaList.Sort();
                for (int i = 0; i < areaList.Count; i++)
                {
                    areaList[i].i = i;
                }
                selectedHotspotList = new List<int>();
                selectedAreaList = new List<int>();
                selectedAreaList.Add(newArea.i);
                updateLinkedInfo();
                fillHotspotTree();
                fillAreaTree();
                areaTree.Nodes[newArea.i].EnsureVisible();
                selectAreas();
            }
        }
        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMode == MouseMode.select && e.Button == MouseButtons.Left)
            {
                changeSelectedAreasCoords(new Point((int)(e.X / ratio), (int)(e.Y / ratio)));
                drawImage();
                initialMousePoint = new Point((int)(e.X / ratio), (int)(e.Y / ratio));
            }
            else if (mouseMode == MouseMode.rect && e.Button == MouseButtons.Left)
            {
                changeNewAreaCoords(new Point((int)(e.X / ratio), (int)(e.Y / ratio)));
                drawImage();
            }
        }
        private void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (coordsChanged)
            {
                coordsChanged = false;
                fillHotspotTree();
                fillAreaTree();
                areaTree.Nodes[newArea.i].EnsureVisible();
            }
        }





 

    }
}