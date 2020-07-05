using System;
using System.Collections.Generic;

namespace assignment_1_group_1
{
    class Program
    {
        static int[] targetRange(int[] marks, int target)
        {
            // initialize found array with {-1,-1}
            // override if found
            int[] found = new int[2] { -1, -1 };
            // for loop operation is O(n)
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] == target)
                {
                    // firstPosition handles instances where the target value
                    // appears only once (e.g. 12 would produce [5, 5] instead of
                    // [5, -1] )
                    int firstPosition = found[0] != -1 ? found[0] : i;
                    // array assignment is O(1)
                    found[0] = firstPosition;
                    found[1] = i;
                }
            }
            return found;
        }
      
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
      
        static bool ContainsDuplicate(char[] arr, int k)
        {
            // instantiate dictionary
            Dictionary<char, int> data = new Dictionary<char, int>();
            // for loop is O(n)
            for (var i = 0; i < arr.Length; i++)
            {
                // try to add current char as key. set value to current index
                bool added = data.TryAdd(arr[i], i);
                // if current char wasn't added, check current array index against
                // the value in the dictionary (i.e. previously seen)
                if (!added)
                {
                    // first index value
                    int firstVal = data[arr[i]];
                    // current (i.e. second) index value
                    int secondVal = i;
                    // take absolute difference
                    int absVal = Math.Abs(firstVal - secondVal);
                    // check absVal is at most equal to k (i.e. <=)
                    if (absVal <= k)
                    {
                        return true;
                    }
                    // set new value of latest index if conditional check fails
                    // in case the result appears again (e.g. [k, a, k, k])
                    data[arr[i]] = i;
                }
            }

            return false;
        }
      
        static void Main(string[] args)
        {
            // Question One
            int[] marks = { 5, 6, 6, 9, 9, 12 };
            int target = 12;
            int[] success = targetRange(marks, target);
            Console.WriteLine("Question 1 Answer:");
            Console.WriteLine("First {0} and Last {1}", success[0], success[1]);

            // QUESTION 2
            string msg = StringReverse("University of South Florida");
            Console.WriteLine("Question 2 Output: {0}", msg);

            // QUESTION 6
            // Example 1
            char[] input = new char[] { 'a', 'g', 'h', 'a' };
            int target = 3;
            bool result = ContainsDuplicate(input, target);
            Console.WriteLine("Question 6 Example 1: {0}", result);
            // Example 2
            char[] input2 = new char[] { 'k', 'y', 'k', 'k' };
            int target2 = 1;
            bool result2 = ContainsDuplicate(input2, target2);
            Console.WriteLine("Question 6 Example 2: {0}", result2);
            // Example 3
            char[] input3 = new char[] { 'a', 'b', 'c', 'a', 'b', 'c' };
            int target3 = 2;
            bool result3 = ContainsDuplicate(input3, target3);
            Console.WriteLine("Question 6 Example 3: {0}", result3);
        }
    }
}
