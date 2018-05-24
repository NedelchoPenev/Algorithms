using System;
using System.Collections.Generic;
using System.Linq;

class CableNetwork
{
    static void Main(string[] args)
    {
        var budget = int.Parse(Console.ReadLine().Split()[1]);
        var nodesCount = int.Parse(Console.ReadLine().Split()[1]);
        var edgesCount = int.Parse(Console.ReadLine().Split()[1]);

        var nodes = new List<Node>();
        var edges = new List<Edge>();

        for (int i = 0; i < nodesCount; i++)
        {
            nodes.Add(new Node { IsConnected = false, Value = i });
        }

        for (int i = 0; i < edgesCount; i++)
        {
            var input = Console.ReadLine().Split();
            var from = int.Parse(input[0]);
            var to = int.Parse(input[1]);
            var price = int.Parse(input[2]);
            bool isConnected = input.Length > 3;

            Node NodeFrom = nodes.Single(n => n.Value == from);
            Node NodeTo = nodes.Single(n => n.Value == to);

            edges.Add(new Edge { From = NodeFrom, To = NodeTo, Price = price });

            if (isConnected)
            {
                NodeFrom.IsConnected = true;
                NodeTo.IsConnected = true;
            }
        }

        int budgetUsed = 0;

        while (budgetUsed < budget)
        {
            var currentEdge = edges
                .OrderBy(e => e.Price)
                .FirstOrDefault(e => !e.From.IsConnected && e.To.IsConnected || e.From.IsConnected && !e.To.IsConnected);

            if (currentEdge == null || budget < budgetUsed + currentEdge.Price)
            {
                break;
            }

            budgetUsed += currentEdge.Price;
            currentEdge.From.IsConnected = true;
            currentEdge.To.IsConnected = true;
        }

        
        Console.WriteLine($"Budget used: {budgetUsed}");
    }
}

class Node
{
    public int Value { get; set; }

    public bool IsConnected { get; set; }
}

class Edge
{
    public Node From { get; set; }

    public Node To { get; set; }

    public int Price { get; set; }
}