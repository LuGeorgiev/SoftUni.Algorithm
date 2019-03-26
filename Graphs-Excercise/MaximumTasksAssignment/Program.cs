using System;
using System.Linq;
using System.Collections.Generic;

namespace MaximumTasksAssignment
{
    class Program
    {
        private static int[][] graph;
        private static int[] parents;

        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine().Split(' ')[1]);
            int tasks = int.Parse(Console.ReadLine().Split(' ')[1]);

            var nodes = people + tasks + 2;// we have start and sink node for MAX FLOW

            //n=3 - S A B C 1 2 3 E
            graph = new int[nodes][];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new int[nodes];
            }

            for (int i = 0; i < people; i++)
            {
                graph[0][i + 1] = 1; // connect begining S with all the people
            }
            for (int i = 0; i < tasks; i++)
            {
                graph[i + people + 1][graph.Length - 1] = 1;// connect END with TASKS
            }

            for (int person = 0; person < people; person++)
            {
                var currentLine = Console.ReadLine();

                for (int task = 0; task < tasks; task++)
                {
                    if (currentLine[task]=='Y')
                    {
                        graph[people + 1][task + people +1] = 1;
                    }
                }
            }
            // INPUT filled in
            parents = new int[graph.Length];
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = -1;
            }

            var start = 0;
            var end = graph.Length - 1;
            while (Bfs(start, end))
            {
                var currentNode = end;
                while (currentNode != start)
                {
                    var prevNode = parents[currentNode];
                    graph[prevNode][currentNode] = 0;
                    graph[currentNode][prevNode] = 1;

                    currentNode = prevNode;
                }
            }

            //next is to extract the solution
            //BFS from TASK to People (backwards) in order to form person-task graph

            var queue = new Queue<int>();
            var result = new SortedSet<string>();
            var visited = new bool[graph.Length];
            visited[end] = true;
            queue.Enqueue(end);

            while (queue.Count>0)
            {
                var node = queue.Dequeue();

                for (int child = 0; child < graph.Length; child++)
                {
                    if (graph[node][child]>0 && !visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;

                        if (node != end && node != start && 
                            child!= end && child != start)
                        {
                            //result.Add($"{child}-{node}");
                            result.Add($"{(char)(child-1+'A')}-{node-people}");
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static bool Bfs(int start, int end)
        {
            var visited = new bool[graph.Length];

            var queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count>0)
            {
                var node = queue.Dequeue();
                for (int child = 0; child < graph.Length; child++)
                {
                    if (!visited[child] && graph[node][child] > 0)
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        parents[child] = node;
                    }
                }
            }

            return visited[end];
        }
    }
}
