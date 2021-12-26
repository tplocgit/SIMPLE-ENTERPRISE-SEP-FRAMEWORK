using SEPFramework.FormControls;
using SEPFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.Factories
{
    public abstract class FactoryForm
    {
        public abstract SEPForm CreateLoginForm(string name);
        public abstract SEPForm CreateRegisterForm(string name);
        public abstract SEPForm CreateDataViewForm(string name, string title, List<Dictionary<string, string>> data);
        public abstract SEPForm CreateInputForm(string name, string title, Dictionary<string, string> fields);
        public static Panel CreateTextBoxsPanel(string name, Dictionary<string,string> fields)
        {

            return new FactoryPanel().CreateTLPabelDockFillFormControls(name, fields);
        }
    }
}
