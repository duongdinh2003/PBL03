using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PBL03.DAL
{
    public class Revenue_DAL
    {
        public dynamic showRevenue_DAL()
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.Revenues.OrderBy(p => p.RevenueInDate).ToList();
                return query;
            }    
        }

        public dynamic showRevenueByDay_DAL(DateTime st, DateTime et)
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.Revenues
                    .Where(p => p.RevenueInDate >= st && p.RevenueInDate <= et)
                    .OrderBy(p => p.RevenueInDate).ToList();
                return query;
            }
        }

        public dynamic drawChartRevenue_DAL()
        {
            using (var db = new PBL3Entities1())
            {
                var data = db.Revenues.Select(p => new { p.RevenueInDate, p.TotalInDate }).OrderBy(p => p.RevenueInDate).ToList();
                return data;
            }
        }
        public dynamic DrawChartRevenueByDay(DateTime st, DateTime et)
        {
            using (var db = new PBL3Entities1())
            {
                var data = db.Revenues
                    .Where(p => p.RevenueInDate >= st && p.RevenueInDate <= et)
                    .Select(p => new
                    {
                        p.RevenueInDate,
                        p.TotalInDate,
                    })
                    .OrderBy(p => p.RevenueInDate)
                    .ToList();
                return data;
            }
        }
        public void AddOrUpdateRevenue_DAL(string id, float total, int customer)
        {
            using (var db = new PBL3Entities1())
            {
                DateTime dt = DateTime.Today;
                //var query = db.Revenues.Where(p => p.RevenueInDate.Day == day && p.RevenueInDate.Month == month && p.RevenueInDate.Year == year)
                //    .FirstOrDefault();
                var date = db.Revenues.FirstOrDefault(p => p.RevenueInDate == dt);
                if (date != null)
                {
                    date.TotalInDate += total;
                    date.NumberOfBill += 1;
                    date.NumberOfCustomer += customer;
                    db.SaveChanges();
                }    
                else
                {
                    var row = new Revenue
                    {
                        ID_Revenue = id,
                        RevenueInDate = dt,
                        TotalInDate = total,
                        NumberOfBill = 1,
                        NumberOfCustomer = customer,
                    };
                    db.Revenues.Add(row);
                    db.SaveChanges();
                }    
            }
        }
        public string countRowInRevenue_DAL()
        {
            using (var db = new PBL3Entities1())
            {
                int count = db.Revenues.Count();
                count++;
                return count.ToString();
            }
        }
        public void drawColumnChart_DAL(Chart chartRevenue)
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.Revenues
                    .Where(p => p.RevenueInDate >= new DateTime(2023, 1, 1) && p.RevenueInDate <= new DateTime(2023, 12, 31))
                    .GroupBy(p => new { p.RevenueInDate.Year, p.RevenueInDate.Month })
                    .Select(c => new
                    {
                        Month = c.Key.Month,
                        Year = c.Key.Year,
                        Total = c.Sum(p => p.TotalInDate)
                    })
                    .OrderBy(c => c.Year)
                    .ThenBy(c => c.Month)
                    .ToList();
                List<float> revenues = new List<float>();
                List<string> months = new List<string>();
                foreach (var item in query)
                {
                    revenues.Add(item.Total);
                    months.Add($"Tháng {item.Month} năm {item.Year}");
                }
                chartRevenue.Series.Clear();
                chartRevenue.ChartAreas.Clear();
                ChartArea chartArea = new ChartArea();
                chartRevenue.ChartAreas.Add(chartArea);
                Series series = new Series();
                series.ChartType = SeriesChartType.Column;
                series.BorderWidth = 2;
                series.Color = Color.Blue;
                series.Name = "Doanh thu";
                series.IsValueShownAsLabel = true;

                series.Points.DataBindXY(months, revenues);

                chartRevenue.Series.Add(series);

                chartRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartRevenue.ChartAreas[0].AxisX.Interval = 1;
                chartRevenue.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

                chartRevenue.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
                chartRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "C";

                chartRevenue.Invalidate();
            }    
        }
    }
}
