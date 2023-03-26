using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FindWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("Text1.txt");

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            var words = noPunctuationText.Split(new char[] { ' ' });

            var dictWords = new Dictionary<string, int>();

            foreach (var item in words)
            {
                if (!dictWords.ContainsKey(item))
                {
                    dictWords.Add(item, 0);
                }
                else
                {
                    dictWords[item] += 1;
                }
            }

            dictWords.Remove(""); // Костыль :)

            dictWords = dictWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, int> kvp in dictWords.Take(10))
            {
                Console.WriteLine($"Слово: {kvp.Key}. Количество раз: {kvp.Value}");
            }
        }
    }
}
