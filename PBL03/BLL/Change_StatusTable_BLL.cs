using Guna.UI2.WinForms;
using PBL03.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PBL03.BLL
{
    public class Change_StatusTable_BLL
    {
        private Change_StatusTable_DAL dal;
        public Change_StatusTable_BLL()
        {
            dal = new Change_StatusTable_DAL();
        }
        public void setColor_Table(Guna2TileButton btn, string id)
        {
            dal.setColor_Table(btn, id);
        }    
        public void changeStatus(string id, bool status, int people)
        {
            dal.changeStatus(id, status, people);
        }
        public List<TableFood> GetTables()
        {
            return dal.GetAllTables();
        }
        public void UpdateTable(string id, bool st, int people)
        {
            dal.UpdateTable(id, st, people);
        }
        public void setColor_Table(FlowLayoutPanel flowpanel)
        {
            dal.setColor_Table(flowpanel);
        }
    }
}
