using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    public static class BinSerach<T>
        where T: IComparable<T>
    {
        public static int BinSearch(List<T> sortedList, T searchedItem)
        {
            int searchedIndex = BinarySearch(sortedList,searchedItem , 0, sortedList.Count);

            return searchedIndex;
        }

        private static int BinarySearch(List<T> sortedList, T searchedItem, int lowIndex, int hiIndex)
        {
            int midIndex = (lowIndex + hiIndex) / 2;
            int index = 0;
            if (sortedList[midIndex].CompareTo(searchedItem)==0)
            {
                return midIndex;
            }
            if (hiIndex-lowIndex<=1)
            {
                if (sortedList[hiIndex].CompareTo(searchedItem) == 0)
                {
                    return hiIndex;
                }
                else
                {
                    return -1;
                }
            }

            if (sortedList[midIndex].CompareTo(searchedItem) == -1)
            {
                index = BinarySearch(sortedList, searchedItem, midIndex, hiIndex);
            }
            else
            {
                index = BinarySearch(sortedList, searchedItem, lowIndex, midIndex);
            }

            return index;
        }
    }
}
