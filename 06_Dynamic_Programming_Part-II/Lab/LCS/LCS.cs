using System;
using System.Collections.Generic;

class LCS
{
    static void Main(string[] args)
    {
        var firstStr = Console.ReadLine();
        var secondStr = Console.ReadLine();

        int[,] lcs = FindLingestCommonSubsequence(firstStr, secondStr);
        Console.WriteLine(lcs[firstStr.Length, secondStr.Length]);
        Console.WriteLine(RetrieveLCS(firstStr, secondStr, lcs));
    }

    static int[,] FindLingestCommonSubsequence(string firstStr, string secondStr)
    {
        var firstLen = firstStr.Length + 1;
        var secondLen = secondStr.Length + 1;
        var lcs = new int[firstLen, secondLen];

        for (int i = 1; i < firstLen; i++)
        {
            for (int j = 1; j < secondLen; j++)
            {
                if (firstStr[i - 1] == secondStr[j - 1])
                {
                    lcs[i, j] = lcs[i - 1, j - 1] + 1;
                }
                else
                {
                    lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                }
            }
        }

        return lcs;
    }

    static String RetrieveLCS(string firstStr, string secondStr, int[,] lcs)
    {
        var sequence = new List<char>();
        var i = firstStr.Length;
        var j = secondStr.Length;

        while (i > 0 && j > 0)
        {
            if (firstStr[i - 1] == secondStr[j - 1])
            {
                sequence.Add(firstStr[i - 1]);
                i--;
                j--;
            }
            else if (lcs[i, j] == lcs[i - 1, j])
            {
                i--;
            }
            else
            {
                j--;
            }
        }

        sequence.Reverse();

        return new string(sequence.ToArray());
    }
}