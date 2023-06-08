using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Frequency_analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            bool caseSensitive = true;
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

            Dictionary<string, int> freqMap = ParseString(input, caseSensitive);
            Console.WriteLine(args[0]);
            PrintMap(freqMap, caseSensitive);
            
        }


        static Dictionary<string,int> ParseString(string input, bool caseSensitive)
        {
            Dictionary<string,int> map;
            if (caseSensitive)
            {
                 map = new Dictionary<string, int>();
            }
            else
            {
                 map = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            }
            
            
            foreach (var item in input)
            {
                int value;
                Match m = Regex.Match(item.ToString(), @"\s|\r|\n|\t");
                if (m.Success)
                {
                    //Console.WriteLine("Whitespace char");
                    continue;
                }
                if (map.ContainsKey(item.ToString()))
                {
                    map[item.ToString()] += 1;
                    //Console.WriteLine(item + ":" + map[item]);
                }
                else
                {
                    map.Add(item.ToString(), 1);
                    //Console.WriteLine(item + ":" + map[item]);
                }
            }

            return map;
        }
        static void PrintMap(Dictionary<string,int> toPrint, bool caseSensitive)
        {
            int totalChars = toPrint.Sum(x => x.Value);
            Console.WriteLine("Total characters: " + totalChars);

            foreach (KeyValuePair<string, int> pair in toPrint.OrderByDescending(i => i.Value).Take(10))
            {
                if (true)
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
