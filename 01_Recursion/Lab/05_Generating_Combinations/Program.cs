using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var set = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = int.Parse(Console.ReadLine());
        var vector = new int[n];

        GenCombs(set, vector, 0, 0);
    }

    private static void GenCombs(int[] set, int[] vector, int index, int border)
    {
        if (index >= vector.Length)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
        else
        {
            for (int i = border; i < set.Length; i++)
            {
                vector[index] = set[i];
                GenCombs(set, vector, index + 1, i + 1);
            }       
        }
    }
}