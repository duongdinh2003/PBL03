﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03.DAL
{
    public class OrderFood_DAL
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
        public string getIDFood(string name)
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.Foods.FirstOrDefault(p => p.NameFood == name);
                if (query != null)
                {
                    return query.ID_Food;
                }
                return null;
            }    
        }
        public void orderMeal_DAL(FlowLayoutPanel flowLayoutPanel)
        {
            using (var db = new PBL3Entities1())
            {
                //var query = from p in db.OrderTables
                //            join c in db.Foods on p.IDFood equals c.ID_Food
                //            where p.IDTable == tb
                //            select new
                //            {
                //                p.ID_Order,
                //                c.NameFood,
                //                p.Quantity,
                //                p.IDTable,
                //                c.Price
                //            };
                //var order = db.OrderTables
                //    .Join(db.Foods, p => p.IDFood, c => c.ID_Food, (p, c) => new { OrderTable = p, Food = c })
                //    .Where(x => x.OrderTable.IDTable == tb)
                //    .Select(x => new
                //    {
                //        x.OrderTable.ID_Order,
                //        x.Food.NameFood,
                //        x.OrderTable.Quantity,
                //        x.OrderTable.IDTable,
                //        x.Food.Price
                //    }).ToList();
                //foreach (var item in order)
                //{
                //    UserControl_Order uo = new UserControl_Order();
                //    uo.lbFood.Text = item.NameFood.ToString();
                //    uo.lbNameTable.Text = item.IDTable.ToString();
                //    uo.lbPrice.Text = item.Price.ToString() + " VND";
                //    uo.numericquantity.Text = item.Quantity.ToString();
                //    flowLayoutPanel.Controls.Add(uo);
                //}
                int count = 0;
                foreach (UserControl_Order uo in flowLayoutPanel.Controls)
                {
                    count++;
                    OrderTable temp = new OrderTable
                    {
                        ID_Order = uo.lbNameTable.Text + count,
                        IDFood = getIDFood(uo.lbFood.Text),
                        Quantity = (int)uo.numericquantity.Value,
                        IDTable = uo.lbNameTable.Text
                    };
                    db.OrderTables.Add(temp);
                    db.SaveChanges();
                }
            }
        }
        public void Showorder_DAL(string tb, FlowLayoutPanel flowLayoutPanel)
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.OrderTables
                    .Join(db.Foods, p => p.IDFood, c => c.ID_Food, (p, c) => new { OrderTable = p, Food = c })
                    .Where(x => x.OrderTable.IDTable == tb)
                    .Select(x => new
                    {
                        x.OrderTable.ID_Order,
                        x.Food.NameFood,
                        x.OrderTable.Quantity,
                        x.OrderTable.IDTable,
                        x.Food.Price
                    }).ToList();
                foreach (var item in query)
                {
                    UserControl_Order uo = new UserControl_Order();
                    uo.lbFood.Text = item.NameFood;
                    uo.lbNameTable.Text = item.IDTable;
                    uo.lbPrice.Text = item.Price.ToString() + " VND";
                    uo.numericquantity.Value = item.Quantity;
                    flowLayoutPanel.Controls.Add(uo);
                }    
            }    
        }
        public int getNumberOfCustomers_DAL(string tb)
        {
            using (var db = new PBL3Entities1())
            {
                var query = db.TableFoods.FirstOrDefault(p => p.ID_Table == tb);
                return query.Capacity;
            }
        }    
    }
}
