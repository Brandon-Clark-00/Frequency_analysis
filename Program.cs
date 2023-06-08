using System;
using System.Collections.Generic;
using System.IO;

namespace Frequency_analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            bool caseSensitive;
            string input;
            if (args.Length == 0)
            {
                Console.WriteLine("missing arguments");
                return;
            }
            else if (args.Length == 1)
            {
                input = File.ReadAllText(args[0]);

            }
            else
            {
                input = File.ReadAllText(args[0]);
                caseSensitive = false;
            }

            PrintList(ParseString(input));
            
        }
        static List<string> ParseString(string input)
        {
            return new List<string>(input.Split(' '));
        }

        static void PrintList(List<string> toPrint)
        {
            foreach (var item in toPrint)
            {
                Console.WriteLine(item);
            }
        }
    }
}
