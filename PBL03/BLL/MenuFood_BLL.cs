using PBL03.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03.BLL
{
    public class MenuFood_BLL
    {
        private MenuFood_DAL dal;
        public MenuFood_BLL()
        {
            dal = new MenuFood_DAL();
        }
        public void getFoodInfor(FlowLayoutPanel flowLayoutPanel)
        {
            dal.getFoodInfor(flowLayoutPanel);
        }
        public void getDrinkInfor(FlowLayoutPanel flowLayoutPanel)
        {
            dal.getDrinkInfor(flowLayoutPanel);
        }
        public void getCreamsInfor(FlowLayoutPanel flowLayoutPanel)
        {
            dal.getCreamsInfor(flowLayoutPanel);
        }
    }
}
