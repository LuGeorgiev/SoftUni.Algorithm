using System;
using System.Collections.Generic;
using System.Linq;

namespace Sticks
{
    class Program
    {
        static bool[] visited;
        private static List<int>[] graph;

        static void Main(string[] args)
        {
            var sticksCount = int.Parse(Console.ReadLine());
            var numberOfPlacings = int.Parse(Console.ReadLine());

            graph = new List<int>[sticksCount];
            for (int i = 0; i < sticksCount; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < numberOfPlacings; i++)
            {
                var tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                var stickIndex = tokens[0];
                var isOnStick = tokens[1];

                graph[stickIndex].Add(isOnStick);
            }

            var result = new List<int>();
            var nodesWithoutIncomingEdges = new HashSet<int>();

            HashSet<int> nodesWithIncomingEdges = NodesWithIncomingEdges();

            //find the nodes that do not have outgoing edges
            for (int i = 0; i < graph.Length; i++)
            {
                if (!nodesWithIncomingEdges.Contains(i))
                {
                    nodesWithoutIncomingEdges.Add(i);
                }
            }

            while (nodesWithoutIncomingEdges.Count != 0)
            {
                var currentNode = nodesWithoutIncomingEdges
                    .OrderByDescending(x=>x)
                    .First();
                nodesWithoutIncomingEdges.Remove(currentNode); // remove the edge that has no outgoing edges
                result.Add(currentNode);
                var children = graph[currentNode].ToList();
                graph[currentNode] = new List<int>(); // remove all edges

                var leftNodesWithIncomingEdges = NodesWithIncomingEdges();

                foreach (var child in children)
                {
                    if (!leftNodesWithIncomingEdges.Contains(child))
                    {
                        nodesWithoutIncomingEdges.Add(child);
                    }
                }
            }

            if (graph.SelectMany(s => s).Any())
            {
                Console.WriteLine("Cannot lift all sticks");
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }

        private static HashSet<int> NodesWithIncomingEdges()
        {
            var nodesWithIncomingEdges = new HashSet<int>();

            //Find all node with incoming edges
            graph.SelectMany(s => s)
                .ToList()
                .ForEach(e => nodesWithIncomingEdges.Add(e));

            return nodesWithIncomingEdges;
        }
    }
}
