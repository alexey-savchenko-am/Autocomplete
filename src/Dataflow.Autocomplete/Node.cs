using System;
using System.Collections.Generic;
using System.Text;

namespace Dataflow.Autocomplete
{
    internal sealed class Node
    {
        public static char EOW = '$';

        public char? Value { get; set; }

        public string Prefix { get; set; }

        public Dictionary<char?, Node> Children { get; set; }

        public Node Parent { get; set; }

        public int Index { get; set; }

        public Node(char? value, string prefix, Node parent, int index)
        {
            Value = value;
            Prefix = prefix;
            Parent = parent;
            Index = index;
            Children = new Dictionary<char?, Node>();

        }

        public bool IsLeaf()
        {
            return Value == EOW && Children.Count == 0;
        }

        public void AppendChild(Node node)
        {
            Children.Add(node.Value, node);
        }

    }
}
