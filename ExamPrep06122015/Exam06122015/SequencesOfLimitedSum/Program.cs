using System;
using System.Linq;
using System.Text;

namespace SequencesOfLimitedSum
{
    class Program
    {
        private static StringBuilder builder = new StringBuilder();

        static void Main(string[] args)
        {
            var targetSum = int.Parse(Console.ReadLine());
            int[] variations = new int[targetSum];


            GetSequences(0, 0, targetSum, variations);
            Console.WriteLine(builder.ToString().Trim());
        }

        private static void GetSequences(int index, int currenSum, int tragetSum, int[] variations)
        {
            if (currenSum <= tragetSum && currenSum!=0)
            {
                builder.AppendLine(string.Join(" ", variations.TakeWhile(x => x != 0)));

            }
            if (currenSum >= tragetSum)
            {
                return;
            }

            for (int i = 1; i <= tragetSum; i++)
            {
                variations[index] = i;

                GetSequences(index + 1, currenSum + i, tragetSum, variations);
            }
            variations[index] = 0;
        }
    }
}
