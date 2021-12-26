using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using SEPFramework.Forms;
using System.Windows.Forms;
using SEPFramework.Factories;

namespace SEPFramework.Buttons
{
    class ButtonInsert : SEPButton
    {
        public ButtonInsert(string name, Size size, Point location) : base(name, "Insert", size, location)
        {

        }
        public ButtonInsert(string name) : base(name, "Insert")
        {

        }

        protected override void OnClick(object sender, EventArgs e)
        {
            Debug.WriteLine("Insert");

            List<SEPButton> buttons = new();

            FactoryButton factory = new FactoryButtonInsert();
            buttons.Add(factory.CreateButton("btnInsert"));

            factory = new FactoryButtonDelete();
            buttons.Add(factory.CreateButton("btnUpdate"));


            Control[,] controls = new Control[,]
{
                { new Label { Text = "aaaaaaaa", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, new TextBox { Dock = DockStyle.Fill } },
                { new Label { Text = "bbbb", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, new TextBox { Dock = DockStyle.Fill } },
                { new Label { Text = "ccccccccc", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, new TextBox { Dock = DockStyle.Fill } }
            };
            FactoryPanel fp = new();
            Panel panelButtons = fp.CreateFLPanelDockRightButtons("panelButtons", buttons);
            Panel panelFC = fp.CreateTLPabelDockFillControls("aaa", controls);
            SEPForm textBoxForm = new("TextboxForm", "TextboxForm", SEPForm.Type.Add, "TextboxForm", new System.Drawing.Size(700, 700), panelButtons, panelFC);
            textBoxForm.Show();
        }
    }
}
