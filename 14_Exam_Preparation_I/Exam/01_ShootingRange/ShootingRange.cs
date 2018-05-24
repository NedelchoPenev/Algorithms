using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ShootingRange
{
    static void Main(string[] args)
    {
        var values = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var target = int.Parse(Console.ReadLine());

        bool[] marked = new bool[values.Length];
        GenerateSequences(0, target, values, marked);
    } 

    private static void GenerateSequences(int index, int target, int[] values, bool[] marked)
    {
        int score = GetScore(values, marked);

        if (score == target)
        {
            Print(values, marked);
        }

        if (index >= values.Length || score >= target)
        {
            return;
        }

        HashSet<int> swapped = new HashSet<int>();
        for (int i = index; i < values.Length; i++)
        {
            if (!swapped.Contains(values[i]))
            {
                Swap(index, i, values);
                marked[index] = true;

                GenerateSequences(index + 1, target, values, marked);

                Swap(index, i, values);
                marked[index] = false;

                swapped.Add(values[i]);
            }
        }
    }

    private static void Swap(int i, int j, int[] values)
    {
        var temp = values[i];
        values[i] = values[j];
        values[j] = temp;
    }

    private static int GetScore(int[] values, bool[] marked)
    {
        int result = 0;
        int multiplier = 1;
        for (int i = 0; i < values.Length; i++)
        {
            if (marked[i])
            {
                result += values[i] * multiplier++;
            }
        }

        return result;
    }

    private static void Print(int[] values, bool[] marked)
    {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < values.Length; i++)
        {
            if (marked[i])
            {
                output.Append(values[i] + " ");
            }
        }

        Console.WriteLine(output.ToString().Trim());
    }
}