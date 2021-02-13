using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProgectName
{
    struct Section : IEqualityComparer
    {
        public string sectionName;
        public List<string> itemsNames;
        public Section(string name, List<string> items)
        {
            sectionName = name;
            itemsNames = items;
        }
        public override string ToString()
        {
            string temp = string.Empty;
            temp += sectionName;
            foreach (string s in itemsNames)
                temp += '\t' + s;
            return temp;
        }
        public static Section FromString(string s)
        {
            if (s != null || s != string.Empty)
            {
                Section sections = new Section();
                string[] vs = s.Split('\t');
                sections.sectionName = vs[0];
                for (int i = 1; i < vs.Length; i++)
                {
                    sections.itemsNames.Add(vs[i]);
                }
                return sections;
            }
            else
                throw new Exception("Wrong string: null or empty");
        }

        public new bool Equals(object x, object y)
        {
            if (x is Section x1 && y is Section y1)
            {
                if (x1.sectionName == y1.sectionName)
                    return true;
                else return false;
            }
            else return false;
        }

        public int GetHashCode(object obj)
        {
            if (obj is Section x)
            {
                int n = x.sectionName.Length;
                string hashCode = string.Empty;
                if (n == 0)
                {
                    return 0;
                }
                else
                {
                    for (int i = 0; i < n && i < 4; i++)
                        hashCode += x.sectionName[i];
                    return Int32.Parse(hashCode);
                }
            }
            return 0;
        }
    }
}
