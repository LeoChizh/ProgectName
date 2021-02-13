using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace ProgectName
{

    public struct Item: IEqualityComparer
    {
        public string itemName;
        public string itemButtonName;
        public int itemPrise;
        public new bool Equals(object x, object y)
        {
            if (x is Item x1 && y is Item y1)
            {
                if (x1.itemName == y1.itemName && x1.itemPrise == y1.itemPrise)
                    return true;
                else return false;
            }
            else return false;
        }

        public int GetHashCode(object obj)
        {
            if (obj is Item x)
            {
                int n = x.itemName.Length;
                string hashCode = string.Empty;
                if (n == 0)
                {
                    return 0;
                }
                else
                {
                    for (int i = 0; i < n && i < 4; i++)
                        hashCode += x.itemName[i];
                    return int.Parse(hashCode);
                }
            }
            return 0;
        }

        public override string ToString()
        {
            string temp = null;
            temp += itemName + '\t' + itemButtonName + '\t' + itemPrise;
            return temp;
        }
        public void ReWriteNames( int n)
        {
            itemButtonName = "itemButton_" + n.ToString();
        }


    }
    class Items: IList<Item>
    {
        
        private readonly List<Item> items;
        public const string path = "Items.txt";

        public Items()
        {
            items = new List<Item>();
            ReadFromFile();
        }
        public void ReadFromFile()
        {
            items.Clear();
            StreamReader sr = new StreamReader(new FileStream(path, FileMode.OpenOrCreate));
            while (!sr.EndOfStream)
            {
                var res = sr.ReadLine();
                string[] vs = res.Split('\t');
                if (vs.Length == 3)
                {
                    Item item = new Item
                    {
                        itemButtonName = vs[1],
                        itemName = vs[0],
                        itemPrise = Int32.Parse(vs[2])
                    };
                    items.Add(item);
                }
            }
            sr.Close();
        }
        public Item this[int index] { get => this.items[index]; set => items[index] = new Item(); }

        public int Count => items.Count;

        public bool IsReadOnly => true;

        
     
        public void Add(Item item)
        {
            item.ReWriteNames(Count);
            items.Add(item);
            
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(Item item)
        {
            foreach (Item item1 in items)
            {
                if (item.Equals(item1))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            if (arrayIndex>= items.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                for (int i = 0; i < items.Count-arrayIndex; i++)
                {
                    array[i] = items[arrayIndex + i];
                }
            }    
           
        }

        public void DeleteItem(string name)
        {
            int n = items.Count;
            for (int i = 0; i < n; i++)
            {
                if (items[i].itemName == name)
                {
                    items.RemoveAt(i);
                    break;
                }
                    
            }
            n = items.Count;
            for (int i = 0; i < n; i++)
            {
                _ = new Item();
                Item temp = items[i];
                temp.ReWriteNames(i);
                items.Insert(i, temp);
                items.RemoveAt(i + 1);
            }
            SaveInFile();

        }

        

        public IEnumerator<Item> GetEnumerator()
        {
            return items.GetEnumerator();
        }


        public Item GetItem(string name)
        {
            int flag = -1;
            for (int i = 0; i < items.Count; i++)
                if (items[i].itemName == name)
                    flag = i;
            return items[flag];
        }

        public int IndexOf(Item item)
        {
            for (int i = 0; i < items.Count; i++)
                if (items[i].Equals(item))
                    return i;
            return -1;

        }

        public void Insert(int index, Item item)
        {
            items.Insert(index,item);
        }

        public bool Remove(Item item)
        {
            return  items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public void SaveInFile()
        {

            using StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create));
            for (int i = 0; i < items.Count; i++)
            {
                sw.WriteLine(items[i].ToString());
            }

        }


    }
    

    public class ItemEventArgs: EventArgs
    {
        public Item Item { set; get; }
        public ItemEventArgs(Item item)
        {
            Item = item;
        }
    }
}
