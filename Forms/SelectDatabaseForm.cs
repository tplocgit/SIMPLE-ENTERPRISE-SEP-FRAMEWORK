using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.Buttons;

namespace SEPFramework.Forms
{
    class SelectDatabaseForm : SEPForm
    {
        public SelectDatabaseForm(string name, List<string> databaseNames) : base(name, "Select Databases", SEPForm.Type.Main, "Login Form", new(width: 500, height: 300))
        {
            this._panelMain = new Panel();
            ComboBox cb = new();
            cb.Items.AddRange(databaseNames.ToArray());
            this._panelMain.Controls.Add(cb);

            SEPButton btnConn = new
            (
                "btnConn", "Connect", 
                (sender, agrs) => 
                {
                    Debug.WriteLine($"Selected: {cb.SelectedItem} at Index = {cb.SelectedIndex}");
                }
            );

            this.SetUpForm();
        }
    }
}
