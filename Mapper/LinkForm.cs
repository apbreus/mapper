using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mapper
{
    public partial class LinkForm : Form
    {
        public int hotspotI;

        public LinkForm(List<HotspotListItem> hotspotList)
        {
            this.DialogResult = DialogResult.Cancel;
            hotspotI = -1;
            InitializeComponent();
            fillHotspotTree(hotspotList);
        }

        private void fillHotspotTree(List<HotspotListItem> hotspotList)
        {
            TreeNode node;
            foreach (HotspotListItem hotspot in hotspotList)
            {
                node = new TreeNode(hotspot.title);
                node.Tag = hotspot.i;
                int i = node.Nodes.Add(new TreeNode(hotspot.id)); node.Nodes[i].Tag = 1;
                hotspotTree.Nodes.Add(node);
            }
        }

        private void CanselButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hotspotTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            hotspotI = (int)e.Node.Tag;
            linkButton.Enabled = true;
        }

        private void linkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
