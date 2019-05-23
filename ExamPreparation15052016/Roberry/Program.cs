using System;
using System.Collections.Generic;
using System.Linq;

namespace Roberry
{
    class Program
    {
        static bool[] colors;
        static int[] distTo;
        static int[] stepsTo;
        static bool[] visited;

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            colors = new bool[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                colors[i] = input[i][input[i].Length - 1] == 'w';
            
            }
            int energy = int.Parse(Console.ReadLine());
            int waitCost = int.Parse(Console.ReadLine());
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int edgeCount = int.Parse(Console.ReadLine());

            List<Edge>[] graph = new List<Edge>[input.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }
            distTo = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
            stepsTo = new int[graph.Length];
            visited = new bool[graph.Length];

            for (int i = 0; i < edgeCount; i++)
            {
                int[] edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int from = edge[0];
                int to = edge[1];
                int weight= edge[2];
                graph[from].Add(new Edge(to, weight));
            }

            Dijikstra(graph, start, end, waitCost);

            int energyLeft = energy - distTo[end];
            if (energyLeft >= 0)
            {
                Console.WriteLine(energyLeft);
            }
            else
            {
                Console.WriteLine($"Busted - need {Math.Abs(energyLeft)} more energy");
            }
        }

        private static void Dijikstra(List<Edge>[] graph, int start, int end, int waitCost)
        {
            distTo[start] = 0;
            while (true)
            {
                int vertex = GetCurrentVertex();
                if (vertex == -1 || vertex == end)
                {
                    break;
                }

                Visit(graph, vertex, waitCost);
            }
        }

        private static void Visit(List<Edge>[] graph, int vertex, int waitCost)
        {
            visited[vertex] = true;
            foreach (var edge in graph[vertex])
            {
                int steps = stepsTo[vertex];
                bool color = steps % 2 == 0 ? colors[edge.To] : !colors[edge.To];
                int additionalCost = color == true ? 0 : waitCost;

                int distance = distTo[vertex] + edge.Weight + additionalCost;
                if (distTo[edge.To] > distance)
                {
                    distTo[edge.To] = distance;
                    stepsTo[edge.To] = steps + 1;
                    if (!color)
                    {
                        stepsTo[edge.To]++;
                    }
                }
            }
        }

        private static int GetCurrentVertex()
        {
            int index = -1;
            int lowestDist = int.MaxValue;
            for (int i = 0; i < distTo.Length; i++)
            {
                if (!visited[i] && distTo[i] < lowestDist)
                {
                    index = i;
                    lowestDist = distTo[i];
                }
            }
            return index;
        }
    }

    internal class Edge
    {
        public Edge(int to, int weigh)
        {
            this.To = to;
            this.Weight = weigh;
        }
        public int To { get; set; }
        public int Weight { get; set; }

        public override string ToString()
           =>$"{this.To}, {this.Weight}";
    }

    class PriorityQueue<T>
        where T : IComparable<T>
    {
        private Dictionary<T, int> searchCollection;
        private List<T> heap;

        public PriorityQueue()
        {
            this.heap = new List<T>();
            this.searchCollection = new Dictionary<T, int>();
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public T DequeueMin()
        {
            var min = this.heap[0];
            var last = this.heap[this.heap.Count - 1];
            this.searchCollection[last] = 0;
            this.heap[0] = last;
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.Sink(0);
            }

            this.searchCollection.Remove(min);

            return min;
        }

        public T PeekMin()
        {
            return this.heap[0];
        }

        public void Enqueue(T element)
        {
            this.searchCollection.Add(element, this.heap.Count);
            this.heap.Add(element);
            this.Swim(this.heap.Count - 1);
        }

        private void Sink(int i)
        {
            var left = (2 * i) + 1;
            var right = (2 * i) + 2;
            var smallest = i;

            if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = left;
            }

            if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = right;
            }

            if (smallest != i)
            {
                T old = this.heap[i];
                this.searchCollection[old] = smallest;
                this.searchCollection[this.heap[smallest]] = i;
                this.heap[i] = this.heap[smallest];
                this.heap[smallest] = old;
                this.Sink(smallest);
            }
        }

        private void Swim(int i)
        {
            var parent = (i - 1) / 2;
            while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
            {
                T old = this.heap[i];
                this.searchCollection[old] = parent;
                this.searchCollection[this.heap[parent]] = i;
                this.heap[i] = this.heap[parent];
                this.heap[parent] = old;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public void DecreaseKey(T element)
        {
            int index = this.searchCollection[element];
            this.Swim(index);
        }
    }
}
