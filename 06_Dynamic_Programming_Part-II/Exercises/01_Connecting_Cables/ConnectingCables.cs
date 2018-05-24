using System;
using System.Collections.Generic;
using System.Linq;

class ConnectingCables
{
    static void Main(string[] args)
    {
        var n1 = Console.ReadLine().Split().Select(int.Parse).ToList();
        var n2 = n1.ToList().OrderBy(n => n).ToList();

        var firstLen = n1.Count + 1;
        var secondLen = n2.Count + 1;

        var maxLen = new int[firstLen, secondLen];

        for (int i = 1; i < firstLen; i++)
        {
            for (int j = 1; j < secondLen; j++)
            {
                if (n1[i - 1] == n2[j - 1])
                {
                    maxLen[i, j] = maxLen[i - 1, j - 1] + 1;
                }
                else
                {
                    maxLen[i, j] = Math.Max(maxLen[i - 1, j], maxLen[i, j - 1]);
                }
            }
        }

        Console.WriteLine($"Maximum pairs connected: {maxLen[n1.Count, n2.Count]}");
    }
}