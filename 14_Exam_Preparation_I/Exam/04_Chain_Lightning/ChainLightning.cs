using System;
using System.Collections.Generic;
using System.Linq;

class ChainLightning
{
    static void Main(string[] args)
    {
        var nodeCount = int.Parse(Console.ReadLine());
        var edgeCount = int.Parse(Console.ReadLine());
        var lightningsCount = int.Parse(Console.ReadLine());

        var edges = new List<Edge>();
        for (int i = 0; i < edgeCount; i++)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            edges.Add(new Edge(input[0], input[1], input[2]));
        }

        List<Edge> spanningForestEdges = Kruskal(nodeCount, edges);
        List<int>[] graph = new List<int>[nodeCount];
        for (int i = 0; i < graph.Length; i++)
        {
            graph[i] = new List<int>();
        }
        foreach (var edge in spanningForestEdges)
        {
            graph[edge.StartNode].Add(edge.EndNode);
            graph[edge.EndNode].Add(edge.StartNode);
        }

        //process lightnings
        var damages = new int[nodeCount];
        for (int i = 0; i < lightningsCount; i++)
        {
            var input = Console.ReadLine().Split();
            int startNode = int.Parse(input[0]);
            int damage = int.Parse(input[1]);
            bool[] visited = new bool[nodeCount];
            int[] depths = new int[nodeCount];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited[startNode] = true;
            depths[startNode] = 0;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (depths[node] > 10)
                {
                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                        depths[child] = depths[node] + 1;
                    }
                }
            }

            damages[startNode] += damage;
            visited[startNode] = false;
            for (int node = 0; node < damages.Length; node++)
            {
                if (visited[node])
                {
                    damages[node] += damage / (int)Math.Pow(2, depths[node]);
                }
            }
        }

        Console.WriteLine(damages.Max());
    }

    public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
    {
        int[] parents = new int[numberOfVertices];
        List<Edge> results = new List<Edge>();
        edges.Sort();
        for (int i = 0; i < parents.Length; i++)
        {
            parents[i] = i;
        }
        foreach (var edge in edges)
        {
            int startRoot = FindRoot(edge.StartNode, parents);
            int endRoot = FindRoot(edge.EndNode, parents);
            if (startRoot != endRoot)
            {
                parents[endRoot] = startRoot;
                results.Add(edge);
            }
        }
        return results;
    }

    public static int FindRoot(int node, int[] parent)
    {
        int beginNode = node;
        while (parent[node] != node)
        {
            node = parent[node];
        }

        int root = node;
        int current = beginNode;
        while (parent[current] != current)
        {
            int parentNode = parent[current];
            parent[current] = root;
            current = parentNode;
        }
        return root;
    }
}

public class Edge : IComparable<Edge>
{
    public Edge(int startNode, int endNode, int weight)
    {
        this.StartNode = startNode;
        this.EndNode = endNode;
        this.Weight = weight;
    }

    public int StartNode { get; set; }

    public int EndNode { get; set; }

    public int Weight { get; set; }

    public int CompareTo(Edge other)
    {
        int weightCompared = this.Weight.CompareTo(other.Weight);
        return weightCompared;
    }
}