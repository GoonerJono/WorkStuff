using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CountingWords
{
    class Program
    {
        public static char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r', '\"' };
        public static Stopwatch sw = new Stopwatch();
        public static string filePath;
        static void Main(string[] args)
        {
            sw.Start();
            Console.WriteLine("Enter a file path");
            filePath = Console.ReadLine();
            if (File.Exists(filePath))
            {
                ProcessFile(filePath);
            }
            else
            {
                Console.WriteLine("Please enter valid file path");
                filePath = Console.ReadLine();
                ProcessFile(filePath);
            }
           
        }

        private static void ProcessFile(string FIlePath)
        {
            string readFileString = StreamReader(filePath);
            var splitFileText = readFileString.Split(chars, StringSplitOptions.RemoveEmptyEntries);
            var wordsCount = CountWords(splitFileText);
            Console.WriteLine($"Total count: {wordsCount.Count}");
            var sortedDict = Top50Count(wordsCount);
            Console.WriteLine($"Sorted word count");
            foreach (var t in sortedDict)
            {
                Console.WriteLine($"Total occurrences of {t.Key}: {t.Value}");
            }
            var greaterThanSix = Top50CountLengthSix(wordsCount);
            Console.WriteLine($"Top 50 words length greater than six in length");
            foreach (var t in greaterThanSix)
            {
                Console.WriteLine($"Total occurrences of {t.Key}: {t.Value}");
            }
            sw.Stop();
            Console.WriteLine($"Time taken to run: {sw.Elapsed}");
            Console.WriteLine("To close press c");
            var entervalue = Console.ReadLine();
            if (entervalue.ToLower() == "c")
            {
                Environment.Exit(0);
            }
        }
        private static string StreamReader(string filePath)
        {
            using (StreamReader stream = new StreamReader(filePath))
            {
                var text = stream.ReadToEnd();
                var nextext = Regex.Replace(text, @"[^0-9a-zA-Z]", " ");
                return nextext;
            }
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
