using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProgectName
{

    public struct Item
    {
        public string itemName;
        public string itemButtonName;
        public int itemPrise;
    }
    class Items
    {
        
        private readonly List<Item> items;
       
        public Items()
        {
            items = new List<Item>();
            StreamReader sr = new StreamReader(new FileStream(FileFunctions._path, FileMode.OpenOrCreate));
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

        public void AddItem(string name, string buttonName, int prise)
        {
            Item temp = new Item
            {
                itemButtonName = buttonName,
                itemName = name,
                itemPrise = prise
            };
            items.Add(temp);
        }
        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public void DeleteItem(string name)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].itemName == name)
                    items.RemoveAt(i);
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
