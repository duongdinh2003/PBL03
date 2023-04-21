using System;
using System.Collections.Generic;
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
    }
}
