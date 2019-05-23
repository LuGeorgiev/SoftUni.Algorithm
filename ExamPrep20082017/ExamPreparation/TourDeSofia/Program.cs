using System;
using System.Collections.Generic;
using System.Linq;

namespace TourDeSofia
{
    class Program
    {
        private static HashSet<int>[] graph;
        private static int start;
        private static HashSet<int> visited = new HashSet<int>();
        private static int[] previous;
        private static bool pathFound = false;

        static void Main(string[] args)
        {
            FillGraph();

            var queue = new Queue<int>();
            queue.Enqueue(start);

            BFS(queue);

            if (pathFound)
            {
                int pathLength = CalculatePath(start);
                Console.WriteLine(pathLength);
            }
            else
            {
                Console.WriteLine(visited.Count);
            }
        }

        private static int CalculatePath(int start)
        {
            int count = 1;
            var parent = previous[start];
            while (true)
            {
                if (parent ==start)
                {
                    return count;
                }
                parent = previous[parent];
                count++;
            }
        }

        private static void BFS(Queue<int> queue)
        {
            while (queue.Count>0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode == start && visited.Contains(start))
                {
                    pathFound = true;
                    return;
                }

                visited.Add(currentNode);
                foreach (var child in graph[currentNode])
                {
                    if (previous[child] == -1)
                    {
                        previous[child] = currentNode;
                    }
                    queue.Enqueue(child);
                }
            }
        }

        private static void FillGraph()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());
            start = int.Parse(Console.ReadLine());
            previous = Enumerable.Repeat(-1, nodes).ToArray();

            graph = new HashSet<int>[nodes];
            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new HashSet<int>();
            }
            for (int i = 0; i < edges; i++)
            {
                var tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                graph[tokens[0]].Add(tokens[1]);
            }
        }
    }
}
