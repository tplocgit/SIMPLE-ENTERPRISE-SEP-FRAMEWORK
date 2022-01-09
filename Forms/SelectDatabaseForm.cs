using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.Buttons;
using SEPFramework.DAO;
using SEPFramework.DI;
using SEPFramework.Factories;
using SEPFramework.Forms;
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
                    //IoCContainer.SetDependency<FactoryFormVertical, FactoryFormVertical>();
                    Debug.WriteLine($"Selected: {cb.SelectedItem} at Index = {cb.SelectedIndex}");
                    //SingletonDatabase singletonDatabase = SingletonDatabase.getInstance();
                    //singletonDatabase.connString = $@"Data Source=.;Initial Catalog={cb.SelectedItem};Integrated Security=SSPI";

                    //IoCContainer.GetDependency<FactoryFormVertical>().CreateLoginForm("Login form").Show();
                }
            );

            this.SetUpForm();
        }
    }
}
