using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace ProgectName
{
    
      
    public static class FileFunctions
    {

        const string _path = "Config.txt";
        const string _pathBase = "TextBase.txt";

        public static void Write(string s)
        {
            using StreamWriter sw = new StreamWriter(new FileStream(_path, FileMode.Append));
            sw.WriteLine(s);
        }

        public static void WriteToBase(string s)
        {
            using StreamWriter sw = new StreamWriter(new FileStream(_pathBase, FileMode.Append));
            sw.WriteLine(s);
        }

        public static void Read(List<Button> example)
        {
            example.Clear();
            StreamReader sr = new StreamReader(new FileStream(_path, FileMode.OpenOrCreate));
            while (!sr.EndOfStream)
            {
                var res = sr.ReadLine();
                string[] vs = res.Split('\t');
                if (vs.Length ==3)
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

        public static void DeleteString(string buttonText)
        {
            string tempFile = "temp.txt";
            StreamReader sr = new StreamReader(new FileStream(_path, FileMode.Open));
            StreamWriter sw = new StreamWriter(tempFile);

            while (!sr.EndOfStream)
            {
                string temp = sr.ReadLine();
                string currentButtonName = temp.Substring(0, temp.IndexOf('\t'));
                int i = 0;
                if (currentButtonName != buttonText)
                {
                    string[] vs = temp.Split('\t');
                    temp = vs[0] + '\t' + Functions.CreateButtonName(i) + '\t' + vs[2];
                    i++;
                    sw.WriteLine(temp);
                }
            }

            sr.Close();
            sw.Close();

            File.Delete(_path);
            File.Copy(tempFile, _path);
            File.Delete(tempFile);

        }
        
        public static int NumberOfButtonsInConfigFile()
        {
            int i = 0;
            StreamReader sr = new StreamReader(new FileStream(_path, FileMode.OpenOrCreate));
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                i++;
            }
            sr.Close();
            return i;
        }
    }
    public static class Functions
    {
        public static string CreateButtonName (int n)
            {
            return ("itemButton_" + n.ToString());
            }
    }
}
