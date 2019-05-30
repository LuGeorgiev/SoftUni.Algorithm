﻿using System;
using System.Linq;

namespace TerranPermutationsWithoutRep
{
    class Program
    {
       // private static string[] elements;
        private static char[] elements;
        private static int counter = 0;

        public static void Main()
        {
            //ReadElements();
            //Sort(); // NB!
            elements = Console.ReadLine().ToCharArray();
            Array.Sort(elements);
            Permute(0, elements.Length - 1);

            Console.WriteLine(counter);
        }


        private static void Permute(int start, int end)
        {
            //Print();
            counter++;

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (elements[left] != elements[right])
                    {
                        Swap(left, right);

                        Permute(left + 1, end);
                    }
                }

                // Return all elements [left, end] to initial positions 
                // before generating new permutations
                var leftElement = elements[left];
                for (int i = left; i <= end - 1; i++)
                {
                    elements[i] = elements[i + 1];
                }

                elements[end] = leftElement;
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        private static void Print()
            => Console.WriteLine(string.Join(" ", elements));

        private static void Sort()
            => elements = elements.OrderBy(x => x).ToArray();

        //private static void ReadElements()
        //    => elements = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }
}
