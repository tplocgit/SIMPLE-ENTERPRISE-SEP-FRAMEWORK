using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace SEPFramework.DataGridViews
{
    public class SEPDataGridView: DataGridView
    {
        
        public SEPDataGridView()
        {
            InitDefault();
        }

        public SEPDataGridView(DataTable data) : this()
        {
            this.DataSource = data;
            Name = "dataGridView";
            AutoSize = true;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public SEPDataGridView(string name, DataTable data) : this(data: data)
        {
            this.Name = name;
        }
        public SEPDataGridView(string name, DataTable data, DataGridViewCellEventHandler onCellDoubleClicked) : this(name:name, data: data)
        {
            this.CellDoubleClick += onCellDoubleClicked;
        }

        public SEPDataGridView(string name, Point location, Size size, DataTable data) 
            : this(name: name, data: data)
        {
            Location = location;
            Size = size;
        }

        private void InitDefault()
        {
            ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ColumnHeadersDefaultCellStyle.Font = new Font(base.Font.FontFamily, 14, FontStyle.Bold);
            ColumnHeadersHeight = 50;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            CellBorderStyle = DataGridViewCellBorderStyle.Single;
            GridColor = Color.Black;
            BackgroundColor = Color.White;
            RowHeadersVisible = false;
            AllowUserToAddRows = false;
        }

        //private void InitColumns()
        //{
        //    if (_data == null || _data.Rows[0].) return;

        //    Dictionary<string, string>.KeyCollection columnNames = _data.First().Keys;
        //    for(int i = 0; i < columnNames.Count; ++i)
        //    {
        //        string name = columnNames.ElementAt(i);
        //        Columns.Add(columnName: name.Replace(" ", ""), headerText: name);
        //    }
        //}

        //private void InitRows()
        //{
        //    foreach (Dictionary<string, string> rowData in this._data)
        //    {
        //        int rIndex = this.Rows.Add();
        //        foreach (string key in rowData.Keys)
        //            this.Rows[rIndex].Cells[key].Value = rowData[key];
        //    }
        //}

        public Dictionary<string, string> rowData(int rowIndex)
        {
            return this.Rows[rowIndex]
                .Cells
                .Cast<DataGridViewCell>()
                .Select(item => new Dictionary<string, string>()
                {
                    {
                        this._dataGridView.Columns[item.ColumnIndex].HeaderText,
                        item.Value.ToString()
                    }
                })
                .ToList();
        } 
    }
}
