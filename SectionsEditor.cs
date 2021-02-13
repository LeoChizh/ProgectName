using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProgectName
{
    public partial class SectionsEditor : Form
    {
        private AddButton formAddButton;
        SectionExpanded section;
        public SectionsEditor()
        {

            InitializeComponent();

            dGVItems.AllowUserToAddRows = false;
            dGVSectionItems.AllowUserToAddRows = false;


            section = new SectionExpanded();
            DGVItemRefresh();
            bntAddItem.Click += BntAddItem_Click;
            this.FormClosing += SectionsEditor_FormClosing;
            bntDeleteItem.Click += BntDeleteItem_Click;
            
        }

        private void BntDeleteItem_Click(object sender, EventArgs e)
        {
            if (dGVItems.SelectedCells.Count != 1 || dGVItems.SelectedCells[0].ColumnIndex != 0)
            {
                MessageBox.Show("Выберете одно наименование", "Ошибка ввода", MessageBoxButtons.OK);
            }
            else
            {
                section.items.DeleteItem(dGVItems.SelectedCells[0].Value.ToString());
                DGVItemRefresh();
            }
            
        }

        private void FormAddButton_RaiseAddItemEvent(object sender, ItemEventArgs e)
        {
            section.items.Add(e.Item);
            DGVItemRefresh();
            formAddButton.RaiseAddItemEvent -= FormAddButton_RaiseAddItemEvent;
        }

        private void SectionsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            section.items.SaveInFile();
        }

        private void BntAddItem_Click(object sender, EventArgs e)
        {
            formAddButton = new AddButton
            {
                Visible = true
            };
            formAddButton.RaiseAddItemEvent += FormAddButton_RaiseAddItemEvent;
            DGVItemRefresh();
        }

        private void DGVItemRefresh()
        {
            
            dGVItems.Rows.Clear();
            int i = 0;
            foreach (Item it in section.items)
            {
                dGVItems.Rows.Add();
                dGVItems.Rows[i].Cells[0].Value = it.itemName;
                dGVItems.Rows[i].Cells[2].Value = it.itemPrise;
                i++;
            }

        }

        private void dGVItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string temp = dGVItems.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (e.ColumnIndex == 1 && checkBox1.Checked)
            {
                bool flag = true;
                foreach(string s in section.mainList)
                {
                    if (s == temp)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    section.mainList.Add(temp);
                    DGVSetionedItemsRefresh();
                }
               
            }
        }

        private void DGVSetionedItemsRefresh()
        {
            dGVSectionItems.Rows.Clear();
            int i = 0;
            foreach (string s in section.mainList)
            {
                dGVSectionItems.Rows.Add();
                dGVSectionItems.Rows[i].Cells[0].Value = s;
                i++;
            }
        }

        private void dGVSectionItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string temp = dGVSectionItems.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (e.ColumnIndex == 1 && checkBox1.Checked)
            {
                section.mainList.Remove(temp);
                DGVSetionedItemsRefresh();

            }
        }
    }
}
