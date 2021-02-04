using System;
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
        }

        public delegate void CustomEventHandler(object sender, CustomEventArgs args);
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        private void button_OK_Click(object sender, EventArgs e)
        {
            //int code;
            //int.TryParse(textBox2.Text, out code);
            string buttonName = Functions.CreateButtonName(WriteAndRead.NumberOfButtonsInConfigFile());
            OnRaiseCustomEvent(new CustomEventArgs(textBox1.Text.ToString(),buttonName ));

            WriteAndRead.Write(textBox1.Text + "\t" + buttonName);

            Close();
        }

        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<CustomEventArgs> raiseEvent = RaiseCustomEvent;

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
