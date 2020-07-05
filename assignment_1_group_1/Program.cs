using System;

namespace assignment_1_group_1
{
    class Program
    {

        public static int minSum(int[] arr)
        {
            int aSum = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {

                if (arr[i] != arr[i + 1])
                {
                    aSum += arr[i + 1];
                }
                else
                {
                    arr[i + 1] += 1;
                    aSum += arr[i + 1];

                }
                if (i == arr.Length - 1)
                {
                    aSum += arr[arr.Length];
                }
            }

            return aSum;
        }






        static void Main(string[] args)
        {

            // *QUESTION 3
            int[] arr1 = new int[] { 4, 5, 6, 9 };
            int a = minSum(arr1);
            Console.WriteLine(a);
            Console.ReadLine();



        }

    }
  }

