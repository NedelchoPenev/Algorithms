using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Reverse(array, 0);
    }

    private static void Reverse(int[] array, int index)
    {
        if (index >= array.Length)
        {
            return;
        }

        Reverse(array, index + 1);
        Console.Write(array[index] + " ");
    }
}