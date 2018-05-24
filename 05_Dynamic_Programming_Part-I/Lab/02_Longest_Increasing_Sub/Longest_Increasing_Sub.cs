using System;
using System.Collections.Generic;
using System.Linq;

class Longest_Increasing_Sub
{
    static void Main(string[] args)
    {
        var s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] len = new int[s.Length];
        int[] prev = new int[s.Length];

        int maxLen = 0;
        int lastIndex = -1;

        for (int index = 0; index < s.Length; index++)
        {
            len[index] = 1;
            prev[index] = - 1;

            for (int j = 0; j < index; j++)
            {
                if (s[index] > s[j] && len[index] <= len[j])
                {
                    len[index] = len[j] +1;
                    prev[index] = j;
                }
            }

            if (len[index] > maxLen)
            {
                maxLen = len[index];
                lastIndex = index;
            }
        }

        List<int> longestSeq = new List<int>();
        while (lastIndex != -1)
        {
            longestSeq.Add(s[lastIndex]);
            lastIndex = prev[lastIndex];
        }

        longestSeq.Reverse();
        Console.WriteLine(string.Join(" ", longestSeq));
    }
}