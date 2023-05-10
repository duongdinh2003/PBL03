using PBL03.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03.BLL
{
    public class Revenue_BLL
    {
        private Revenue_DAL dal;
        public Revenue_BLL()
        {
            dal = new Revenue_DAL();
        }
        public dynamic showRevenue_BLL()
        {
            return dal.showRevenue_DAL();
        }
        public dynamic drawChartRevenue_BLL()
        {
            return dal.drawChartRevenue_DAL();
        }
    }
}
