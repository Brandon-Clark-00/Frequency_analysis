using System;
using System.Collections.Generic;

namespace Frequency_analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length>0)
            {
                Console.WriteLine("Hello " + args[0] + "!");
            }
            else
            {
                Console.WriteLine("Hello user");
            }
            
        }

        void PrintList(List<string> toPrint)
        {
            foreach (var item in toPrint)
            {
                Console.WriteLine(item);
            }
        }
    }
}
