using System;

namespace NestedLoopsRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            SimulateLoops(loops);
        }

        private static void SimulateLoops(int loopsNumber)
        {
            var vector = new int[loopsNumber];

            GenerateLoop(vector, 0);
        }

        private static void GenerateLoop(int[] vector,int index)
        {
            if (index>vector.Length-1)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                int possibleValues = vector.Length;

                for (int i = 0; i < possibleValues; i++)
                {
                    vector[index] = i + 1;
                    GenerateLoop(vector, index + 1);
                }
            }
        }
    }
}
