using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03.DAL
{
    public class MenuFood_DAL
    {
        //private static Menu_DAL instance;
        //public static Menu_DAL Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //            instance = new Menu_DAL();
        //        return instance;
        //    }
        //}

        public void getFoodInfor(FlowLayoutPanel flowLayoutPanel)
        {
            using (var db = new PBL3Entities1())
            {
                var data = db.Foods.Where(p => p.IDCategory == "FD").Select(p => new
                {
                    p.NameFood,
                    p.QuantityFood,
                    p.Price
                }).ToList();
                int stt = 0;
                foreach (var item in data)
                {
                    // Tạo một đối tượng UserControl_Menu mới
                    UserControl_Menu uf = new UserControl_Menu();

                    // Truyền giá trị cho các label của user control
                    uf.STT.Text = (++stt).ToString();
                    uf.Soluong.Text = item.QuantityFood.ToString();
                    uf.Name_Food.Text = item.NameFood.ToString();
                    uf.Price.Text = item.Price.ToString() + " VND";

                    

                    // Thêm user control vào FlowLayoutPanel
                    flowLayoutPanel.Controls.Add(uf);
                }
            }
        }
        public void getDrinkInfor(FlowLayoutPanel flowLayoutPanel)
        {
            using (var db = new PBL3Entities1())
            {
                var data = db.Foods.Where(p => p.IDCategory == "DR").Select(p => new
                {
                    p.NameFood,
                    p.QuantityFood,
                    p.Price
                }).ToList();
                int stt = 0;
                foreach (var item in data)
                {
                    // Tạo một đối tượng UserControl_Menu mới
                    UserControl_Menu uf = new UserControl_Menu();

                    // Truyền giá trị cho các label của user control
                    uf.STT.Text = (++stt).ToString();
                    uf.Soluong.Text = item.QuantityFood.ToString();
                    uf.Name_Food.Text = item.NameFood.ToString();
                    uf.Price.Text = item.Price.ToString() + " VND";



                    // Thêm user control vào FlowLayoutPanel
                    flowLayoutPanel.Controls.Add(uf);
                }
            }
        }
        public void getCreamsInfor(FlowLayoutPanel flowLayoutPanel)
        {
            using (var db = new PBL3Entities1())
            {
                var data = db.Foods.Where(p => p.IDCategory == "CR").Select(p => new
                {
                    p.NameFood,
                    p.QuantityFood,
                    p.Price
                }).ToList();
                int stt = 0;
                foreach (var item in data)
                {
                    // Tạo một đối tượng UserControl_Menu mới
                    UserControl_Menu uf = new UserControl_Menu();

                    // Truyền giá trị cho các label của user control
                    uf.STT.Text = (++stt).ToString();
                    uf.Soluong.Text = item.QuantityFood.ToString();
                    uf.Name_Food.Text = item.NameFood.ToString();
                    uf.Price.Text = item.Price.ToString() + " VND";

                    // Thêm user control vào FlowLayoutPanel
                    flowLayoutPanel.Controls.Add(uf);
                }
            }
        }
        public dynamic GetFirstFood()
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.Foods
                    .Take(5)
                    .Select(p => new { p.ID_Food, p.NameFood, p.Price, p.QuantityFood })
                    .ToList();
                return query;
            }
        }
        public dynamic GetNextFood(int row)
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.Foods
                    .OrderBy(p => p.ID_Food)
                    .Skip(row)
                    .Take(5)
                    .Select(p => new { p.ID_Food, p.NameFood, p.Price, p.QuantityFood })
                    .ToList();
                return query;
            }
        }
        public dynamic GetPreviousFood(int row)
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.Foods
                    .OrderBy(p => p.ID_Food)
                    .Skip(-row)
                    .Take(5)
                    .Select(p => new { p.ID_Food, p.NameFood, p.Price, p.QuantityFood })
                    .ToList();
                return query;
            }
        }
        public int CountRow()
        {
            using (var db = new PBL3Entities1())
            {
                var count = db.Foods.Count();
                return count;
            }
        }
        public string GetID_FoodCategory(string name)
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.FoodCategories.FirstOrDefault(p => p.NameCategory == name);
                return query.ID_Category;
            }
        }
        public void AddFood(string id, string name, float price, string idCategory, string picture)
        {
            using (var db = new PBL3Entities1())
            {
                Food temp = new Food
                {
                    ID_Food = id,
                    NameFood = name,
                    Price = price,
                    StatusFood = true,
                    IDCategory = idCategory,
                    QuantityFood = 200,
                    PictureFood = picture
                };
                db.Foods.Add(temp);
                db.SaveChanges();
            }
        }
        public void EditFood(string id, string name, float price, bool tt, string idCategory, int quantity, string picture)
        {
            using (var db = new PBL3Entities1())
            {
                var food = db.Foods.Find(id);
                food.NameFood = name;
                food.Price = price;
                food.StatusFood = tt;
                food.IDCategory = idCategory;
                food.QuantityFood = quantity;
                food.PictureFood = picture;
                db.SaveChanges();
            }
        }
        public List<FoodCategory> GetAllCategory()
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.FoodCategories.ToList();
                return query;
            }
        }
        public bool CheckExistedIDFood(string id)
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.Foods.Find(id);
                if (query == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
