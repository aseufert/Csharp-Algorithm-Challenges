using System;
using System.Linq;
using System.Collections.Generic;

namespace assignment_1_group_1
{
    class Program
    {
        static void question_four()
        {
            Console.WriteLine("Input string:");
            string input = Console.ReadLine();
            // iniitialize objects
            Dictionary<char, int> data = new Dictionary<char, int>();
            string output = "";

            foreach (char c in input)
            {
                bool added = data.TryAdd(c, 1);
                // increment on conflict
                if (!added) {
                    data[c] += 1;
                }
            }
            foreach (KeyValuePair<char, int> pair in data.OrderByDescending(r => r.Value))
            {
                // creates new string for each char based on value count
                // and appends to output string
                output += new string(pair.Key, pair.Value); 
            }
            Console.WriteLine(output);
        }
        static void Main(string[] args)
        {
            question_four();
        }
    }
}
