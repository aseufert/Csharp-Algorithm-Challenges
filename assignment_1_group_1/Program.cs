using System;

namespace assignment_1_group_1
{
    class Program
    {
        public static string StringReverse(string s)
        {
            string result = "";
            string temp = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    result = temp + " " + result;
                    temp = "";
                }
                else
                    temp += s[i];
            }
            result = temp + " " + result;

            Console.WriteLine(result);
        }
        static void Main(string[] args)
        {
            string output = StringReverse("University of South Florida");
            Console.WriteLine(output);
        }
    }
}