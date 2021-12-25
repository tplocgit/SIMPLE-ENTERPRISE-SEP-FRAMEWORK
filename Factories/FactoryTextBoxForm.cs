using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Factories
{
    public abstract class FactoryTextBoxForm
    {
        public abstract SEPFramework.Forms.SEPForm CreateForm(Dictionary<string, string> pairLbTb);
    }
}
