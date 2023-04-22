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
    public partial class UserControl_Food : UserControl
    {
        private Form_Order f;
        private OrderFood_BLL bll;
        public UserControl_Food()
        {
            InitializeComponent();
            bll = new OrderFood_BLL();
            f = new Form_Order();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (btnSelect.Visible == true)
            {
                btnSelect.Visible = false;
            }
            else
            {
                btnSelect.Visible = true;
            }
        }

        private void UserControl_Click(object sender, EventArgs e)
        {
            if (btnSelect.Visible == true)
            {
                btnSelect.Visible = false;
            }
            else
            {
                btnSelect.Visible = true;
            }
            f.flowLayout_Order.Controls.Clear();
            OrderFood_BLL bll = new OrderFood_BLL();
            bll.orderMeal_BLL(f.flowLayout_Order, "B1");
            //UserControl_Order uo = new UserControl_Order();
            //uo.lbFood.Text = "Cá viên chiên";
            //uo.lbNameTable.Text = "B1";
            //uo.lbPrice.Text = "15000 VND";
            //uo.numericquantity.Value = 1;
            //f.flowLayout_Order.Controls.Add(uo);
        }
    }
}
