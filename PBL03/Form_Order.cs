using PBL03.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03
{
    public partial class Form_Order : Form
    {
        private OrderFood_BLL bll;
        private Bill_BLL bill;
        private Change_StatusTable_BLL statusTable;
        public Form_Order()
        {
            InitializeComponent();
            this.AutoScroll = false;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bll = new OrderFood_BLL();
            bill = new Bill_BLL();
            statusTable = new Change_StatusTable_BLL();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            flowLayout_Food.Controls.Clear();
            pnStast.Height = btnFood.Height;
            pnStast.Top = btnFood.Top;
            bll.getFood_BLL(flowLayout_Food);
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            //if (tbSearch.Text == "")
            //{
            //    tbSearch.Text = "Search for menu";
            //    tbSearch.ForeColor = Color.DimGray;
            //}
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            //if (tbSearch.Text == "Search for menu")
            //{
            //    tbSearch.Text = "";
            //    tbSearch.ForeColor = Color.DimGray;
            //}
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDrink_Click(object sender, EventArgs e)
        {
            flowLayout_Food.Controls.Clear();
            pnStast.Height = btnDrink.Height;
            pnStast.Top = btnDrink.Top;
            bll.getDrink_BLL(flowLayout_Food);
        }

        private void btnCream_Click(object sender, EventArgs e)
        {
            flowLayout_Food.Controls.Clear();
            pnStast.Height = btnCream.Height;
            pnStast.Top = btnCream.Top;
            bll.getCreams_BLL(flowLayout_Food);
        }

        private void btnSubtotal_Click(object sender, EventArgs e)
        {
            double subtotal = 0;
            double total = 0;
            int kh = Convert.ToInt32(lbNumberCustomer.Text);
            if (ckbVoucher.Checked)
            {
                if (kh >= 5 && kh <= 10)
                {
                    lbVoucher.Text = "5 %";
                }
                else if (kh > 10)
                {
                    lbVoucher.Text = "10 %";
                }
                else if (kh < 5)
                {
                    lbVoucher.Text = "0 %";
                }    
            }
            else
            {
                lbVoucher.Text = "0 %";
            }    
            foreach (UserControl_Order uo in flowLayout_Order.Controls)
            {
                string t = uo.lbPrice.Text;
                int endIndex = t.IndexOf(" ");
                string st = t.Substring(0, endIndex);
                subtotal += Convert.ToDouble(st) * (double)uo.numericquantity.Value;
            }
            string vc = lbVoucher.Text;
            int percent = vc.IndexOf(" ");
            string voucher = vc.Substring(0, percent);
            total = subtotal - subtotal * Convert.ToDouble(voucher) / 100;
            lbSubtotal.Text = subtotal.ToString() + " VND";
            lbTotal.Text = total.ToString() + " VND";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                DateTime dt = DateTime.Now;
                string t = lbSubtotal.Text;
                int endIndex = t.IndexOf(" ");
                string st = t.Substring(0, endIndex);
                float sub = Convert.ToSingle(st);
                bll.orderMeal_BLL(flowLayout_Order);
                bill.addBill_BLL(dt, lbTable.Text, sub);
                MessageBox.Show("Đã lưu order vào hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DateTime dt = DateTime.Now;
                string t = lbSubtotal.Text;
                int endIndex = t.IndexOf(" ");
                string st = t.Substring(0, endIndex);
                float sub = Convert.ToSingle(st);
                bll.updateMeal_BLL(flowLayout_Order, lbTable.Text);
                bill.updateBill_BLL(dt, lbTable.Text, sub);
                MessageBox.Show("Đã cập nhật order vào hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            if (ckbVoucher.Checked)
            {
                DateTime dt = DateTime.Now;
                string t = lbSubtotal.Text;
                int endIndex = t.IndexOf(" ");
                string st = t.Substring(0, endIndex);
                float sub = Convert.ToSingle(st);
                float change = 0;
                int people = Convert.ToInt32(lbNumberCustomer.Text);
                if (people >= 5 && people <= 10)
                {
                    change = (float)(sub * 0.05 + 50000);
                }
                else if (people > 10)
                {
                    change = (float)(sub * 0.1 + 50000);
                }
                else if (people < 5)
                {
                    change = 50000;
                }
                bill.addBillHistoryWithDC_BLL(lbTable.Text, dt, sub, sub + 50000, change, people);
                bill.payBill_BLL(dt, lbTable.Text);
                bll.removeOrder_BLL(lbTable.Text);
                statusTable.refreshTable_BLL(lbTable.Text);
                Form_StatusTable ftb = (Form_StatusTable)Application.OpenForms["Form_StatusTable"];
                ftb.setColorTable();
                MessageBox.Show("Đã thanh toán hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                DateTime dt = DateTime.Now;
                string t = lbSubtotal.Text;
                int endIndex = t.IndexOf(" ");
                string st = t.Substring(0, endIndex);
                float sub = Convert.ToSingle(st);
                int people = Convert.ToInt32(lbNumberCustomer.Text);
                bill.addBillHistoryWithoutDC_BLL(lbTable.Text, dt, sub, sub + 50000, "KM003", 50000, people);
                bill.payBill_BLL(dt, lbTable.Text);
                bll.removeOrder_BLL(lbTable.Text);
                statusTable.refreshTable_BLL(lbTable.Text);
                Form_StatusTable ftb = (Form_StatusTable)Application.OpenForms["Form_StatusTable"];
                ftb.setColorTable();
                MessageBox.Show("Đã thanh toán hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flowLayout_Food.Controls.Clear();
            bll.getFoodBySearch_BLL(flowLayout_Food, tbSearch.Text);
        }
    }
}
