using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SEPFramework.Buttons
{
    public abstract class SEPButton : Button
    {
        protected SEPButton()
        {
            TabIndex = 0;
            UseVisualStyleBackColor = true;
            AutoSize = true;
            MinimumSize = new Size(150, 40);
            Click += OnClick;
        }

        protected SEPButton(string name, string text) : this()
        {
            Name = name;
            Text = text;
        }

        protected SEPButton(string name, string text, Size size, Point location) : this(name: name, text: text)
        {
            Size = size;
            Location = location;
        }


        protected abstract void OnClick(object sender, EventArgs e);
    }
}
