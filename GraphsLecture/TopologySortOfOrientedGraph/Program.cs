using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologySortOfOrientedGraph
{
    class Program
    {
        static bool[] visited;
        static List<int>[] graph;

        static void Main(string[] args)
        {
            graph = new List<int>[]
                {
                    new List<int>{ 1, 2},
                    new List<int>{ 3, 4},
                    new List<int>{ 5 },
                    new List<int>{ 2, 5 },
                    new List<int>{ 3 },
                    new List<int>{ },
                };

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
                var currentNode = nodesWithoutIncomingEdges.First();
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

            if (graph.SelectMany(s=>s).Any())
            {
                Console.WriteLine("Sorry, Cyclical graph!");
            }
            else
            {
                Console.WriteLine(string.Join(" ",result));
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
