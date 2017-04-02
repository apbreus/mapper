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
    public partial class MainForm
    {
        private void manipulateFile(string menuItemText)
        {
            switch (menuItemText)
            {
                case "&Open":
                    this.openFileDialog.Filter = "Map File(map.xml)|map.xml|Image Files(*.png; *.jpg; *.gif; *.bmp)|*.png; *.jpg; *.gif; *.bmp";
                    if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (this.openFileDialog.FileName.Contains("map.xml"))
                        {
                            mapFileName = this.openFileDialog.FileName;
                            openMap();
                        }
                        else
                        {
                            imageFileName = this.openFileDialog.FileName;
                            openImage();
                        }
                    }
                    break;
                case "&Save":
                    if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("The Save button was clicked, but for sample purposes " +
                            "\nthe " + this.saveFileDialog.FileName + " file does not save.", "Sample Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                default:
                    this.Close();
                    this.Dispose();
                    break;
            }
        }
        private void drawAll()
        {
            if (image != null)
            {
                ratio = (double)(picPanel.Height - 10) / imageHeight;
                if ((int)(imageWidth * ratio) > picPanel.Width)
                {
                    ratio = (double)(picPanel.Width - 10) / imageWidth;
                }
                drawImage();
            }
        }
        private void drawX1()
        {
            if (image != null)
            {
                ratio = 1.0;
                drawImage();
            }
        }
        private void drawIn()
        {
            if (image != null)
            {
                ratio += 0.1;
                drawImage();
            }
        }
        private void drawOut()
        {
            if (image != null)
            {
                ratio -= 0.1;
                drawImage();
            }
        }
        private void clearImage()
        {
            if (image != null)
            {
                picBox.Width = (int)(imageWidth * ratio);
                picBox.Height = (int)(imageHeight * ratio);
                picBox.Image = (System.Drawing.Image)image.Clone();
            }
        }
        private void drawImage()
        {
            if (image != null)
            {
                picBox.Width = (int)(imageWidth * ratio);
                picBox.Height = (int)(imageHeight * ratio);
                picBox.Image = (System.Drawing.Image)image.Clone();
                drawAreas();
            }
        }
        private void drawAreas()
        {
            Graphics g = Graphics.FromImage(picBox.Image);
            foreach (AreaListItem area in areaList)
            {
                if (area.selected)
                    g.FillRectangle(selectedAreaBrush, area.rect);
                else
                    g.FillRectangle(areaBrush, area.rect);
            }
            g.Dispose();
        }
        private void openImage()
        {
            image = Image.FromFile(imageFileName);
            imageWidth = image.Width;
            imageHeight = image.Height;
            imageSize.Text = imageWidth + "x" + imageHeight;
            drawAll();
        }
        private void openMap()
        {
            //формирование imageFileName
            XmlDocument doc = new XmlDocument();
            doc.Load(mapFileName);
            XmlNode node = doc.SelectSingleNode("//image");
            if (node == null) return;
            node = node.Attributes.GetNamedItem("src");
            if (node == null) return;
            imageFileName = mapFileName.Replace("map.xml", node.Value);
            //формирование boardNo
            boardNo = node.Value;
            int k = boardNo.LastIndexOf(".");
            boardNo = boardNo.Substring(0, k);
            this.Text = "Mapper - " + boardNo;
            //заполнение списка областей areaList
            XmlNodeList nodeList = doc.SelectNodes("//area");
            if (nodeList == null) return;
            fillAreaList(nodeList);
            //заполнение списка горячих точек hotspotList
            hotspotList.Clear();
            if (imageFileName.Contains("Resource"))
            {
                k = imageFileName.IndexOf("Resource");
                resourceFileName = imageFileName.Substring(0, k) + "00000-0-A00-00-00A0-A.xml";
                doc.Load(resourceFileName);
                string str = boardNo;
                k = str.IndexOf("-");
                str = str.Substring(k + 1, str.Length - k - 1);
                k = str.IndexOf(".");
                string mi = str.Substring(0, k);
                str = "//graphic[@boardno='" + boardNo.Replace(mi, Ietm.TransRu(mi)) + "']";
                node = doc.SelectSingleNode(str);
                if (node != null)
                {
                    nodeList = node.SelectNodes(".//hotspot");
                    fillHotspotList(nodeList);
                }
            }
            //обновление информации о связях горячих точек c областями
            updateLinkedInfo();
            //вывод списка горячих точек, областей и рисунка
            fillHotspotTree();
            fillAreaTree();
            openImage();
        }
        private void fillAreaList(XmlNodeList nodeList)
        {
            XmlNode node;
            AreaListItem area;
            string[] coords;
            areaList.Clear();
            foreach (XmlNode areaNode in nodeList)
            {
                area = new AreaListItem();
                area.i = areaList.Count;
                area.id = "id: none";
                node = areaNode.Attributes.GetNamedItem("id");
                if (node != null) area.id = node.Value;
                area.title = "title: none";
                node = areaNode.Attributes.GetNamedItem("title");
                if (node != null) area.title = node.Value;
                area.alt = "alt: none";
                node = areaNode.Attributes.GetNamedItem("alt");
                if (node != null) area.alt = node.Value;
                area.coords = "coords: none";
                node = areaNode.Attributes.GetNamedItem("coords");
                if (node != null) area.coords = node.Value;
                coords = area.coords.Split(',');
                area.x = Convert.ToInt32(coords[0]);
                area.y = Convert.ToInt32(coords[1]);
                area.w = Convert.ToInt32(coords[2]) - area.x;
                area.h = Convert.ToInt32(coords[3]) - area.y;
                area.rect = new Rectangle(
                    (int)(area.x),
                    (int)(area.y),
                    (int)(area.w),
                    (int)(area.h)
                );
                areaList.Add(area);
            }
            areaList.Sort();
            for (int i = 0; i < areaList.Count; i++)
            {
                areaList[i].i = i;
            }
        }
        private void fillAreaTree()
        {
            TreeNode node;
            areaTree.Nodes.Clear();
            int i;
            foreach (AreaListItem area in areaList)
            {
                node = new TreeNode(area.title);
                node.Tag = area.i;
                i = node.Nodes.Add(new TreeNode(area.alt)); node.Nodes[i].Tag = 1;
                i = node.Nodes.Add(new TreeNode(area.coords)); node.Nodes[i].Tag = 2;
                i = node.Nodes.Add(new TreeNode(area.id)); node.Nodes[i].Tag = 3;
                if (area.linked)
                {
                    node.ImageIndex = (int)LinkedType.linked;
                    node.SelectedImageIndex = (int)LinkedType.linked;
                }
                else
                {
                    node.ImageIndex = (int)LinkedType.unlinked;
                    node.SelectedImageIndex = (int)LinkedType.unlinked;
                }
                areaTree.Nodes.Add(node);
            }
            areaCountLabel.Text = areaTree.Nodes.Count.ToString();
        }
        private void fillHotspotList(XmlNodeList nodeList)
        {
            XmlNode node;
            HotspotListItem hotspot;
            hotspotList.Clear();
            foreach (XmlNode hotspotNode in nodeList)
            {
                hotspot = new HotspotListItem();
                hotspot.id = "id: none";
                node = hotspotNode.Attributes.GetNamedItem("id");
                if (node != null) hotspot.id = node.Value;
                hotspot.title = "title: none";
                node = hotspotNode.Attributes.GetNamedItem("title");
                if (node != null) hotspot.title = node.Value;
                hotspotList.Add(hotspot);
            }
            hotspotList.Sort();
            for (int i = 0; i < hotspotList.Count; i++)
            {
                hotspotList[i].i = i;
            }
        }
        private void fillHotspotTree()
        {
            TreeNode node;
            hotspotTree.Nodes.Clear();
            int i;
            foreach (HotspotListItem hotspot in hotspotList)
            {
                node = new TreeNode(hotspot.title);
                node.Tag = hotspot.i;
                i = node.Nodes.Add(new TreeNode(hotspot.id)); node.Nodes[i].Tag = 1;
                if (hotspot.linked)
                {
                    node.ImageIndex = (int)LinkedType.linked;
                    node.SelectedImageIndex = (int)LinkedType.linked;
                }
                else
                {
                    node.ImageIndex = (int)LinkedType.unlinked;
                    node.SelectedImageIndex = (int)LinkedType.unlinked;
                }
                hotspotTree.Nodes.Add(node);
            }
            hotspotCountLabel.Text = hotspotTree.Nodes.Count.ToString();
        }
        private void updateLinkedInfo()
        {
            for (int i = 0; i < hotspotList.Count; i++)
            {
                hotspotList[i].i = i;
                hotspotList[i].linked = false;
                hotspotList[i].areaI = new List<int>();
            }
            for (int i = 0; i < areaList.Count; i++)
            {
                areaList[i].i = i;
            }
            if (hotspotList.Count > 0)
            {
                foreach (AreaListItem area in areaList)
                {
                    area.linked = false;
                    area.hotspotI = -1;
                    foreach (HotspotListItem hotspot in hotspotList)
                    {
                        if (area.id == hotspot.id)
                        {
                            area.linked = true;
                            area.hotspotI = hotspot.i;
                            hotspot.linked = true;
                            hotspot.areaI.Add(area.i);
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < areaList.Count; i++)
                {
                    if (areaList[i].id.Contains("none"))
                        areaList[i].linked = false;
                    else
                        areaList[i].linked = true;
                    areaList[i].hotspotI = -1;
                }
            }
        }
        //формирование списка областей по списку горячих точек
        private List<int> fillSelectedAreaTreeNodesList(List<int> selectedHotspotTreeNodesList)
        {
            List<int> list = new List<int>();
            foreach(int i in selectedHotspotTreeNodesList)
            {
                list.AddRange(hotspotList[i].areaI);
            }
            return list;
        }
        //формирование списка горячих точек по списку областей
        private List<int> fillSelectedHotspotTreeNodesList(List<int> selectedAreaTreeNodesList)
        {
            List<int> list = new List<int>();
            foreach (int i in selectedAreaTreeNodesList)
            {
                if (areaList[i].hotspotI >= 0)
                    list.Add(areaList[i].hotspotI);
            }
            return list;
        }
        //очистка дерева
        private void clearTree(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.BackColor = SystemColors.Window;
                node.ForeColor = SystemColors.WindowText;
            }
        }
        //выделение узлов дерева горячих точек
        private void selectHotspotTreeNodes()
        {
            clearTree(hotspotTree.Nodes);
            foreach (int i in selectedHotspotList)
            {
                hotspotTree.Nodes[i].BackColor = SystemColors.Highlight;
                hotspotTree.Nodes[i].ForeColor = SystemColors.HighlightText;
                hotspotTree.Nodes[i].EnsureVisible();
            }
        }
        //выделение узлов дерева областей
        private void selectAreaTreeNodes()
        {
            clearTree(areaTree.Nodes);
            foreach (int i in selectedAreaList)
            {
                areaTree.Nodes[i].BackColor = SystemColors.Highlight;
                areaTree.Nodes[i].ForeColor = SystemColors.HighlightText;
                areaTree.Nodes[i].EnsureVisible();
            }
        }
        //выделение областей на рисунке
        private void selectAreas()
        {
            foreach (AreaListItem area in areaList)
            {
                area.selected = false;    
            }
            foreach (int i in selectedAreaList)
            {
                areaList[i].selected = true;
            }
        }




        //поиск области по точке
        private AreaListItem findArea(Point p)
        {
            foreach (AreaListItem area in areaList)
            {
                if (area.rect.Contains(p))
                    return area;
            }
            return null;
        }
        private void changeSelectedAreasCoords(Point p)
        {
            int deltaX = p.X - initialMousePoint.X;
            int deltaY = p.Y - initialMousePoint.Y;
            foreach (AreaListItem area in areaList)
            {
                if (area.selected)
                {
                    coordsChanged = true;
                    area.x += deltaX;
                    area.y += deltaY;
                    area.rect.X += deltaX;
                    area.rect.Y += deltaY;
                    area.coords = String.Format("{0},{1},{2},{3}", area.x, area.y, area.w, area.h);
                }
            }
        }
        private void changeSelectedAreasCoords(int deltaX, int deltaY)
        {
            foreach (AreaListItem area in areaList)
            {
                if (area.selected)
                {
                    coordsChanged = true;
                    area.x += deltaX;
                    area.y += deltaY;
                    area.rect.X += deltaX;
                    area.rect.Y += deltaY;
                    area.coords = String.Format("{0},{1},{2},{3}", area.x, area.y, area.w, area.h);
                }
            }
        }
        private void changeNewAreaCoords(Point p)
        {
            coordsChanged = true;
            newArea.w = p.X - newArea.x;
            newArea.h = p.Y - newArea.y;
            newArea.rect.Width = newArea.w;
            newArea.rect.Height = newArea.h;
            newArea.coords = String.Format("{0},{1},{2},{3}", newArea.x, newArea.y, newArea.w, newArea.h);
        }


    }
}
