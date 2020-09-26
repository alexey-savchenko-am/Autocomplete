using System.Collections.Generic;

namespace Dataflow.Autocomplete
{

    internal sealed class Trie
    {

        private readonly Node _root = new Node(null, null, null, 0);

        public void Add(string word)
        {
            var pref = FindPrefixNode(word);

            // do not try to add dublicate word to trie
            if (pref.Prefix != null && pref.Prefix.Equals(word))
                return;

            var currentNode = pref;

            string txt = pref.Prefix;

            for (var i = currentNode.Index; i < word.Length; i++)
            {
                var ch = word[i];
                txt += ch;
                var newNode = new Node(ch, txt, currentNode, i + 1);
                currentNode.Children.Add(ch, newNode);
                currentNode = newNode;
            }

            var finishNode = new Node(Node.EOW, txt, currentNode, currentNode.Index + 1);
            currentNode.Children.Add(Node.EOW, finishNode);

        }

        public List<string> Search(string key)
        {
            var result = new List<string>();

            var pref = FindPrefixNode(key);

            if (pref == _root)
                return result;

            if (!pref.Prefix.Equals(key))
                return result;

            SearchInternal(pref, result);

            return result;
        }


        private void SearchInternal(Node node, List<string> result)
        {
            if (node.IsLeaf())
            {
                result.Add(node.Prefix);
                return;
            }


            foreach (var child in node.Children)
            {
                SearchInternal(child.Value, result);
            }
        }


        private Node FindPrefixNode(string word)
        {
            var result = _root;

            foreach (var symbol in word)
            {
                if (result.Children != null && result.Children.TryGetValue(symbol, out var node))
                {
                    result = node;
                    continue;
                }

                break;
            }

            return result;
        }

  
    }
}
