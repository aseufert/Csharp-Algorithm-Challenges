using System;

namespace assignment_1_group_1
{
    class Program
    {

public static int[] TargetRange(int[] marks, int target)
{
    int first = -1;
    int last = -1;

    for (int i = 0; i < marks.Length; i++)
    {
        if (marks[i] == target)
        {
            first = i;
            break;
        }
    }

    for (int x = marks.Length - 1; x > -1; x--)
    {
        if (marks[x] == target)
        {
            last = x;
            break;
        }

    }

    int[] trange = new int[] { first, last };
    return trange;
}




static void Main(string[] args)
{
    
    // *QUESTION 1
    //make variables for inputs
    int[] m = new int[] { 5, 6, 6, 9, 9, 12};
    int t = 10;
    //make variable for output result
    int[] result = TargetRange(m, t) ;
    //print output of function
    Console.WriteLine($"[{result[0]},{result[1]}]");
    Console.ReadLine();

}

    }
  }

