using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace assignment_1_group_1

{
    public class Question_4
    {
        public string FrequencySort(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                {
                    int value = map[c];
                    map[c] = ++value;
                }
                else
                    map[c] = 1;
            }

            var sortedMap = map.OrderByDescending(c => c.Value);
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<char, int> pair in sortedMap)
            {
                int n = pair.Value;
                while (n-- > 0)
                    sb.Append(pair.Key);
            }

            return sb.ToString();

        }
        static void Main(string[] args)
        {
            Question_4();
        }
    }
}
