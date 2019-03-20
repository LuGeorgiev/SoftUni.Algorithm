using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static bool[] visitedNodes;
        static List<int>[] graphNoDirect;

        static void Main(string[] args)
        {
             graphNoDirect = new List<int>[]
            {
                new List<int>{2, 3, 4, 5, 6 },
                new List<int>{3,6 },
                new List<int>{0, 1, 5 },
                new List<int>{1, 4, 4 },
                new List<int>{1, 2, 6 },
                new List<int>{1, 2, 3 },
                new List<int>{0, 1, 4},
            };

            visitedNodes = new bool[graphNoDirect.Length];
            for (int i = 0; i < graphNoDirect.Length; i++)
            {
                DFS(i);
            }

            Console.WriteLine();           
        }
              

        private static void DFS(int node)
        {
            if (!visitedNodes[node])
            {
                visitedNodes[node] = true;

                foreach (var child in graphNoDirect[node])
                {
                    DFS(child);
                }
                Console.Write($"{node} ");
            }
        }
    }
}
