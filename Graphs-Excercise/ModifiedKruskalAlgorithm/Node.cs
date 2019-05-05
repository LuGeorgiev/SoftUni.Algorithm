using System;
using System.Collections.Generic;
using System.Text;

namespace ModifiedKruskalAlgorithm
{
    public class Node
    {
        public Node(int root)
        {
            this.Value = root;
            this.Children = new List<Node>();
            this.Parent = this;
        }

        public int Value { get; set; }

        public Node Parent { get; set; }

        public List<Node> Children { get; set; }
    }
}
