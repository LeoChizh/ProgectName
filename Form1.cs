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
        const string WarningText = "Внимание! Включен режим удаления кнопок";
        private readonly Items items;
        private AddButton formAddButton;
        private readonly List<Button> itemsButtons;
        int i;
        private bool _isDeleted;

        public Form1()
        {
           
            InitializeComponent();
            itemsButtons = new List<Button>();
            Warning.Text = string.Empty;
            RefreshFlowLayoutPanel();
            dataGridView1.CellMouseDown += DataGridView1_CellMouseDown;
            items = new Items();
            i = 0;
        }

        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            label1.Text = (i++).ToString();
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
    }
}
