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
        private OrderFood_BLL bll;
        public UserControl_Food()
        {
            InitializeComponent();
            bll = new OrderFood_BLL();
        }

        private void UserControl_Click(object sender, EventArgs e)
        {
            if (btnSelect.Visible == false)
            { 
                btnSelect.Visible = true;
                UserControl_Order uo = new UserControl_Order();
                Form_Order f1 = (Form_Order)Application.OpenForms["Form_Order"];
                uo.lbFood.Text = lbFood.Text;
                uo.lbNameTable.Text = f1.lbTable.Text;
                uo.lbPrice.Text = lbPrice.Text;
                uo.numericquantity.Value = 1;
                f1.flowLayout_Order.Controls.Add(uo);
            }
        }
            
    }
}
