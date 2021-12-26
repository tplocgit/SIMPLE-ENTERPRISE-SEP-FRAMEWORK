using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Buttons
{
    class ButtonRegister : SEPButton
    {
        public ButtonRegister(string name, Size size, Point location) : base(name, "Register", size, location)
        {

        }

        public ButtonRegister(string name) : base(name, "Register")
        {

        }

        protected override void OnClick(object sender, EventArgs e)
        {
            Debug.WriteLine("Register");
        }
    }
}
