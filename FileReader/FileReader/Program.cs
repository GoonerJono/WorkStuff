using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var Dicts = new Dictionary<string, string>();
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\xboxl\OneDrive\Documents\university"))
            {
                string contents = File.ReadAllText(file);
                Dicts.Add("name",contents);
            }

            foreach(var dict in Dicts)
            {
                Console.WriteLine($"{dict.Value}");
            }
            Console.ReadLine();
        }
    }
}
