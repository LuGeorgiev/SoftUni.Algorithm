using System;
using System.Collections.Generic;
using System.Linq;

namespace Needles
{
    class Program
    {
        private static Dictionary<int, int> valueWithIndex = new Dictionary<int, int>(512);
        //private static SortedSet<int> valuesWithoutHoles = new SortedSet<int>();
        private static LinkedList<int> result = new LinkedList<int>();

        static void Main(string[] args)
        {
            var lineLengthAndNumbersLength = Console.ReadLine();
            // TODO Check if arr is empty

            var arrNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var toFiindPlace = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < arrNumbers.Length-1; i++)
            {
                int currentValue = arrNumbers[i];
                int nextValue = arrNumbers[i + 1];
                if (currentValue != nextValue)
                {                    
                    valueWithIndex[currentValue] = i;
                    //if (currentValue!=0)
                    //{
                    //    valuesWithoutHoles.Add(currentValue);
                    //}
                }
            }
            int lastNumber = arrNumbers[arrNumbers.Length - 1];
            if (lastNumber != 0)
            {
                valueWithIndex[lastNumber] = arrNumbers.Length - 1;
                //valuesWithoutHoles.Add(lastNumber);
            }

            if (valueWithIndex.ContainsKey(0))
            {
                valueWithIndex.Remove(0);
            }

            //int lowestvalue = valuesWithoutHoles.First();
            //int highestvalue = valuesWithoutHoles.Last();

            var orderedKeys = valueWithIndex.Keys
                .OrderBy(x => x);
            int lowestValue = orderedKeys.First();
            int highestValue = orderedKeys.Last();

            foreach (var numberToInsert in toFiindPlace)
            {
                if (numberToInsert <= lowestValue)
                {
                    result.AddLast(0);
                }
                else if (numberToInsert > highestValue)
                {
                    result.AddLast(valueWithIndex[highestValue]+1);
                }
                else
                {
                    //var previousElement = valuesWithoutHoles
                    //    .Where(x => x < numberToInsert)
                    //    .Last();
                    var previousElement = valueWithIndex.Keys
                        .Where(x => x < numberToInsert)
                        .Last();


                    result.AddLast(valueWithIndex[previousElement]+1);
                }
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
