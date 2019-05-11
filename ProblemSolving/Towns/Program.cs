using System;
using System.Linq;

namespace Towns
{
    class Program
    {
        static int[] citizents;
        static int[] LIS; //Longest Increasing Subsequence Count
        static int[] LDS; //Longest Decreasing Subsequemce Count

        static void Main(string[] args)
        {
            var townsCount = int.Parse(Console.ReadLine());
            citizents = new int[townsCount];
            LIS = Enumerable.Repeat(1, townsCount).ToArray();
            for (int i = 0; i < townsCount; i++)
            {
                var peopleInTown = int.Parse(Console.ReadLine()
                    .Split(' ')
                    .First());
                citizents[i] = peopleInTown;    
            }

            var highestTownsVisited = 0;
            for (int i = 1; i < townsCount; i++)
            {                
                var currentTownValue = citizents[i];

                for (int j = 0; j < i; j++)
                {
                    var townToCompare = citizents[j];
                    if (currentTownValue > townToCompare 
                        && LIS[j]+1>LIS[i])
                    {
                        LIS[i]++;
                    }
                  
                }

                // Calculate Longest Decreasing subsequence from the town
                LDS = Enumerable.Repeat(1, townsCount).ToArray();         
                var maxDecreasingSequence = 1;
                for (int j = i; j < townsCount; j++)
                {                    
                    for (int k = i; k < j; k++)
                    {                        
                        if (citizents[j] < citizents[k] && LDS[k]+1 >LDS[j])
                        {
                            LDS[j]++;
                            if (LDS[j]>maxDecreasingSequence)
                            {
                                maxDecreasingSequence = LDS[j];
                            }
                        }
                    }
                }

                if (LIS[i] + maxDecreasingSequence > highestTownsVisited)
                {
                    highestTownsVisited = LIS[i] + maxDecreasingSequence;
                }
            }

            Console.WriteLine(highestTownsVisited-1);            
        }
    }
}
