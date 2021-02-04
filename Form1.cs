using System;
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
        const string WarningText = "Внимание! Включен режим удаления кнопок";
       
        private AddButton formAddButton;
        private List<Button> itemsButtons;

        private bool _isDeleted;

        public Form1()
        {
         
            InitializeComponent();
            itemsButtons = new List<Button>();
            Warning.Text = string.Empty;
        }

        private void FormAddButton_RaiseCustomEvent(object sender, CustomEventArgs e)

        {
            label1.Text = e.ItemName + "\ncode " + e.ButtonName;
            Button button = new Button();
            button.Text = e.ItemName;
            button.Name = e.ButtonName;
            itemsButtons.Add(button);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


            formAddButton = new AddButton();
            formAddButton.RaiseCustomEvent += FormAddButton_RaiseCustomEvent;
            if (e.ClickedItem.Name == "addButton")
            {

                formAddButton.Visible = true;
            }
            // used this to refresh buttons 
            if (e.ClickedItem.Name == "refresh")
            {
                label1.Text = null;

                WriteAndRead.Read(itemsButtons);

                for (int i = flowLayoutPanel1.Controls.Count; i < itemsButtons.Count; i++)
                {
                    label1.Text = label1.Text + " " + itemsButtons[i].Text;

                    flowLayoutPanel1.Controls.Add(itemsButtons[i]);
                    itemsButtons[i].Click += Form1_Click;
                }
            }
            else if (e.ClickedItem.Name == "deleteBtn")
            {
                _isDeleted = !_isDeleted;

                if (_isDeleted == true)
                {
                    Warning.Text = WarningText;
                }
                else
                    Warning.Text = string.Empty;
            }

        }

        private void Form1_Click(object sender, EventArgs e)
        {

            Button s = sender as Button;


            if (_isDeleted == true)
            {
                for (var i = 0; i < flowLayoutPanel1.Controls.Count; i++)
                {
                    if (flowLayoutPanel1.Controls[i].Name == s.Name)
                        flowLayoutPanel1.Controls.Remove(s);
                }

                WriteAndRead.DeleteString(s.Text + s.Name);
                ((Button)sender).Dispose();
                return;
            }


            label2.Text = s.Name;
            string temp = s.Name + "\t" + s.Text + "\t" + DateTime.Now;

            WriteAndRead.WriteToBase(temp);
        }
    }
}
