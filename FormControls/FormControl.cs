using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SEPFramework.FormControls
{
    public class FormControl : Panel
    {
        private Label _label;
        private TextBox _textBox;

        public string Value
        {
            get { return _textBox.Text; }
            set { this._textBox.Text = value; }
        }

        public string LabelText
        {
            get { return this._label.Text; }
            set { this._label.Text = value; }
        }

        public FormControl()
        {
            this._label = new();
            //this._label.Dock = DockStyle.Left;
            //this._label.TextAlign = ContentAlignment.MiddleCenter;

            this._textBox = new();
            this._textBox.Dock = DockStyle.Fill;
            this._textBox.Multiline = false;
            this._textBox.AcceptsReturn = true;
            this._textBox.AcceptsTab = true;

            this.Controls.AddRange(new Control[] { this._textBox, this._label });
        }

        public FormControl(string name, string labelText, string value) : this()
        {
            this.Name = name;
            this._label.Text = labelText;
            this._textBox.Text = value;
        }
    }
}
