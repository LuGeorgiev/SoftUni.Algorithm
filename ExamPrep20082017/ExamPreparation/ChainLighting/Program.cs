using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainLighting
{
    class Program
    {
        static private bool[] marked;
        static private int[] damage;
        static private PriorityQueue<Edge> queue;
        static private Dictionary<int, List<int>> msf;

        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());
            int lightingCount = int.Parse(Console.ReadLine());

            var graph = new List<Edge>[nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                graph[i] = new List<Edge>();
            }
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeTokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int from = edgeTokens[0];
                int to = edgeTokens[1];
                int weight = edgeTokens[2];
                var edge = new Edge(from, to, weight);
                graph[from].Add(edge);
                graph[to].Add(edge);
            }

            marked = new bool[graph.Length];
            damage = new int[graph.Length];
            msf = new Dictionary<int, List<int>>();

            for (int i = 0; i < graph.Length; i++)
            {
                PrimMSF(graph, i);
            }

            for (int i = 0; i < lightingCount; i++)
            {
                var lightingArgs = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int source = lightingArgs[0];
                int power = lightingArgs[1];

                DFS(source, source, power);
            }

            Console.WriteLine(damage.Max());
        }

        private static void DFS(int vertex, int parent, int power)
        {
            damage[vertex] += power;
            foreach (var child in msf[vertex])
            {
                if (child!=parent)
                {
                    DFS(child, vertex, power / 2);
                }
            }
        }

        private static void PrimMSF(List<Edge>[] graph, int source)
        {
            queue = new PriorityQueue<Edge>();

            Visit(graph, source);

            while (queue.Count>0)
            {
                var edge = queue.DequeueMin();
                int v = edge.Either();
                int w = edge.Other(v);

                if (marked[v] && marked[w])
                {
                    continue;
                }

                AddEdgeToMSF(edge);

                if (!marked[v])
                {
                    Visit(graph, v);
                }
                if (!marked[w])
                {
                    Visit(graph, w);
                }
            }
        }

        private static void AddEdgeToMSF(Edge edge)
        {
            if (!msf.ContainsKey(edge.V))
            {
                msf.Add(edge.V, new List<int>());
            }

            if (!msf.ContainsKey(edge.W))
            {
                msf.Add(edge.W, new List<int>());
            }

            msf[edge.V].Add(edge.W);
            msf[edge.W].Add(edge.V);
        }

        private static void Visit(List<Edge>[] graph, int source)
        {
            marked[source] = true;
            foreach (var edge in graph[source])
            {
                if (!marked[edge.Other(source)])
                {
                    queue.Enqueue(edge);
                }
            }
        }
    }

    
}
