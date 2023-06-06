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
    public partial class Form_Update : Form
    {
        public delegate void Mydele();
        public Mydele pass;
        public Form_Update()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbAccount.Enabled == true)
            {
                if (tbID.Text == "" || tbName.Text == "" || tbPhone.Text == "" || tbAddress.Text == "" || tbSalary.Text == "" || tbAccount.Text == "" || tbPassword.Text == "")
                {
                    MessageBox.Show("Chưa nhập đủ thông tin của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (!Manager_BLL.Instance.CheckExistedIDEmployee(tbID.Text))
                    {
                        MessageBox.Show("ID này đã tồn tại! Vui lòng nhập ID khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (!Manager_BLL.Instance.CheckExistedUsername(tbAccount.Text))
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            string hashpassword = BCrypt.Net.BCrypt.HashPassword(tbPassword.Text);
                            float salary = float.Parse(tbSalary.Text);
                            Manager_BLL.Instance.Add(tbID.Text, tbName.Text, tbPhone.Text, tbAddress.Text, salary, tbAccount.Text, hashpassword);
                            MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pass();
                            this.Dispose();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Lương nhân viên phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                if (tbName.Text == "" || tbPhone.Text == "" || tbAddress.Text == "" || tbSalary.Text == "")
                {
                    MessageBox.Show("Chưa nhập đủ thông tin nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((MessageBox.Show("Bạn có muốn sửa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        float salary = float.Parse(tbSalary.Text);
                        Manager_BLL.Instance.Edit(tbID.Text, tbName.Text, tbPhone.Text, tbAddress.Text, salary, tbAccount.Text);
                        MessageBox.Show("Chỉnh sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pass();
                        this.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lương nhân viên phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pass();
            this.Dispose();
        }
    }
}
