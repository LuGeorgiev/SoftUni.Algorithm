using System;

namespace CombinationsWithRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int setOfElements = int.Parse(Console.ReadLine());
            int elementsCount = int.Parse(Console.ReadLine());
            if (elementsCount>setOfElements)
            {
                Console.WriteLine("Wrong input");
                return;
            }

            GenerateReprededCombinations(setOfElements, elementsCount);
        }

        private static void GenerateReprededCombinations(int setOfElements, int elementsCount)
        {
            int[] vector = new int[elementsCount];
            StartGenerating(vector, 0, setOfElements);
        }

        private static void StartGenerating(int[] vector, int index, int setOfElements)
        {
            if (index>vector.Length-1)
            {
                Console.WriteLine(string.Join(" ",vector));
            }
            else
            {
                for (int i = 0; i < setOfElements; i++)
                {
                    vector[index] = i + 1;
                    StartGenerating(vector, index + 1, setOfElements);
                }
            }
        }
    }
}
