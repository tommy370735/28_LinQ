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
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
            this.order_DetailsTableAdapter1.Fill(this.nwDataSet1.Order_Details);
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            
            SetYears();
        }

        private void SetYears()
        {//todo 設定comboBox1的內容
            this.comboBox1.Items.Add("所有年份訂單");
            var q = from n in this.nwDataSet1.Orders
                    group n by n.OrderDate.Year into n_years臨時資料表
                    select n_years臨時資料表.Key;

            foreach (int y in q)
            {
                this.comboBox1.Items.Add(y);
            }

            this.comboBox1.SelectedIndex = 0;
        }



        private void button14_Click(object sender, EventArgs e)
        {
            //todo：.log抓取
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files =  dir.GetFiles();

            var q = from n in files where n.Extension == ".log" select n;

            this.dataGridView1.DataSource = q.ToList();

            //this.dataGridView1.DataSource = files;

        }

        private void button6_Click(object sender, EventArgs e)
        {//todo：顯示所有資料
            lblMaster.Text = "Orders 資料";
            lblDetails.Text = "訂單明細";
            IEnumerable<global::_28_LinQ.nwDataSet.OrdersRow> q = from n in this.nwDataSet1.Orders where !n.IsShippedDateNull() select n;
            dataGridView1.DataSource = q.ToList();
            //this.bindingSource1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {//todo：抓comboBox內對應資料
            lblMaster.Text = "Orders 資料";
            lblDetails.Text = "訂單明細";
            if (this.comboBox1.Text == "所有年份訂單")
            {
                IEnumerable<global::_28_LinQ.nwDataSet.OrdersRow> q = from n in this.nwDataSet1.Orders where !n.IsShippedDateNull() select n;
                dataGridView1.DataSource = q.ToList();
            }
            else
            {
                IEnumerable<global::_28_LinQ.nwDataSet.OrdersRow> q = from n in this.nwDataSet1.Orders
                                                                      where !n.IsShippedDateNull() && n.OrderDate.Year.ToString() == this.comboBox1.Text
                                                                      select n;
                dataGridView1.DataSource = q.ToList();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //todo：資料夾產生時間CreationTime
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from n in files where n.CreationTime.Year == 2022 select n;

            this.dataGridView1.DataSource = q.ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //todo：大檔案，Length超過1MB
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from n in files where n.Length > 1000000 select n;

            this.dataGridView1.DataSource = q.ToList();
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{//todo：comboBox抓資料
        //    if (this.comboBox1.Text == "所有年份訂單")
        //    {
        //        IEnumerable<global::_28_LinQ.nwDataSet.OrdersRow> q = from n in this.nwDataSet1.Orders where !n.IsShippedDateNull() select n;
        //        dataGridView1.DataSource = q.ToList();
        //    }
        //    else
        //    {
        //        IEnumerable<global::_28_LinQ.nwDataSet.OrdersRow> q = from n in this.nwDataSet1.Orders 
        //                                                              where !n.IsShippedDateNull() && n.OrderDate.Year.ToString() == this.comboBox1.Text
        //                                                              select n;
        //        dataGridView1.DataSource = q.ToList();
        //    }
        //}



        int X = 0;//X為忽略比數
        private void button12_Click(object sender, EventArgs e)
        {//todu：上X筆
            lblMaster.Text = "Products 資料";
            lblDetails.Text = "";
            #region
            //int a;
            //if (int.TryParse(textBox1.Text, out a))
            //{
            //    if(X*a< this.nwDataSet1.Products.Rows.Count && X*a >=0)
            //    {
            //        X--;
            //        if (X < 0)
            //        {
            //            X = 0;
            //        }
            //        var q = from n in this.nwDataSet1.Products select n;
            //        var w = q.Skip(X * a).Take(a);
            //        this.dataGridView1.DataSource = w.ToList();
            //    }
            //}
            #endregion
            int a;
            if (int.TryParse(textBox1.Text, out a))
            {
                X=X - a;
                if (X < 0)
                {
                    X = 0;
                }
                var q = from n in this.nwDataSet1.Products select n;
                var w = q.Skip(X).Take(a);
                this.dataGridView1.DataSource = w.ToList();
            }
                label6.Text = X.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {//todu：下X筆
            lblMaster.Text = "Products 資料";
            lblDetails.Text = "";
            int a;
            if(int.TryParse(textBox1.Text, out a))
            {
                #region
                //if (X * a < this.nwDataSet1.Products.Rows.Count && X * a >= 0)
                //{
                //    X++;
                //    if(X * a > this.nwDataSet1.Products.Rows.Count)
                //    {
                //        X=X - 1;
                //    }
                //    var q = from n in this.nwDataSet1.Products select n;
                //    var w = q.Skip(X * a).Take(a);
                //    this.dataGridView1.DataSource = w.ToList();
                //}
                //else if (X*a == 0)
                //{
                //    var q = from n in this.nwDataSet1.Products select n;
                //    var w = q.Skip(X * a).Take(a);
                //    this.dataGridView1.DataSource = w.ToList();
                //    X++;
                //}
                #endregion

                //var s = (from p in nwDataSet1.Products
                //        select p).Distinct();

                //int i = this.nwDataSet1.Products.Select(x => x.ProductID).Count();

                X = X + a;
                if (X > this.nwDataSet1.Products.Count)
                {
                    X = this.nwDataSet1.Products.Count;
                    return;
                }
                var q = from n in this.nwDataSet1.Products select n;
                var w = q.Skip(X).Take(a);
                this.dataGridView1.DataSource = w.ToList();


            }


            label6.Text = X.ToString();
            //Distinct()
        }
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {//todo：dataGridView2取得資料
            if (e.RowIndex >= 0)
            {
                var q = from n in this.nwDataSet1.Order_Details
                              where n.OrderID == (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value
                              select n;
                this.dataGridView2.DataSource = q.ToList();
            }
        }
    }
}


//總比數 a
//忽略Skip a
