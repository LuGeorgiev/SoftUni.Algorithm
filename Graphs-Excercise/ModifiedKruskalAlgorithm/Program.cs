using System;
using System.Collections.Generic;
using System.Linq;

namespace ModifiedKruskalAlgorithm
{
    class Program
    {
        private static List<Edge> edges;
        private static Node[] nodes;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine()
                                    .Split(' ')
                                    .ToArray()[1]);
            var edgesCount = int.Parse(Console.ReadLine()
                                     .Split(' ')
                                     .ToArray()[1]);

            edges = new List<Edge>();
            nodes = new Node[nodesCount];

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeTokens = Console.ReadLine()
                    .Split(' ')
                    .Select(x => int.Parse(x))
                    .ToArray();

                var startNodeValue = edgeTokens[0];
                Node startNode = null;
                if (nodes[startNodeValue] == null)
                {
                    startNode = new Node(startNodeValue);
                    nodes[startNodeValue] = startNode;
                }
                else
                {
                    startNode = nodes[startNodeValue];
                }

                var endNodeValue = edgeTokens[1];
                Node endNode = null;
                if (nodes[endNodeValue] == null)
                {
                    endNode = new Node(endNodeValue);
                    nodes[endNodeValue] = endNode;
                }
                else
                {
                    endNode = nodes[endNodeValue];
                }

                edges.Add(new Edge(startNode, endNode, edgeTokens[2]));

            }
            List<Edge> minimalSpanningTree = ModifiedKruskal();

            Console.WriteLine($"Minimum spanning forest weight: {minimalSpanningTree.Sum(x=>x.Weight)}");
            minimalSpanningTree.ForEach(x => Console.WriteLine(x));
        }

        private static List<Edge> ModifiedKruskal()
        {
            edges.Sort();
            var MST = new List<Edge>();

            foreach (var edge in edges)
            {
                var startNode = edge.StartNode;
                if (startNode.Parent.Value != edge.EndNode.Parent.Value)
                {
                    MST.Add(edge);

                    var currentEndNodeParent = edge.EndNode.Parent;

                    foreach (var child in edge.EndNode.Parent.Children)
                    {
                        startNode.Parent.Children.Add(child);
                        child.Parent = startNode.Parent;
                    }
                    startNode.Parent.Children.Add(currentEndNodeParent);
                    currentEndNodeParent.Parent = startNode.Parent;
                }
            }

            return MST;
        }
    }
}
