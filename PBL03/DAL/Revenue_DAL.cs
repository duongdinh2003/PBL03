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
                var query = db.Revenues.ToList();
                return query;
            }    
        }
        public dynamic drawChartRevenue_DAL()
        {
            using (var db = new PBL3Entities1())
            {
                var data = db.Revenues.Select(p => new { p.RevenueInDate, p.TotalInDate }).ToList();
                return data;
            }
        }
    }
}
