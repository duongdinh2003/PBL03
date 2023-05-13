using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public dynamic drawChartRevenue_DAL()
        {
            using (var db = new PBL3Entities1())
            {
                var data = db.Revenues.Select(p => new { p.RevenueInDate, p.TotalInDate }).OrderBy(p => p.RevenueInDate).ToList();
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
    }
}
