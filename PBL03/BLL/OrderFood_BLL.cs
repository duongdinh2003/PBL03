using PBL03.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03.BLL
{
    internal class OrderFood_BLL
    {
        private OrderFood_DAL dal;
        public OrderFood_BLL()
        {
            dal = new OrderFood_DAL();
        }
        public void getFood_BLL(FlowLayoutPanel flowPanel)
        {
            dal.getFood_DAL(flowPanel);
        }
        public void getDrink_BLL(FlowLayoutPanel flowPanel)
        {
            dal.getDrink_DAL(flowPanel);
        }
        public void getCreams_BLL(FlowLayoutPanel flowPanel)
        {
            dal.getCreams_DAL(flowPanel);
        }
        public void orderMeal_BLL(FlowLayoutPanel flowPanel, string tb)
        {
            dal.orderMeal_DAL(flowPanel, tb);
        }
    }
}
