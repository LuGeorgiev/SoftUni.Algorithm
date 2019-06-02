using System;
using System.Collections.Generic;

namespace _02GalacticBeacon
{
    public class Cell
    {
        public Cell(int row, int col, int junctionsTillNow)
        {
            Row = row;
            Col = col;
            JunctionsTillNow = junctionsTillNow;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int JunctionsTillNow { get; set; }

        public override string ToString()
        => $"R{this.Row} C{this.Col} junc{this.JunctionsTillNow}";
    }


    class Program
    {
        private static char[,] matrix;
        private static Queue<Cell> trace = new Queue<Cell>();
        
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            var firstLine = Console.ReadLine().ToCharArray();
            matrix = new char[numberOfLines, firstLine.Length];
            for (int i = 0; i < firstLine.Length; i++)
            {
                matrix[0, i] = firstLine[i];
            }

            for (int i = 1; i < numberOfLines; i++)
            {
                var nextLine = Console.ReadLine().ToCharArray();
                for (int j = 0; j < firstLine.Length; j++)
                {
                    matrix[i, j] = nextLine[j];
                }
            }
            var startCell = FindStartCell();

            trace.Enqueue(startCell);
            //FindDirections(startCell);
            Cell lastCell = null;
            while (trace.Count > 0)
            {
                var currentCel = trace.Dequeue();
                if (matrix[currentCel.Row,currentCel.Col]=='5')
                {
                    lastCell = currentCel;
                    break;
                }
                FindDirections(currentCel);
            }

            //CHECK LAST CELL JUNCTIONS
            Console.WriteLine(lastCell.JunctionsTillNow);
            
        }

        private static void FindDirections(Cell currentCell)
        {
            int maxRow = matrix.GetLength(0);
            int maxColl = matrix.GetLength(1);
            int curentRow = currentCell.Row;
            int curentCol = currentCell.Col;

            matrix[currentCell.Row, currentCell.Col] = '1';

            bool upPossile= curentRow - 1>=0 && (matrix[curentRow-1,curentCol]=='0'|| matrix[curentRow - 1, curentCol] == '5');
            bool rightPossile= curentCol + 1 < maxColl && (matrix[curentRow , curentCol+1] == '0' || matrix[curentRow, curentCol + 1] == '5');
            bool downPossile= curentRow + 1 < maxRow && (matrix[curentRow + 1, curentCol] == '0' || matrix[curentRow + 1, curentCol] == '5');
            bool leftPossile= curentCol - 1 >= 0 && (matrix[curentRow , curentCol-1] == '0' || matrix[curentRow, curentCol - 1] == '5');

            int directionsCount = CalculateDirections(upPossile,rightPossile,downPossile,leftPossile);
            if (directionsCount>1)
            {
                currentCell.JunctionsTillNow += 1;
            }
            if (upPossile)
            {
                trace.Enqueue(new Cell(curentRow - 1, curentCol, currentCell.JunctionsTillNow));
            }
            if (rightPossile)
            {
                trace.Enqueue(new Cell(curentRow, curentCol + 1, currentCell.JunctionsTillNow));
            }
            if (downPossile)
            {
                trace.Enqueue(new Cell(curentRow+1, curentCol, currentCell.JunctionsTillNow));
            }
            if (leftPossile)
            {
                trace.Enqueue(new Cell(curentRow , curentCol -1, currentCell.JunctionsTillNow));
            }
        }

        private static int CalculateDirections(bool upPossile, bool rightPossile, bool downPossile, bool leftPossile)
        {
            int result = 0;
            if (upPossile)
            {
                result++;
            }
            if (rightPossile)
            {
                result++;
            }
            if(downPossile)
            {
                result++;
            }
            if (leftPossile)
            {
                result++;
            }
            return result;
        }

        private static Cell FindStartCell()
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]=='3')
                    {
                        return  new Cell(i, j, 0);                        
                    }
                }
            }
            return null;
        }
    }
}
