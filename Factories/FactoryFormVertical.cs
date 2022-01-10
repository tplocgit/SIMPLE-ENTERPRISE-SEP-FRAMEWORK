using SEPFramework.Buttons;
using SEPFramework.Forms;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace SEPFramework.Factories
{
    class FactoryFormVertical : FactoryForm
    {
        public override SEPForm CreateLoginForm(string name)
        {
            SEPButton buttonLogin = new("btnLogin", "btnLogin");

            SEPButton buttonRegister = new("btnRegister", "btnRegister");

            List<SEPButton> buttons = new() { buttonLogin, buttonRegister };
            FactoryPanel factoryPanel = new();

            Dictionary<string, string> _fields = new()
            {
                ["Username:"] = "",
                ["Password:"] = ""
            };

            return new SEPForm
            (
                name: name,
                titleText: "Login",
                SEPForm.Type.Main,
                text: "Login Form",
                size: new(width: 500, height: 300),
                flPanelButtons: factoryPanel.CreateFLPanelDockBottomButtons("panelButtons", buttons),
                panelContent: factoryPanel.CreateTLPabelDockFillFormControls("panelTextboxs", _fields)
            )
            { MaximumSize = new(width: 500, height: 300) };
        }

        public override SEPForm CreateRegisterForm(string name)
        {
            SEPButton buttonLogin = new("btnLogin", "btnLogin");

            SEPButton buttonRegister = new("btnRegister", "btnRegister");

            List<SEPButton> buttons = new() { buttonLogin, buttonRegister };
            FactoryPanel factoryPanel = new();

            Dictionary<string, string> _fields = new()
            {
                ["Username:"] = "",
                ["Password:"] = ""
            };

            return new SEPForm
            (
                name: name,
                titleText: "Register",
                SEPForm.Type.Main,
                text: "Register Form",
                size: new(width: 500, height: 300),
                flPanelButtons: factoryPanel.CreateFLPanelDockBottomButtons("panelButtons", buttons),
                panelContent: factoryPanel.CreateTLPabelDockFillFormControls("panelTextboxs", _fields)
            )
            { MaximumSize = new(width: 500, height: 300) };
        }
        public override SEPForm CreateDataViewForm(string name, string title, DataTable data)
        {
            FactoryPanel factoryPanel = new();
            Panel panelDgv = factoryPanel.CreatePanelDataGridView("panelDgv", data);
            SEPButton buttonInsert = new("btnInsert", "btnInsert");

            SEPButton buttonDelete = new("btnDelete", "btnDelete");

            List<SEPButton> buttons = new() { buttonInsert, buttonDelete };

            Panel paneButtons = factoryPanel.CreateFLPanelDockBottomButtons("pabelButtons", buttons);

            return new
            (
                name: name,
                titleText: title,
                SEPForm.Type.Main,
                text: "Register Form",
                size: new(width: 500, height: 500),
                flPanelButtons: paneButtons,
                panelContent: panelDgv
            );
        }
        public override SEPForm CreateInputForm(string name, string title, Dictionary<string, string> fields)
        {
            FactoryPanel factoryPanel = new();
            Panel panelTb = factoryPanel.CreateTLPabelDockFillFormControls("panelTb", fields);
            SEPButton buttonSave = new("btnSave", "btnSave");

            List<SEPButton> buttons = new() { buttonSave };

            Panel paneButtons = factoryPanel.CreateFLPanelDockBottomButtons("pabelButtons", buttons);

            return new
            (
                name: name,
                titleText: "Register",
                SEPForm.Type.Main,
                text: "Register Form",
                size: new(width: 500, height: 500),
                flPanelButtons: paneButtons,
                panelContent: panelTb
            );
        }
    }
}
