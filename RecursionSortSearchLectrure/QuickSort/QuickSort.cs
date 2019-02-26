using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSort
{
    public static class QuickSort<T>
        where T: IComparable
    {
        public static List<T> Sort(List<T> arrToSort)           
        {
            if (arrToSort.Count<=1)
            {
                return arrToSort;
            }

            Random rnd = new Random();
            var lowerArr = new List<T>();
            var higherArr = new List<T>();

            var rndIndex = rnd.Next(arrToSort.Count);
            var pivot = arrToSort[rndIndex];

            for (int i = 0; i < rndIndex; i++)
            {
                if (arrToSort[i].CompareTo(pivot)==-1)
                {
                    lowerArr.Add(arrToSort[i]);
                }
                else
                {
                    higherArr.Add(arrToSort[i]);

                }
            }
            for (int i = rndIndex+1; i < arrToSort.Count; i++)
            {
                if (arrToSort[i].CompareTo(pivot) == -1)
                {
                    lowerArr.Add(arrToSort[i]);
                }
                else
                {
                    higherArr.Add(arrToSort[i]);

                }
            }

            return Concat(Sort(lowerArr),pivot,Sort(higherArr));
        }

        private static List<T> Concat(List<T> lowerArr, T pivot, List<T> higherArr)
        {
            var sortedArr = new List<T>(lowerArr);
            sortedArr.Add(pivot);
            foreach (var item in higherArr)
            {
                sortedArr.Add(item);
            }

            return sortedArr;
        }
    }
}
