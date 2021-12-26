using SEPFramework.Buttons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Factories
{
    public class FactoryButtonLogin : FactoryButton
    {
        public override SEPButton CreateButton(string name, Point location)
        {
            return new ButtonLogin(name, DefaultSize, location);
        }

        public override SEPButton CreateButton(string name)
        {
            return new ButtonLogin(name);
        }
    }
}
