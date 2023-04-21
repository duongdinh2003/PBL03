using Guna.UI2.WinForms;
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
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
        }

        private void btn_Food_Click(object sender, EventArgs e)
        {
            flowLayout_Show.Controls.Clear();
            pnStas.Width = btn_Food.Width;
            pnStas.Left = btn_Food.Left;
            MenuFood_BLL bll = new MenuFood_BLL();
            bll.getFoodInfor(flowLayout_Show);
        }

        private void btn_Drink_Click(object sender, EventArgs e)
        {
            flowLayout_Show.Controls.Clear();
            pnStas.Width = btn_Drink.Width;
            pnStas.Left = btn_Drink.Left;
            MenuFood_BLL bll = new MenuFood_BLL();
            bll.getDrinkInfor(flowLayout_Show);
        }

        private void btn_Creams_Click(object sender, EventArgs e)
        {
            flowLayout_Show.Controls.Clear();
            pnStas.Width = btn_Creams.Width;
            pnStas.Left = btn_Creams.Left;
            MenuFood_BLL bll = new MenuFood_BLL();
            bll.getCreamsInfor(flowLayout_Show);
        }
    }
}
