using System;
using System.Linq;
using System.Diagnostics;
namespace Dataflow.Autocomplete.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var autocomplete = Autocomplete.Process(Names.All);

            var sw = new Stopwatch();

            while (true)
            {
                Console.Write("Type a name or a part of name you want to find: ");

                var word = Console.ReadLine();

                sw.Start();
                var matches = autocomplete.Match(word);
                sw.Stop();

                if (matches.Any())
                {
                    var result = string.Join(", ", matches);
                    Console.WriteLine($"Matches detected ({sw.ElapsedTicks} ticks): {result}");
                }
                else
                    Console.WriteLine("No matches detected");

                sw.Reset();

                Console.WriteLine();

                if (word.Equals("exit"))
                    break;

            }

        }
    }
}
