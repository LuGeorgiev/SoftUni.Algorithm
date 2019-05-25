using System;
using System.Collections.Generic;
using System.Linq;

namespace BridgesWorkingSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] bridges = Console.ReadLine()
                .Split();

            var bridgesFound = new List<int>();
            int lastBridge = 0;
            for (int i = 0; i < bridges.Length; i++)
            {
                for (int j = lastBridge; j < i; j++)
                {
                    string start = bridges[j];
                    string end = bridges[i];

                    if (start == end)
                    {
                        bridgesFound.Add(i);
                        bridgesFound.Add(j);

                        lastBridge = i;
                        break;
                    }
                }
            }

            string[] result = Enumerable.Repeat("X", bridges.Length).ToArray();
            foreach (var index in bridgesFound)
            {
                result[index] = bridges[index];
            }
            if (bridgesFound.Count == 0)
            {
                Console.WriteLine("No bridges found");
            }
            else if (bridgesFound.Count == 2)
            {
                Console.WriteLine("1 bridge found");
            }
            else
            {
                Console.WriteLine($"{bridgesFound.Count/2} bridges found");
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
