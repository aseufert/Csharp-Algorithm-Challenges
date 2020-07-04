using System;
using System.Collections.Generic;

namespace assignment_1_group_1
{
    class Program
    {
        static string StringReverse(string s)
        {
            LinkedList<string> final = new LinkedList<string>();
            string currentWord = "";
            // single for loop is O(n)
            for (var i = s.Length; i > 0; i--)
            {
                char value = s[i - 1];
                if (value == ' ')
                {
                    // linked list AddFirst is O(1)
                    final.AddFirst(currentWord);
                    currentWord = "";
                } else
                {
                    // string appending is O(1)
                    currentWord += value;
                }
            }
            final.AddFirst(currentWord);

            return string.Join(" ", final);
        }
        static void Main(string[] args)
        {
            string msg = StringReverse("University of South Florida");
            Console.WriteLine(msg);
        }
    }
}
