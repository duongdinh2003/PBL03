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
        private int index = 0;
        private MenuFood_BLL bll;
        public Form_ManageFood()
        {
            InitializeComponent();
            bll = new MenuFood_BLL();
        }

        private void ShowDGVFood()
        {
            dgvFood.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFood.DataSource = bll.GetNextFood(index);
            dgvFood.Columns["ID_Food"].HeaderText = "ID";
            dgvFood.Columns["NameFood"].HeaderText = "Tên món";
            dgvFood.Columns["Price"].HeaderText = "Giá";
            dgvFood.Columns["QuantityFood"].HeaderText = "Số lượng còn dư";
        }

        private void Form_ManageFood_Load(object sender, EventArgs e)
        {
            ShowDGVFood();
            SetEnableButton();
        }

        private void SetEnableButton()
        {
            btnNext.Enabled = index + 5 < bll.CountRow();
            btnPrevious.Enabled = index > 0;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            index -= 5;
            if (index < 0)
            {
                index = 0;
            }
            dgvFood.DataSource = bll.GetNextFood(index);
            SetEnableButton();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index += 5;
            dgvFood.DataSource = bll.GetNextFood(index);
            SetEnableButton();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form_EditFood fef = new Form_EditFood();
            fef.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form_EditFood fef = new Form_EditFood();
            fef.Show();
        }
    }
}
