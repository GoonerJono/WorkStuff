using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CountingWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string text = "";
            using (StreamReader stream = new StreamReader(@"C:\Users\xboxl\OneDrive\Documents\2600-0.txt"))
            {
                 text = stream.ReadToEnd();
            }
            // var test = "This is a new sentence used to determine how many words are in the sentence";
            char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r','"' };
            var newtest = text.Split(chars);
            var testing = CountWords(newtest);
            Console.WriteLine($"Total count: {testing.Count}");
            var sortedDict = testing.OrderByDescending(entry => entry.Value)
                     .Take(50)
                     .ToDictionary(pair => pair.Key, pair => pair.Value);
            Console.WriteLine($"thos sorted dictionary count: {sortedDict.Count}");
            foreach (var t in sortedDict)
            {
                Console.WriteLine($"Total occurrences of {t.Key}: {t.Value}");
                Console.WriteLine();
            }
            sw.Stop();
            Console.WriteLine($"Time taken to run: {sw.Elapsed}");
            Console.ReadLine();
        }

        private static Dictionary<string, int> CountWords(string[] words)
        {
            
            Dictionary<string, int> wordandcount = new Dictionary<string, int>();
            foreach(var word in words)
            {
                if(!wordandcount.ContainsKey(word))
                {
                    wordandcount.Add(word,1);
                } else
                {
                    wordandcount[word] += 1;
                }
            }
            return wordandcount;
        }
    }
}
