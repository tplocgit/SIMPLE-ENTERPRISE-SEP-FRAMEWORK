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
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<SEPButton> buttons = new();

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
            };

            SEPDataGridView dataGridView = new(data);

            FactoryPanel factoryPanel = new FactoryPanel();
             
            Panel panelGridView = factoryPanel.CreatePanelDataGridView("panelGridView", data);
            Panel panelButtons = factoryPanel.CreateFLPanelDockRightButtons("panelButtons", buttons);



            Application.Run(new FactoryFormVertical().CreateLoginForm("loginForm"));
            //Application.Run(new SEPForm("DataView", "DataView", SEPForm.Type.Main, "DataView", SEPForm.SEPFormDefaultSize, panelButtons, panelGridView));
        }
    }
}
