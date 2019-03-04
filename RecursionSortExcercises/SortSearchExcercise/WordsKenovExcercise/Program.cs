using System;
using System.Collections.Generic;
using System.Linq;

namespace WordsKenovExcercise
{
    class Program
    {
        private static char[] elements;
        private static int counter = 0;
        public static void GeneratePermutationWithRep(int index)
        {
            if (index>= elements.Length)
            {
                for (int i = 1; i < elements.Length; i++)
                {
                    if (elements[i]==elements[i-1])
                    {
                        return;
                    }
                }
                counter++;
            }
            else
            {
                var swapped = new HashSet<int>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        GeneratePermutationWithRep(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            elements = input.ToCharArray();

            var allUnique = input.Distinct().Count() == input.Length;
            if (allUnique)
            {
                counter = 1;
                for (int i = 0; i <= input.Length ; i++)
                {
                    counter *= i;
                }

            }
            else
            {
                 GeneratePermutationWithRep(0);
            }


            Console.WriteLine(counter);
        }
    }
}
