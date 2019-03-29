using System;
using System.Collections.Generic;
using System.Linq;

namespace SumWithUnlimitedCoins
{
    class Program
    {
        public static void Main()
        {
            int[] coins = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = int.Parse(Console.ReadLine());

            int combinations = FindCombinationForGivenSum(coins, sum);
            Console.WriteLine(combinations);
        }

        private static int FindCombinationForGivenSum(int[] coins, int targetSum)
        {
            int[,] maxCombCount = new int[coins.Length + 1, targetSum + 1];
            for (int i = 0; i <= coins.Length; i++)
            {
                maxCombCount[i, 0] = 1;
            }

            for (int coin = 1; coin <= coins.Length; coin++)
            {
                for (int sum = 1; sum <= targetSum; sum++)
                {
                    if (coins[coin - 1] <= sum)
                    {
                        maxCombCount[coin, sum] = maxCombCount[coin - 1, sum] + maxCombCount[coin, sum - coins[coin - 1]];
                    }
                    else
                    {
                        maxCombCount[coin, sum] = maxCombCount[coin - 1, sum];
                    }
                }
            }
            return maxCombCount[coins.Length, targetSum];
        }
    }
}
