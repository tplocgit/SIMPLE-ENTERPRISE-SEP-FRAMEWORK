using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.DataGridViews;
using SEPFramework.Buttons;

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
            TableLayoutPanel panel = new() { Name = panelName, Dock = DockStyle.Fill };
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
    }
}
