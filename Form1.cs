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
        private readonly Items items;
        private AddButton formAddButton;
        private readonly List<Button> itemsButtons;
        private bool _isDeleted;
        private readonly Check check;
        

        public Form1()
        {
           
            InitializeComponent();
            itemsButtons = new List<Button>();
            Warning.Text = string.Empty;
            RefreshFlowLayoutPanel();
            dataGridView1.CellMouseDown += DataGridView1_CellMouseDown;
            items = new Items();
            check = new Check();
            check.RiseCheck_Changed += Check_RiseCheck_Changed;
           
        }

        private void Check_RiseCheck_Changed(object sender, EventArgs e)
        {
            check.ShowInDataGridView(dataGridView1, label1);
        }

       

        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            label1.Text = (check.total).ToString();
        }

        

        private void FormAddButton_RaiseCustomEvent(object sender, EventArgs e)

        {
            RefreshFlowLayoutPanel();


        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


            formAddButton = new AddButton();
            formAddButton.RaiseRefreshEvent += FormAddButton_RaiseRefreshEvent;
            
            if (e.ClickedItem.Name == "addButton")
            {

                formAddButton.Visible = true;
                formAddButton.RaiseRefreshEvent += FormAddButton_RaiseCustomEvent;
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

        private void FormAddButton_RaiseRefreshEvent(object sender, ItemEventArgs e)
        {
            items.AddItem(e.Item);
        }

        private void Form1_Click(object sender, EventArgs e)
        {

            Button s = sender as Button;


            if (_isDeleted == true)
            {
                for (var i = 0; i < flowLayoutPanel1.Controls.Count; i++)
                {

                    if (flowLayoutPanel1.Controls[i].Name == s.Name)
                    { 
                        FileFunctions.DeleteString(s.Text);
                        items.DeleteItem(s.Text);
                        RefreshFlowLayoutPanel();
                    }
                        
                }

                return;
            }
            else
            {
                string temp = s.Name + "\t" + s.Text + "\t" + DateTime.Now;
                FileFunctions.WriteToBase(temp);
                check.AddItem(items.GetItem(s.Text));
            }

            
        }
        private void RefreshFlowLayoutPanel()
        {
            
            
            for (int i = 0; i < itemsButtons.Count; i++)
            {
                flowLayoutPanel1.Controls.Remove(itemsButtons[i]);
                itemsButtons[i].Click -= Form1_Click;
            }
            FileFunctions.Read(itemsButtons);
            for (int i = 0; i < itemsButtons.Count; i++)
            {

                flowLayoutPanel1.Controls.Add(itemsButtons[i]);
                itemsButtons[i].Click += Form1_Click;
            }

        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (check.total != 0)
            {
                check.OrderTime = DateTime.Now;
                check.WriteToFile_txt();
                check.Clear();
            }
                
        }
    }
}
