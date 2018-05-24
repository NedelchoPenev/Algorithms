using System;
using System.Collections.Generic;
using System.Linq;

using Wintellect.PowerCollections;

class BreakCycles
{
    private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
    private static OrderedBag<Tuple<string, string>> edges = new OrderedBag<Tuple<string, string>>();
    private static HashSet<string> visited = new HashSet<string>();

    private static bool stopRecursion = false;

    static void Main(string[] args)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            var parms = input.Split(new[] { " -> ", " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            graph[parms[0]] = new List<string>(parms.Skip(1));

            for (int i = 1; i < parms.Count; i++)
            {
                edges.Add(new Tuple<string, string>(parms[0], parms[i]));
            }
        }

        var result = new List<Tuple<string, string>>();
        foreach (var edge in edges)
        {
            visited.Clear();
            stopRecursion = false;
            var parent = edge.Item1;
            var child = edge.Item2;

            graph[parent].Remove(child);
            graph[child].Remove(parent);

            bool needToRemove = CheckForCycle(parent, child, null);

            if (needToRemove)
            {
                if (!result.Contains(new Tuple<string, string>(child, parent)))
                {
                    result.Add(edge);
                }
            }
            else
            {
                graph[parent].Add(child);
                graph[child].Add(parent);
            }
        }

        Console.WriteLine($"Edges to remove: {result.Count}");
        foreach (var tuple in result)
        {
            Console.WriteLine($"{tuple.Item1} - {tuple.Item2}");
        }
    }

    private static bool CheckForCycle(string from, string to, string parent)
    {
        if (visited.Contains(from))
        {
            return false;
        }

        if (from == to)
        {
            stopRecursion = true;
            return stopRecursion;
        }

        visited.Add(from);
        foreach (var child in graph[from])
        {
            if (child == parent)
            {
                continue;
            }

            CheckForCycle(child, to, from);
            if (stopRecursion)
            {
                return true;
            }
        }

        return false;
    }
}