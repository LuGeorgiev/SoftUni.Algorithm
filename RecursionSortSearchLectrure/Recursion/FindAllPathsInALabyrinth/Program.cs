using System;

namespace FindAllPathsInALabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] labyrinth = FillMatrix(rows, cols);

            int startRow = 0;
            int startCol = 0;

            FindAllPaths(labyrinth, startRow, startCol);
        }

        private static void FindAllPaths(char[,] labyrinth, int startRow, int startCol)
        {
            labyrinth[startRow, startCol] = 'S';
            FindPaths(labyrinth, startRow, startCol, "");
        }

        private static void FindPaths(char[,] labyrinth, int row, int col, string path)
        {
            if (!IsCellAcessible(labyrinth,row,col))
            {
                return;
            }
            if (labyrinth[row, col] == 'e')
            {
                Console.WriteLine(path);
                return;
            }
            Mark(labyrinth, row, col);
            FindPaths(labyrinth, row, col+1, path + "R");
            FindPaths(labyrinth, row+1, col, path + "D");
            FindPaths(labyrinth, row, col-1, path + "L");
            FindPaths(labyrinth, row-1, col, path + "U");
            Unmark(labyrinth,row, col);
        }

        private static void Mark(char[,] labyrinth, int row, int col)
        {
            if (labyrinth[row,col]=='-')
            {
                labyrinth[row, col] = 'v';
            }
        }

        private static void Unmark(char[,] labyrinth, int row, int col)
        {
            if (labyrinth[row, col] == 'v')
            {
                labyrinth[row, col] = '-';
            }
        }       

        private static bool IsCellAcessible(char[,] labyrinth, int row, int col)
        {
            if (   row<0 
                || col<0 
                || row>labyrinth.GetLength(0)-1 
                || col>labyrinth.GetLength(1)-1
                || labyrinth[row,col]=='*'
                || labyrinth[row,col]=='v')
            {
                return false;
            };

            return true;
        }

        private static char[,] FillMatrix(int rows, int cols)
        {
            var result = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = line[j];
                }
            }
            return result;
        }
    }
}
