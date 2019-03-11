using System;
using System.Linq;

namespace RodCutting
{
    class Program
    {
        private static int[] rodPrices;
        private static int[] bestPrices;
        private static int[] bestCombos;

        static void Main(string[] args)
        {
            rodPrices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            bestPrices = new int[rodPrices.Length];
            bestCombos = new int[rodPrices.Length];
            int lengthNeeded = int.Parse(Console.ReadLine());

            int highestPrice = CutRod(lengthNeeded);
            //int highestPrice = CutRodIter(pcsNeeded);
            Console.WriteLine(highestPrice);
            Reconstructsolution(lengthNeeded);
        }

        private static int CutRodIter(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                int currentBest = bestPrices[n];
                for (int j = 1; j <= i; j++)
                {
                    currentBest = Math.Max(bestPrices[i], rodPrices[j] + bestPrices[i - j]);
                    if (currentBest>bestPrices[i])
                    {
                        bestPrices[i] = currentBest;
                        bestCombos[i] = j;
                    }
                }
            }
            return bestPrices[n];
        }

       
        private static int CutRod(int n)
        {
            if (bestPrices[n]>0)
            {
                return bestPrices[n];
            }

            if (n==0)
            {
                return 0;
            }

            var currentBest = bestPrices[n];
            for (int i = 1; i <= n; i++)
            {
                currentBest = Math.Max(currentBest, rodPrices[i] + CutRod(n - i));
                if (currentBest>bestPrices[n])
                {
                    bestPrices[n] = currentBest;
                    bestCombos[n] = i;
                }
            }

            return bestPrices[n];
        }

        private static void Reconstructsolution(int n)
        {
            while (n-bestCombos[n]!=0)
            {
                Console.Write(bestCombos[n]+" ");
                n = n - bestCombos[n];
            }
            Console.WriteLine(bestCombos[n]);
        }
    }
}
