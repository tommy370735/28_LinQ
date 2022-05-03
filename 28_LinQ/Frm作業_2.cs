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
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();

            this.productPhotoTableAdapter1.Fill(this.avDataSet1.ProductPhoto);
            this.comboBox2.SelectedIndex = 0;
            dateTimePicker1.Value = new DateTime(2008, 01, 01);
            dateTimePicker2.Value = new DateTime(2013, 12, 31);

            SetStart();
        }

        private void SetStart()
        {
            var q = (from n in this.avDataSet1.ProductPhoto
                     orderby n.ModifiedDate.Year
                     select n.ModifiedDate.Year).Distinct();

            this.comboBox3.DataSource = q.ToList();
        }

        private void Databinding(EnumerableRowCollection Q)
        {

            if (Q.Cast<DataRow>().ToList().Count !=0)
            {
                this.dataGridView1.DataSource = null;
                this.pictureBox1.DataBindings.Clear();
                this.bindingSource1.DataSource = Q;
                this.dataGridView1.DataSource = this.bindingSource1;
                this.pictureBox1.DataBindings.Add("Image", this.bindingSource1, "LargePhoto", true);
                lblMaster.Text = $"目前取得總計： {this.bindingSource1.Count}  筆資料。";
            }
            else
            {
                //this.dataGridView1.DataSource = null;
                this.dataGridView1.Rows.Clear();
                this.pictureBox1.DataBindings.Clear();
                lblMaster.Text = $"此查詢條件無對應資料提供。";
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            var q = from n in this.avDataSet1.ProductPhoto
                          select n;
            //this.bindingSource1.DataSource = q.ToList();
            //this.dataGridView1.DataSource = this.bindingSource1;
            //this.pictureBox1.DataBindings.Add("Image", this.bindingSource1, "LargePhoto", true);

            Databinding(q);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DateTime stard = dateTimePicker1.Value;
            //DateTime endd = dateTimePicker2.Value;
            var q = from n in this.avDataSet1.ProductPhoto
                    where n.ModifiedDate >= dateTimePicker1.Value && n.ModifiedDate <= dateTimePicker2.Value
                    orderby n.ModifiedDate
                    select n;
            //this.dataGridView1.DataSource = q.ToList();
            Databinding(q);
        }
     

        private void button5_Click(object sender, EventArgs e)
        {
            var q = this.avDataSet1.ProductPhoto.Where(n => n.ModifiedDate.Year.ToString() == comboBox3.SelectedItem.ToString());
            //this.dataGridView1.DataSource = q.ToList();
            if (q.ToList().Count != 0)
            {
                Databinding(q);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "第一季")
            {
                var q = this.avDataSet1.ProductPhoto.Where
                    (n => n.ModifiedDate.Year.ToString() == comboBox3.SelectedItem.ToString()
                    && (n.ModifiedDate.Month == 1 || n.ModifiedDate.Month == 2 || n.ModifiedDate.Month == 3));
                //this.dataGridView1.DataSource = q.ToList();
                Databinding(q);
            }
            else if(comboBox2.Text == "第二季")
            {
                var q = this.avDataSet1.ProductPhoto.Where
                    (n => n.ModifiedDate.Year.ToString() == comboBox3.SelectedItem.ToString()
                    && (n.ModifiedDate.Month == 4 || n.ModifiedDate.Month == 5 || n.ModifiedDate.Month == 6));
                //this.dataGridView1.DataSource = q.ToList();
                Databinding(q);
            }
            else if (comboBox2.Text == "第三季")
            {
                var q = this.avDataSet1.ProductPhoto.Where
                    (n => n.ModifiedDate.Year.ToString() == comboBox3.SelectedItem.ToString()
                    && (n.ModifiedDate.Month == 7 || n.ModifiedDate.Month == 8 || n.ModifiedDate.Month == 9));
                //this.dataGridView1.DataSource = q.ToList();
                Databinding(q);
            }
            else if (comboBox2.Text == "第四季")
            {
                var q = this.avDataSet1.ProductPhoto.Where
                    (n => n.ModifiedDate.Year.ToString() == comboBox3.SelectedItem.ToString()
                    && (n.ModifiedDate.Month == 10 || n.ModifiedDate.Month == 11 || n.ModifiedDate.Month == 12));
                //this.dataGridView1.DataSource = q.ToList();
                Databinding(q);
            }
            else if (comboBox2.Text == "全年度")
            {
                var q = this.avDataSet1.ProductPhoto.Where(n => n.ModifiedDate.Year.ToString() == comboBox3.SelectedItem.ToString());
                //this.dataGridView1.DataSource = q.ToList();
                Databinding(q);
            }
        }


    }
}


//public static class MyDateTime
//{
//    public static DateTime Datm(this DateTime tt, DateTime t1, DateTime t2)
//    {

//    }
//}

