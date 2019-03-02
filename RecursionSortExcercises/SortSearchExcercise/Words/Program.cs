using System;
using System.Collections.Generic;
using System.Linq;

namespace Words
{
    class Program
    {
        static HashSet<string> uniqueWords = new HashSet<string>();
        static char[] word;

        static void Main(string[] args)
        {
            word = Console.ReadLine().ToArray();
            //int[] vector = Enumerable.Range(0,word.Length).ToArray();
            GeneratePermutations(word,0);

            Console.WriteLine(uniqueWords.Count);
        }

        private static void GeneratePermutations(char[] vector,int index)
        {
            if (index>=word.Length)
            {
                IsValidWord(vector);
                //Console.WriteLine(string.Join("", vector) );
            }
            else
            {
                GeneratePermutations(vector, index + 1);
                for (int i = index+1; i < vector.Length; i++)
                {
                    Swap(vector, index, i);
                    GeneratePermutations(vector, index + 1);
                    Swap(vector, index, i);
                }
            }
        }

        private static void Swap(char[] vector, int first, int second)
        {
            var temp = vector[first];
            vector[first] = vector[second];
            vector[second] = temp;
        }

        private static void IsValidWord(char[] vector)
        {
            for (int i = 0; i < vector.Length-1; i++)
            {
                if (vector[i]==vector[i+1])
                {
                    return;
                }
            }
            uniqueWords.Add(string.Join("",vector));
        }
    }
}
