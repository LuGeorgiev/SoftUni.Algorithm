using System;
using System.Collections.Generic;
using System.Linq;

namespace IterativePermutationsWithRep
{
    class Program
    {
        private static string[] elements;
        private static HashSet<string> printedPermutations = new HashSet<string>();

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ').ToArray();

            var permutations = new Queue<List<int>>();
            permutations.Enqueue(new List<int>() { 0 });

            GeneratePerumattionsWithoutRep(permutations);
        }

        private static void GeneratePerumattionsWithoutRep(Queue<List<int>> permutations)
        {
            if (elements.Length == 1)
            {
                PrintPermuttaion(new List<int>() { 0 });
            }

            while (permutations.Count > 0)
            {
                var currentPermutaion = permutations.Dequeue();
                if (currentPermutaion.Count == elements.Length)
                {                   
                    PrintPermuttaion(currentPermutaion);
                }
                else
                {
                    AddElements(permutations, currentPermutaion);
                }

            };
        }

        private static void AddElements(Queue<List<int>> permutations, List<int> currentPermutaion)
        {
            //Insert next index in all possible positions
            int valueToInesrt = currentPermutaion.Count;

            for (int indexToInsert = 0; indexToInsert <= valueToInesrt; indexToInsert++)
            {
                var newPermutation = new List<int>(valueToInesrt); //capacity is equal to inserted value
                for (int i = 0; i < indexToInsert; i++)
                {
                    newPermutation.Add(currentPermutaion[i]);
                }
                newPermutation.Add(valueToInesrt);
                for (int i = indexToInsert; i < currentPermutaion.Count; i++)
                {
                    newPermutation.Add(currentPermutaion[i]);
                }

                permutations.Enqueue(newPermutation);
            }
        }

        private static void PrintPermuttaion(List<int> permuttaion)
        {
            var result = "";
            for (int i = 0; i < permuttaion.Count; i++)
            {
                result+=$"{elements[permuttaion[i]]} ";
            }
            if (!printedPermutations.Contains(result))
            {
                printedPermutations.Add(result);
                Console.WriteLine(result);
            }
        }
    }
}
