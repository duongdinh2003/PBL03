using PBL03.DAL.Quan_Ly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL03.BLL.Quan_Ly
{
    internal class Manager_BLL
    {
        private static Manager_BLL db;
        public static Manager_BLL Instance
        {
            get
            {
                if (db == null)
                {
                    db = new Manager_BLL();
                }

                return db;
            }
        }

        public dynamic Show()
        {
            return Manager_DAL.Instance.Show();
        }

        public bool CheckExistedIDEmployee(string id)
        {
            return Manager_DAL.Instance.CheckExistedIDEmployee(id);
        }

        public bool CheckExistedUsername(string username)
        {
            return Manager_DAL.Instance.CheckExistedUsername(username);
        }

        public void Add(string Id, string name, string phone, string address, float salary, string Username, string Password)
        {
            Manager_DAL.Instance.add(Id, name, phone, address, salary, Username, Password);
        }

        public void Edit(string Id, string Name, string PhoneNumber, string Address, float Salary, string User)
        {
            Manager_DAL.Instance.Edit(Id, Name, PhoneNumber, Address, Salary, User);
        }

        public void Delete(string id, string User)
        {
            Manager_DAL.Instance.Delete(id, User);
        }
    }
}
