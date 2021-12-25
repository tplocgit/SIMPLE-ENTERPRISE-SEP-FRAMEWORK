using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SEPFramework.DataGridViews
{
    public class SEPDataGridView: DataGridView
    {
        private List<Dictionary<string, string>> _data;
        
        public SEPDataGridView()
        {
            InitDefault();
        }

        public SEPDataGridView(List<Dictionary<string, string>> data) : this()
        {
            this._data = data;
            Name = "dataGridView";
            AutoSize = true;
            InitColumns();
            InitRows();
        }

        public SEPDataGridView(string name, List<Dictionary<string, string>> data) : this(data: data)
        {
            this.Name = name;
        }

        public SEPDataGridView(string name, Point location, Size size, List<Dictionary<string, string>> data) 
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

        private void InitColumns()
        {
            if (_data == null || _data.Count <= 0) return;

            Dictionary<string, string>.KeyCollection columnNames = _data.First().Keys;
            for(int i = 0; i < columnNames.Count; ++i)
            {
                string name = columnNames.ElementAt(i);
                Columns.Add(columnName: name.Replace(" ", ""), headerText: name);
            }
        }

        private void InitRows()
        {
            foreach (Dictionary<string, string> rowData in this._data)
            {
                int rIndex = this.Rows.Add();
                foreach (string key in rowData.Keys)
                    this.Rows[rIndex].Cells[key].Value = rowData[key];
            }
        }
    }
}
