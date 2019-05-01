using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CableNetwork
{
    class Program
    {
        // MST Approach
        class Edge
        {
            public int First { get; set; }

            public int Second { get; set; }

            public int Cost { get; set; }
        }

        static Dictionary<int, List<Edge>> graph;

        static HashSet<int> spanningTree;

        static int totalBudget;
        static int usedBudget = 0;

        static void Main(string[] args)
        {
            totalBudget = int.Parse(Console.ReadLine().Split(' ')[1]);
            var nodes = int.Parse(Console.ReadLine().Split(' ')[1]);
            var edges = int.Parse(Console.ReadLine().Split(' ')[1]);

            graph = new Dictionary<int, List<Edge>>();
            spanningTree = new HashSet<int>();

            for (int i = 0; i < edges; i++)
            {
                var edgeParts = Console.ReadLine().Split(' ');
                var edge = new Edge
                {
                    First = int.Parse(edgeParts[0]),
                    Second = int.Parse(edgeParts[1]),
                    Cost = int.Parse(edgeParts[2])
                };

                if (!graph.ContainsKey(edge.First))
                {
                    graph[edge.First] = new List<Edge>();
                }

                if (!graph.ContainsKey(edge.Second))
                {
                    graph[edge.Second] = new List<Edge>();
                }

                graph[edge.First].Add(edge);
                graph[edge.Second].Add(edge);

                if (edgeParts.Length>3)
                {
                    spanningTree.Add(edge.First);
                    spanningTree.Add(edge.Second);
                }
            }

            Prim();
            Console.WriteLine($"Budget used: {usedBudget}");
        }

        public static void Prim()
        {
            var queue = new OrderedBag<Edge>(Comparer<Edge>.Create((a, b) => a.Cost - b.Cost));
            queue.AddMany(spanningTree
                .SelectMany(n => graph[n]));

            while (queue.Count>0)
            {
                var min = queue.RemoveFirst();
                var nonTreeNode = -1;

                if (spanningTree.Contains(min.First) && !spanningTree.Contains(min.Second))
                {
                    nonTreeNode = min.Second;
                }
                if (!spanningTree.Contains(min.First) && spanningTree.Contains(min.Second))
                {
                    nonTreeNode = min.First;
                }
                if (nonTreeNode==-1)
                {
                    continue;
                }

                if (totalBudget >= min.Cost)
                {
                    totalBudget -= min.Cost;
                    usedBudget += min.Cost;
                }
                else
                {
                    break;
                }

                spanningTree.Add(nonTreeNode);
                queue.AddMany(graph[nonTreeNode]);
            }
        }
    }
}
