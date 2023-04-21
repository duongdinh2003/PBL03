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
        public Form_Order()
        {
            InitializeComponent();
            this.AutoScroll = false;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bll = new OrderFood_BLL();
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
            if (tbSearch.Text == "")
            {
                tbSearch.Text = "Search for menu";
                tbSearch.ForeColor = Color.DimGray;
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text == "Search for menu")
            {
                tbSearch.Text = "";
                tbSearch.ForeColor = Color.DimGray;
            }
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
    }
}
