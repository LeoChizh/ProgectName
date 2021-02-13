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
        #region Event
        public event EventHandler<ItemEventArgs> RaiseAddItemEvent;

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int prise)){
                Item item = new Item
                {
                    itemName = textBox1.Text,
                    itemPrise = prise,
                };

                OnRaiseRefreshEvent(new ItemEventArgs(item));
                Close();
            }
            else 
                MessageBox.Show("Неправильный формат цены", "Ошибка ввода", MessageBoxButtons.OK);
        }
        
        protected virtual void OnRaiseRefreshEvent(ItemEventArgs e)
        {
            RaiseAddItemEvent?.Invoke(this, e);
        }
        #endregion 
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
