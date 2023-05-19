using PBL03.DAL;
using PBL03.Supporter;
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
        public dynamic GetFirstFood()
        {
            return dal.GetFirstFood();
        }    
        public dynamic GetNextFood(int row)
        {
            return dal.GetNextFood(row);
        }
        public dynamic GetPreviousFood(int row)
        {
            return dal.GetPreviousFood(row);
        }
        public int CountRow()
        {
            return dal.CountRow();
        }
        public string GetID_FoodCategory(string name)
        {
            return dal.GetID_FoodCategory(name);
        }
        public void AddFood(string id, string name, float price, string idCategory, string picture)
        {
            dal.AddFood(id, name, price, idCategory, picture);
        }
        public void EditFood(string id, string name, float price, bool tt, string idCategory, int quantity, string picture)
        {
            dal.EditFood(id, name, price, tt, idCategory, quantity, picture);
        }
        public List<CBBItem> SetCBBCategory()
        {
            List<CBBItem> list = new List<CBBItem>();
            int count = 0;
            foreach (FoodCategory i in dal.GetAllCategory())
            {
                list.Add(new CBBItem
                {
                    Value = ++count,
                    Text = i.NameCategory
                });
            }
            return list;
        }
        public bool CheckExistedIDFood(string id)
        {
            return dal.CheckExistedIDFood(id);
        }
    }
}
