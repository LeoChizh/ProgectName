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
        private AddButton formAddButton;
        public Form1()
        {
            InitializeComponent();
            itemsButtons = new List<Button>();


        }

        private void FormAddButton_RaiseCustomEvent(object sender, CustomEventArgs e)

        {
            
            label1.Text = e.ItemName+"\ncode "+e.Code;
            Button button = new Button();
            button.Text = e.ItemName;
            button.Name = e.Code.ToString();
            this.itemsButtons.Add(button);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            label1.Text = e.ClickedItem.Text;
            if (e.ClickedItem.Name== "addButton")
            {
                this.formAddButton.Visible = true;
            }
            if (e.ClickedItem.Name == "refresh")
            {
                label1.Text = null;

                for (int i=0; i<itemsButtons.Count; i++)
                {
                    label1.Text = label1.Text +" " +itemsButtons[i].Text;
                }
            }

        }
    }
}
