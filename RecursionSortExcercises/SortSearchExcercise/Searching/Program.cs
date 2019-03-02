using System;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbres = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var searchFor = 7;

            
            //int searchedIndex = LineraSearch(numbres, searchFor);

            //Array have to be sorted when using Binary search
            int searchedIndex = BinarySearch(numbres, searchFor);

            Console.WriteLine(searchedIndex);
        }

        private static int BinarySearch(int[] numbres, int searchFor)
        {
            int index = BinarySearch(numbres, searchFor, 0, numbres.Length - 1);
            return index;
        }

        private static int BinarySearch(int[] numbres, int searchFor, int startIndex, int endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (numbres[midIndex] == searchFor)
            {
                return midIndex;
            }
            else if (endIndex - startIndex <= 1 && numbres[endIndex] == searchFor)
            {
                return endIndex;
            }
            else if (endIndex - startIndex <= 1 && numbres[endIndex] != searchFor)
            {
                return -1;
            }

            if (numbres[midIndex]<searchFor)
            {
                return BinarySearch(numbres, searchFor, midIndex, endIndex);
            }
            else
            {
                return BinarySearch(numbres, searchFor, startIndex, midIndex);
            }
        }

        private static int LineraSearch(int[] numbres, int searchFor)
        {
            for (int i = 0; i < numbres.Length; i++)
            {
                if (numbres[i]==searchFor)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
