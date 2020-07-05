// C# program to find intersection using Hashing 
using System;
using System.Linq;
using System.Collections.Generic;

class GFG
{

    // Prints intersection of nums1[0..m-1] and nums2[0..n-1] 
    static void Intersect1(int[] nums1, int[] nums2)
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

    // Driver Code 
    static void Main()
    {
        int[] nums1 = { 3, 6, 2 };
        int[] nums2 = { 6, 3, 6, 7, 3 };

        Console.WriteLine("\nIntersection of two arrays is : ");
        Intersect1(nums1, nums2);
    }
}
© 2020 GitHub, Inc.