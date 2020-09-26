using System;
using System.Collections.Generic;
using System.Text;

namespace Dataflow.Autocomplete
{
    public interface IAutocomplete
    {
        ICollection<string> Match(string str);
    }
}
