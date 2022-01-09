using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SEPFramework.FormControls
{
    public class FormControl
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

        public Label ControlLabel
        {
            get { return this._label; }
            set { this._label = value; }
        }

        public TextBox ControlTextBox
        {
            get { return this._textBox; }
            set { this._textBox = value; }
        }

        public void SetPasswordChar(char c)
        {
            this._textBox.PasswordChar = c;
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
            this._textBox.AcceptsTab = false;
        }

        public FormControl(string labelText, string value) : this()
        {
            this._label.Text = labelText;
            this._textBox.Text = value;
        }

        public FormControl(string labelText, string value, char pwdChar) : this(labelText, value)
        {
            this._textBox.PasswordChar = pwdChar;
        }

        public static List<FormControl> CreateFormControlList(Dictionary<string,string> labelValuePairs)
        {
            List<FormControl> list = new();
            foreach(string label in labelValuePairs.Keys)
                list.Add(new(label, labelValuePairs[label]));
            return list;
        }
    }
}
