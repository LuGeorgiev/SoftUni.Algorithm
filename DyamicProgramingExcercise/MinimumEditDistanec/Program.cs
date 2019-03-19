using System;
using System.Linq;

namespace MinimumEditDistanec
{
    class Program
    {
        static void Main(string[] args)
        {
            var costReplace = int.Parse(Console.ReadLine().Split(" = ").Last());
            var costInsert = int.Parse(Console.ReadLine().Split(" = ").Last());
            var costDelete = int.Parse(Console.ReadLine().Split(" = ").Last());
            var first = Console.ReadLine().Split(" = ").Last().Trim();
            var second = Console.ReadLine().Split(" = ").Last().Trim();

            var dp = new int[first.Length + 1, second.Length + 1];

            for (int i = 1; i <= second.Length; i++)
            {
                dp[0, i] = dp[0, i - 1] + costInsert;
            }
            for (int i = 1; i <= first.Length; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + costDelete;
            }

            for (int i = 1; i <= first.Length ; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i-1]==second[j-1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        var delete = dp[i - 1, j] + costDelete;
                        var insert = dp[i, j - 1] + costInsert;
                        var replace = dp[i - 1, j - 1] + costReplace;

                        dp[i, j] = Math.Min(insert, Math.Min(replace, delete));
                    }
                }
            }

            Console.WriteLine("Minimum edit distance: "+dp[first.Length,second.Length]);

            //then go backwards. if the best is Upwards them it was delete, if best is at left it was Insert, diagonal is replace
        }
    }
}
