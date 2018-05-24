using System;
using System.Linq;

class SumTo13
{
    private const int TargetSum = 13;

    static void Main(string[] args)
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(Sum(numbers, 0, 0) ? "Yes" : "No");
    }

    private static bool Sum(int[] numbers, int index, int currentSum)
    {
        if (index > numbers.Length - 1)
        {
            return TargetSum == currentSum;
        }

        return Sum(numbers, index + 1, currentSum + numbers[index])
               || Sum(numbers, index + 1, currentSum - numbers[index]);
    }
}