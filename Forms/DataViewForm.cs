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
        private readonly SqlServerDAO _sqlServerDao = new(SingletonDatabase.getInstance().connString);
        private readonly string _dbTableRef;
        private SEPDataGridView _dataGridView;

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
                this._dataGridView.DataSource = this._sqlServerDao.GetAllData(this._dbTableRef);
            });

            FactoryPanel factoryPanel = new();

            this._panelButtons = factoryPanel.CreateFLPanelDockRightButtons("btnPanel", new List<SEPButton> { btnInsert, btnDelete, btnReload });
        }

        private void SetUpDataGridView(DataTable dataSource)
        {
            this._dataGridView = new("dgv", dataSource, (sender, e) =>
            {
                Debug.WriteLine(e.RowIndex);
                Debug.WriteLine(this._dataGridView.Rows[e.RowIndex]);
            }) { Dock = System.Windows.Forms.DockStyle.Fill };
            this._panelMain = new System.Windows.Forms.Panel();
            this._panelMain.Controls.Add(this._dataGridView);
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
