using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ProgectName
{
    class Check
    {
        public const string path = "Check_list.txt";
        public List<Item> items;
        public List<int> quantity;
        public List<int> multiply;
        public int total;
        public DateTime OrderTime;
        public event EventHandler RiseCheck_Changed;

        public Check()
        {
            items = new List<Item>();
            quantity = new List<int>();
            multiply = new List<int>();
            OrderTime = new DateTime();
        }

        public void AddItem(Item item)
        {
            if (items.Contains(item))
            {
                int i = items.IndexOf(item);
                quantity[i]++;
                multiply[i] = quantity[i] * items[i].itemPrise;
                total += item.itemPrise;
            }
            else
            {
                items.Add(item);
                quantity.Add(1);
                multiply.Add(item.itemPrise);
                total += item.itemPrise;
            }
            RiseCheck_Changed(this,new EventArgs());
        }

        internal void ShowInDataGridView(DataGridView dataGridView1, Label label)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = items[i].itemName;
                string s = quantity[i].ToString() + 'x' + items[i].itemPrise.ToString() + '=' + multiply[i].ToString();
                dataGridView1.Rows[i].Cells[3].Value = s;
            }
            label.Text = "Сумма:"+'\t'+total.ToString();



        }

        internal void AddItem(int rowIndex)
        {
            if (rowIndex < items.Count)
            {
                quantity[rowIndex]++;
                multiply[rowIndex] = quantity[rowIndex] * items[rowIndex].itemPrise;
                total += items[rowIndex].itemPrise;
            }
            RiseCheck_Changed(this, new EventArgs());
        }

        internal void DeleteItem(int rowIndex)
        {
            if (rowIndex < items.Count)
            {
                if (quantity[rowIndex] == 1)
                {
                    total -= items[rowIndex].itemPrise;
                    items.RemoveAt(rowIndex);
                    quantity.RemoveAt(rowIndex);
                    multiply.RemoveAt(rowIndex);
                    
                }
                else
                {
                    quantity[rowIndex]--;
                    multiply[rowIndex] = quantity[rowIndex] * items[rowIndex].itemPrise;
                    total -= items[rowIndex].itemPrise;
                }
            }
            RiseCheck_Changed(this, new EventArgs());
        }

        protected virtual void OnRiseCheck_Changed(EventArgs e)
        {
            RiseCheck_Changed?.Invoke(this, e);
        }

        public void DeleteItem(Item item)
        {
            if (items.Contains(item))
            {
                int i = items.IndexOf(item);
                if (quantity[i] == 1)
                {
                    total -= items[i].itemPrise;
                    items.RemoveAt(i);
                    quantity.RemoveAt(i);
                    multiply.RemoveAt(i);
                    
                }
                else
                {
                    quantity[i]--;
                    multiply[i] = quantity[i] * items[i].itemPrise;
                    total -= items[i].itemPrise;
                }
                RiseCheck_Changed(this, new EventArgs());
            }
        }

        public void WriteToFile_txt()
        {
            string s="Check begin \n";
            for (int i =0; i<items.Count; i++)
            {
                s += items[i].itemName + '\t' + quantity[i] + '*' + items[i].itemPrise + '=' + multiply[i] + '\n';
            }
            s += "Total:\t" + total + '\t' + "Time:" + '\t'+OrderTime+ + '\n';
            using StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Append));
            sw.WriteLine(s);
        }

        public void Clear()
        {
            items.Clear();
            quantity.Clear();
            multiply.Clear();
            total = 0;
            OrderTime = DateTime.MinValue;
            RiseCheck_Changed(this, new EventArgs());
        }
    }
}
