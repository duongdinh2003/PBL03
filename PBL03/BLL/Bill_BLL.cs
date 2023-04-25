using PBL03.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL03.BLL
{
    public class Bill_BLL
    {
        private Bill_DAL dal;
        public Bill_BLL()
        {
            dal = new Bill_DAL();
        }
        public void addBill_BLL(DateTime timein, string tb, float subtotal)
        {
            dal.addBill_DAL(timein, tb, subtotal);
        }
    }
}
