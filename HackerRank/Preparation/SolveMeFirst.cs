using System;
using System.Collections.Generic;
using System.IO;
class Solution
{

    static void validation(int number)
    {
        if(number <= 0)
        {
            throw new ArgumentException("Number should be positive");
        }
        else if(number > 1000)
        {
            throw new ArgumentException("Number should be less than 1000");
        }
    }
    static int solveMeFirst(int a, int b)
    {
        validation(a);
        validation(b);
        // Hint: Type return a+b; below  
        return a + b;
    }

    static void Main(String[] args)
    {
        int val1 = Convert.ToInt32(Console.ReadLine());
        int val2 = Convert.ToInt32(Console.ReadLine());
        int sum = solveMeFirst(val1, val2);
        Console.WriteLine(sum);
    }
}