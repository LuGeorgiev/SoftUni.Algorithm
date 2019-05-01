using System;
using System.Collections.Generic;
using System.Linq;


//We are given a directed graph.We are given also a set of pairs of vertices.Find the shortest distance between each pair of vertices or -1 if there is no path connecting them.  
//On the first line, you will get N, the number of vertices in the graph. On the second line, you will get P, the number of pairs between which to find the shortest distance.
//On the next N lines will be the edges of the graph and on the next P lines, the pairs.

namespace DistanceBetweenVetrices
{

    class Program
    {
        static Dictionary<int, List<int>> graph;

        static void Main(string[] args)
        {
            var nodeInputs = int.Parse(Console.ReadLine());
            var pathsNumber = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodeInputs; i++)
            {
                var nodeData = Console.ReadLine()
                    .Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var currentNode = nodeData[0];
                if (!graph.ContainsKey(currentNode))
                {
                    graph[currentNode] = new List<int>();
                }
                if (nodeData.Length > 1)
                {
                    for (int j = 1; j < nodeData.Length; j++)
                    {
                        graph[currentNode].Add(nodeData[j]);
                    }
                }
            }

            for (int i = 0; i < pathsNumber; i++)
            {
                var verticesData = Console.ReadLine()
                    .Split('-')
                    .Select(int.Parse)
                    .ToArray();
                int start = verticesData[0];
                int end = verticesData[1];

                var distance = CalculateDistance(start, end);
                Console.WriteLine($"{{{start}, {end}}} -> {distance}");
            }
        }

        private static int CalculateDistance(int start, int end)
        {
            
            var queue = new Queue<int>();
            var visited = new HashSet<int>();
            var distances = new Dictionary<int, int>();
            distances.Add(start,0);
            visited.Add(start);

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var curentNode = queue.Dequeue();

                foreach (var child in graph[curentNode])
                {
                    if (child == end)
                    {
                        return distances[curentNode]+1 ;
                    }
                    else if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                        var currentDistance = distances[curentNode]+1;
                        distances.Add(child, currentDistance);
                    }
                }
            }

            return -1;
        }
    }
}
