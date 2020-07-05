using System;
using System.Linq;
using System.Collections.Generic;

namespace assignment_1_group_1
{
    class Program
    {
        static int calculatePivot(int first, int last)
        {
            // calculates midpoint of two points
            int sum = first + last;
            return sum / 2;
        }

        /// Use pivot point to split index on a portion of the array 
        static int binarySearch(int target, int[] data, int firstIndex=0, int lastIndex=0, bool initialAttempt=true)
        {
            // exit condition if value not found
            if (lastIndex <= -1)
            {
                return -1;
            }
            // calculate pivot point in recursion
            // for first run, use length
            int last = initialAttempt ? data.Length - 1 : lastIndex;
            // pivot is the midpoint index of the current array that
            // allows for split enabling binary log n search
            int pivot = calculatePivot(firstIndex, last);
            // check if value at pivot equals or not
            if (target == data[pivot])
            {
                return pivot;
            }
            // base exit condition for recursion
            // if target != data[pivot] and first == last,
            // there's no more spliting possible
            else if (!initialAttempt && firstIndex == lastIndex)
            {
                return -1;
            }
            // if target < the value at pivot point, decrement pivot
            // and pass as the last index value
            else if (target < data[pivot])
            {
                return binarySearch(target, data, firstIndex, pivot - 1, false);
            }
            // if target > value at pivot point, increment pivot as the
            // first value pass index as last
            else
            {
                return binarySearch(target, data, pivot + 1, last, false);
            }

        }

        static int[] Intersect1(int[] nums1, int[] nums2)
        {
            // sort arrays
            Array.Sort(nums1);
            Array.Sort(nums2);
            // linked list to hold final results
            LinkedList<int> final = new LinkedList<int>();
            // for loop is O(n)
            for (var i = 0; i < nums1.Length; i++)
            {
                // binary search is log n
                int position = binarySearch(nums1[i], nums2);
                if (position != -1)
                {
                    final.AddLast(nums1[i]);
                    // set found position value in nums2 to number lower than
                    // current target at nums1[i] so that it won't be reused.
                    // this works because nums1 is sorted and subsequent
                    // loops will only increase the target value. By incrementing
                    // current value, it wont get picked up again
                    nums2[position] = nums1[i] - 1;
                }
            }

            // convert linked list to array to conform to the method signature
            return final.ToArray();
        }

        static void Main(string[] args)
        {
            // QUESTION 5
            // Scenario 1
            int[] nums1 = { 2, 5, 5, 2 };
            int[] nums2 = { 5, 5 };
            int[] results = Intersect1(nums1, nums2);
            foreach (int result in results)
            {
                Console.WriteLine(result);
            }
            //Scenario 2
            int[] nums3 = { 3, 6, 2 };
            int[] nums4 = { 6, 3, 6, 7, 3 };
            int[] results2 = Intersect1(nums3, nums4);
            foreach (int result in results2)
            {
                Console.WriteLine(result);
            }
        }
    }
}
