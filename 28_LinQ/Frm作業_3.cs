using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_3 : Form
    {
        public Frm作業_3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,21 };
            
            foreach (int i in nums)
            {
                TreeNode node;
                if (i < 8)
                {
                    if (this.treeView1.Nodes["Small"] == null)
                    {//                                                ↑← ← ←↓辨識項目 ↓標題
                        node =this.treeView1.Nodes.Add("Small", "Small");
                        node.Nodes.Add(i.ToString());
                    }
                    else
                    {
                        this.treeView1.Nodes["Small"].Nodes.Add(i.ToString());
                    }
                }
                else if (i>7 && i <15)
                {
                    if (this.treeView1.Nodes["Medium"] == null)
                    {
                        node= this.treeView1.Nodes.Add("Medium", "Medium");
                        node.Nodes.Add(i.ToString());
                    }
                    else
                    {
                        this.treeView1.Nodes["Medium"].Nodes.Add(i.ToString());
                    }
                }
                else if(i>14)
                {
                    if (this.treeView1.Nodes["Large"] == null)
                    {
                        node = this.treeView1.Nodes.Add("Large", "Large");
                        node.Nodes.Add(i.ToString());
                    }
                    else
                    {
                        this.treeView1.Nodes["Large"].Nodes.Add(i.ToString());
                    }
                }
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            this.treeView1.Nodes.Clear();
            //this.dataGridView1.DataSource = files;

            var q = from n in files
                    group n by findsize(n.Length) into g
                    select new
                    {
                        MyKey = g.Key,
                        MyCount = g.Count(),
                        MyGroup = g
                    };
            this.dataGridView1.DataSource = q.ToList();
            //treeview=================================

            foreach(var group in q)
            {
                string s = $"{group.MyKey}({group.MyCount})";
                TreeNode node = this.treeView1.Nodes.Add(/*group.MyKey.ToString(),*/ s);
                foreach(var item in group.MyGroup)
                {
                    node.Nodes.Add(item.ToString());
                }
            }

        }

        private string findsize(long length)
        {
            if (length < 10000)
                return "Small";
            else if (length < 50000)
                return "Medium";
            else
                return "Large";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            this.treeView1.Nodes.Clear();
            var q = from n in files
                    group n by n.CreationTime.Year into g
                    orderby g.Key.ToString() ascending
                    select new
                    {
                        MyYear = g.Key,
                        MyCount = g.Count(),
                        MyGroup =g
                    };
            this.dataGridView1.DataSource = q.ToList();
            //treeview=================================
            foreach( var group in q)
            {
                string s = $"{group.MyYear}({group.MyCount})";
                TreeNode node = this.treeView1.Nodes.Add(s);
                foreach(var item in group.MyGroup)
                {
                    node.Nodes.Add(item.ToString());
                }
            }
        }

    }
}
