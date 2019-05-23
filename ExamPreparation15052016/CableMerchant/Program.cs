using System;
using System.Linq;

namespace CableMerchant
{
    class Program
    {
        private static int[] rodPrices;
        private static int[] bestPrices;

        static void Main(string[] args)
        {
            int[] prices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            rodPrices = new int[prices.Length + 1];
            for (int i = 1; i < rodPrices.Length; i++)
            {
                rodPrices[i] = prices[i - 1];
            }
            bestPrices = new int[rodPrices.Length];

            int junctionPrice = int.Parse(Console.ReadLine());
            CutRodIter(junctionPrice);
            var result = string.Join(" ", bestPrices);
            int firstSpace = result.IndexOf(' ');
            Console.WriteLine(result.Substring(firstSpace+1));
        }

        private static void CutRodIter(int junctionPrice)
        {
            for (int i = 1; i < bestPrices.Length; i++)
            {
                int currentBest = bestPrices[bestPrices.Length-1];
                for (int j = 1; j <= i; j++)
                {
                    currentBest = Math.Max(rodPrices[i], rodPrices[j] + bestPrices[i - j] -junctionPrice*2);
                    if (currentBest > bestPrices[i])
                    {
                        bestPrices[i] = currentBest;
                    }
                }
            }            
        }

    }
}
