using System;
using System.Linq;

namespace ZergZerg
{
    class Program
    {
        private static char[,] matrix;
        private static int rows;
        private static int cols;
        private static int counter = 0;

        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            rows = input[0];
            cols = input[1];
            matrix = new char[rows, cols];

            var baseCoordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            matrix[baseCoordinates[0], baseCoordinates[1]] = 'B';
            matrix[0, 0] = 'V';

            var numberOfEnemies = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEnemies; i++)
            {
                input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                matrix[input[0], input[1]] = 'E';
            }

            DFS(0, 0);
            Console.WriteLine(counter);
        }

        private static void DFS(int row, int col)
        {

            if (matrix[row,col]=='B')
            {
                counter++;
                return;
            }

            // Move Right
            if (col + 1 < cols && matrix[row, col + 1] != 'E' )
            {
                DFS(row, col + 1);
            }

            // Move down
            if (row + 1 < rows && matrix[row+1, col] != 'E' )
            {
                
                DFS(row + 1, col);
            }
        }
    }
}
