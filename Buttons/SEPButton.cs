using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SEPFramework.Buttons
{
    public class SEPButton : Button
    {
        public SEPButton()
        {
            TabIndex = 0;
            UseVisualStyleBackColor = true;
            AutoSize = true;
            //MinimumSize = new Size(150, 40);
        }

        public SEPButton(string name, string text) : this()
        {
            Name = name;
            Text = text;
        }

        public SEPButton(string name, string text, EventHandler eh) : this(name, text)
        {
            Click += eh;
        }
    }
}
