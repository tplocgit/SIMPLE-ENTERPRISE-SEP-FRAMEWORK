using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace SEPFramework.Buttons
{
    class ButtonDelete : SEPButton
    {
        public ButtonDelete(string name, Size size, Point location) : base(name, "Delete", size, location)
        {

        }

        public ButtonDelete(string name) : base(name, "Delete")
        {

        }

        protected override void OnClick(object sender, EventArgs e)
        {
            Debug.WriteLine("Delete");
        }
    }
}
