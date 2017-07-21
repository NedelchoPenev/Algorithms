using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] vector = new int[n];
        Gen01(vector, 0);
    }

    private static void Gen01(int[] vector, int index)
    {
        if (index >= vector.Length)
        {
            Console.WriteLine(string.Join("", vector));
        }
        else
        {
            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Gen01(vector, index + 1);
            }
        }
    }
}