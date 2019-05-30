using System;
using System.Collections.Generic;

namespace Protos
{
    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int maxCounter = 0;
        static void Main(string[] args)
        {
            int numberOfProtos = int.Parse(Console.ReadLine());

            graph = new List<int>[numberOfProtos];
            for (int i = 0; i < numberOfProtos; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < numberOfProtos; i++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < numberOfProtos; j++)
                {
                    if (input[j]=='Y')
                    {
                        graph[i].Add(j);
                        graph[j].Add(i);
                    }
                }
            }

            for (int currentProtos = 0; currentProtos < numberOfProtos; currentProtos++)
            {
                visited = new bool[numberOfProtos];
                if (!visited[currentProtos])
                {
                    DFS(currentProtos, 0);
                }
            }
            Console.WriteLine(maxCounter);
        }

        private static void DFS(int currentProtos, int counter)
        {
            visited[currentProtos] = true;
            if (counter>maxCounter)
            {
                maxCounter = counter;
            }

            foreach (var protos in graph[currentProtos])
            {
                if (!visited[protos])
                {
                    DFS(protos, counter + 1);
                }
            }
        }
    }
}
