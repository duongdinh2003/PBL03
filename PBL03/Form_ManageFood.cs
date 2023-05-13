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
    public partial class Form_ManageFood : Form
    {
        private MenuFood_BLL bll;
        public Form_ManageFood()
        {
            InitializeComponent();
            bll = new MenuFood_BLL();
        }

        private void ShowDGVFood()
        {
            dgvFood.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFood.DataSource = bll.GetAllFood();
            dgvFood.Columns["ID_Food"].HeaderText = "ID";
            dgvFood.Columns["NameFood"].HeaderText = "Tên món";
            dgvFood.Columns["Price"].HeaderText = "Giá";
            dgvFood.Columns["QuantityFood"].HeaderText = "Số lượng còn dư";
        }

        private void Form_ManageFood_Load(object sender, EventArgs e)
        {
            ShowDGVFood();
        }
    }
}
