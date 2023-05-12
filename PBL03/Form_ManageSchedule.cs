using PBL03.BLL.LichLamViec;
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
    public partial class Form_ManageSchedule : Form
    {
        public Form_ManageSchedule()
        {
            InitializeComponent();
            ShowSchedule();
        }
        private void ShowSchedule()
        {
            dgvWorkSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWorkSchedule.DataSource = Schedule_BLL.Instance.ShowSchedule();
            dgvWorkSchedule.Columns["ID_Schedule"].HeaderText = "ID";
            dgvWorkSchedule.Columns["Name_Employee"].HeaderText = "Tên nhân viên";
            dgvWorkSchedule.Columns["NameShift"].HeaderText = "Ca";
            dgvWorkSchedule.Columns["DateWork"].HeaderText = "Ngày làm";
            dgvWorkSchedule.Columns["Note"].HeaderText = "Ghi chú";
            dgvWorkSchedule.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form_EditSchedule fe = new Form_EditSchedule();
            fe.Show();
            fe.pass += new Form_EditSchedule.MyDele(ShowSchedule);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form_EditSchedule fe = new Form_EditSchedule();
            if (dgvWorkSchedule.SelectedRows.Count > 0)
            {
                fe.txtIDSchedule.Enabled = false;
                fe.txtIDSchedule.Text = dgvWorkSchedule.SelectedRows[0].Cells["ID_Schedule"].Value.ToString();
                fe.txtNameEmployee.Text = dgvWorkSchedule.SelectedRows[0].Cells["Name_Employee"].Value.ToString();
                fe.cbbShiftWork.Text = dgvWorkSchedule.SelectedRows[0].Cells["NameShift"].Value.ToString();
                fe.dtpickerDateWork.Value = Convert.ToDateTime(dgvWorkSchedule.SelectedRows[0].Cells["DateWork"].Value.ToString());
                fe.rtbNote.Text = dgvWorkSchedule.SelectedRows[0].Cells["Note"].Value != null ? dgvWorkSchedule.SelectedRows[0].Cells["Note"].Value.ToString() : "";
                fe.Show();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hàng để chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            fe.pass += new Form_EditSchedule.MyDele(ShowSchedule);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvWorkSchedule.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa lịch này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvWorkSchedule.SelectedRows[0].Cells["ID_Schedule"].Value.ToString());
                    Schedule_BLL.Instance.DeleteSchedule(id);
                    ShowSchedule();
                }
            }
        }
    }
}
