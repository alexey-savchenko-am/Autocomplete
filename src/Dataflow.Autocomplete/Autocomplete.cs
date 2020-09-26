using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dataflow.Autocomplete
{
    public class Autocomplete
        : IAutocomplete
    {
        private readonly Trie _trie;

        private Autocomplete()
        {
            _trie = new Trie();
        }

        public static IAutocomplete Process(IEnumerable<string> payload)
        {
            var autocomplete = new Autocomplete();
            return autocomplete.ProcessInternal(payload);
        }

        public ICollection<string> Match(string str)
        {
           return _trie.Search(str);
        }

        private IAutocomplete ProcessInternal(IEnumerable<string> payload)
        {
            var enumerator = payload.GetEnumerator();
            while (enumerator.MoveNext())
            {
                _trie.Add(enumerator.Current);
            }

            return this;
        }


    }
}
