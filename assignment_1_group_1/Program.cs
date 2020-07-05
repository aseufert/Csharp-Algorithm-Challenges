using System;

namespace assignment_1_group_1
{
    class Program
    {

        public static string StringReverse(string s)
        {
            string reverse = "";
            string temp = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    temp += s[i];
                }
                if (s[i] == ' ')
                {

                    for (int j = temp.Length - 1; j > -1; j--)
                    {
                        reverse += temp[j];
                    }
                    reverse += " ";
                    temp = "";
                }
            }
            return reverse;

        }





        static void Main(string[] args)
        {

            // *QUESTION 2
            string str = StringReverse("University of South Florida");
            Console.WriteLine(str);
            Console.ReadLine();


        }

    }
  }

