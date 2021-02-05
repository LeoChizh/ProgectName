﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ProgectName
{
    public partial class AddButton : Form
    {



        public AddButton()
        {
            InitializeComponent();
            textBox1.KeyDown += AddButton_KeyDown;
            textBox2.KeyDown += AddButton_KeyDown;
        }

        private void AddButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox2.Text.Length > 0 && textBox1.Text.Length > 0)
            {
                button_OK.PerformClick();
            }
            else if (e.KeyCode == Keys.Enter && textBox1.Text.Length > 0)
            {
                textBox2.Focus();

            }

        }

        public delegate void CustomEventHandler(object sender, EventArgs e);
        public event EventHandler RaiseCustomEvent;

        private void button_OK_Click(object sender, EventArgs e)
        {
            //int code;
            //int.TryParse(textBox2.Text, out code);
            string buttonName = Functions.CreateButtonName(FileFunctions.NumberOfButtonsInConfigFile());
            OnRaiseCustomEvent(new EventArgs());

            FileFunctions.Write(textBox1.Text + "\t" + buttonName);

            Close();
        }

        protected virtual void OnRaiseCustomEvent(EventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler raiseEvent = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (raiseEvent != null)
            {
                // Format the string to send inside the CustomEventArgs parameter


                // Call to raise the event.
                raiseEvent(this, e);
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
