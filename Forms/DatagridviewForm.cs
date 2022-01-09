using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.DataGridViews;
using SEPFramework.Buttons;
using System.Diagnostics;
using SEPFramework.Factories;

namespace SEPFramework.Forms
{
    class DatagridviewForm : SEPForm
    {
        public DatagridviewForm(string name, string tableLabel, string tableTitle, DataTable dataSource) : base(name, tableTitle, SEPForm.Type.Main, tableLabel, new System.Drawing.Size(1000, 700))
        {
            SEPDataGridView dataGridView = new("dgv", dataSource) { Dock = System.Windows.Forms.DockStyle.Fill };
            this._panelMain = new System.Windows.Forms.Panel();
            this._panelMain.Controls.Add(dataGridView);

            SEPButton btnInsert = new SEPButton("btnInsert", "Insert", (sender, agrs) =>
            {
                Debug.WriteLine("Insert");
            }); 

            SEPButton btnDelete = new SEPButton("btnDelete", "Delete", (sender, agrs) =>
            {
                Debug.WriteLine("Delete");
            }); 

            SEPButton btnReload = new SEPButton("btnReload", "Reload", (sender, agrs) =>
            {
                Debug.WriteLine("Reload");
            });

            FactoryPanel factoryPanel = new();

            this._panelButtons = factoryPanel.CreateFLPanelDockRightButtons("btnPanel", new List<SEPButton> { btnInsert, btnDelete, btnReload });

            this.SetUpForm();
        }
    }
}
