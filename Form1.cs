﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgectName
{
    public partial class Form1 : Form
    {
        private AddButton formAddButton;
        public Form1()
        {
            InitializeComponent();
            this.formAddButton = new AddButton();
            formAddButton.RaiseCustomEvent += FormAddButton_RaiseCustomEvent;
           
        }

        private void FormAddButton_RaiseCustomEvent(object sender, CustomEventArgs e)
        {
            label1.Text = e.Message;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            label1.Text = e.ClickedItem.Text;
            if (e.ClickedItem.Name== "addButton")
            {
                this.formAddButton.Visible = true;
            }
        }
    }
}
