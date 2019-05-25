using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Bridges
{
    class Program
    {
        private static int[] input;
        private static SortedSet<int> bestBridge = new SortedSet<int>();

        static void Main(string[] args)
        {

            input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 1; i < input.Length; i++)
            {
                var currentBestBridge = new SortedSet<int>() { };
                var startIndex = i - 1;
                var currentStart = input[startIndex];
                var index = i;

                while (true)
                {
                    if (index > input.Length - 1)
                    {
                        break;
                    }
                    if (currentStart == input[index])
                    {
                        currentBestBridge.Add(index);
                        currentBestBridge.Add(startIndex);

                        if (currentBestBridge.Count > bestBridge.Count
                            || (currentBestBridge.Count == bestBridge.Count
                                 && string.Join("", currentBestBridge).CompareTo(string.Join("", bestBridge)) == 1))
                        {

                            bestBridge = currentBestBridge;
                        }
                        startIndex = index;
                        currentStart = input[index];
                    }

                    index++;

                    if (index > input.Length - 1)
                    {
                        if (startIndex < input.Length - 2)
                        {
                            startIndex = startIndex + 1;
                            currentStart = input[startIndex];
                            index = startIndex + 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            var builder = new StringBuilder();
            foreach (var sybmol in input)
            {
                if (bestBridge.Contains(sybmol))
                {
                    builder.Append($"{sybmol} ");

                }
                else
                {
                    builder.Append("X ");
                }
            }
            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
