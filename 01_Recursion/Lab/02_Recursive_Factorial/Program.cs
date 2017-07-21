using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(Factorial(n));
    }

    private static long Factorial(int number)
    {
        if (number == 0)
        {
            return 1;
        }

        return number * Factorial(number - 1);
    }
}