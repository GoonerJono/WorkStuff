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
            char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r', '\"' };
            var splitText = text.Split(chars, StringSplitOptions.RemoveEmptyEntries);
            var WordsCounted = CountWords(splitText);
            Console.WriteLine($"Total count: {WordsCounted.Count}");
            var sortedDict = Top50Count(WordsCounted);
            Console.WriteLine($"Sorted word count");
            foreach (var t in sortedDict)
            {
                Console.WriteLine($"Total occurrences of {t.Key}: {t.Value}");
            }
            var greaterThanSix = Top50CountLengthSix(WordsCounted); 
            Console.WriteLine($"Top 50 words length greater than six in length");
            foreach (var t in greaterThanSix)
            {
                Console.WriteLine($"Total occurrences of {t.Key}: {t.Value}");
            }
            sw.Stop();
            Console.WriteLine($"Time taken to run: {sw.Elapsed}");
            Console.ReadLine();
        }

        private static Dictionary<string, int> CountWords(string[] words)
        {

            Dictionary<string, int> wordandcount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordandcount.ContainsKey(word))
                {
                    wordandcount.Add(word, 1);
                }
                else
                {
                    wordandcount[word] += 1;
                }
            }
            return wordandcount;
        }

        private static Dictionary<string, int> Top50Count(Dictionary<string, int> ListValues)
        {
          return ListValues.OrderByDescending(entry => entry.Value)
                     .Take(50)
                     .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private static Dictionary<string, int> Top50CountLengthSix(Dictionary<string, int> ListValues)
        {
            return ListValues.Where(entry => entry.Key.Length > 6)
                     .OrderByDescending(entry => entry.Value)
                     .Take(50)
                     .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
