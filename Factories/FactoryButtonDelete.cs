using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SEPFramework.Buttons;

namespace SEPFramework.Factories
{
    class FactoryButtonDelete : FactoryButton
    {
        public override SEPButton CreateButton(string name, Point location)
        {
            return new ButtonDelete(name, DefaultSize, location);
        }
        public override SEPButton CreateButton(string name)
        {
            return new ButtonDelete(name);
        }
    }
}
