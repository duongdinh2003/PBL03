using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03.DAL.LichLamViec
{
    internal class Schedule_DAL
    {
        PBL3Entities1 db;
        private static Schedule_DAL _Instance;
        public static Schedule_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Schedule_DAL();
                }
                return _Instance;
            }
        }
        public Schedule_DAL()
        {
            db = new PBL3Entities1();
        }
        public dynamic ShowSchedule_DAL()
        {
            var query = db.WorkSchedules
                .Join(db.Employees, p => p.IDEmployee, c => c.ID_Employee, (p, c) => new { WorkSchedule = p, Employee = c })
                .Select(x => new
                {
                    x.WorkSchedule.ID_Schedule,
                    x.Employee.Name_Employee,
                    x.WorkSchedule.ShiftWork.NameShift,
                    x.WorkSchedule.DateWork,
                    x.WorkSchedule.Note
                })
                .ToList();
            return query;
        }
        public dynamic SearchSchedule(string name, string shift)
        {
            var query = db.WorkSchedules
                .Join(db.Employees, p => p.IDEmployee, c => c.ID_Employee, (p, c) => new { WorkSchedule = p, Employee = c })
                .Where(x => x.Employee.Name_Employee.Contains(name) && x.WorkSchedule.ShiftWork.NameShift == shift)
                .Select(x => new
                {
                    x.WorkSchedule.ID_Schedule,
                    x.Employee.Name_Employee,
                    x.WorkSchedule.ShiftWork.NameShift,
                    x.WorkSchedule.DateWork,
                    x.WorkSchedule.Note
                })
                .ToList();
            return query;
        }
        public dynamic ShowAllScheduleOfEPL(string name)
        {
            var query = db.WorkSchedules
                .Join(db.Employees, p => p.IDEmployee, c => c.ID_Employee, (p, c) => new { WorkSchedule = p, Employee = c })
                .Where(x => x.Employee.Name_Employee == name)
                .Select(x => new
                {
                    x.WorkSchedule.ID_Schedule,
                    x.Employee.Name_Employee,
                    x.WorkSchedule.ShiftWork.NameShift,
                    x.WorkSchedule.DateWork,
                    x.WorkSchedule.Note
                })
                .ToList();
            return query;
        }
        //public void GetScheduleFollowEPL(string epl, RichTextBox rtb)
        //{
        //    var query = db.WorkSchedules
        //        .Join(db.ShiftWorks, p => p.IDShift, c => c.ID_Shift, (p, c) => new { WorkSchedule = p, ShiftWork = c })
        //        .Where(x => x.WorkSchedule.IDEmployee == epl)
        //        .Select(x => new
        //        {
        //            x.WorkSchedule.IDEmployee,
        //            x.ShiftWork.NameShift,
        //            x.WorkSchedule.DateWork,
        //            x.WorkSchedule.Note,
        //        })
        //        .ToList();
        //    if (query.Any())
        //    {
        //        foreach (var item in query)
        //        {
        //            rtb.AppendText(" - " + item.NameShift.PadRight(10) + item.DateWork.ToShortDateString() + " - " + item.Note + "\n");
        //        }
        //    }
        //    else
        //    {
        //        rtb.Text = "Hôm nay không có lịch làm việc";
        //    }
        //}
        public List<string> GetScheduleFollowEPL(string epl)
        {
            List<string> list = new List<string>();
            var query = db.WorkSchedules
                .Join(db.ShiftWorks, p => p.IDShift, c => c.ID_Shift, (p, c) => new { WorkSchedule = p, ShiftWork = c })
                .Where(x => x.WorkSchedule.IDEmployee == epl)
                .Select(x => new
                {
                    x.WorkSchedule.IDEmployee,
                    x.ShiftWork.NameShift,
                    x.WorkSchedule.DateWork,
                    x.WorkSchedule.Note,
                })
                .ToList();
            foreach (var i in query)
            {
                list.Add(" - " + i.NameShift + ", " + i.DateWork.ToString("dd/MM/yyyy") + ", " + i.Note + "\n");
            }
            return list;
        }
        public string GetIDEmployee(string acc)
        {
            var query = db.Employees.FirstOrDefault(p => p.Acc == acc);
            return query.ID_Employee;
        }
        public void AddSchedule(int id, string idepl, int idshift, DateTime dt, string note)
        {
            WorkSchedule temp = new WorkSchedule
            {
                ID_Schedule = id,
                IDEmployee = idepl,
                IDShift = idshift,
                DateWork = dt,
                Note = note
            };
            db.WorkSchedules.Add(temp);
            db.SaveChanges();
        }
        public void EditSchedule(int id, string idepl, int idshift, DateTime dt, string note)
        {
            var query = db.WorkSchedules.Find(id);
            query.IDEmployee = idepl;
            query.IDShift = idshift;
            query.DateWork = dt;
            query.Note = note;
            db.SaveChanges();
        }
        public void DeleteSchedule(int id)
        {
            var query = db.WorkSchedules.FirstOrDefault(p => p.ID_Schedule == id);
            db.WorkSchedules.Remove(query);
            db.SaveChanges();
        }
        public List<ShiftWork> GetAllShift()
        {
            var query = db.ShiftWorks.ToList();
            return query;
        }
        public string GetIDEmployeeByName(string name)
        {
            var query = db.Employees.FirstOrDefault(p => p.Name_Employee == name);
            if (query != null)
            {
                return query.ID_Employee;
            }
            return null;
        }
        public int GetIDShift(string name)
        {
            var query = db.ShiftWorks.FirstOrDefault(p => p.NameShift == name);
            return query.ID_Shift;
        }
    }
}
