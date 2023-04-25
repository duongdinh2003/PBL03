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
    }
}
