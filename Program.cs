using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.Buttons;
using SEPFramework.Forms;
using SEPFramework.Factories;
using SEPFramework.DataGridViews;
using SEPFramework.FormControls;
using SEPFramework.DI;
using SEPFramework.DAO.DB;
using SEPFramework.DAO;
using SEPFramework.DAO.MemberShip;
using System.Data;

namespace SEPFramework
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database databases = new Database();
            List<string> list = databases.GetDatabaseList();
            SelectDatabaseForm sldb = new SelectDatabaseForm("SelectDatabase", list);
            Application.Run(sldb);
            
        }
    }
}
