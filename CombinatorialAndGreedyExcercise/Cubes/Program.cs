using System;
using System.Collections.Generic;
using System.Linq;

namespace Cubes
{
    class Program
    {
        private static HashSet<string> allCubes = new HashSet<string>();
        private static HashSet<string> uniqueCubes = new HashSet<string>();
        private static int[] elements;

        static void Main(string[] args)
        {

            //elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            elements = "1 1 2 2 2 3 3 3 3 3 3 3".Split(' ').Select(int.Parse).ToArray();
            Array.Sort(elements);

            Permute(0, elements.Length - 1);
            Console.WriteLine(uniqueCubes.Count);
        }

        private static void Permute(int start, int end)
        {
            //Logic HERE
            //Console.WriteLine(string.Join(" ", elements));
            var currentCube = string.Join("", elements);
            if (!allCubes.Contains(string.Join("",elements)))
            {
                uniqueCubes.Add(currentCube);

                AddAllRotations(elements);
            }

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (elements[left] != elements[right])
                    {
                        Swap(left, right);
                        Permute(left + 1, end);
                    }
                }

                var firstElement = elements[left];
                for (int i = left; i < end - 1; i++)
                {
                    elements[i] = elements[i + 1];
                }
                elements[end] = firstElement;
            }
        }

        private static void AddAllRotations(int[] elements)
        {
            FlipAllSites(elements);
        }

        private static void FlipAllSites(int[] elements)
        {
            var currentCube = new int[] 
            {
                elements[0],
                elements[1],
                elements[2],
                elements[3],
                elements[4],
                elements[5],
                elements[6],
                elements[7],
                elements[8],
                elements[9],
                elements[10],
                elements[11],
            };
            allCubes.Add(string.Join("", currentCube));
            RotateOnBasicSide(currentCube, 0);

            var cubeOnTop = new int[]
            {
                elements[11],
                elements[10],
                elements[9],
                elements[8],
                elements[4],
                elements[7],
                elements[6],
                elements[5],
                elements[3],
                elements[2],
                elements[1],
                elements[0],
            };
            allCubes.Add(string.Join("", cubeOnTop));
            RotateOnBasicSide(cubeOnTop, 0);

            var cubeOnFront = new int[]
            {
                elements[4],
                elements[8],
                elements[5],
                elements[0],
                elements[11],
                elements[9],
                elements[1],
                elements[3],
                elements[7],
                elements[10],
                elements[6],
                elements[2],
            };
            allCubes.Add(string.Join("", cubeOnFront));
            RotateOnBasicSide(cubeOnFront, 0);

            var cubeOnBack = new int[]
            {
                elements[10],
                elements[6],
                elements[2],
                elements[7],
                elements[11],
                elements[9],
                elements[1],
                elements[3],
                elements[4],
                elements[8],
                elements[5],
                elements[0],
            };
            allCubes.Add(string.Join("", cubeOnBack));
            RotateOnBasicSide(cubeOnBack, 0);

            var cubeOnRight = new int[]
            {
                elements[1],
                elements[5],
                elements[9],
                elements[6],
                elements[0],
                elements[8],
                elements[10],
                elements[2],
                elements[3],
                elements[4],
                elements[11],
                elements[7],
            };
            allCubes.Add(string.Join("", cubeOnRight));
            RotateOnBasicSide(cubeOnRight, 0);

            var cubeOnLeft = new int[]
            {
                elements[4],
                elements[11],
                elements[7],
                elements[3],
                elements[0],
                elements[8],
                elements[10],
                elements[2],
                elements[5],
                elements[9],
                elements[6],
                elements[1],
            };
            allCubes.Add(string.Join("", cubeOnLeft));
            RotateOnBasicSide(cubeOnLeft, 0);
        }

        private static void RotateOnBasicSide(int[] elements,int count)
        {
            if (count>=3)
            {
                return;
            }
            var inputCube = new int[12];
            inputCube[0] = elements[8];
            inputCube[8] = elements[10];
            inputCube[10] = elements[2];
            inputCube[2] = elements[0];
            inputCube[1] = elements[5];
            inputCube[5] = elements[9];
            inputCube[9] = elements[6];
            inputCube[6] = elements[1];
            inputCube[3] = elements[4];
            inputCube[4] = elements[11];
            inputCube[11] = elements[7];
            inputCube[7] = elements[3];

            allCubes.Add(string.Join("", inputCube));
            RotateOnBasicSide(inputCube, count + 1);
        }

      

        private static void Swap(int left, int right)
        {
            var temp = elements[left];
            elements[left] = elements[right];
            elements[right] = temp;
        }
    }
}
