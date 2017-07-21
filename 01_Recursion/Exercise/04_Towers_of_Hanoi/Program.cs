using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static int stepsTaken = 0;

    private static Stack<int> source;
    private static Stack<int> destination;
    private static Stack<int> spare;

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var range = Enumerable.Range(1, n).Reverse();
        source = new Stack<int>(range);
        destination = new Stack<int>();
        spare = new Stack<int>();

        PrintRods();
        MoveDisks(n, source, spare, destination);
    }

    private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> spare, Stack<int> destination)
    {
        if (bottomDisk == 1)
        {
            stepsTaken++;
            int disk = source.Pop();
            destination.Push(disk);
            Console.WriteLine($"Step #{stepsTaken}: Moved disk");
            PrintRods();
            return;
        }

        MoveDisks(bottomDisk - 1, source, destination, spare);
        destination.Push(source.Pop());
        stepsTaken++;
        Console.WriteLine($"Step #{stepsTaken}: Moved disk");
        PrintRods();
        MoveDisks(bottomDisk - 1, spare, source, destination);
    }

    private static void PrintRods()
    {
        Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
        Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
        Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
        Console.WriteLine();
    }
}