﻿using PBL03.BLL;
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
    public partial class Form_Revenue : Form
    {
        private Revenue_BLL bll;
        public Form_Revenue()
        {
            InitializeComponent();
            bll = new Revenue_BLL();
        }

        private void Form_Revenue_Load(object sender, EventArgs e)
        {
            //chartRevenue.Series["Doanh thu"].Points.AddXY("Dinh", 3000);
            //chartRevenue.Series["Doanh thu"].Points.AddXY("Hung", 2000);
            //chartRevenue.Series["Doanh thu"].Points.AddXY("Minh", 7000);
            //chartRevenue.Series["Doanh thu"].Points.AddXY("Nhat", 4000);
            //chartRevenue.Series["Doanh thu"].Points.AddXY("Thanh", 6000);
            using (var db = new PBL3Entities1())
            {
                var data = db.Revenues.Select(p => new { p.RevenueInDate, p.TotalInDate }).ToList();
                foreach (var item in data)
                {
                    chartRevenue.Series["Doanh thu"].Points.AddXY(item.RevenueInDate, item.TotalInDate);
                }
            }
            showRevenue();
        }
        public void showRevenue()
        {
            bll.showRevenue_BLL(dgvRevenue);
        }    
    }
}
