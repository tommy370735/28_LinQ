using _28_LinQ;
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
        NorthwindEntities dbContext = new NorthwindEntities();
        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView2.DataSource = null;
            this.treeView1.Nodes.Clear();
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,21 };
            
            foreach (int i in nums)
            {
                TreeNode node;
                if (i < 8)
                {
                    if (this.treeView1.Nodes["Small"] == null)
                    {//                                              ↑ ← ← ←↓辨識項目 ↓標題
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
            this.dataGridView2.DataSource = null;
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
            this.dataGridView2.DataSource = null;
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
            //this.dataGridView1.DataSource = q.ToList();
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

        private void button8_Click(object sender, EventArgs e)
        {//NW Products 低中高 價產品 
            this.dataGridView2.DataSource = null;
            var q = from n in dbContext.Products.AsEnumerable()
                    group n by findunitprice(n.UnitPrice) into g
                    select new
                    {
                        商品類型 = g.Key,
                        種類數量 = g.Count(),
                        商品項目 = g
                    };
            this.dataGridView1.DataSource = q.ToList();
            //treeview=================================
            foreach (var group in q)
            {
                string s = $"{group.商品類型}({group.種類數量})";
                TreeNode node = this.treeView1.Nodes.Add( s) ;
                foreach (var item in group.商品項目)
                {
                    node.Nodes.Add(item.ProductName);
                }
            }

        }

        private object findunitprice(decimal? unitPrice)
        {
            if (unitPrice < 50)
                return "便宜貨";
            else if (unitPrice < 100)
                return "有賺頭";
            else
                return "奢侈品";
        }

        private void button15_Click(object sender, EventArgs e)
        {// Orders -  Group by 年
            var q = from n in dbContext.Orders
                          group n by n.OrderDate.Value.Year into g
                          orderby g.Key
                          select new
                          {
                              年份 = g.Key,
                              年訂單數 = g.Count()
                          };
            this.dataGridView1.DataSource = q.ToList();

            //============================================

            var q2 = from n2 in dbContext.Orders
                     orderby n2.OrderDate.Value.Year
                     select n2;
            this.dataGridView2.DataSource = q2.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {// Orders -  Group by 年 / 月
            var q = from n in this.dbContext.Orders
                          group n by new { n.OrderDate.Value.Year, n.OrderDate.Value.Month } into g
                          orderby g.Key
                          select new
                          {
                              時間 =g.Key,
                              月訂單數 = g.Count()
                          };
            this.dataGridView1.DataSource = q.ToList();

            //================================================

            var q2 = from n2 in dbContext.Orders
                     orderby n2.OrderDate.Value.Year, n2.OrderDate.Value.Month
                     select n2;
            this.dataGridView2.DataSource = q2.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var q = from n in this.dbContext.Order_Details
                    group n by n.Order.OrderDate.Value.Year into g
                    orderby g.Key
                    select new
                    {
                        年份 = g.Key,
                        年銷售金額 = g.Sum(n =>n.Quantity*n.UnitPrice)
                    };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //無法格式化============================
            //var q = from n in this.dbContext.Order_Details
            //        group n by n.Order.EmployeeID into g
            //        select new
            //        {
            //            員工編號 = g.Key,
            //            銷售額 = g.Sum(n=>n.UnitPrice*n.Quantity)
            //        };
            //this.dataGridView1.DataSource = q.OrderByDescending(g => g.銷售額).Take(5).ToList();
            //格式化===============================
            var q = (from n in this.dbContext.Order_Details.AsEnumerable()
                     group n by n.Order.EmployeeID into g
                     select new
                     {
                         員工編號 = g.Key,
                         銷售額 = g.Sum(n => n.UnitPrice * n.Quantity)
                     }).OrderByDescending(p => p.銷售額).Select(o => new { o.員工編號, 銷售總額 = $"{o.銷售額:C2}" }).Take(5);
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var q = from n in this.dbContext.Products.AsEnumerable()
                    orderby n.UnitPrice descending
                    select new
                    {
                        n.ProductID,
                        n.ProductName,
                        UnitPrice = $"{n.UnitPrice :c2}",
                        n.Category.CategoryName
                    };
            this.dataGridView1.DataSource = q.Take(5).ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var q = from n in this.dbContext.Products
                    orderby n.UnitPrice
                    select new
                    {
                        產品名 = n.ProductName,
                        產品價格 = n.UnitPrice
                    };
            if(q.Any(n => n.產品價格 > 300))
            {
                this.dataGridView1.DataSource = q.OrderByDescending(n=>n.產品價格).ToList();
            }
            else
            {
                MessageBox.Show("沒有單價大於300的產品。");
            }
        }
    }
}
