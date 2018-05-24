using System;
using System.Collections.Generic;
using System.Linq;

class ModifiedKruskal
{
    static void Main(string[] args)
    {
        var nodesCount = int.Parse(Console.ReadLine().Split()[1]);
        var edgesCount = int.Parse(Console.ReadLine().Split()[1]);

        var edges = new List<Edge>();

        for (int i = 0; i < edgesCount; i++)
        {
            var input = Console.ReadLine().Split();
            var startNode = int.Parse(input[0]);
            var endNode = int.Parse(input[1]);
            var weight = int.Parse(input[2]);

            edges.Add(new Edge(startNode, endNode, weight));
        }

        var minimumSpanningForest = Kruskal(nodesCount, edges);

        Console.WriteLine("Minimum spanning forest weight: " + minimumSpanningForest.Sum(e => e.Weight));
    }

    public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
    {
        edges.Sort();
        var parent = new int[numberOfVertices];
        for (int i = 0; i < numberOfVertices; i++)
        {
            parent[i] = i;
        }

        var spanningTree = new List<Edge>();
        foreach (var edge in edges)
        {
            int rootStartNode = FindRoot(edge.StartNode, parent);
            int rootEndNode = FindRoot(edge.EndNode, parent);
            if (rootEndNode != rootStartNode)
            {
                spanningTree.Add(edge);
                parent[rootEndNode] = rootStartNode;
            }
        }

        return spanningTree;
    }

    private static int FindRoot(int node, int[] parent)
    {
        int root = node;
        while (parent[root] != root)
        {
            root = parent[root];
        }

        while (node != root)
        {
            int previousParent = parent[node];
            parent[node] = root;
            node = previousParent;
        }

        return root;
    }
}

class Edge : IComparable<Edge>
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

    public override string ToString()
    {
        return $"({this.StartNode} {this.EndNode}) -> {this.Weight}";
    }
}