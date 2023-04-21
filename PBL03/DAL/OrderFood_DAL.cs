using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03.DAL
{
    internal class OrderFood_DAL
    {
        public void getFood_DAL(FlowLayoutPanel flowLayoutPanel)
        {
            using (var db = new PBL3Entities1())
            {
                var data = db.Foods.Where(p => p.IDCategory == "FD").Select(p => new
                {
                    p.NameFood,
                    p.Price,
                    p.PictureFood
                }).ToList();
                foreach (var item in data)
                {
                    // Tạo một đối tượng UserControl_Menu mới
                    UserControl_Food uf = new UserControl_Food();

                    // Truyền giá trị cho các label của user control
                    
                    uf.lbFood.Text = item.NameFood.ToString();
                    uf.lbPrice.Text = item.Price.ToString() + " VND";
                    string imagepath = Path.Combine(Application.StartupPath, item.PictureFood.ToString()); 
                    //Image img = Image.FromFile(imagepath);
                    //uf.BackgroundImage = img;

                    byte[] imagedata = File.ReadAllBytes(imagepath);
                    using (MemoryStream ms = new MemoryStream(imagedata))
                    {
                        Image img = Image.FromStream(ms);
                        uf.BackgroundImage = img;
                    }


                    // Thêm user control vào FlowLayoutPanel
                    flowLayoutPanel.Controls.Add(uf);
                }
            }
        }
        public void getDrink_DAL(FlowLayoutPanel flowLayoutPanel)
        {
            using (var db = new PBL3Entities1())
            {
                var data = db.Foods.Where(p => p.IDCategory == "DR").Select(p => new
                {
                    p.NameFood,
                    p.Price,
                    p.PictureFood
                }).ToList();
                foreach (var item in data)
                {
                    // Tạo một đối tượng UserControl_Menu mới
                    UserControl_Food uf = new UserControl_Food();

                    // Truyền giá trị cho các label của user control

                    uf.lbFood.Text = item.NameFood.ToString();
                    uf.lbPrice.Text = item.Price.ToString() + " VND";
                    string imagepath = Path.Combine(Application.StartupPath, item.PictureFood.ToString());
                    //Image img = Image.FromFile(imagepath);
                    //uf.BackgroundImage = img;

                    byte[] imagedata = File.ReadAllBytes(imagepath);
                    using (MemoryStream ms = new MemoryStream(imagedata))
                    {
                        Image img = Image.FromStream(ms);
                        uf.BackgroundImage = img;
                    }


                    // Thêm user control vào FlowLayoutPanel
                    flowLayoutPanel.Controls.Add(uf);
                }
            }
        }
        public void getCreams_DAL(FlowLayoutPanel flowLayoutPanel)
        {
            using (var db = new PBL3Entities1())
            {
                var data = db.Foods.Where(p => p.IDCategory == "CR").Select(p => new
                {
                    p.NameFood,
                    p.Price,
                    p.PictureFood
                }).ToList();
                foreach (var item in data)
                {
                    // Tạo một đối tượng UserControl_Menu mới
                    UserControl_Food uf = new UserControl_Food();

                    // Truyền giá trị cho các label của user control

                    uf.lbFood.Text = item.NameFood.ToString();
                    uf.lbPrice.Text = item.Price.ToString() + " VND";
                    string imagepath = Path.Combine(Application.StartupPath, item.PictureFood.ToString());
                    //Image img = Image.FromFile(imagepath);
                    //uf.BackgroundImage = img;

                    byte[] imagedata = File.ReadAllBytes(imagepath);
                    using (MemoryStream ms = new MemoryStream(imagedata))
                    {
                        Image img = Image.FromStream(ms);
                        uf.BackgroundImage = img;
                    }


                    // Thêm user control vào FlowLayoutPanel
                    flowLayoutPanel.Controls.Add(uf);
                }
            }
        }
    }
}
