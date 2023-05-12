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
    public partial class Form_ViewSchedule : Form
    {
        public Form_ViewSchedule()
        {
            InitializeComponent();
        }

        private void Form_ViewSchedule_Load(object sender, EventArgs e)
        {
            ShowSchedule();
        }
        private void ShowSchedule()
        {
            FormMain fm = (FormMain)Application.OpenForms["FormMain"];
            string id = Schedule_BLL.Instance.GetIDEmployee(fm.lbNameUser.Text);
            //    var schedule = Schedule_BLL.Instance.GetScheduleFollowEPL(id);
            if (Schedule_BLL.Instance.GetScheduleFollowEPL(id).Count == 0)
            {
                rtbSchedule.AppendText("Hôm nay không có lịch làm việc");
            }
            else
            {
                foreach (var item in Schedule_BLL.Instance.GetScheduleFollowEPL(id))
                {
                    rtbSchedule.AppendText(item);
                }
            }
        }    
    }
}
