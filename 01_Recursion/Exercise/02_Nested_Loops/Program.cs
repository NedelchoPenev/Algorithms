using System;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var array = new int[n];
        LoopRecursion(array, 0);
    }

    private static void LoopRecursion(int[] array, int index)
    {
        if (index == array.Length)
        {
            Console.WriteLine(string.Join(" ", array));
        }
        else
        {
            for (int i = 1; i <= array.Length; i++)
            {
                array[index] = i;
                LoopRecursion(array, index + 1);
            }
        }
    }
}