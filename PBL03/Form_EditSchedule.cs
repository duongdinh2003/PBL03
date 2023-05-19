using PBL03.BLL.LichLamViec;
using PBL03.Supporter;
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
    public partial class Form_EditSchedule : Form
    {
        public delegate void MyDele();
        public MyDele pass;

        public Form_EditSchedule()
        {
            InitializeComponent();
            SetCBBShift();
        }

        private void SetCBBShift()
        {
            foreach (var item in Schedule_BLL.Instance.GetAllShift())
            {
                cbbShiftWork.Items.Add(new CBBItem
                {
                    Value = item.ID_Shift,
                    Text = item.NameShift
                });
            }    
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtIDSchedule.Enabled == true)
            {
                if (txtIDSchedule.Text == "" || txtNameEmployee.Text == "" || cbbShiftWork.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }   
                else
                {
                    int id = Convert.ToInt32(txtIDSchedule.Text);
                    string idepl = Schedule_BLL.Instance.GetIDEmployeeByName(txtNameEmployee.Text);
                    int idshift = Schedule_BLL.Instance.GetIDShift(cbbShiftWork.SelectedItem.ToString());
                    DateTime dt = Convert.ToDateTime(dtpickerDateWork.Value.ToString("yyyy/MM/dd"));
                    string note = rtbNote.Text;
                    Schedule_BLL.Instance.AddSchedule(id, idepl, idshift, dt, note);
                    pass();
                    MessageBox.Show("Thêm lịch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }    
            else
            {
                if (txtIDSchedule.Text == "" || txtNameEmployee.Text == "" || cbbShiftWork.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int id = Convert.ToInt32(txtIDSchedule.Text);
                    string idepl = Schedule_BLL.Instance.GetIDEmployeeByName(txtNameEmployee.Text);
                    int idshift = Schedule_BLL.Instance.GetIDShift(cbbShiftWork.SelectedItem.ToString());
                    DateTime dt = Convert.ToDateTime(dtpickerDateWork.Value.ToString("yyyy/MM/dd"));
                    string note = rtbNote.Text;
                    Schedule_BLL.Instance.EditSchedule(id, idepl, idshift, dt, note);
                    pass();
                    MessageBox.Show("Cập nhật lịch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }    
            }    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
