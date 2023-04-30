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
        public void updateBill_BLL(DateTime timein, string tb, float subtotal)
        {
            dal.updateBill_DAL(timein, tb, subtotal);
        }
        public void addBillHistoryWithDC_BLL(string tb, DateTime dt, float subtotal, float paidbyCustomer, float change, int people)
        {
            dal.addBillHistoryWithDC_DAL(tb, dt, subtotal, paidbyCustomer, change, people);
        }
        public void addBillHistoryWithoutDC_BLL(string tb, DateTime dt, float subtotal, float paidbyCustomer, string discount, float change, int people)
        {
            dal.addBillHistoryWithoutDC_DAL(tb, dt, subtotal, paidbyCustomer, discount, change, people);
        }
        public void payBill_BLL(DateTime dt, string tb)
        {
            dal.payBill_DAL(dt, tb);
        }
    }
}
