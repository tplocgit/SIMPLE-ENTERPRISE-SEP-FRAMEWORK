using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.DataGridViews;
using SEPFramework.Buttons;
using SEPFramework.FormControls;

namespace SEPFramework.Factories
{
    public class FactoryPanel
    {
        private static FlowLayoutPanel CreateFLPanelControls(string panelName, FlowDirection flowDirection, DockStyle dockStyle, Control[] controls)
        {
            FlowLayoutPanel panel = new();
            panel.Dock = dockStyle;
            panel.Name = panelName;
            panel.FlowDirection = flowDirection;
            panel.Controls.AddRange(controls);
            panel.MinimumSize = new(160, 0);
            return panel;
        }

        private FlowLayoutPanel CreateFLPanelDockBottomControls(string panelName, Control[] controls)
        {
            return CreateFLPanelControls(panelName, FlowDirection.RightToLeft, DockStyle.Bottom, controls);
        }


        public Panel CreatePanelDataGridView(string panelName, List<Dictionary<string, string>> data)
        {
            Panel panel = new();
            panel.Dock = DockStyle.Fill;
            panel.Name = panelName;
            panel.Padding = new Padding(5);

            SEPDataGridView dataGridView = new(data);
            dataGridView.Dock = DockStyle.Fill;

            panel.Controls.Add(dataGridView);

            return panel;
        }

        public FlowLayoutPanel CreateFLPanelDockRightButtons(string panelName, List<SEPButton> buttons)
        {
            return CreateFLPanelControls(panelName, FlowDirection.TopDown, DockStyle.Right, buttons.ToArray());
        }

        public FlowLayoutPanel CreateFLPanelDockBottomButtons(string panelName, List<SEPButton> buttons)
        {
            return this.CreateFLPanelDockBottomControls(panelName, buttons.ToArray());
        }

        public FlowLayoutPanel CreateFLPanelDockFillControls(string panelName, Control[] controls)
        {
            return CreateFLPanelControls(panelName, FlowDirection.TopDown, DockStyle.Fill, controls);
        }

        public TableLayoutPanel CreateTLPabelDockFillControls(string panelName, Control[,] controls)
        {
            TableLayoutPanel panel = new() { Name = panelName, Dock = DockStyle.Fill, Padding = new(0, 2, 0, 0) };
            panel.ColumnCount = controls.GetLength(1);
            panel.RowCount = controls.GetLength(0);
            for(int row = 0; row < panel.RowCount; ++row)
                for(int col = 0; col < panel.ColumnCount; ++col)
                {
                    panel.Controls.Add(controls[row, col], col, row);
                }
            panel.Controls.Add(new Control());
            return panel;
        }

        public TableLayoutPanel CreateTLPabelDockFillFormControls(string panelName, List<FormControl> controls)
        {
            TableLayoutPanel panel = new() { Name = panelName, Dock = DockStyle.Fill, Padding = new(0, 2, 0, 0) };
            panel.RowCount = controls.Count;
            panel.ColumnCount = 2;

            for(int i = 0; i < controls.Count; ++i)
            {
                panel.Controls.Add(controls[i].ControlLabel, 0, i);
                panel.Controls.Add(controls[i].ControlTextBox, 1, i);
            }

            panel.Controls.Add(new Control());
            return panel;
        }

        public TableLayoutPanel CreateTLPabelDockFillFormControls(string panelName, Dictionary<string, string> fields)
        {
            TableLayoutPanel panel = new() { Name = panelName, Dock = DockStyle.Fill, Padding = new(0, 2, 0, 0) };
            panel.RowCount = fields.Keys.Count;
            panel.ColumnCount = 2;

            for (int i = 0; i < fields.Keys.Count; ++i)
            {
                string key = fields.Keys.ElementAt(i);
                FormControl fc = new(key, fields[key]);
                panel.Controls.Add(fc.ControlLabel, 0, i);
                panel.Controls.Add(fc.ControlTextBox, 1, i);
            }

            panel.Controls.Add(new Control() { Width = 0 });
            return panel;
        }
    }
}
