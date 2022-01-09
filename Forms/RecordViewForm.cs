using SEPFramework.Buttons;
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

        private RecordViewForm(string name, string tableLabel, string tableTitle, SaveType type) : base(name, tableTitle, SEPForm.Type.Main, tableLabel, new System.Drawing.Size(500, 500))
        {
            this._sType = type;
            SEPButton btnInsert = new("btnInsert", "Insert", (sender, agrs) =>
            {
                Debug.WriteLine("Save");
                foreach(FormControl i in _fields)
                {
                    Debug.WriteLine(i.Value);
                }
            });

            SEPButton btnCancel = new("btnDelete", "Delete", (sender, agrs) =>
             {
                 Debug.WriteLine("Cancel");
             });


            FactoryPanel factoryPanel = new();

            this._panelButtons = factoryPanel.CreateFLPanelDockRightButtons("btnPanel", new List<SEPButton> { btnInsert, btnCancel });
        }

        public RecordViewForm(string name, string tableLabel, string tableTitle, SaveType type, DataGridViewRow row) : this(name, tableLabel, tableTitle, type)
        {
            foreach(DataGridViewColumn col in row.DataGridView.Columns)
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
    }
}
