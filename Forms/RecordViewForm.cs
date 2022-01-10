using SEPFramework.Buttons;
using SEPFramework.DAO;
using SEPFramework.DAO.DB;
using SEPFramework.Factories;
using SEPFramework.FormControls;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SEPFramework.Forms
{
    class RecordViewForm : SEPForm
    {
        public enum SaveType
        {
            Insert = 0,
            Update = 1,
        }

        SaveType _sType;
        List<FormControl> _fields = new();
        SqlServerDAO sqlServerDAO = new SqlServerDAO(SingletonDatabase.getInstance().connString);
        string _tableName = "";

        private RecordViewForm(string name, string tableLabel, string tableTitle, SaveType type) : base(name, tableTitle, SEPForm.Type.Main, tableLabel, new System.Drawing.Size(500, 500))
        {
            this._sType = type;
            SEPButton btnInsert = new("btnSave", "btnSave", (sender, agrs) =>
            {
                Debug.WriteLine("Save");
                Dictionary<string, object> insertDict = this.GetFormDataAsDict();
                foreach (FormControl i in _fields)
                {
                    Debug.WriteLine(i.LabelText + ": " + i.Value);
                }
                if(this._sType == SaveType.Insert)
                {
                    // Insert Action here
                    Debug.WriteLine("Insert");
                    sqlServerDAO.Insert(insertDict, this._tableName);
                }
                else if(this._sType == SaveType.Update)
                {
                    // Update action here
                    Debug.WriteLine("Update");
                }
            });

            SEPButton btnCancel = new("btnCancel", "Cancel", (sender, agrs) =>
             {
                 Debug.WriteLine("Cancel");
                 this.Hide();
             });


            FactoryPanel factoryPanel = new();

            this._panelButtons = factoryPanel.CreateFLPanelDockRightButtons("btnPanel", new List<SEPButton> { btnInsert, btnCancel });
        }

        public RecordViewForm(string name, string tableLabel, string tableTitle, SaveType type, DataGridViewRow row) : this(name, tableLabel, tableTitle, type)
        {
            foreach (DataGridViewColumn col in row.DataGridView.Columns)
            {
                string label = col.HeaderText;
                string value = row.Cells[col.Index].Value.ToString();
                _fields.Add(new(label, value));
            }
            FactoryPanel factoryPanel = new();

            this._panelMain = factoryPanel
                .CreateTLPabelDockFillFormControls("rowPanel", _fields);

            this.SetUpForm();
        }

        public Dictionary<string, object> GetFormDataAsDict()
        {
            return this
                ._fields
                .Aggregate(new Dictionary<string, object>(), (acc, curr) =>
                {
                    acc[curr.LabelText] = curr.Value;
                    return acc;
                });
        }
    }
}
