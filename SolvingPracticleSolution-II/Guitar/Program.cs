using System;
using System.Linq;

namespace Guitar
{
    class Program
    {
        static bool[,] matrix;

        static void Main(string[] args)
        {
            var tones = Console.ReadLine()
                .Split(new[] { ' ', ',' })
                .Where(x => x.Length > 0)
                .Select(x => int.Parse(x))
                .ToArray();
            var initialTone = int.Parse(Console.ReadLine());
            var maxTone = int.Parse(Console.ReadLine());
            matrix = new bool[tones.Length + 1, maxTone + 1];
            matrix[0, initialTone] = true;

            //Collons are all teh possible one values 0-N
            //Rows are all th etone deviation + 1 (one more for teh initial state)
            for (int i = 0; i < tones.Length; i++)
            {
                var currentTone = tones[i];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //Finds the possibilities from previous tone add/substract
                    if (matrix[i,j])
                    {
                        //If it is possible lowers tone
                        if (j-currentTone>=0)
                        {
                            matrix[i + 1, j - currentTone] = true;
                        }

                        //If it is possibles increasese tone
                        if (j+currentTone<=maxTone)
                        {
                            matrix[i + 1, j + currentTone] = true;
                        }
                    }
                }
            }
            bool isToneFount = false;
            int lastRol = matrix.GetLength(0) - 1;
            //finds the highest possible tone from all possible deviations
            for (int i = matrix.GetLength(1)-1; i >= 0; i--)
            {
                if (matrix[lastRol, i])
                {
                    isToneFount = true;
                    Console.WriteLine(i);
                    break;
                }
            }
            if (!isToneFount)
            {
                Console.WriteLine("-1");
            }
        }
    }
}
