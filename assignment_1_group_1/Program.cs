using System;

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
        static void Main(string[] args)
        {
            // Question One
            int[] marks = { 5, 6, 6, 9, 9, 12 };
            int target = 12;
            int[] success = targetRange(marks, target);
            Console.WriteLine("First {0} and Last {1}", success[0], success[1]);
        }
    }
}
