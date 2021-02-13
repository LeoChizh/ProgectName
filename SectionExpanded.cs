using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using System.Text;

namespace ProgectName
{
    
    class SectionExpanded
    {
        public  readonly Items items;
        readonly List<Section> sections;
        public  List<string> mainList;
        public const string path = "Section.txt";

        public SectionExpanded()
        {
            items = new Items();
            mainList = new List<string>();
            sections = new List<Section>();
        }

        public void WriteToFile_txt()
        {
            StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create));
            foreach (Item item in items)
                sw.WriteLine(item.itemName.ToString());
            sw.WriteLine('\t');
            foreach (Section s in sections)
                sw.WriteLine(s);
            sw.WriteLine('\t');
            foreach (string s in mainList)
                sw.WriteLine(s);

            sw.Close();

        }
    }
}
