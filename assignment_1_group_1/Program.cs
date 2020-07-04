using System;

namespace assignment_1_group_1
{
    class Program
    {
        static int minSum(int[] arr)
        {
            // initialize total variable that will hold sum
            int total = 0;
            // standard for loop is O(n)
            for (int i = 0; i < arr.Length; i++)
            {
                // i != 0 prevents out of range index check
                // arr[i] == arr[i - 1] checks current value versus
                // previous. && specifies that both conditions must be true
                if (i != 0 && arr[i] == arr[i - 1])
                {
                    // if values are the same, increment current value by 1
                    arr[i] += 1;
                }
                // add each position to the total variable
                total += arr[i];
            }

            return total;
        }
        static void Main(string[] args)
        {
            int[] input = { 4, 5, 6, 9 };
            int total = minSum(input);
            Console.WriteLine(total);
        }
    }
}
