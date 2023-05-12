using PBL03.BLL.ThuNgan;
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
    public partial class FormChangePass : Form
    {
        public FormChangePass()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string hasspassword = BCrypt.Net.BCrypt.HashPassword(tbOld.Text);

            if (BCrypt.Net.BCrypt.Verify(tbOld.Text, Cashier_BLL.Instance.getPassword(tbUser.Text)))
            {
                if (tbNewpass.Text == "" || tbConfirm.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập mật khẩu mới thì mới thay đổi được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (tbNewpass.Text == tbConfirm.Text)
                {
                    if ((MessageBox.Show("Bạn có muốn thay đổi mật khẩu không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        string hasspassword2 = BCrypt.Net.BCrypt.HashPassword(tbConfirm.Text);
                        Cashier_BLL.Instance.ChangePassword(tbUser.Text, hasspassword2);
                        MessageBox.Show("Thay đổi mật khẩu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }

                }
                else
                {
                    MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không giống nhau !");
                }
            }
            else
            {
                MessageBox.Show("Bạn nhập sai mật khẩu !");
            }
        }

        private void tbNewpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
