using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Molecules
{

    class Program
    {
        static void Main(string[] args)
        {
            var nodes = new Dictionary<int, Node>();
            int nodesNumber = int.Parse(Console.ReadLine());
            for (int i = 1; i <= nodesNumber; i++)
            {
                nodes.Add(i, new Node(i));

            }
            int verecesNumber = int.Parse(Console.ReadLine());

            var graph = new Dictionary<Node, Dictionary<Node, int>>();
            foreach (var node in nodes.Values)
            {
                graph[node] = new Dictionary<Node, int>();
            }

            for (int i = 0; i < verecesNumber; i++)
            {
                var vertArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int from = vertArgs[0];
                int to = vertArgs[1];
                int weight = vertArgs[2];

                graph[nodes[from]].Add(nodes[to], weight);
            }

            var trace = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = trace[0];
            int end = trace[1];

            PrintPath(graph, nodes, start, end);
        }
        public static void PrintPath(Dictionary<Node, Dictionary<Node, int>> graph, Dictionary<int, Node> nodes, int sourceNode, int destinationNode)
        {
            var path = DijkstraWithPriorityQueue.DijkstraAlgorithm(graph, nodes[sourceNode], nodes[destinationNode]);
            Console.WriteLine(nodes[destinationNode].DistanceFromStart);


            HashSet<int> unreachableNodes = UnreachableFill(graph, nodes, sourceNode);
            Console.WriteLine(string.Join(" ", unreachableNodes.OrderBy(x => x)));

        }

        private static HashSet<int> UnreachableFill(Dictionary<Node, Dictionary<Node, int>> graph, Dictionary<int, Node> nodes, int sourceNode)
        {
            HashSet<int> visitedNodes = new HashSet<int>();
            visitedNodes.Add(sourceNode);
            foreach (var child in graph[nodes[sourceNode]].Keys)
            {
                DFS(child, visitedNodes, graph, nodes);
            }
            HashSet<int> unVisited = new HashSet<int>();

            foreach (var nodeId in nodes.Keys)
            {
                if (!visitedNodes.Contains(nodeId))
                {
                    unVisited.Add(nodeId);
                }
            }

            return unVisited;
        }

        private static void DFS(Node current, HashSet<int> visitedNodes, Dictionary<Node, Dictionary<Node, int>> graph, Dictionary<int, Node> nodes)
        {
            if (!visitedNodes.Contains(nodes[current.Id].Id))
            {
                visitedNodes.Add(current.Id);
                foreach (var child in graph[nodes[current.Id]].Keys)
                {
                    DFS(child, visitedNodes, graph, nodes);
                }
            }
        }
    }
    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(
            Dictionary<Node, Dictionary<Node, int>> graph,
            Node sourceNode,
            Node destinationNode)
        {
            int?[] previous = new int?[graph.Count + 1];
            bool[] visited = new bool[graph.Count + 1];
            var priorityQueue = new PriorityQueue<Node>();

            foreach (var kvp in graph)
            {
                kvp.Key.DistanceFromStart = double.PositiveInfinity;
            }
            sourceNode.DistanceFromStart = 0;
            priorityQueue.Enqueue(sourceNode);

            visited[sourceNode.Id] = true;
            while (priorityQueue.Count > 0)
            {
                var curentNode = priorityQueue.ExtractMin();

                if (curentNode.CompareTo(destinationNode) == 0)
                {
                    break;
                }

                foreach (var edge in graph[curentNode])
                {
                    if (!visited[edge.Key.Id])
                    {
                        priorityQueue.Enqueue(edge.Key);
                        visited[edge.Key.Id] = true;
                    }

                    var distance = curentNode.DistanceFromStart + graph[curentNode][edge.Key];
                    if (distance < edge.Key.DistanceFromStart)
                    {
                        edge.Key.DistanceFromStart = distance;
                        previous[edge.Key.Id] = curentNode.Id;
                        priorityQueue.DecreaseKey(edge.Key);
                    }
                }
            }

            if (double.IsInfinity(destinationNode.DistanceFromStart))
            {
                return null;
            }

            var path = new List<int>();
            int? current = destinationNode.Id;
            while (current != null)
            {
                path.Add(current.Value);
                current = previous[current.Value];
            }
            path.Reverse();

            return path;
        }
    }

    public class Node : IComparable<Node>
    {
        // set default value for the distance equal to positive infinity
        public Node(int id, double distance = double.PositiveInfinity)
        {
            this.Id = id;
            this.DistanceFromStart = distance;
        }

        public int Id { get; set; }

        public double DistanceFromStart { get; set; }

        public int CompareTo(Node other)
        {
            return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
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

        public T ExtractMin()
        {
            var min = this.heap[0];
            var last = this.heap[this.heap.Count - 1];
            this.searchCollection[last] = 0;
            this.heap[0] = last;
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.HeapifyDown(0);
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
            this.HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyDown(int i)
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
                this.HeapifyDown(smallest);
            }
        }

        private void HeapifyUp(int i)
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
            this.HeapifyUp(index);
        }
    }
}
