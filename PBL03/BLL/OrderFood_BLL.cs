﻿using PBL03.DAL;
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
        public void orderMeal_BLL(FlowLayoutPanel flowPanel)
        {
            dal.orderMeal_DAL(flowPanel);
        }
        public void Showorder_BLL(string tb, FlowLayoutPanel flowLayoutPanel)
        {
            dal.Showorder_DAL(tb, flowLayoutPanel);
        }
        public int getNumberOfCustomers_BLL(string tb)
        {
            return dal.getNumberOfCustomers_DAL(tb);
        }
    }
}
