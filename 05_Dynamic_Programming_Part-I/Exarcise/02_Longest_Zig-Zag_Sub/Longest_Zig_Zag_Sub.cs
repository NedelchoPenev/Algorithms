using System;
using System.Collections.Generic;
using System.Linq;

class Longest_Zig_Zag_Sub
{
    static void Main(string[] args)
    {
        var sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] evenBig = new int[sequence.Length];
        int[] oddBig = new int[sequence.Length];
        int[] prevEven = new int[sequence.Length];
        int[] prevOdd = new int[sequence.Length];

        int maxLenEven = 0;
        int maxLenOdd = 0;
        int lastIndexEven = -1;
        int lastIndexOdd = -1;

        for (int index = 0; index < sequence.Length; index++)
        {
            evenBig[index] = 1;
            oddBig[index] = 1;
            prevEven[index] = -1;
            prevOdd[index] = -1;

            for (int i = 0; i < index; i++)
            {
                if (evenBig[i] % 2 == 0 && sequence[index] > sequence[i])
                {
                    TryIncrementLength(evenBig, index, i, prevEven);
                }
                else if (evenBig[i] % 2 != 0 && sequence[index] < sequence[i])
                {
                    TryIncrementLength(evenBig, index, i, prevEven);
                }
                if (oddBig[i] % 2 == 0 && sequence[index] < sequence[i])
                {
                    TryIncrementLength(oddBig, index, i, prevOdd);
                }
                else if (oddBig[i] % 2 != 0 && sequence[index] > sequence[i])
                {
                    TryIncrementLength(oddBig, index, i, prevOdd);
                }
            }

            if (evenBig[index] > maxLenEven)
            {
                maxLenEven = evenBig[index];
                lastIndexEven = index;
            }
            if (oddBig[index] > maxLenOdd)
            {
                maxLenOdd = oddBig[index];
                lastIndexOdd = index;
            }
        }

        if (maxLenEven > maxLenOdd)
        {
            PrintResult(sequence, lastIndexEven, prevEven);
        }
        else
        {
            PrintResult(sequence, lastIndexOdd, prevOdd);
        }
    }

    private static void PrintResult(int[] sequence, int lastIndex, int[] prev)
    {
        List<int> longestSeq = new List<int>();
        while (lastIndex != -1)
        {
            longestSeq.Add(sequence[lastIndex]);
            lastIndex = prev[lastIndex];
        }

        longestSeq.Reverse();
        Console.WriteLine(string.Join(" ", longestSeq));
    }

    private static void TryIncrementLength(int[] evenBig, int index, int i, int[] prevEven)
    {
        if (evenBig[index] <= evenBig[i])
        {
            evenBig[index] = evenBig[i] + 1;
            prevEven[index] = i;
        }
    }
}