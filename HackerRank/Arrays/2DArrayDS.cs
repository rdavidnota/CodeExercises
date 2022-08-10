using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int getBiggest(List<int> arr)
    {
        int biggest = Int32.MinValue;

        for (int i = 0; i < arr.Count; i++)
        {
            if (biggest < arr[i])
            {
                biggest = arr[i];
            }
        }

        return biggest;
    }

    public static int sumElements(List<int> arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    public static List<int> getElements(List<List<int>> arr, int positionX, int positionY)
    {
        List<int> elements = new List<int>();

        elements.Add(arr[positionX - 1][positionY - 1]);
        elements.Add(arr[positionX - 1][positionY]);
        elements.Add(arr[positionX - 1][positionY + 1]);

        elements.Add(arr[positionX][positionY]);

        elements.Add(arr[positionX + 1][positionY - 1]);
        elements.Add(arr[positionX + 1][positionY]);
        elements.Add(arr[positionX + 1][positionY + 1]);

        return elements;
    }
    public static int hourglassSumCopilot(List<List<int>> arr)
    {
        for (int i = 1; i < arr.Count - 1; i++)
        {
            for (int j = 1; j < arr[i].Count - 1; j++)
            {
                List<int> elements = getElements(arr, i, j);
                int biggest = getBiggest(elements);
                arr[i][j] = biggest;
            }
        }
    }
    public static int hourglassSum(List<List<int>> arr)
    {
        List<int> listSumElements = new List<int>();
        int bigSum = Int32.MinValue;
        for (int i = 1; i < arr.Count - 1; i++)
        {
            for (int j = 1; j < arr[i].Count - 1; j++)
            {
                List<int> elements = getElements(arr, i, j);
                listSumElements.Add(sumElements(elements));
            }
        }

        bigSum = getBiggest(listSumElements);
        return bigSum;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
