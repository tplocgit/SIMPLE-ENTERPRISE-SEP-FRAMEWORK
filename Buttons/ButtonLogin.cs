using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Buttons
{
    class ButtonLogin : SEPButton
    {
        public ButtonLogin(string name, Size size, Point location) : base(name, "Login", size, location)
        {

        }

        public ButtonLogin(string name) : base(name, "Login")
        {

        }

        protected override void OnClick(object sender, EventArgs e)
        {
            Debug.WriteLine("Login");
        }
    }
}
