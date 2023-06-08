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


            Dictionary<char, int> freqMap = ParseString(input);
            PrintMap(freqMap);
            
        }



      /*  static List<string> ParseString(string input)
        {
            return new List<string>(input.Split(' '));
        }

        static void PrintList(List<string> toPrint)
        {
            foreach (var item in toPrint)
            {
                Console.WriteLine(item);
            }
        }*/


        static Dictionary<char,int> ParseString(string input)
        {
            var map = new Dictionary<char, int>();
            
            foreach (var item in input)
            {
                int value;
                Match m = Regex.Match(item.ToString(), @"\s|\r|\n|\t");
                if (m.Success)
                {
                    //Console.WriteLine("Whitespace char");
                    continue;
                }
                if (map.ContainsKey(item))
                {
                    map[item] += 1;
                    //Console.WriteLine(item + ":" + map[item]);
                }
                else
                {
                    map.Add(item, 1);
                    //Console.WriteLine(item + ":" + map[item]);
                }
            }

            return map;
        }
        static void PrintMap(Dictionary<char,int> toPrint)
        {
            int totalChars = toPrint.Sum(x => x.Value);
            Console.WriteLine("Total characters: " + totalChars);
            foreach (KeyValuePair<char, int> pair in toPrint.OrderByDescending(i => i.Value))
            {
                Console.WriteLine(pair.Key + ":" + pair.Value);
            }

        }
    }
}
