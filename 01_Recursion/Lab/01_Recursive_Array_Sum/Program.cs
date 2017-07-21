using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Sum(array, 0));
    }

    private static int Sum(int[] array, int index)
    {
        if (index > array.Length - 1)
        {
            return 0;
        }

        return array[index] + Sum(array, index + 1);
    }
}