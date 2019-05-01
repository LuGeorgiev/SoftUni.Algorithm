using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace MostReliablePath
{
    class Program
    {
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
            var nodes = int.Parse(Console.ReadLine().Split(' ')[1]);
            var pathParts = Console.ReadLine().Split(' ');
            var start = int.Parse(pathParts[1]);
            var end = int.Parse(pathParts[3]);

            var edges = int.Parse(Console.ReadLine().Split(' ')[1]);
            graph = new Dictionary<int, List<Edge>>();

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
            }

            var percentages = Enumerable.Repeat<double>(-1, graph.Count).ToArray();
            percentages[start] = 100;

            var visited = new bool[graph.Count];
            visited[start] = true;

            var previous = new int[graph.Count];
            previous[start] = -1;

            var queue = new OrderedBag<int>(
                Comparer<int>.Create((a, b) => (int)(percentages[b] - percentages[a])));
            queue.Add(start);

            while (queue.Count > 0)
            {
                var min = queue.RemoveFirst();
                if (percentages[min] == -1)
                {
                    break;
                }

                foreach (var child in graph[min])
                {
                    var otherNode = child.First == min
                        ? child.Second
                        : child.First;

                    if (!visited[otherNode])
                    {
                        visited[otherNode] = true;
                        queue.Add(otherNode);
                    }
                    var newPerc = percentages[min] / 100 * child.Cost;
                    if (percentages[otherNode] < newPerc)
                    {
                        percentages[otherNode] = newPerc;

                        //For backtracking
                        previous[otherNode] = min;

                        //To reorder the changed path
                        queue = new OrderedBag<int>(queue,
                            Comparer<int>.Create((a, b) => (int)(percentages[b] - percentages[a])));
                    }
                }
            }

            var result = new List<int>();
            var current = end;
            while (current!=-1)
            {
                result.Add(current);

                current = previous[current];
            }
            result.Reverse();


            Console.WriteLine($"Most realiable path: {percentages[end]:F2}%");
            Console.WriteLine(string.Join(" -> ", result));
        }
    }
}
