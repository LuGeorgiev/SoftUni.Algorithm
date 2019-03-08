using System;

namespace KinghtsTour
{
    class Program
    {
        private static int[,] board;

        static void Main(string[] args)
        {
            var boardDimentions = int.Parse(Console.ReadLine());
            board = new int[boardDimentions, boardDimentions];

            MoveKnight(0, 0, 1);
            
        }

        private static void MoveKnight(int row, int col, int step)
        {
            int boardSize = board.GetLength(0);
            board[row, col] = step;

            if (step==boardSize*boardSize)
            {
                PrintMovement();
                return;
            }

            if (CanMove(row+2,col+1)) //DownRight
            {
                MoveKnight(row+2, col+1, step + 1);
            }
            if (CanMove(row+1, col+2)) //RightDown
            {
                MoveKnight(row+1, col+2, step + 1);
            }
            if (CanMove(row-1, col+2)) //RightUp
            {
                MoveKnight(row-1, col+2, step + 1);
            }
            if (CanMove(row+2, col+1))//UpRight
            {
                MoveKnight(row+2, col+1, step + 1);
            }
            if (CanMove(row-2, col-1)) //UpLeft
            {
                MoveKnight(row-2, col-1, step + 1);
            }
            if (CanMove(row-1, col-2)) //LeftUp
            {
                MoveKnight(row-1, col-2, step + 1);
            }
            if (CanMove(row + 1, col - 2)) //LeftDown
            {
                MoveKnight(row + 1, col - 2, step + 1);
            }
            if (CanMove(row + 2, col - 1)) //DownLeft
            {
                MoveKnight(row + 2, col - 1, step + 1);
            }

            board[row, col] = 0;
        }

        private static bool CanMove(int row, int col)
        {
            int boardSize = board.GetLength(0);
            if (   row < 0
                || col < 0
                || row>boardSize-1
                || col >boardSize-1
                || board[row,col]!=0)
            {
                return false;
            }


            return true;
        }

        private static void PrintMovement()
        {
            int boardSize = board.GetLength(0);
            int size = (boardSize * boardSize).ToString().Length + 1;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write((board[i,j]+" ").PadLeft(size));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

