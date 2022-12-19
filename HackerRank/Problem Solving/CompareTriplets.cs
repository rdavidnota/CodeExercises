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
     * Complete the 'compareTriplets' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    private static  char evaluate(int a, int b) {
        if(a>b){
            return 'A';
        }else if(a == b){
            return 'E';
        }else{
            return 'B';
        }
    }
    
    private static bool evaluateInputs(int a, int b){
        return (a==b) && a == 3;
    }
    
    public static List<int> compareTriplets(List<int> a, List<int> b)
    {
        if(!evaluateInputs(a.Count, b.Count)){
            throw new ArgumentException("La entrada de datos no tiene el formato correcto.");
        }

        int aliceScore = 0;
        int bobScore = 0;
        for(int index = 0; index< 3; index++){
            switch(evaluate(a.ElementAt(index), b.ElementAt(index))){
                case 'A': aliceScore++; break;
                case 'B': bobScore++; break;
            }
        }

        List<int> resultado = new List<int>(){aliceScore, bobScore};
        return resultado;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        List<int> b = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(bTemp => Convert.ToInt32(bTemp)).ToList();

        List<int> result = Result.compareTriplets(a, b);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
