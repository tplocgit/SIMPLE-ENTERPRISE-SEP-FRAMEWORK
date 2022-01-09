using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.FormControls;
using System.Windows.Forms;
using SEPFramework.Factories;
using SEPFramework.Buttons;
using System.Diagnostics;

namespace SEPFramework.Forms
{
    class LoginForm : SEPForm
    {
        private FormControl username = new("Username", "");
        private FormControl password = new("Password", "");
        public LoginForm(string name) : base (name, "Login Form", SEPForm.Type.Main, "Login Form", new(width: 500, height: 300))
        {
            FactoryPanel factoryPanel = new();
            SEPButton btn_login = new ("Button Login", "Login" , OnClickLogin);
            SEPButton btn_register = new ("Button Register", "Register" , OnClickRegister);
            List<SEPButton> btn = new() { btn_login, btn_register };
            List<FormControl> fc = new() { this.username, this.password };

            this._panelButtons = factoryPanel.CreateFLPanelDockBottomButtons("Login/Register", btn);
            this._panelMain = factoryPanel.CreateTLPabelDockFillFormControls("main", fc);
            this.SetUpForm();
        }

        private void OnClickLogin(object sender, EventArgs args)
        {
            Debug.WriteLine("Login");
        }

        private void OnClickRegister(object sender, EventArgs args)
        {
            Debug.WriteLine("Register");
        }
    }
}
