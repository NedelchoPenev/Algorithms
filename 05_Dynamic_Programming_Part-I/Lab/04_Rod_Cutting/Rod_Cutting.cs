using System;
using System.Linq;

class Rod_Cutting
{
    private static int[] bestPrice;

    private static int[] cuts;

    static void Main(string[] args)
    {
        var rod = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int cut = int.Parse(Console.ReadLine());

        bestPrice = new int[rod.Length];
        cuts = new int[cut +1];
        Console.WriteLine(RodCutting(rod, cut));
        PrintBestCuts(cut);
    }

    private static void PrintBestCuts(int cut)
    {
        while (cut - cuts[cut] != 0)
        {
            Console.Write(cuts[cut] + " ");
            cut = cut - cuts[cut];
        }

        Console.WriteLine(cuts[cut]);
    }

    private static int RodCutting(int[] rod, int cut)
    {
        if (bestPrice[cut] != 0)
        {
            return bestPrice[cut];
        }

        if (cut == 0)
        {
            return 0;
        }

        var currentBest = 0;
        for (int i = 1; i <= cut; i++)
        {
            currentBest = Math.Max(currentBest, rod[i] + RodCutting(rod, cut - i));

            if (currentBest > bestPrice[cut])
            {
                bestPrice[cut] = currentBest;
                cuts[cut] = i;
            }
        }

        return bestPrice[cut];
    }
}