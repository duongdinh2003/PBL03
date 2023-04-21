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
        public UserControl_Food()
        {
            InitializeComponent();
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
        }
    }
}
