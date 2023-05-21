using PBL03.BLL;
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

namespace PBL03
{
    public partial class Form_Revenue : Form
    {
        private Revenue_BLL bll;
        public Form_Revenue()
        {
            InitializeComponent();
            bll = new Revenue_BLL();
        }

        public void showRevenue()
        {
            dgvRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenue.DataSource = bll.showRevenue_BLL();
            dgvRevenue.Columns["ID_Revenue"].HeaderText = "STT";
            dgvRevenue.Columns["RevenueInDate"].HeaderText = "Ngày";
            dgvRevenue.Columns["TotalInDate"].HeaderText = "Tổng trong ngày";
            dgvRevenue.Columns["NumberOfBill"].HeaderText = "SL hóa đơn";
            dgvRevenue.Columns["NumberOfCustomer"].HeaderText = "SL khách";
        }
        public void drawChartRevenue()
        {
            chartRevenue.Series.Clear();
            chartRevenue.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();
            chartRevenue.ChartAreas.Add(chartArea);
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            series.Color = Color.Blue;
            series.Name = "Doanh thu";
            series.IsValueShownAsLabel = false;

            foreach (var item in bll.drawChartRevenue_BLL())
            {
                series.Points.AddXY(item.RevenueInDate, item.TotalInDate);
            }
            

            chartRevenue.Series.Add(series);

            chartRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartRevenue.ChartAreas[0].AxisX.Interval = 1;
            chartRevenue.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            chartRevenue.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chartRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "C";

            chartRevenue.Invalidate();
            //foreach (var item in bll.drawChartRevenue_BLL())
            //{
            //    chartRevenue.Series["Doanh thu"].Points.AddXY(item.RevenueInDate, item.TotalInDate);
            //}
        }

        public void DrawChartRevenueByDay()
        {
            DateTime st = dtpickerStartDay.Value.Date;
            DateTime et = dtpickerEndDay.Value.Date;
            if (st < et)
            {
                chartRevenue.Series.Clear();
                chartRevenue.ChartAreas.Clear();
                ChartArea chartArea = new ChartArea();
                chartRevenue.ChartAreas.Add(chartArea);
                Series series = new Series();
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 2;
                series.Color = Color.Blue;
                series.Name = "Doanh thu";
                series.IsValueShownAsLabel = false;

                foreach (var item in bll.DrawChartRevenueByDay(st, et))
                {
                    series.Points.AddXY(item.RevenueInDate, item.TotalInDate);
                }


                chartRevenue.Series.Add(series);

                chartRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartRevenue.ChartAreas[0].AxisX.Interval = 1;
                chartRevenue.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

                chartRevenue.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
                chartRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "C";

                chartRevenue.Invalidate();
            }
            else
            {
                MessageBox.Show("Ngày không hợp lệ");
            }
        }

        private void Form_Revenue_Load(object sender, EventArgs e)
        {
            //chartRevenue.Series["Doanh thu"].Points.AddXY("Dinh", 3000);
            //chartRevenue.Series["Doanh thu"].Points.AddXY("Hung", 2000);
            //chartRevenue.Series["Doanh thu"].Points.AddXY("Minh", 7000);
            //chartRevenue.Series["Doanh thu"].Points.AddXY("Nhat", 4000);
            //chartRevenue.Series["Doanh thu"].Points.AddXY("Thanh", 6000);
            //using (var db = new PBL3Entities1())
            //{
            //    var data = db.Revenues.Select(p => new { p.RevenueInDate, p.TotalInDate }).ToList();
            //    foreach (var item in data)
            //    {
            //        chartRevenue.Series["Doanh thu"].Points.AddXY(item.RevenueInDate, item.TotalInDate);
            //    }
            //}
            showRevenue();
            drawChartRevenue();
        }

        private void rbtnNgay_CheckedChanged(object sender, EventArgs e)
        {
            //if (chartRevenue.Series["Doanh thu"].ChartType == SeriesChartType.Line)
            //{
            //    chartRevenue.Series["Doanh thu"].ChartType = SeriesChartType.Column;
            //}
            //    drawChartRevenue();
            DrawChartRevenueByDay();
            DateTime st = dtpickerStartDay.Value.Date;
            DateTime et = dtpickerEndDay.Value.Date;
            dgvRevenue.DataSource = bll.showRevenueByDay_BLL(st, et);
        }

        private void rbtnThang_CheckedChanged(object sender, EventArgs e)
        {
            //if (chartRevenue.Series["Doanh thu"].ChartType == SeriesChartType.Column)
            //{
            //    chartRevenue.Series["Doanh thu"].ChartType = SeriesChartType.Line;
            //}

                drawColumnChart();
        }
        private void drawColumnChart()
        {
            bll.drawColumnChart_BLL(chartRevenue);
        }


    }
}
