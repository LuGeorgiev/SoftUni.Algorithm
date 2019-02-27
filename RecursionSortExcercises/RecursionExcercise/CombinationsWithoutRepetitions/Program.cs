using System;

namespace CombinationsWithoutRepetitions
{
    class Program
    {
        static void Main(string[] args)
        {
            int setOfElements = int.Parse(Console.ReadLine());
            int elementsCount = int.Parse(Console.ReadLine());

            CombinationsWithoutReps(setOfElements, elementsCount);

        }

        private static void CombinationsWithoutReps(int setOfElements, int elementsCount)
        {
            var vector = new int[elementsCount];

            Generate(vector, 0, setOfElements,0);
        }

        private static void Generate(int[] vector, int index, int setOfElements,int border)
        {
            if (index>vector.Length-1)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }
            else
            {
                for (int i = border; i <= setOfElements-1; i++)
                {
                    vector[index] = i + 1;
                    Generate(vector, index + 1, setOfElements,i+1);    
                }
            }
        }
    }
}
