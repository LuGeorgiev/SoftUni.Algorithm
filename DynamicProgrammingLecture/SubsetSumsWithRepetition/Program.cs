using System;

namespace SubsetSumsWithRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 2 };
            var targetSum = 6;

            var possibleSum = new bool[targetSum + 1];
            possibleSum[0] = true;

            for (int sum = 0; sum < possibleSum.Length; sum++)
            {
                if (possibleSum[sum])
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        var newSum = sum + nums[i];
                        if (newSum <= targetSum)
                        {
                            possibleSum[newSum] = true;
                        }
                    }
                }
            }
            //Is sum possible
            Console.WriteLine(possibleSum[targetSum]);

            //Retrive sums
            while (targetSum!=0)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    var sum = targetSum - nums[i];
                    if (sum>=0 && possibleSum[sum])
                    {
                        Console.WriteLine(nums[i]+ " ");
                        targetSum =sum;
                    }
                }
            }
        }
    }
}
