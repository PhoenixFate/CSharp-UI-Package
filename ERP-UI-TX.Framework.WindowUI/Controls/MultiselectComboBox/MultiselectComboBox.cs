#region COPYRIGHT
//
//     THIS IS GENERATED BY TEMPLATE
//     
//     AUTHOR  :     ROYE
//     DATE       :     2010
//
//     COPYRIGHT (C) 2010, TIANXIAHOTEL TECHNOLOGIES CO., LTD. ALL RIGHTS RESERVED.
//
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace TX.Framework.WindowUI.Controls
{
    [ToolboxBitmap(typeof(ComboBox))]
    [ToolboxItem(true)]
    public partial class MultiselectComboBox : TXPopupComboBox
    {
        private MultiselectComboBoxListControl _CheckBoxComboBoxListControl;
        private string _DisplayMemberSingleItem = null;
        private CheckBoxProperties _CheckBoxProperties;

        public event EventHandler CheckBoxCheckedChanged;

        public MultiselectComboBox()
            : base()
        {
            InitializeComponent();
            _CheckBoxProperties = new CheckBoxProperties();
            _CheckBoxProperties.PropertyChanged += new EventHandler(_CheckBoxProperties_PropertyChanged);
            _CheckBoxComboBoxListControl = new MultiselectComboBoxListControl(this);
            _CheckBoxComboBoxListControl.Items.CheckBoxCheckedChanged += new EventHandler(Items_CheckBoxCheckedChanged);
            _CheckBoxComboBoxListControl.Dock = DockStyle.Fill;
            MultiselectComboBoxListControlContainer container = new MultiselectComboBoxListControlContainer();
            container.Padding = new Padding(4, 0, 0, 14);
            container.Controls.Add(_CheckBoxComboBoxListControl);
            DropDownControl = container;
            PopupDropDown.Resizable = true;
            this.Click += new EventHandler(MultiselectComboBox_Click);
        }

        void MultiselectComboBox_Click(object sender, EventArgs e)
        {
            this.ShowDropDown();
        }

        private void Items_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            OnCheckBoxCheckedChanged(sender, e);
        }

        protected void OnCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (DropDownStyle != ComboBoxStyle.DropDownList)
            {
                string ListText = string.Empty;
                foreach (MultiselectComboBoxItem Item in _CheckBoxComboBoxListControl.Items)
                {
                    if (Item.Checked)
                    {
                        ListText += string.IsNullOrEmpty(ListText) ? Item.Text : String.Format(", {0}", Item.Text);
                    }
                }
                Text = ListText;
            }

            EventHandler handler = CheckBoxCheckedChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            if (DropDownControl != null)
            {
                Size Size = new Size(Width, DropDownControl.Height);
                PopupDropDown.Size = Size;
            }
            base.OnResize(e);
        }

        public void ClearSelection()
        {
            foreach (MultiselectComboBoxItem Item in CheckBoxItems)
            {
                if (Item.Checked)
                {
                    Item.Checked = false;
                }
            }
        }

        public void UpdateText()
        {
            string ListText = string.Empty;
            foreach (MultiselectComboBoxItem Item in _CheckBoxComboBoxListControl.Items)
            {
                if (Item.Checked)
                {
                    ListText += string.IsNullOrEmpty(ListText) ? Item.Text : String.Format(", {0}", Item.Text);
                }
            }
            Text = ListText;
        }

        private void _CheckBoxProperties_PropertyChanged(object sender, EventArgs e)
        {
            foreach (MultiselectComboBoxItem Item in CheckBoxItems)
            {
                Item.ApplyProperties(CheckBoxProperties);
            }
        }

        [
        Description("The properties that will be assigned to the checkboxes as default values."),
        Browsable(true)
        ]
        public CheckBoxProperties CheckBoxProperties
        {
            get { return _CheckBoxProperties; }
            set
            {
                _CheckBoxProperties = value;
                _CheckBoxProperties_PropertyChanged(this, EventArgs.Empty);
            }
        }

        [Browsable(false)]
        public MultiselectComboBoxItemList CheckBoxItems
        {
            get { return _CheckBoxComboBoxListControl.Items; }
        }

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = value;
                if (!string.IsNullOrEmpty(ValueMember))
                {
                    _CheckBoxComboBoxListControl.SynchroniseControlsWithComboBoxItems();
                }
            }
        }

        public new string ValueMember
        {
            get { return base.ValueMember; }
            set
            {
                base.ValueMember = value;
                if (!string.IsNullOrEmpty(ValueMember))
                {
                    _CheckBoxComboBoxListControl.SynchroniseControlsWithComboBoxItems();
                }
            }
        }

        public string DisplayMemberSingleItem
        {
            get
            {
                if (string.IsNullOrEmpty(_DisplayMemberSingleItem))
                    return DisplayMember;
                else
                    return _DisplayMemberSingleItem;
            }
            set { _DisplayMemberSingleItem = value; }
        }

        [
        Browsable(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
        ]
        public new ObjectCollection Items
        {
            get { return base.Items; }
        }
    }
}