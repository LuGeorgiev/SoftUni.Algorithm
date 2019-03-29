using System;
using System.Linq;

namespace ConnectingCables
{

    class Program
    {
        static void Main(string[] args)
        {
            var cables = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int maxPairs = FindLIS(cables);
            Console.WriteLine("Maximum pairs connected: "+maxPairs);
        }

        private static int FindLIS(int[] cables)
        {
            
            if (cables.Length==0)
            {
                return 0;
            }

            int[] currentLongest = new int[cables.Length + 1];
            currentLongest[1] = 1;

            for (int cableSlot = 2; cableSlot < currentLongest.Length; cableSlot++)
            {
                int currentValue = cables[cableSlot - 1];
                for (int toCompare = cableSlot-1; toCompare >0; toCompare--)
                {
                    if (currentValue >= cables[toCompare-1]
                        && currentLongest[cableSlot] < currentLongest[toCompare] )
                    {
                        currentLongest[cableSlot] = currentLongest[toCompare] + 1;
                    }
                }
            }            

            return currentLongest.Max();
        }
    }
}
