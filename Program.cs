using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Frequency_analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            bool caseSensitive = true;
            string input="";
            if (args.Length == 0) // Ends if there are no arguments with error message
            {
                Console.WriteLine("Missing arguments. Please enter essential filepath argument and optional case sensitivity argument (true by default)");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
            else if (args.Length == 1) // Inputs text from file and save it in string
            {
                input = File.ReadAllText(args[0]);

            }
            else // more than one argument makes it non case sensitive
            {
                input = File.ReadAllText(args[0]);
                caseSensitive = false;
            }

            Dictionary<string, int> freqMap = ParseString(input, caseSensitive);
            Console.WriteLine(args[0]);
            PrintMap(freqMap, caseSensitive);

            return;

        }


        static Dictionary<string, int> ParseString(string input, bool caseSensitive)
        {
            Dictionary<string, int> map;

            map = caseSensitive ? new Dictionary<string, int>() : new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase); // Uses ternary conditional operator to call correct constructor based on boolean
       
            foreach (var item in input)
            {
               
                if (Char.IsWhiteSpace(item)/*|| Char.IsPunctuation(item)*/) // Checks for whitespace character from list (https://learn.microsoft.com/en-us/dotnet/api/system.char.iswhitespace?view=net-7.0), Note: commented out but option to include punction is there (https://learn.microsoft.com/en-us/dotnet/api/system.char.ispunctuation?view=net-7.0)
                {
                    continue;
                }
                if (map.ContainsKey(item.ToString())) // Check for existing char in map
                {
                    map[item.ToString()] += 1;
                }
                else // Adds if char not present in map
                {
                    map.Add(item.ToString(), 1);
                }
            }
            
            return map;
        }

        static void PrintMap(Dictionary<string, int> toPrint, bool caseSensitive)
        {
            int totalChars = toPrint.Sum(x => x.Value);
            Console.WriteLine("Total characters: " + totalChars);

            foreach (KeyValuePair<string, int> pair in toPrint.OrderByDescending(i => i.Value).Take(10)) // Uses linq and lambda expression to order map descending (Acsending requires removal of 'Descending' from .OrderByDescending"
            {
                if (caseSensitive)
                {
                    Console.WriteLine(pair.Key + " (" + pair.Value + ")");
                }
                else
                {
                    Console.WriteLine(pair.Key.ToLower() + " (" + pair.Value + ")");
                }

               
            }

        }
    }
}
