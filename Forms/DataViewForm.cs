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
using SEPFramework.DAO.DB;
using SEPFramework.DAO;


namespace SEPFramework.Forms
{
    class DataViewForm : SEPForm
    {
        private SqlServerDAO _sqlServerDao = new(SingletonDatabase.getInstance().connString);
        private string _dbTableRef;
       private DataViewForm(string name, string tableLabel, string tableTitle) : base(name, tableTitle, SEPForm.Type.Main, tableLabel, new System.Drawing.Size(1000, 700))
        {
            SEPButton btnInsert = new("btnInsert", "Insert", (sender, agrs) =>
            {
                Debug.WriteLine("Insert");

            });

            SEPButton btnDelete = new("btnDelete", "Delete", (sender, agrs) =>
            {
                Debug.WriteLine("Delete");
            });

            SEPButton btnReload = new("btnReload", "Reload", (sender, agrs) =>
            {
                Debug.WriteLine("Reload");
            });

            FactoryPanel factoryPanel = new();

            this._panelButtons = factoryPanel.CreateFLPanelDockRightButtons("btnPanel", new List<SEPButton> { btnInsert, btnDelete, btnReload });

            this.SetUpForm();
        }

        private void SetUpDataGridView(DataTable dataSource)
        {
            SEPDataGridView dataGridView = new("dgv", dataSource) { Dock = System.Windows.Forms.DockStyle.Fill };
            this._panelMain = new System.Windows.Forms.Panel();
            this._panelMain.Controls.Add(dataGridView);
        }

        public DataViewForm(string name, string tableLabel, string tableTitle, string dataTableName) : this(name, tableTitle, tableLabel)
        {
            this._dbTableRef = dataTableName;
            DataTable dataSource = _sqlServerDao.GetAllData(this._dbTableRef);
            this.SetUpDataGridView(dataSource);
            this.SetUpForm();
        }
    }
}
