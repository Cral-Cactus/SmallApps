using System;
using System.Collections.Generic;
using System.Linq;

namespace CountTimesFound
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            Console.WriteLine("end = END");

            while (true)
            {
                string input = Console.ReadLine().ToLower();

                if (input == "end")
                {
                    break;
                }

                if (wordCounts.ContainsKey(input))
                {
                    wordCounts[input]++;
                }
                else
                {
                    wordCounts[input] = 1;
                }
            }

            var sortedWords = wordCounts.OrderByDescending(x => x.Value);

            foreach (var item in sortedWords)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}