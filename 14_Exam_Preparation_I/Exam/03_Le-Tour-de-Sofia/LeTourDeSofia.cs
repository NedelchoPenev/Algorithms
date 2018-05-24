using System;
using System.Collections.Generic;
using System.Linq;

class LeTourDeSofia
{
    static Dictionary<int, List<int>> graph;

    static Dictionary<int, bool> visited;

    static void Main(string[] args)
    {
        var junctions = int.Parse(Console.ReadLine());
        var streets = int.Parse(Console.ReadLine());
        var startEnd = int.Parse(Console.ReadLine());

        visited = new Dictionary<int, bool>();
        InitializeGraph(junctions, streets);

        foreach (var vertex in graph.Keys)
        {
            visited[vertex] = false;
        }

        Console.WriteLine(CalculateShortestDistance(startEnd, startEnd));
    }

    private static int CalculateShortestDistance(int start, int end)
    {
        Queue<int> vertices = new Queue<int>();
        vertices.Enqueue(start);
        List<int> children;
        int distance = 1;
        int junctionsVisited = 1;

        while (vertices.Count > 0)
        {
            children = new List<int>();

            while (vertices.Count > 0)
            {
                var current = vertices.Dequeue();
                foreach (var child in graph[current])
                {
                    if (!visited[child])
                    {
                        if (child == end)
                        {
                            return distance;
                        }

                        visited[child] = true;
                        children.Add(child);
                        junctionsVisited++;
                    }
                }
            }

            vertices = new Queue<int>(children);
            distance++;
        }

        return junctionsVisited;
    }

    private static void InitializeGraph(int junctions, int streets)
    {
        graph = new Dictionary<int, List<int>>();
        for (int i = 0; i < junctions; i++)
        {
            graph.Add(i, new List<int>());
        }

        for (int i = 0; i < streets; i++)
        {
            var input = Console.ReadLine().Split();
            var startVertix = int.Parse(input[0]);
            var childVertix = int.Parse(input[1]);

            graph[startVertix].Add(childVertix);
        }
    }
}