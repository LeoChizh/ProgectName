using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ProgectName
{
    public partial class Form1 : Form
    {
        private Items items;
        
        private SectionsEditor sectionsEditor;
        private readonly List<Button> itemsButtons;
        private readonly Check check;
        private readonly SectionExpanded sectionedItems;
        

        public Form1()
        {
           
            InitializeComponent();
            sectionedItems = new SectionExpanded();
            sectionedItems.WriteToFile_txt();
            itemsButtons = new List<Button>();
            Warning.Text = string.Empty;
            RefreshFlowLayoutPanel();
            dataGridView1.CellMouseDown += DataGridView1_CellMouseDown;
            items = new Items();
            check = new Check();
            check.RiseCheck_Changed += Check_RiseCheck_Changed;
            dataGridView1.AllowUserToAddRows = false;

           
        }

       

        private void Check_RiseCheck_Changed(object sender, EventArgs e)
        {
            check.ShowInDataGridView(dataGridView1, label1);
        }

       

        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (e.ColumnIndex == 1)
                check.AddItem(e.RowIndex);
            if (e.ColumnIndex == 2)
                check.DeleteItem(e.RowIndex);
            

        }

        

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {   
           
            if (e.ClickedItem.Name == "editSections")
            {
                sectionsEditor = new SectionsEditor
                {
                    Visible = true
                };
                sectionsEditor.FormClosed += SectionsEditor_FormClosed;
            }

        }

        private void SectionsEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            sectionsEditor.FormClosed -= SectionsEditor_FormClosed;
            items.ReadFromFile();
            RefreshFlowLayoutPanel();
        }

        private void Form1_Click(object sender, EventArgs e)
        {

            Button s = sender as Button;
            check.AddItem(items.GetItem(s.Text));

        }
        private void RefreshFlowLayoutPanel()
        {
            
            
            for (int i = 0; i < itemsButtons.Count; i++)
            {
                flowLayoutPanel1.Controls.Remove(itemsButtons[i]);
                itemsButtons[i].Click -= Form1_Click;
            }
            Read(itemsButtons);
           
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

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            if (check.total != 0)
            {
                check.Clear();
            }
        }

        public static void Read(List<Button> example)
        {
            example.Clear();
            StreamReader sr = new StreamReader(new FileStream(Items.path, FileMode.OpenOrCreate));
            while (!sr.EndOfStream)
            {
                var res = sr.ReadLine();
                string[] vs = res.Split('\t');
                if (vs.Length == 3)
                {
                    Button button = new Button
                    {
                        Name = vs[1],
                        Text = vs[0]
                    };
                    example.Add(button);
                }
            }
            sr.Close();
        }
    }
}
