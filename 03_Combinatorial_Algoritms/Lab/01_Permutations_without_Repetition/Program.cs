using System;

class Program
{
    static void Main(string[] args)
    {
        var elements = Console.ReadLine().Split();
        GeneratePermutations(elements, 0);
    }

    private static void GeneratePermutations(string[] elements, int index)
    {
        if (index >= elements.Length)
        {
            Console.WriteLine(string.Join(" ", elements));
        }
        else
        {
            GeneratePermutations(elements, index + 1);
            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(ref elements[index], ref elements[i]);
                GeneratePermutations(elements, index+1);
                Swap(ref elements[index], ref elements[i]);
            }
        }
    }

    private static void Swap(ref string first, ref string second)
    {
        var temp = first;
        first = second;
        second = temp;
    }
}