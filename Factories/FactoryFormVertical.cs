using SEPFramework.Buttons;
using SEPFramework.Forms;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SEPFramework.Factories
{
    class FactoryFormVertical : FactoryForm
    {
        public override SEPForm CreateLoginForm(string name)
        {
            //FactoryButton factoryButton = new FactoryButtonLogin();
            //SEPButton buttonLogin = factoryButton.CreateButton("btnLogin");

            //factoryButton = new FactoryButtonRegister();
            //SEPButton buttonRegister = factoryButton.CreateButton("btnRegister");

            //List<SEPButton> buttons = new() { buttonLogin, buttonRegister };
            //FactoryPanel factoryPanel = new();

            //Dictionary<string, string> _fields = new()
            //{
            //    ["Username:"] = "",
            //    ["Password:"] = ""
            //};

            //return new SEPForm
            //(
            //    name: name,
            //    titleText: "Login",
            //    SEPForm.Type.Main,
            //    text: "Login Form",
            //    size: new(width: 500, height: 300),
            //    flPanelButtons: factoryPanel.CreateFLPanelDockBottomButtons("panelButtons", buttons),
            //    panelContent: factoryPanel.CreateTLPabelDockFillFormControls("panelTextboxs", _fields)
            //)
            //{ MaximumSize = new(width: 500, height: 300) };
            return new LoginForm("A KKK");
        }

        public override SEPForm CreateRegisterForm(string name)
        {
            //FactoryButton factoryButton = new FactoryButtonLogin();
            //SEPButton buttonLogin = factoryButton.CreateButton("btnLogin");

            //factoryButton = new FactoryButtonRegister();
            //SEPButton buttonRegister = factoryButton.CreateButton("btnRegister");

            //List<SEPButton> buttons = new() { buttonLogin, buttonRegister };
            //FactoryPanel factoryPanel = new();

            //Dictionary<string, string> _fields = new()
            //{
            //    ["Username:"] = "",
            //    ["Password:"] = ""
            //};

            //return new SEPForm
            //(
            //    name: name,
            //    titleText: "Register",
            //    SEPForm.Type.Main,
            //    text: "Register Form",
            //    size: new(width: 500, height: 300),
            //    flPanelButtons: factoryPanel.CreateFLPanelDockBottomButtons("panelButtons", buttons),
            //    panelContent: factoryPanel.CreateTLPabelDockFillFormControls("panelTextboxs", _fields)
            //)
            //{ MaximumSize = new(width: 500, height: 300) };
            return null;
        }
        public override SEPForm CreateDataViewForm(string name, string title, List<Dictionary<string, string>> data)
        {
            //FactoryPanel factoryPanel = new();
            //Panel panelDgv = factoryPanel.CreatePanelDataGridView("panelDgv", data);
            //FactoryButton factoryButton = new FactoryButtonInsert();
            //SEPButton buttonInsert = factoryButton.CreateButton("btnInsert");

            //factoryButton = new FactoryButtonDelete();
            //SEPButton buttonDelete = factoryButton.CreateButton("btnDelete");

            //List<SEPButton> buttons = new() { buttonInsert, buttonDelete };

            //Panel paneButtons = factoryPanel.CreateFLPanelDockBottomButtons("pabelButtons", buttons);

            //return new
            //(
            //    name: name,
            //    titleText: title,
            //    SEPForm.Type.Main,
            //    text: "Register Form",
            //    size: new(width: 500, height: 500),
            //    flPanelButtons: paneButtons,
            //    panelContent: panelDgv
            //);
            return null;
        }
        public override SEPForm CreateInputForm(string name, string title, Dictionary<string, string> fields)
        {
            //FactoryPanel factoryPanel = new();
            //Panel panelTb = factoryPanel.CreateTLPabelDockFillFormControls("panelTb", _fields);
            //FactoryButton factoryButton = new FactoryButtonSave();
            //SEPButton buttonSave = factoryButton.CreateButton("btnSave");

            //List<SEPButton> buttons = new() { buttonSave };

            //Panel paneButtons = factoryPanel.CreateFLPanelDockBottomButtons("pabelButtons", buttons);

            //return new
            //(
            //    name: name,
            //    titleText: "Register",
            //    SEPForm.Type.Main,
            //    text: "Register Form",
            //    size: new(width: 500, height: 500),
            //    flPanelButtons: paneButtons,
            //    panelContent: panelTb
            //);
            return null;
        }
    }
}
