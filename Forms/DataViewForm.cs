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
using System.Windows.Forms;

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
                //SEPForm insertForm = new RecordViewForm("Insert row", "Insert row", "Edit your new line to insert", RecordViewForm.SaveType.Insert, this._dataGridView.Rows[0]);
                SEPForm insertForm = new RecordViewForm(name, tableLabel, tableTitle, this._dbTableRef, RecordViewForm.SaveType.Insert, this._dataGridView.Rows[0]);
                insertForm.Show();
            });

            SEPButton btnDelete = new("btnDelete", "Delete", (sender, agrs) =>
            {
                // Delete evetn here
                Debug.WriteLine("Delete");


                // Get Selected Rows by this._dataGridView.SelectedRows
                // Get Selected Column by this._dataGridView.SelectedColumns
                // Get first row this._dataGridView.SelectedRows[0] if this._dataGridView.SelectedRows.Count > 0

                DataGridViewSelectedRowCollection rowColection = this._dataGridView.SelectedRows;
                if (rowColection.Count <= 0)
                {
                    // No row selected here
                    return;
                }
                foreach(DataGridViewRow row in rowColection)
                {
                    Debug.WriteLine(string.Join(Environment.NewLine, this._dataGridView.RowDataToDict(row.Index)));
                    _sqlServerDao.Delete(_dbTableRef, row.Cells[0].Value);
                }
            });

            SEPButton btnReload = new("btnReload", "Reload", (sender, agrs) =>
            {
                Debug.WriteLine("Reload");
                this._dataGridView.DataSource = this._sqlServerDao.GetAllData(this._dbTableRef);
            });

            SEPButton btnUpdate = new("btnUpdate", "btnUpdate", (sender, agrs) =>
            {
                Debug.WriteLine("Update");
                DataGridViewSelectedRowCollection selectedRows = this._dataGridView.SelectedRows;
                if(selectedRows.Count <= 0)
                {
                    return;
                }
                RecordViewForm rvf = new("rvf", "Update", "Update", this._dbTableRef, RecordViewForm.SaveType.Update, selectedRows[0]);
                rvf.Show();
            });

            FactoryPanel factoryPanel = new();

            this._panelButtons = factoryPanel.CreateFLPanelDockRightButtons("btnPanel", new List<SEPButton> { btnInsert, btnUpdate, btnDelete, btnReload });
        }

        private void SetUpDataGridView(DataTable dataSource)
        {
            this._dataGridView = new
                (name: "dgv", data: dataSource, onCellDoubleClicked: OnCellDoubleClicked) 
                { Dock = DockStyle.Fill };
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

        private void OnCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            // Double click cell event here 
            Debug.WriteLine(e.RowIndex);
            Debug.WriteLine(this._dataGridView.Rows[e.RowIndex]);
            DataGridViewSelectedRowCollection selectedRowCollection = this._dataGridView.SelectedRows;
            if(selectedRowCollection.Count <= 0)
            {
                MessageBox.Show("Error: No row selected");
            }
            DataGridViewRow selectedFirstRow = selectedRowCollection[0];
            new RecordViewForm("rvf", "Record", "Record", this._dbTableRef, RecordViewForm.SaveType.Update, selectedFirstRow);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DataViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "DataViewForm";
            this.Load += new System.EventHandler(this.DataViewForm_Load);
            this.ResumeLayout(false);
        }

        private void DataViewForm_Load(object sender, EventArgs e)
        {

        }
    }
}
