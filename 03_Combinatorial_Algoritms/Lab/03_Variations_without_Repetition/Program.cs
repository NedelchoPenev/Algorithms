using System;

class Program
{
    private static bool[] used;

    private static string[] vector;

    static void Main(string[] args)
    {
        var elements = Console.ReadLine().Split();
        int k = int.Parse(Console.ReadLine());
        //used = new bool[elements.Length];
        vector = new string[k];
        GenerateVariations(elements, 0, k);
    }

    private static void GenerateVariations(string[] elements, int index, int k)
    {
        if (index >= k)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
        else
        {
            for (int i = 0; i < elements.Length; i++)
            {
              //  if (!used[i])
              //  {
               //     used[i] = true;
                    vector[index] = elements[i];
                    GenerateVariations(elements, index + 1, k);
              //      used[i] = false;
             //   }
            }
        }
    }
}