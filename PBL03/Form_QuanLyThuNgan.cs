using Guna.UI2.WinForms;
using PBL03.BLL.Quan_Ly;
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
    public partial class Form_QuanLyThuNgan : Form
    {
        public Form_QuanLyThuNgan()
        {
            InitializeComponent();
            ShowDT();
        }
        private void ShowDT()
        {
            dtgvShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvShow.DataSource = Manager_BLL.Instance.Show();
            dtgvShow.Columns["ID_Employee"].HeaderText = "ID";
            dtgvShow.Columns["Name_Employee"].HeaderText = "Tên nhân viên";
            dtgvShow.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            dtgvShow.Columns["Address_Employee"].HeaderText = "Địa chỉ";
            dtgvShow.Columns["Salary"].HeaderText = "Lương 1 giờ";
            dtgvShow.Columns["Acc"].HeaderText = "Account";
            dtgvShow.Visible = true;
        }    
        //private async void hideSubMenu()
        //{
        //    if (pnMenu.Visible && btnHomeUp.Visible)
        //    {
        //        pnMenu.Visible = false;
        //        btnHomeUp.Visible = true;
        //        btnHomeDown.Visible = false;
        //    }
        //}
        //private void showSubMenu(Panel subMenu, Guna2Button btn1, Guna2Button btn2)
        //{
        //    if (subMenu.Visible == false)
        //    {
        //        hideSubMenu();
        //        subMenu.Visible = true;
        //        btn1.Visible = false;
        //        btn2.Visible = true;
        //    }
        //    else
        //    {
        //        subMenu.Visible = false;
        //        btn1.Visible = true;
        //        btn2.Visible = false;
        //    }
        //}

        private void btnExpand_Click(object sender, EventArgs e)
        {
            //showSubMenu(pnMenu, btnHomeUp, btnHomeDown);
            pnMenu.Visible = true;
            btnHomeDown.Visible = true;
            btnHomeUp.Visible = false;
            btnExpand.Visible = false;
            btnCollapse.Visible = true;
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            pnMenu.Visible = false;
            btnHomeUp.Visible = true;
            btnExpand.Visible = true;
            btnHomeDown.Visible = false;
            btnCollapse.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dtgvShow.Visible = false;
            pnDisplayFunction.Visible = true;
            pnDisplayFunction.Controls.Clear();
            Form_Update fu = new Form_Update();
            fu.TopLevel = false;
            fu.FormBorderStyle = FormBorderStyle.None;
            fu.Dock = DockStyle.Fill;
            pnDisplayFunction.Controls.Clear();
            pnDisplayFunction.Controls.Add(fu);
            fu.Size = pnDisplayFunction.Size;
            fu.Show();
            fu.pass += new Form_Update.Mydele(ShowDT);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dtgvShow.Visible = false;
            pnDisplayFunction.Visible = true;
            pnDisplayFunction.Controls.Clear();
            Form_Update fu = new Form_Update();
            fu.TopLevel = false;
            pnDisplayFunction.Controls.Add(fu);
            fu.Size = pnDisplayFunction.Size;
            if (dtgvShow.SelectedRows.Count > 0)
            {
                fu.Show();
                fu.tbAccount.Text = dtgvShow.SelectedRows[0].Cells["Acc"].Value.ToString();
                fu.tbAccount.Enabled = false;
                fu.tbID.Text = dtgvShow.SelectedRows[0].Cells["ID_Employee"].Value.ToString();
                fu.tbID.Enabled = false;
                fu.tbPassword.Enabled = false;
                fu.tbName.Text = dtgvShow.SelectedRows[0].Cells["Name_Employee"].Value.ToString();
                fu.tbAddress.Text = dtgvShow.SelectedRows[0].Cells["Address_Employee"].Value.ToString();
                fu.tbPhone.Text = dtgvShow.SelectedRows[0].Cells["PhoneNumber"].Value.ToString();
                fu.tbSalary.Text = dtgvShow.SelectedRows[0].Cells["Salary"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hàng để chỉnh sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            fu.pass += new Form_Update.Mydele(ShowDT);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pnDisplayFunction.Visible = false;
            dtgvShow.Visible = true;
            if ((MessageBox.Show("Bạn có muốn xoá không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                Manager_BLL.Instance.Delete(dtgvShow.SelectedRows[0].Cells["Id_Employee"].Value.ToString(), dtgvShow.SelectedRows[0].Cells["Acc"].Value.ToString());
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ShowDT();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtgvShow.DataSource = Manager_BLL.Instance.Show();
        }

        private void Form_QuanLyThuNgan_Load(object sender, EventArgs e)
        {
            dtgvShow.DataSource = Manager_BLL.Instance.Show();
        }
    }
}
