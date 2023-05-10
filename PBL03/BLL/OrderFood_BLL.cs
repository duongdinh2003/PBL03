using PBL03.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03.BLL
{
    public class OrderFood_BLL
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
        //public void orderMeal_BLL(FlowLayoutPanel flowPanel)
        //{
        //    dal.orderMeal_DAL(flowPanel);
        //}
        public void orderMeal_BLL(int count, string idfood, int quantity, string idtable)
        {
            dal.orderMeal_DAL(count, idfood, quantity, idtable);
        }    
        public void subQuantityFood(string food, int quantity)
        {
            dal.subQuantityFood(food, quantity);
        }
        public bool checkExistedFood(string idfood)
        {
            return dal.checkExistedFood(idfood);
        }
        public void updateMeal_BLL(string tb, int qtt, string food)
        {
            dal.updateMeal_DAL(tb, qtt, food);
        }
        public string getIDFood(string food)
        {
            return dal.getIDFood(food);
        }
        public int countOrder(string tb)
        {
            return dal.countOrder(tb);
        }
        public dynamic Showorder_BLL(string tb)
        {
            return dal.Showorder_DAL(tb);
        }
        public int getNumberOfCustomers_BLL(string tb)
        {
            return dal.getNumberOfCustomers_DAL(tb);
        }
        //public void updateMeal_BLL(FlowLayoutPanel flowLayoutPanel, string tb)
        //{
        //    dal.updateMeal_DAL(flowLayoutPanel, tb);
        //}
        public void removeOrder_BLL(string tb)
        {
            dal.removeOrder_DAL(tb);
        }
        public dynamic getFoodBySearch_BLL(string name)
        {
            return dal.getFoodBySearch_DAL(name);
        }
    }
}
