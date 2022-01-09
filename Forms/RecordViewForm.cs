using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.Buttons;
using SEPFramework.Factories;

namespace SEPFramework.Forms
{
    class RecordViewForm : SEPForm
    {
        enum SaveType
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

            SEPButton btnCancel= new("btnDelete", "Delete", (sender, agrs) =>
            {
                Debug.WriteLine("Cancel");
            });


            FactoryPanel factoryPanel = new();

            this._panelButtons = factoryPanel.CreateFLPanelDockRightButtons("btnPanel", new List<SEPButton> { btnInsert, btnDelete, btnReload });
        }

    }
}
