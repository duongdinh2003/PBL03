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
        public void showRevenue_BLL(DataGridView dgv)
        {
            dal.showRevenue_DAL(dgv);
        }
    }
}
