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

        public event EventHandler RaiseRefreshEvent;

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int prise)){
                string buttonName = Functions.CreateButtonName(FileFunctions.NumberOfButtonsInConfigFile());
                FileFunctions.Write(textBox1.Text + "\t" + buttonName + '\t' + prise);
                OnRaiseRefreshEvent(new EventArgs());
                Close();
            }
            else 
                MessageBox.Show("Неправильный формат цены", "Ошибка ввода", MessageBoxButtons.OK);
        }
        
        protected virtual void OnRaiseRefreshEvent(EventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            RaiseRefreshEvent?.Invoke(this, e);
        }
        
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
