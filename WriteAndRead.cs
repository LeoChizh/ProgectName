using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace ProgectName
{
    public static class WriteAndRead
    {

        const string _path = "Text.txt";
        const string _pathBase = "TextBase.txt";

        public static void Write(string s)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(_path, FileMode.Append)))
            {
                sw.WriteLine(s);
            }
        }

        public static void WriteToBase(string s)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(_pathBase, FileMode.Append)))
            {
                sw.WriteLine(s);
            }
        }



        public static void Read(List<Button> example)
        {
            example.Clear();

            StreamReader sr = new StreamReader(new FileStream(_path, FileMode.OpenOrCreate));

            while (!sr.EndOfStream)
            {
                var res = sr.ReadLine();
                var inOff = res.IndexOf('\t');
                if (inOff > 0)
                {
                    var item = res.Substring(0, inOff);
                    var code = res.Substring(inOff);
                    Button button = new Button();
                    button.Name = code;
                    button.Text = item;
                    example.Add(button);
                }
            }

            sr.Close();
        }

        public static void DeleteString(string s)
        {
            var str = "temp.txt";
            StreamReader sr = new StreamReader(new FileStream(_path, FileMode.Open));
            StreamWriter sw = new StreamWriter(str);
            var cnt = 0;

            while (!sr.EndOfStream)
            {
                var temp = sr.ReadLine();

                cnt++;
                if (temp == s)
                    continue;
                sw.WriteLine(temp);
            }

            sr.Close();
            sw.Close();

            File.Delete(_path);
            File.Copy(str,_path);
            File.Delete(str);

        }
    }
}
