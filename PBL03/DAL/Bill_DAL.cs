using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03.DAL
{
    public class Bill_DAL
    {
        public void addBill_DAL(DateTime timein, string tb,  float subtotal)
        {
            using (var db = new PBL3Entities1())
            {
                Bill temp = new Bill
                    {
                        TimeCheckIn = timein,
                        TimeCheckOut = timein,
                        idEmployee = "TN001",
                        idTable = tb,
                        TotalMoney = subtotal,
                        statusBill = false
                    };
                db.Bills.Add(temp);
                db.SaveChanges();
            }    
        }
        public void updateBill_DAL(DateTime timein, string tb, float subtotal)
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.Bills.Where(p => p.idTable == tb).FirstOrDefault();
                if (query != null)
                {
                    var bill = db.Bills.Single(p => p.idTable == tb);
                    bill.TotalMoney = subtotal;
                }
                else
                {
                    Bill temp = new Bill
                    {
                        TimeCheckIn = timein,
                        TimeCheckOut = timein,
                        idEmployee = "TN001",
                        idTable = tb,
                        TotalMoney = subtotal,
                        statusBill = false
                    };
                    db.Bills.Add(temp);
                }    
                db.SaveChanges();
            }
        }
        public int getIDBill_DAL(string tb)
        {
            using (var db = new PBL3Entities1())
            {
                var idbill = db.Bills.Single(p => p.idTable == tb && p.statusBill == false);
                return idbill.ID_Bill;
            }
        }
        public void payBill_DAL(DateTime dt, string tb)
        {
            using (var db = new PBL3Entities1())
            {
                var bill = db.Bills.Single(p => p.idTable == tb && p.statusBill == false);
                bill.statusBill = true;
                bill.TimeCheckOut = dt;
                db.SaveChanges();
            }    
        }
        public void addBillHistory_DAL(string tb, DateTime dt, float subtotal, float paidbyCustomer, string discount, float change)
        {
            using (var db = new PBL3Entities1())
            {
                int id = getIDBill_DAL(tb);
                BillHistory bill = new BillHistory
                {
                    IDBill = id,
                    DatePay = dt,
                    TotalMoney = subtotal,
                    MoneyCustomerPay = paidbyCustomer,
                    IDDiscount = discount,
                    Exchange = change
                };
                db.BillHistories.Add(bill);
                db.SaveChanges();
            }
        }
    }
}
