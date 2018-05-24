using System;
using System.Collections.Generic;

class CyclesInAGraph
{
    private static Dictionary<string, List<string>> graph;

    private static HashSet<string> visited;

    private static HashSet<string> cycleNodes;

    private static bool noAcyclic;

    static void Main(string[] args)
    {
        graph = new Dictionary<string, List<string>>();

        while (true)
        {
            var input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
            {
                break;
            }

            var edge = input.Split('–');

            if (!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = new List<string>();
            }

            if (!graph.ContainsKey(edge[1]))
            {
                graph[edge[1]] = new List<string>();
            }

            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        visited = new HashSet<string>();
        cycleNodes = new HashSet<string>();

        foreach (var node in graph.Keys)
        {
            DFS(node, null);
        }

        Console.WriteLine("Acyclic: {0}", noAcyclic ? "No" : "Yes");
    }

    private static void DFS(string node, string parent)
    {
        if (cycleNodes.Contains(node))
        {
            noAcyclic = true;
            return;
        }

        if (visited.Contains(node) || noAcyclic)
        {
            return;
        }

        if (!visited.Contains(node))
        {
            visited.Add(node);
            cycleNodes.Add(node);

            foreach (var child in graph[node])
            {
                if (child != parent)
                {
                    DFS(child, node);
                }
            }

            cycleNodes.Remove(node);
        }
    }
}