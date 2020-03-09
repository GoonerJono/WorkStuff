using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Parser;

namespace CountingWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            using (Parser parser = new Parser(@"C:\Users\xboxl\OneDrive\Documents\2600-0.txt"))
            {
                using (TextReader reader = parser.GetText())
                {
                     text = reader.ReadToEnd();
                }
            }
            // var test = "This is a new sentence used to determine how many words are in the sentence";
            char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r' };
            var newtest = text.Split(chars);
            var testing = CountWords(newtest);
            Console.WriteLine($"Total count: {testing.Count}");
            foreach(var t in testing)
            {
                Console.WriteLine($"Total occurrences of {t.Key}: {t.Value}");
                Console.WriteLine();
            }
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
