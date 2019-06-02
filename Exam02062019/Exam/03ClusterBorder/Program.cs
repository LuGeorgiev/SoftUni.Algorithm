using System;
using System.Linq;
using System.Text;

namespace _03ClusterBorder
{
    class Program
    {
        private static int[] singleShipTrasfer;
        private static int[] pairShipTransfer;
        private static int optimalTime = 0;
        private static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            singleShipTrasfer = Console.ReadLine().Split().Select(int.Parse).ToArray();
            pairShipTransfer = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < singleShipTrasfer.Length; i++)
            {
                bool toPassSingle = i == singleShipTrasfer.Length - 1
                    || singleShipTrasfer[i] < pairShipTransfer[i] ;
                if (toPassSingle)
                {
                    optimalTime += singleShipTrasfer[i];
                    result.AppendLine($"Single {i + 1}");
                }
                else
                {
                    optimalTime += pairShipTransfer[i];
                    result.AppendLine($"Pair of {i+1} and {i+2}");
                    i ++;
                }
            }
            Console.WriteLine($"Optimal Time: {optimalTime}");
            Console.WriteLine(result.ToString().Trim());
        }
    }
}
