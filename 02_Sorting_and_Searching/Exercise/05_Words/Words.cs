using System;
using System.Collections.Generic;

class Words
{
    static int wordsFound = 0;

    static void Main(string[] args)
    {
        char[] word = Console.ReadLine().ToCharArray();
        GeneratePermutations(word, 0);
        Console.WriteLine(wordsFound);
    }

    private static void GeneratePermutations(char[] word, int index)
    {
        if (word.Length <= index)
        {
            if (!CheckForRepetitions(word))
            {
                wordsFound++;
            }
        }

        HashSet<char> swapped = new HashSet<char>();
        for (int i = index; i < word.Length; i++)
        {
            if (!swapped.Contains(word[i]))
            {
                Swap(ref word[index],ref word[i]);
                GeneratePermutations(word, index + 1);
                Swap(ref word[index], ref word[i]);
                swapped.Add(word[i]);
            }
        }
    }

    private static void Swap(ref char first, ref char second)
    {
        var temp = first;
        first = second;
        second = temp;
    }

    private static bool CheckForRepetitions(char[] word)
    {
        for (int i = 1; i < word.Length; i++)
        {
            if (word[i - 1] == word[i])
            {
                return true;
            }
        }

        return false;
    }
}