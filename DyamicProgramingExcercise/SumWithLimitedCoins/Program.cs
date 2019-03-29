using System;
using System.Linq;

namespace SumWithLimitedCoins
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

            int comb = Findcombinations(coins, sum);
            Console.WriteLine(comb);
        }

        private static int Findcombinations(int[] coins, int targetSum)
        {
            int[,] maxCount = new int[coins.Length + 1, targetSum + 1];
            for (int i = 0; i <= coins.Length; i++)
            {
                maxCount[i, 0] = 1;
            }

            for (int coin = 1; coin <= coins.Length; coin++)
            {
                for (int sum = targetSum; sum >= 0; sum--)
                {
                    if (coins[coin - 1] <= sum && maxCount[coin - 1, sum - coins[coin - 1]] != 0)
                    {
                        maxCount[coin, sum]++;
                    }
                    else
                    {
                        maxCount[coin, sum] = maxCount[coin - 1, sum];
                    }
                }
            }
          

            int count = 0;
            for (int i = 0; i <= coins.Length; i++)
            {
                if (maxCount[i, targetSum] != 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
