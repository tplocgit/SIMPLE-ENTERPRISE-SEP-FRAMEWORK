using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.FormControls;
using System.Windows.Forms;
using SEPFramework.Factories;
using SEPFramework.Buttons;
namespace SEPFramework.Forms
{
    class LoginForm : SEPForm
    {
        FormControl username = new("Username", "");
        FormControl password = new("Password", "");
        LoginForm(string name) : base (name, "Login Form", SEPForm.Type.Main, "Login Form", new(width: 500, height: 300))
        {
            FactoryPanel factoryPanel = new();
            SEPButton btn_login = new ButtonLogin("Button Login");
            SEPButton btn_register = new ButtonRegister("Button Register");
            List<SEPButton> btn = new List<SEPButton>();
            btn.Add(btn_login);
            btn.Add(btn_register);
            this._panelButtons = factoryPanel.CreateFLPanelDockBottomButtons("Login/Register", btn);
        }
        
    }
}
