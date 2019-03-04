namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var coinsQuantity = new Dictionary<int, int>();
            var sortedCoins = coins.OrderByDescending(x => x).Distinct().ToArray();

            foreach (var coin in sortedCoins)
            {

                if (targetSum < coin)
                {
                    continue;
                }

                int coinsCount = targetSum / coin;
                coinsQuantity[coin] = coinsCount;
                targetSum -= coin * coinsCount;
            }
            if (targetSum!=0)
            {
                throw new InvalidOperationException();
            }

            return coinsQuantity;
        }
    }
}