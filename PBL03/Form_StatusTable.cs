using Guna.UI2.WinForms;
using PBL03.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03
{
    public partial class Form_StatusTable : Form
    {
        private Change_StatusTable_BLL bll;
        private OrderFood_BLL order;
        public Form_StatusTable()
        {
            InitializeComponent();
            bll = new Change_StatusTable_BLL();
            order = new OrderFood_BLL();
        }


        private void Button_StatusTable_Click(object sender, EventArgs e)
        {
            //Guna2TileButton btn = (Guna2TileButton)sender;
            //if (btn.FillColor != Color.Red)
            //{
            //    if (numberOfPeople.Value != 0)
            //    {
            //        DialogResult result = MessageBox.Show("Bạn có muốn xác nhận chọn bàn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (result == DialogResult.Yes)
            //        {
            //            btn.FillColor = Color.Red;
            //            Change_StatusTable_BLL bll = new Change_StatusTable_BLL();
            //            bll.changeStatus(btn.Text, true, (int)numberOfPeople.Value);

            //            bll.setColor_Table(flowLayout_Table);
            //            Form_Order ftn = new Form_Order();
            //            ftn.lbTable.Text = btn.Text;
            //            ftn.lbNumberCustomer.Text = numberOfPeople.Value.ToString();
            //            ftn.Show();
            //            Form_StatusTable_Load(null, null);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Chưa chọn số lượng khách trong bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //else
            //{
            //    DialogResult result = MessageBox.Show("Bàn này đã được chọn. Vui lòng chọn bàn khác\nBạn có muốn gọi thêm món cho bàn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        Form_Order ftn = new Form_Order();
            //        ftn.lbTable.Text = btn.Text;
            //        ftn.lbNumberCustomer.Text = order.getNumberOfCustomers_BLL(btn.Text).ToString();
            //        ftn.btnSave.Text = "Update";
            //        ftn.Show();
            //        order.Showorder_BLL(btn.Text, ftn.flowLayout_Order);
            //    }
            //}
        }

        
        public void setColorTable()
        {
            Change_StatusTable_BLL bll = new Change_StatusTable_BLL();
            bll.setColor_Table(flowLayout_Table);
        }

        private void Form_StatusTable_Load(object sender, EventArgs e)
        {
            setColorTable();
        }

        private void Show_InfoTable_ClickMouse(object sender, MouseEventArgs e)
        {
            Ricktb_Show_InfoTable.Controls.Clear();
            Guna2TileButton btn = (Guna2TileButton)sender;
            if (e.Button == MouseButtons.Right && btn.FillColor == Color.Red)
            {
                bll.Show_in_RickTextBox_BLL(btn.Text, Ricktb_Show_InfoTable);
            }
            else
            {
                if (btn.FillColor != Color.Red)
                {
                    if (numberOfPeople.Value != 0)
                    {
                        DialogResult result = MessageBox.Show("Bạn có muốn xác nhận chọn bàn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            btn.FillColor = Color.Red;
                            Change_StatusTable_BLL bll = new Change_StatusTable_BLL();
                            bll.changeStatus(btn.Text, true, (int)numberOfPeople.Value);
                            FormMain fm = (FormMain)Application.OpenForms["FormMain"];
                            bll.setColor_Table(flowLayout_Table);
                            Form_Order ftn = new Form_Order();
                            ftn.lbTable.Text = btn.Text;
                            ftn.lbUserName.Text = fm.lbNameUser.Text;
                            ftn.lbNumberCustomer.Text = numberOfPeople.Value.ToString();
                            ftn.Show();
                            Form_StatusTable_Load(null, null);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn số lượng khách trong bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bàn này đã được chọn\nBạn có muốn gọi thêm món cho bàn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        FormMain fm = (FormMain)Application.OpenForms["FormMain"];
                        Form_Order ftn = new Form_Order();
                        ftn.lbTable.Text = btn.Text;
                        ftn.lbUserName.Text = fm.lbNameUser.Text;
                        ftn.lbNumberCustomer.Text = order.getNumberOfCustomers_BLL(btn.Text).ToString();
                        ftn.btnSave.Text = "Update";
                        ftn.Show();
                    //    order.Showorder_BLL(btn.Text, ftn.flowLayout_Order);
                        foreach (var item in order.Showorder_BLL(btn.Text))
                        {
                            UserControl_Order uo = new UserControl_Order();
                            uo.lbFood.Text = item.NameFood;
                            uo.lbNameTable.Text = item.IDTable;
                            uo.lbPrice.Text = item.Price.ToString() + " VND";
                            uo.numericquantity.Value = item.Quantity;
                            ftn.flowLayout_Order.Controls.Add(uo);
                        }
                    }
                }
            }
        }
    }
}
