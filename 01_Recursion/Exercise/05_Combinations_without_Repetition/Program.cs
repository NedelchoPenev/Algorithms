using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        var array = new int[k];

        Comb(n, array, 0, 1);
    }

    private static void Comb(int n, int[] array, int index, int border)
    {
        if (index == array.Length)
        {
            Console.WriteLine(string.Join(" ", array));
        }
        else
        {
            for (int i = border; i <= n; i++)
            {
                array[index] = i;
                Comb(n, array, index + 1, i + 1);
            }
        }
    }
}