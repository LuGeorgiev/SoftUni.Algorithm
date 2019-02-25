using System;
using System.Linq;

namespace GenerateCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var elements = int.Parse(Console.ReadLine());

            GenerateCombinations(line, elements);
        }

        private static void GenerateCombinations(int[] line, int elements)
        {
            GenerateCombination(line, new int[elements], 0, 0);
        }

        private static void GenerateCombination(int[] line, int[] vector ,int index, int border)
        {
            if (index>=vector.Length)
            {
                Console.WriteLine(string.Join(", ", vector));
            }
            else
            {
                for (int i = border; i < line.Length; i++)
                {
                    vector[index] = line[i];
                    GenerateCombination(line, vector,index+1,i+1);
                }
            }
        }
    }
}
