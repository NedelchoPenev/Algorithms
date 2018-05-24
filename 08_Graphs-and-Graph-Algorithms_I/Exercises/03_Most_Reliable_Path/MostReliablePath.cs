using System;
using System.Collections.Generic;
using System.Linq;

using Wintellect.PowerCollections;

class MostReliablePath
{
    static void Main(string[] args)
    {
        int nodeCount = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
        string[] arguments = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int source = int.Parse(arguments[1]);
        int destination = int.Parse(arguments[3]);
        int edgeCount = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);

        var nodes = new Dictionary<int, Node>();
        var graph = new Dictionary<Node, Dictionary<Node, double>>();

        for (int i = 0; i < edgeCount; i++)
        {
            int[] input =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int start = input[0];
            int end = input[1];
            double reliability = input[2] / 100d;

            if (!nodes.ContainsKey(start))
            {
                var startNode = new Node(start);
                nodes.Add(start, startNode);
                graph.Add(startNode, new Dictionary<Node, double>());
            }
            if (!nodes.ContainsKey(end))
            {
                var endNode = new Node(end);
                nodes.Add(end, endNode);
                graph.Add(endNode, new Dictionary<Node, double>());
            }
            var sourceNode = nodes[start];
            var destNode = nodes[end];
            graph[sourceNode].Add(destNode, reliability);
            graph[destNode].Add(sourceNode, reliability);
        }

        var path = DijkstraAlgorithm(graph, nodes[source], nodes[destination]);

        if (path == null)
        {
            Console.WriteLine("no path");
        }
        else
        {
            Console.WriteLine("Most reliable path reliability: {0:f2}%", nodes[destination].DistanceFromStart * 100);
            Console.WriteLine(string.Join(" -> ", path));
        }
    }

    private static List<int> DijkstraAlgorithm(
        Dictionary<Node, Dictionary<Node, double>> graph,
        Node sourceNode,
        Node destinationNode)
    {
        var visited = new bool[graph.Count];
        int?[] previous = new int?[graph.Count];

        PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

        sourceNode.DistanceFromStart = 1;
        priorityQueue.Enqueue(sourceNode);
        visited[sourceNode.Id] = true;

        while (priorityQueue.Count > 0)
        {
            var maxNode = priorityQueue.ExtractMax();
            if (destinationNode == maxNode)
            {
                break;
            }

            foreach (var edge in graph[maxNode])
            {
                if (!visited[edge.Key.Id])
                {
                    priorityQueue.Enqueue(edge.Key);
                    visited[edge.Key.Id] = true;
                }

                double reliability = edge.Value * maxNode.DistanceFromStart;
                if (reliability > edge.Key.DistanceFromStart)
                {
                    edge.Key.DistanceFromStart = reliability;
                    previous[edge.Key.Id] = maxNode.Id;
                    priorityQueue.DecreaseKey(edge.Key);
                }
            }
        }

        if (double.IsNegativeInfinity(destinationNode.DistanceFromStart))
        {
            return null;
        }

        var path = new List<int>();
        int? current = destinationNode.Id;
        while (current != null)
        {
            path.Add(current.Value);
            current = previous[current.Value];
        }

        path.Reverse();

        return path;
    }
}

class Node : IComparable<Node>
{
    public Node(int id, double distance = double.NegativeInfinity)
    {
        this.Id = id;
        this.DistanceFromStart = distance;
    }

    public int Id { get; set; }

    public double DistanceFromStart { get; set; }

    public int CompareTo(Node other)
    {
        return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
    }
}

class PriorityQueue<T>
    where T : IComparable<T>
{
    private readonly Dictionary<T, int> searchCollection;

    private readonly List<T> heap;

    public PriorityQueue()
    {
        this.heap = new List<T>();
        this.searchCollection = new Dictionary<T, int>();
    }

    public int Count => this.heap.Count;

    public bool Contains(T node)
    {
        return this.searchCollection.ContainsKey(node);
    }

    public T ExtractMax()
    {
        var max = this.heap[0];
        var last = this.heap[this.heap.Count - 1];
        this.searchCollection[last] = 0;
        this.heap[0] = last;
        this.heap.RemoveAt(this.heap.Count - 1);
        if (this.heap.Count > 0)
        {
            this.HeapifyDown(0);
        }

        this.searchCollection.Remove(max);

        return max;
    }

    public T PeekMax()
    {
        return this.heap[0];
    }

    public void Enqueue(T element)
    {
        this.searchCollection.Add(element, this.heap.Count);
        this.heap.Add(element);
        this.HeapifyUp(this.heap.Count - 1);
    }

    private void HeapifyDown(int i)
    {
        var left = (2 * i) + 1;
        var right = (2 * i) + 2;
        var largest = i;

        if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[largest]) > 0)
        {
            largest = left;
        }

        if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[largest]) > 0)
        {
            largest = right;
        }

        if (largest != i)
        {
            T old = this.heap[i];
            this.searchCollection[old] = largest;
            this.searchCollection[this.heap[largest]] = i;
            this.heap[i] = this.heap[largest];
            this.heap[largest] = old;
            this.HeapifyDown(largest);
        }
    }

    private void HeapifyUp(int i)
    {
        var parent = (i - 1) / 2;
        while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) > 0)
        {
            T old = this.heap[i];
            this.searchCollection[old] = parent;
            this.searchCollection[this.heap[parent]] = i;
            this.heap[i] = this.heap[parent];
            this.heap[parent] = old;

            i = parent;
            parent = (i - 1) / 2;
        }
    }

    public void DecreaseKey(T element)
    {
        int index = this.searchCollection[element];
        this.HeapifyUp(index);
    }
}