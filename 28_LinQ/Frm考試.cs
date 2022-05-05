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
using System.Windows.Forms.DataVisualization.Charting;

namespace LinqLabs
{
    public partial class Frm考試 : Form
    {
        public Frm考試()
        {
            InitializeComponent();

            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 90, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 40, Gender = "Female" },
                                            new Student{ Name = "ggg", Class = "CS_103", Chi = 90, Eng = 60, Math = 70, Gender = "Male" },
                                            new Student{ Name = "hhh", Class = "CS_101", Chi = 90, Eng = 90, Math = 90, Gender = "Female" },
                                            new Student{ Name = "iii", Class = "CS_102", Chi = 70, Eng = 80, Math = 90, Gender = "Male" },
                                            new Student{ Name = "jjj", Class = "CS_103", Chi = 80, Eng = 80, Math = 60, Gender = "Male" },
                                            new Student{ Name = "kkk", Class = "CS_101", Chi = 30, Eng = 60, Math = 80, Gender = "Male" },
                                            new Student{ Name = "lll", Class = "CS_101", Chi = 80, Eng = 80, Math = 90, Gender = "Female" },

                                          };
        }

        List<Student> students_scores;

        NorthwindEntities dbContext = new NorthwindEntities();

        public class Student
        {
            public string Name { get; set; }
            public string Class { get;  set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get;  set; }
            public string Gender { get; set; }
        }

        int count_student = 0;
        int count_one = 0;
        int count_NWind = 0;
        private void button36_Click(object sender, EventArgs e)
        {
            //this.chart1.DataSource = null;
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					

            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學員國文英文科目成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	

            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |				
            // 數學不及格 ... 是誰 
            #endregion
            count_NWind = 0;
            count_student++;

            if (count_student == 1)
            {// 共幾個 學員成績 ?	
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("各班學生成績數");
                var q = from n in students_scores
                        group n by n.Class into g
                        select new
                        {
                            班級 = g.Key,
                            成績數 = g.Count()*3
                        };
                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "班級";
                this.chart1.Series[0].YValueMembers = "成績數";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            }
            else if (count_student == 2)
            {// 找出 前面三個 的學員所有科目成績
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("總分前三名學生國文成績");
                this.chart1.Series.Add("總分前三名學生英文成績");
                this.chart1.Series.Add("總分前三名學生數學成績");
                var q = from n in students_scores
                        orderby n.Chi+n.Eng+n.Math descending
                        select new
                        {
                            姓名 = n.Name,
                            國文 = n.Chi,
                            英文 = n.Eng,
                            數學 = n.Math
                        };
                this.chart1.DataSource = q.Take(3).ToList();
                this.chart1.Series[0].XValueMember = "姓名";
                this.chart1.Series[0].YValueMembers = "國文";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.Series[1].XValueMember = "姓名";
                this.chart1.Series[1].YValueMembers = "英文";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.Series[2].XValueMember = "姓名";
                this.chart1.Series[2].YValueMembers = "數學";
                this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            else if (count_student == 3)
            {// 找出 後面兩個 的學員所有科目成績
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("總分後二名學生國文成績");
                this.chart1.Series.Add("總分後二名學生英文成績");
                this.chart1.Series.Add("總分後二名學生數學成績");
                var q = from n in students_scores
                        orderby n.Chi + n.Eng + n.Math ascending
                        select new
                        {
                            姓名 = n.Name,
                            國文 = n.Chi,
                            英文 = n.Eng,
                            數學 = n.Math
                        };
                this.chart1.DataSource = q.Take(2).ToList();
                this.chart1.Series[0].XValueMember = "姓名";
                this.chart1.Series[0].YValueMembers = "國文";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.Series[1].XValueMember = "姓名";
                this.chart1.Series[1].YValueMembers = "英文";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.Series[2].XValueMember = "姓名";
                this.chart1.Series[2].YValueMembers = "數學";
                this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            else if (count_student == 4)
            {// 找出 Name 'aaa','bbb','ccc' 的學員國文英文科目成績
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("國文");
                this.chart1.Series.Add("英文");
                var q = from n in students_scores
                        where n.Name=="aaa" || n.Name == "bbb" || n.Name == "ccc"
                        select new
                        {
                            姓名 = n.Name,
                            國文 = n.Chi,
                            英文 = n.Eng,
                        };
                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "姓名";
                this.chart1.Series[0].YValueMembers = "國文";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.Series[1].XValueMember = "姓名";
                this.chart1.Series[1].YValueMembers = "英文";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            else if (count_student == 5)
            {// 找出學員 'bbb' 的成績
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("國文");
                this.chart1.Series.Add("英文");
                this.chart1.Series.Add("數學");
                var q = from n in students_scores
                        where n.Name == "bbb"
                        select new
                        {
                            姓名 = n.Name,
                            國文 = n.Chi,
                            英文 = n.Eng,
                            數學 = n.Math
                        };

                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "姓名";
                this.chart1.Series[0].YValueMembers = "國文";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.Series[1].XValueMember = "姓名";
                this.chart1.Series[1].YValueMembers = "英文";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.Series[2].XValueMember = "姓名";
                this.chart1.Series[2].YValueMembers = "數學";
                this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            }
            else if (count_student == 6)
            {// 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("國文");
                this.chart1.Series.Add("英文");
                this.chart1.Series.Add("數學");
                var q = from n in students_scores
                        where n.Name != "bbb"
                        select new
                        {
                            姓名 = n.Name,
                            國文 = n.Chi,
                            英文 = n.Eng,
                            數學 = n.Math
                        };
                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "姓名";
                this.chart1.Series[0].YValueMembers = "國文";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.Series[1].XValueMember = "姓名";
                this.chart1.Series[1].YValueMembers = "英文";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.Series[2].XValueMember = "姓名";
                this.chart1.Series[2].YValueMembers = "數學";
                this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            }
            else if (count_student == 7)
            {// 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("國文");
                this.chart1.Series.Add("數學");
                var q = from n in students_scores
                        where n.Name == "aaa" || n.Name == "bbb" || n.Name == "ccc"
                        select new
                        {
                            姓名 = n.Name,
                            國文 = n.Chi,
                            數學 = n.Math
                        };
                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "姓名";
                this.chart1.Series[0].YValueMembers = "國文";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.Series[1].XValueMember = "姓名";
                this.chart1.Series[1].YValueMembers = "數學";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            else if (count_student == 8)
            {// 數學不及格 ... 是誰
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("數學");
                var q = from n in students_scores
                        where n.Math < 60
                        select new
                        {
                            姓名 = n.Name,
                            數學 = n.Math
                        };
                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "姓名";
                this.chart1.Series[0].YValueMembers = "數學";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            else if (count_student == 9)
            {
                count_student = 1;
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("各班學生成績數");
                var q = from n in students_scores
                        group n by n.Class into g
                        select new
                        {
                            班級 = g.Key,
                            成績數 = g.Count() * 3
                        };
                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "班級";
                this.chart1.Series[0].YValueMembers = "成績數";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
        }
  
        private void button37_Click(object sender, EventArgs e)
        {
            count_student = 0;
            count_one++;
            if (count_one == 1)
            {//個人 sum, min, max, avg
                //var q = from n in students_scores
                        
            }
            else if (count_one == 2)
            {//各科 sum, min, max, avg
                //var q = from n in students_scores
                //        select new
                //        {

                //        };
            }
            else if (count_one == 3)
            {
                count_one = 1;
            }
        }


        private void radm()
        {
            double R_Chi, R_Eng, R_Math, R_Sum, R_Avg;
            Random Rd = new Random();
            R_Chi = Rd.Next(101);
            R_Eng = Rd.Next(101);
            R_Math = Rd.Next(101);

            R_Sum = R_Chi + R_Eng + R_Math;
            R_Avg = Math.Round(R_Sum / 3, 1);

        }
        private void button33_Click(object sender, EventArgs e)
        {
            // split=> 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 
            // print 每一群是哪幾個 ? (每一群 sort by 分數 descending)




        }

        private void button35_Click(object sender, EventArgs e)
        {
            // 統計 :　所有隨機分數出現的次數/比率; sort ascending or descending
            // 63     7.00%
            // 100    6.00%
            // 78     6.00%
            // 89     5.00%
            // 83     5.00%
            // 61     4.00%
            // 64     4.00%
            // 91     4.00%
            // 79     4.00%
            // 84     3.00%
            // 62     3.00%
            // 73     3.00%
            // 74     3.00%
            // 75     3.00%
        }

        private void button34_Click(object sender, EventArgs e)
        {
            count_student = 0;
            count_NWind++;
            if (count_NWind==1)
            {//年度最高銷售金額 年度最低銷售金額
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("年度最高銷售金額");
                this.chart1.Series.Add("年度最低銷售金額");
                var q = (from n in dbContext.Order_Details
                         group n by n.Order.OrderDate.Value.Year into g
                         select new
                         {
                             年份 = g.Key,
                             最高訂單金額 = g.GroupBy(o => o.OrderID).Select(n => n.Sum(p => p.UnitPrice * p.Quantity)).Max(),
                             最低訂單金額 = g.GroupBy(o => o.OrderID).Select(n => n.Sum(p => p.UnitPrice * p.Quantity)).Min()
                         }) ;

                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "年份";
                this.chart1.Series[0].YValueMembers = "最高訂單金額";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.DataSource = q.ToList();
                this.chart1.Series[1].XValueMember = "年份";
                this.chart1.Series[1].YValueMembers = "最低訂單金額";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            else if (count_NWind == 2)
            {// 那一年總銷售最好 ? 那一年總銷售最不好 ?
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("年銷售金額");
                var q = from n in dbContext.Order_Details
                        group n by n.Order.OrderDate.Value.Year into g
                        orderby g.Key descending
                        select new
                        {
                            年份 = g.Key,
                            年銷售金額 = g.Sum(n => n.Quantity * n.UnitPrice)
                        };
                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "年份";
                this.chart1.Series[0].YValueMembers = "年銷售金額";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
            else if (count_NWind == 3)
            {// 那一個月總銷售最好 ? 那一個月總銷售最不好 ?
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("月銷售金額");
                var q = from n in dbContext.Order_Details
                        group n by n.Order.OrderDate.Value.Month into g
                        orderby g.Key 
                        select new
                        {
                            月份 = g.Key,
                            月銷售金額 = g.Sum(n => n.Quantity * n.UnitPrice)
                        };
                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "月份";
                this.chart1.Series[0].YValueMembers = "月銷售金額";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            else if (count_NWind == 4)
            {// 每年 總銷售分析 圖
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("年銷售金額");
                var q = from n in dbContext.Order_Details
                        group n by n.Order.OrderDate.Value.Year into g
                        orderby g.Key descending
                        select new
                        {
                            年份 = g.Key,
                            年銷售金額 = g.Sum(n => n.Quantity * n.UnitPrice)
                        };
                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "年份";
                this.chart1.Series[0].YValueMembers = "年銷售金額";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            else if (count_NWind == 5)
            {// 每月 總銷售分析 圖
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("月銷售金額");
                var q = from n in dbContext.Order_Details.AsEnumerable()
                        group n by n.Order.OrderDate.Value.ToString("yyyy-MM") into g
                        orderby g.Key 
                        select new
                        {
                            月份 = g.Key,
                            月銷售金額 = g.Sum(n => n.Quantity * n.UnitPrice)
                        };
                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "月份";
                this.chart1.Series[0].YValueMembers = "月銷售金額";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            }
            else if (count_NWind == 6)
            {
                count_NWind = 1;
                this.chart1.DataSource = null;
                this.chart1.Series.Clear();
                this.chart1.Series.Add("年度最高銷售金額");
                this.chart1.Series.Add("年度最低銷售金額");
                var q = (from n in dbContext.Order_Details
                         group n by n.Order.OrderDate.Value.Year into g
                         select new
                         {
                             年份 = g.Key,
                             最高訂單金額 = g.GroupBy(o => o.OrderID).Select(n => n.Sum(p => p.UnitPrice * p.Quantity)).Max(),
                             最低訂單金額 = g.GroupBy(o => o.OrderID).Select(n => n.Sum(p => p.UnitPrice * p.Quantity)).Min()
                         });

                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "年份";
                this.chart1.Series[0].YValueMembers = "最高訂單金額";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                this.chart1.DataSource = q.ToList();
                this.chart1.Series[1].XValueMember = "年份";
                this.chart1.Series[1].YValueMembers = "最低訂單金額";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
