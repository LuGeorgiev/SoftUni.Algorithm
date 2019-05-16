using System;
using System.Linq;
using System.Text;

namespace Balls
{
    class Program
    {

        private static int pockets;
        private static int balls;
        private static int capacity;

        static StringBuilder builder = new StringBuilder();
        
        static void Main(string[] args)
        {
            pockets = int.Parse(Console.ReadLine());
            balls = int.Parse(Console.ReadLine());
            capacity = int.Parse(Console.ReadLine());

            //var ballsByPockets = Enumerable.Repeat(1,pockets).ToArray();
            var ballsByPockets = new int[pockets];

            FillBalls(0,balls, ballsByPockets);

            Console.WriteLine(builder.ToString().Trim());
        }

        private static void FillBalls(int index, int ballsLeft, int[] ballsByPockets)
        {
            if (index==pockets)
            {
                if (ballsLeft==0)
                {
                    builder.AppendLine(string.Join(", ", ballsByPockets));
                }
                return;
            }

            var ballsToPut = ballsLeft - (pockets - (index + 1));
            if (ballsLeft>capacity)
            {
                ballsToPut = capacity;
            }

            for (int i = ballsToPut; i >0; i--)
            {
                ballsByPockets[index] = i;
                FillBalls(index + 1, ballsLeft-i, ballsByPockets);
            }
        }
    }
}
