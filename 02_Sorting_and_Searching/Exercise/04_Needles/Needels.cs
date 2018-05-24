using System;
using System.Collections.Generic;
using System.Linq;

class Needels
{
    static void Main()
    {
        var args = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var collectionCount = args[0];
        var numbersToInsertCount = args[1];

        int[] collection = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] numbersToInsert = Console.ReadLine().Split().Select(int.Parse).ToArray();

        List<int> indexes = new List<int>();

        for (int num = 0; num < numbersToInsertCount; num++)
        {
            bool solutionFound = false;
            for (int currentIndex = 0; currentIndex < collectionCount; currentIndex++)
            {
                if (collection[currentIndex] != 0 && collection[currentIndex] >= numbersToInsert[num])
                {
                    int index = FindIndex(collection, currentIndex);
                    indexes.Add(index);
                    solutionFound = true;
                    break;
                }
            }

            if (!solutionFound)
            {
                int index = FindIndex(collection, collectionCount);
                indexes.Add(index);
            }
        }

        Console.WriteLine(string.Join(" ", indexes));
    }

    private static int FindIndex(int[] collection, int currentIndex)
    {
        while (currentIndex > 0 && collection[currentIndex - 1] == 0)
        {
            currentIndex--;
        }

        return currentIndex;
    }
}