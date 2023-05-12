using PBL03.DAL.LichLamViec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03.BLL.LichLamViec
{
    internal class Schedule_BLL
    {
        private static Schedule_BLL _Instance;
        public static Schedule_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Schedule_BLL();
                }
                return _Instance;
            }
        }
        public dynamic ShowSchedule()
        {
            return Schedule_DAL.Instance.ShowSchedule_DAL();
        }
        //public void GetScheduleFollowEPL(string epl, RichTextBox rtb)
        //{
        //    Schedule_DAL.Instance.GetScheduleFollowEPL(epl, rtb);
        //}
        public List<string> GetScheduleFollowEPL(string epl)
        {
            return Schedule_DAL.Instance.GetScheduleFollowEPL(epl);
        }
        public string GetIDEmployee(string acc)
        {
            return Schedule_DAL.Instance.GetIDEmployee(acc);
        }
        public void AddSchedule(int id, string idepl, int idshift, DateTime dt, string note)
        {
            Schedule_DAL.Instance.AddSchedule(id, idepl, idshift, dt, note);
        }
        public void EditSchedule(int id, string idepl, int idshift, DateTime dt, string note)
        {
            Schedule_DAL.Instance.EditSchedule(id, idepl, idshift, dt, note);
        }
        public void DeleteSchedule(int id)
        {
            Schedule_DAL.Instance.DeleteSchedule(id);
        }
        public List<ShiftWork> GetAllShift()
        {
            return Schedule_DAL.Instance.GetAllShift();
        }
        public string GetIDEmployeeByName(string name)
        {
            return Schedule_DAL.Instance.GetIDEmployeeByName(name);
        }
        public int GetIDShift(string name)
        {
            return Schedule_DAL.Instance.GetIDShift(name);
        }
    }
}
