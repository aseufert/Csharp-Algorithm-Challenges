// C# program to check fixed point  
// in an array using linear search 
using System; 
using System.Collections.Generic;
using System.Linq; 
 
 
class GFG 
{ 
    static int[] targetRange(int []marks, int target) 
    { 
        int n = marks.Length;
        int i; 
        List<int> aresult = new List<int>(); 
        
        // Output result as a vector
        for(i = 0; i < n; i++) 
        { 
          if(marks[i] == target) 
          aresult.Add(i);
        }
        
        // Create a list
        List<int> nulllist = new List<int>() {-1,-1};
        // Convert list to a array
        int[] nullint = nulllist.ToArray();
        
        // If nothing match return [-1,-1]
        if(aresult.Count == 0) 
        return nullint;
        
        int[] intList = aresult.ToArray();
        
        return intList;
    } 
    
    
    public static void Main() 
    { 
        int []arr = {5, 9, 9, 6, 6, 12};
        int mytarget = 9; 
        var myresult = targetRange(arr, mytarget);
        
        foreach(int element in myresult) 
        { 
            Console.WriteLine(element); 
        } 

    } 
} 
