using System;
using System.Collections.Generic;

class Blocks
{
    private const int LettersToChoose = 4;

    static readonly HashSet<string> usedCombinations = new HashSet<string>();

    private static char[] letters;

    static void Main(string[] args)
    {
        var numberOfLetters = int.Parse(Console.ReadLine());

        var blocksFound = FindBlocks(numberOfLetters);

        PrintResult(blocksFound);
    }

    private static void PrintResult(HashSet<string> blocksFound)
    {
        Console.WriteLine($"Number of blocks: {blocksFound.Count}");

        foreach (var combination in blocksFound)
        {
            Console.WriteLine(combination);
        }
    }

    private static void FillLetters(int numberOfLetters)
    {
        for (int i = 0; i < numberOfLetters; i++)
        {
            letters[i] = (char)('A' + i);
        }
    }

    public static HashSet<string> FindBlocks(int numberOfLetters)
    {
        letters = new char[numberOfLetters];
        FillLetters(numberOfLetters);

        var used = new bool[numberOfLetters];
        var currentCombination = new char[LettersToChoose];
        HashSet<string> results = new HashSet<string>();

        GenVariations(letters, currentCombination, used, results);

        return results;
    }

    private static void GenVariations(
        char[] letters,
        char[] currentCombination,
        bool[] used,
        HashSet<string> results,
        int index = 0)
    {
        if (index >= currentCombination.Length)
        {
            AddResult(currentCombination, results);
        }
        else
        {
            for (int i = 0; i < letters.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    currentCombination[index] = letters[i];
                    GenVariations(letters, currentCombination, used, results, index + 1);
                    used[i] = false;
                }
            }
        }
    }

    private static void AddResult(char[] result, HashSet<string> results)
    {
        var currentCombination = new string(result);
        if (!usedCombinations.Contains(currentCombination))
        {
            results.Add(currentCombination);

            usedCombinations.Add(currentCombination);
            usedCombinations.Add(new string(new[] { result[3], result[0], result[1], result[2] }));
            usedCombinations.Add(new string(new[] { result[2], result[3], result[0], result[1] }));
            usedCombinations.Add(new string(new[] { result[1], result[2], result[3], result[0] }));
        }
    }
}