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
        public void showRevenue_DAL(DataGridView dgv)
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.Revenues.ToList();
                dgv.DataSource = query;
            }    
        }
    }
}
