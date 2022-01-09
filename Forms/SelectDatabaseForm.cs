using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.Buttons;
using SEPFramework.Factories;

namespace SEPFramework.Forms
{
    class SelectDatabaseForm : SEPForm
    {
        public SelectDatabaseForm(string name, List<string> databaseNames) : base(name, "Select Databases", SEPForm.Type.Main, "Login Form", new(width: 500, height: 300))
        {
            this._panelMain = new FlowLayoutPanel();
            ComboBox cb = new();
            cb.Items.AddRange(databaseNames.ToArray());
            SEPButton btnConn = new
            (
                "btnConn", "Connect",
                (sender, agrs) =>
                {
                    Debug.WriteLine($"Selected: {cb.SelectedItem} at Index = {cb.SelectedIndex}");
                }
            );

            this._panelMain.Controls.AddRange(new Control[2]{ cb, btnConn });

            this.SetUpForm();
        }
    }
}
