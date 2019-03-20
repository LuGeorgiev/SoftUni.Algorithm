using System;
using System.Collections.Generic;

namespace BfsGraph
{
    class Program
    {
        static bool[] visitedNodes;
        static List<int>[] graphNoDirect;

        static void Bfs(int n)
        {
            if (visitedNodes[n])
            {
                return;
            }
            var queue = new Queue<int>();
            queue.Enqueue(n);
            visitedNodes[n] = true;

            while (queue.Count!=0)
            {
                var currentNode = queue.Dequeue();
                Console.Write(currentNode +" ");
                foreach (var child in graphNoDirect[currentNode])
                {
                    if (!visitedNodes[child])
                    {
                        queue.Enqueue(child);
                        visitedNodes[child] = true;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            graphNoDirect = new List<int>[]
           {
                new List<int>{3,6 },
                new List<int>{1, 4, },
                new List<int>{2, 3, 4, 5, 6 },
                new List<int>{0, 1, 5 },
                new List<int>{1, 2, 6 },
                new List<int>{1, 2, 3 },
                new List<int>{0, 1, 4},
           };

            visitedNodes = new bool[graphNoDirect.Length];
            for (int i = 0; i < graphNoDirect.Length; i++)
            {
                Bfs(0);
            }

        }
    }
}
