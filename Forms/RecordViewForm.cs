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

        private RecordViewForm(string name, string tableLabel, string tableTitle, SaveType type) : base(name, tableTitle, SEPForm.Type.Main, tableLabel, new System.Drawing.Size(500, 500))
        {
            this._sType = type;
            SEPButton btnInsert = new("btnInsert", "Insert", (sender, agrs) =>
            {
                Debug.WriteLine("Save");

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
            DataGridViewRow headers = row.DataGridView.Rows[0];
            Dictionary<string, string> fields = Enumerable
                .Range(0, headers.Cells.Count)
                .ToDictionary(i => headers.Cells[i].Value.ToString(), i => type == SaveType.Update ? row.Cells[i].Value.ToString() : "");

            FactoryPanel factoryPanel = new();

            this._panelMain = factoryPanel
                .CreateTLPabelDockFillFormControls("rowPanel", FormControl.CreateFormControlList(fields));

            this.SetUpForm();
        }
    }
}
