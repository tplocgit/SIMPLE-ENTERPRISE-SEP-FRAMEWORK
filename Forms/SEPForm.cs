﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.Buttons;
using SEPFramework.DataGridViews;
using System.Diagnostics;

namespace SEPFramework.Forms
{
    public partial class SEPForm : System.Windows.Forms.Form
    {
        public enum Type
        {
            Main = 0,
            Add = 1,
            Update = 2
        };

        public static readonly Size SEPFormDefaultSize = new(width: 1500, height: 1000);
        private static readonly float t_defaultTitleFontSize = 20;
        private static readonly int t_defaultMargin = 10;
        private static readonly float t_defaultDockSideWidthPercent = 0.2f;
        private static readonly Size t_minSize = new(width: 500, height: 500);
        private string _titleText;
        private Type _type;

        // This panel contains main content in the center of form
        private Panel _panelMain;

        private Label _labelTitle = new();

        // This panel contains buttons
        private Panel _panelButtons = new();

        public SEPForm()
        {
            InitializeComponent();
            MinimumSize = t_minSize;
        }

        public SEPForm(string name, string titleText, Type type, string text,
            Size size, Panel flPanelButtons, Panel panelContent) : this()
        {
            _type = type;
            _panelButtons = flPanelButtons;
            _titleText = titleText;
            _panelMain = panelContent;
            Text = text;
            Size = size;
            Name = name;
            SetUpForm();
        }

        private void SetUpForm()
        {
            SetUpTitle();
            SetUpPanelMain();
            SetUpButtons();
            SetUpLayouts();
        }

        private void SetUpLayouts()
        {
            this.Controls.AddRange(new Control[] { this._panelMain, this._panelButtons, this._labelTitle});
        }

        private void SetUpButtons()
        {
            this._panelButtons.Width = (int) (MathF.Min(t_defaultDockSideWidthPercent * this.Width, 150f + t_defaultMargin / 2));
        }

        private void SetUpTitle()
        {
            _labelTitle.Text = _titleText;
            _labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            _labelTitle.Height = 50;
            //_labelTitle.Location = new Point(x: (Size.Width - _labelTitle.Size.Width) / 2, y: t_defaultMargin);
            _labelTitle.Font = new(Font.FontFamily, t_defaultTitleFontSize, FontStyle.Bold);
            _labelTitle.Dock = DockStyle.Top;
        }

        private void SetUpPanelMain()
        {
            this._panelMain.Dock = DockStyle.Fill;
            this._panelMain.Padding = new Padding(t_defaultMargin / 2);
        }

        //private void SEPForm_Load(object sender, EventArgs e)
        //{

        //}

        //private void wq(object sender, EventArgs e)
        //{

        //}
    }
}
