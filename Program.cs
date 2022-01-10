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
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            /*List<SEPButton> buttons = new();

            FactoryButton factory = new FactoryButtonInsert();
            buttons.Add(factory.CreateButton("btnInsert"));

            factory = new FactoryButtonDelete();
            buttons.Add(factory.CreateButton("btnUpdate"));

            List<Dictionary<string, string>> data = new()
            {
                new()
                {
                    ["col1"] = "cell1",
                    ["col2"] = "cell2",
                    ["col3"] = "cell3",
                    ["col4"] = "cell4",
                    ["col5"] = "cell5",
                },
                new()
                {
                    ["col1"] = "cell6",
                    ["col2"] = "cell7",
                    ["col3"] = "cell8",
                    ["col4"] = "cell9",
                    ["col5"] = "cell0",
                }
            };*/

            //SEPDataGridView dataGridView = new(data);

            //IoCContainer.SetDependency<FactoryPanel, FactoryPanel>();

            //Panel panelGridView = IoCContainer.GetDependency<FactoryPanel>().CreatePanelDataGridView("panelGridView", data);
            //Panel panelButtons = IoCContainer.GetDependency<FactoryPanel>().CreateFLPanelDockRightButtons("panelButtons", buttons);




            //Application.Run(new DataViewForm("", "", "", ""));



            //-----------------------------Get list of available database on this PC--------------------------
            Database databases = new Database();
            List<string> list = databases.GetDatabaseList();
            SelectDatabaseForm sldb = new SelectDatabaseForm("SelectDatabase", list);
            ////SelectDatabaseForm sldb = new SelectDatabaseForm("SelectDatabase", new List<string>{ "a", "b"});
            //Application.Run(sldb);
            /*
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            */




            /*
            //-----------------------------Get list of tables in selected database-------------------------------------------
            Console.WriteLine($"------------------- {selected_database}  database table ------------------------"); 
            List<string> tables = singletonDatabase.GetAllTablesName();
            foreach (var i in tables)
            {
                Console.WriteLine(i);
            }
            */

            //SqlServerDAO sqlServerDAO = new SqlServerDAO(singletonDatabase.connString);


            //List<string> data = sqlServerDAO.GetAllFieldsName("OFFICER");
            //foreach (string item in data)
            //{
            //    Console.Write(item+"\t");
            //}
            //Console.WriteLine();
            //DataTable dataTable = sqlServerDAO.GetAllData("OFFICER");
            //foreach (DataRow dataRow in dataTable.Rows)
            //{
            //    //int count = 0;
            //    foreach (var item in dataRow.ItemArray)
            //    {

            //        //Console.Write(item + $"-{count}-type:{item.GetType()}\t");
            //        //count++;
            //        if (item.GetType() == typeof(System.DBNull))
            //            Console.Write("<NULL>\t");
            //        else
            //            Console.Write(item + "\t");

            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
