# Autocomplete

Splits an array of words into symbol's tree and allows quickly search data by key inside this tree.

# Usage

```
var words = new string[]
{
  "rose", "blade", "black", "alphabet", "blue", "bold", "ring", "banana", "blazer" 
};

var autocomplete = Autocomplete.Process(words);

// returns: "blade", "black", "blue", "bold",  "banana", "blazer" 
var matches = autocomplete.Match("b");

// returns: "blade", "black", "blue", "blazer" 
matches = autocomplete.Match("bl");

// returns: "blade", "black", "blazer" 
matches = autocomplete.Match("bla");

```
