using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.Buttons;

namespace SEPFramework.Factories
{
    public abstract class FactoryButton
    {
        private static readonly int DefaultSizeWidth = 150;
        private static readonly int DefaultSizeHeight = 50;
        public static readonly System.Drawing.Size DefaultSize = new(width: DefaultSizeWidth, height: DefaultSizeHeight);

        public abstract SEPButton CreateButton(string name, System.Drawing.Point location);
        public abstract SEPButton CreateButton(string name);
    }
}
