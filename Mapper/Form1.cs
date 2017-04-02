using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mapper
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void fileMenuItem_Click(object sender, EventArgs e)
		{
			manipulateFile(((ToolStripMenuItem)sender).Text);
		}

		private void fileToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			manipulateFile(((ToolStripItem)e.ClickedItem).Text);
		}

		private void formatMenuItem_Click(object sender, EventArgs e)
		{
 		}

		private void formatToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
		}

		private void changeOpacityToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

        private Image image = null;
        private double ratio = 1.0;
        private void manipulateFile(string menuItemText)
		{
			switch (menuItemText)
			{
				case "&Open":
                    this.openFileDialog.Filter = "Image Files(*.png; *.jpg; *.gif; *.bmp)|*.png; *.jpg; *.gif; *.bmp";
                    if (this.openFileDialog.ShowDialog() == DialogResult.OK)
					{
                        image = Image.FromFile(this.openFileDialog.FileName);
                        PictureBox.Image = image;
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

        private void toolStripInButton_Click(object sender, EventArgs e)
        {
            if (image == null)
                return;
            ratio += 0.1;
            zoom();
        }

        private void toolStripOutButton_Click(object sender, EventArgs e)
        {
            if (image == null)
                return;
            ratio -= 0.1;
            zoom();
        }

        private void zoom()
        {
            if (image == null)
                return;
            
        }
	}
}