using System;

class Program
{
    private static string[] elements;
    private static int k;

    private static string[] vector;

    static void Main(string[] args)
    {
        elements = Console.ReadLine().Split();
        k = int.Parse(Console.ReadLine());
        vector = new string[elements.Length];
        GenerateCombinations(0, 0);
    }

    private static void GenerateCombinations(int index, int start)
    {
        if (index >= k)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
        else
        {
            for (int i = start; i < elements.Length; i++)
            {
                vector[index] = elements[i];
                GenerateCombinations(index + 1, i + 1);
            }
        }
    }
}