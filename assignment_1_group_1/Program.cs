
using System;
using System.Linq;
using System.Collections.Generic;

namespace assignment_1_group_1
{
    class Program
    {
    // Prints intersection of nums1[0..m-1] and nums2[0..n-1] 
    static void Intersect2(int[] nums1, int[] nums2)
    {
        int[] arrlong;
        int[] arrshort;

        if (nums1.Length >= nums2.Length)
        {
            arrlong = nums1;
            arrshort = nums2;
        }

        else
        {
            arrlong = nums2;
            arrshort = nums1;
        }

        HashSet<int> hs = new HashSet<int>();

        for (int i = 0; i < arrlong.Length; i++)
            hs.Add(arrlong[i]);

        for (int i = 0; i < arrshort.Length; i++)
            if (hs.Contains(arrshort[i]))
                Console.Write(arrshort[i] + " ");
    }
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
            
            // QUESTION 3
            int[] input = { 4, 5, 6, 9 };
            int total = minSum(input);
            Console.WriteLine("Question 3 output: {0}", total);
          
            // QUESTION 4
            question_four();
          
            // QUESTION 5 - Part A
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
          
            // QUESTION 5 - Part B
            int[] nums1b = { 3, 6, 2 };
            int[] nums2b = { 6, 3, 6, 7, 3 };

            Console.WriteLine("\nIntersection of two arrays is : ");
            Intersect1(nums1b, nums2b);

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