using System;
using System.Collections.Generic;
using System.Text;

namespace ModifiedKruskalAlgorithm
{
    public class Edge :IComparable<Edge>
    {
        public Edge(Node startNode, Node endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public Node StartNode { get; set; }
        public Node EndNode { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Edge other)
            => this.Weight.CompareTo(other.Weight);

        public override string ToString()
            => $"({this.StartNode.Value} {this.EndNode.Value}) -> {this.Weight}";
    }
}
