using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Buttons
{
    class ButtonSave : SEPButton
    {
        public ButtonSave(string name, Size size, Point location) : base(name, "Save", size, location)
        {

        }

        public ButtonSave(string name) : base(name, "Save")
        {

        }

        protected override void OnClick(object sender, EventArgs e)
        {
            Debug.WriteLine("Save");
        }
    }
}
