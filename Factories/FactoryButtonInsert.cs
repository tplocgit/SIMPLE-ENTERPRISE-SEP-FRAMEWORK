using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.Buttons;
using System.Drawing;

namespace SEPFramework.Factories
{
    public class FactoryButtonInsert : FactoryButton
    {
        public override SEPButton CreateButton(string name, Point location)
        {
            return new ButtonInsert(name, DefaultSize, location);
        }

        public override SEPButton CreateButton(string name)
        {
            return new ButtonInsert(name);
        }
    }
}
