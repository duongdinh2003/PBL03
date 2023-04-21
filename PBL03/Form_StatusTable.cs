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
    public partial class Form_StatusTable : Form
    {
        Change_StatusTable_BLL bll;
        public Form_StatusTable()
        {
            InitializeComponent();
            bll = new Change_StatusTable_BLL();
        }


        private void Button_StatusTable_Click(object sender, EventArgs e)
        {
            Guna2TileButton btn = (Guna2TileButton)sender;
            if (btn.FillColor != Color.Red)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xác nhận chọn bàn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    btn.FillColor = Color.Red;
                    Change_StatusTable_BLL bll = new Change_StatusTable_BLL();
                    bll.changeStatus(btn.Text, true, (int)numberOfPeople.Value);

                    bll.setColor_Table(flowLayout_Table);
                    Form_Order ftn = new Form_Order();
                    ftn.Show();
                    Form_StatusTable_Load(null, null);
                }
            }
            else
            {
                MessageBox.Show("Bàn này đã được chọn. Vui lòng chọn bàn khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        private void setColorTable()
        {
            Change_StatusTable_BLL bll = new Change_StatusTable_BLL();
            bll.setColor_Table(flowLayout_Table);
        }

        private void Form_StatusTable_Load(object sender, EventArgs e)
        {
            setColorTable();
        }

    }
}
