using System;
using System.Linq;

namespace ZergZerg
{
    class Program
    {
        private static int[,] matrix;
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
            matrix = new int[rows, cols];

            var baseCoordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var baseRow = baseCoordinates[0];
            var baseCol = baseCoordinates[1];
            matrix[baseRow, baseCol] = -2;
            
            var numberOfEnemies = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEnemies; i++)
            {
                input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
                // Enemy
                matrix[input[0], input[1]] = -1;
            }

            // 20/100 in judge
            DFS(0, 0);
            Console.WriteLine(counter);

            // NOT WORKING
            //Dynamic(baseRow, baseCol);
            //if (matrix[baseRow-1,baseCol]>0 && matrix[baseRow, baseCol-1] > 0)
            //{
            //    counter = matrix[baseRow - 1, baseCol] + matrix[baseRow, baseCol - 1];
            //}
            //else if(matrix[baseRow - 1, baseCol] == -1 && matrix[baseRow, baseCol - 1] == -1)
            //{
            //    counter = 0;
            //}
            //else
            //{
            //    counter =Math.Max( matrix[baseRow - 1, baseCol] , matrix[baseRow, baseCol - 1]);
            //}
            //Console.WriteLine(counter);
        }

        private static void Dynamic(int baseRow, int baseCol)
        {
            if (baseRow == 0 && baseCol == 1 || baseRow == 1 && baseCol == 0)
            {
                counter = 1;
                return;
            }

            if (matrix[0,1] != -1)
            {
                matrix[0, 1] = 1;
            }
            if (matrix[1, 0] != -1)
            {
                matrix[1, 0] = 1;
            }

            //fill first row
            for (int row = 2; row <= baseRow; row++)
            {               
                if (matrix[row-1,0]== -1 || matrix[row, 0] == -1)
                {
                    matrix[row, 0] = -1;
                    continue;
                }

                bool canPlaceDown = false;
                if (row+1<=baseRow && matrix[row+1,0]!=-1)
                {
                    canPlaceDown = true;
                }
                bool canPlaceRight = false;
                if (matrix[row,1]!=-1)
                {
                    canPlaceRight = true;
                }

                if (canPlaceRight && canPlaceDown)
                {
                    matrix[row, 0] = matrix[row - 1, 0] + 1;
                }
                else if (canPlaceRight ^ canPlaceDown)
                {
                    matrix[row, 0] = matrix[row - 1, 0];
                }
                else
                {
                    matrix[row, 0] = -1;
                }
            }

            //fill first coll
            for (int col = 2; col <= baseCol; col++)
            {
                if (matrix[0, col - 1] == -1 || matrix[0,col]==-1)
                {
                    matrix[col, 0] = -1;
                    continue;
                }

                bool canPlaceDown = false;
                if (col + 1 <= baseCol && matrix[0, col+1] != -1)
                {
                    canPlaceDown = true;
                }
                bool canPlaceRight = false;
                if (matrix[1, col] != -1)
                {
                    canPlaceRight = true;
                }

                if (canPlaceRight && canPlaceDown)
                {
                    matrix[0, col] = matrix[0, col-1] + 1;
                }
                else if (canPlaceRight ^ canPlaceDown)
                {
                    matrix[0, col] = matrix[0, col-1];
                }
                else
                {
                    matrix[0, col] = -1;
                }
            }

            for (int row = 1; row <= baseRow; row++)
            {
                for (int col = 1; col <= baseCol; col++)
                {
                    if (matrix[row,col]==-1)
                    {
                        continue;
                    }
                    var curentValue = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    if (curentValue==-1)
                    {
                        matrix[row, col] = -1;
                        continue;
                    }

                    bool canPlaceDown = false;
                    if (row + 1 <= baseRow && matrix[row + 1, 0] != -1)
                    {
                        canPlaceDown = true;
                    }
                    bool canPlaceRight = false;
                    if (matrix[row, 1] != -1)
                    {
                        canPlaceRight = true;
                    }

                    if (canPlaceRight && canPlaceDown)
                    {
                        matrix[row, col] = curentValue + 1;
                    }
                    else if (canPlaceRight ^ canPlaceDown)
                    {
                        matrix[row, col] = curentValue;
                    }
                    else
                    {
                        matrix[row, col] = -1;
                    }
                }
            }
        }

        private static void DFS(int row, int col)
        {

            if (matrix[row,col]==-2)
            {
                counter++;
                return;
            }

            // Move Right
            if (col + 1 < cols && matrix[row, col + 1] != -1 )
            {
                DFS(row, col + 1);
            }

            // Move down
            if (row + 1 < rows && matrix[row+1, col] != -1 )
            {
                
                DFS(row + 1, col);
            }
        }
    }
}
