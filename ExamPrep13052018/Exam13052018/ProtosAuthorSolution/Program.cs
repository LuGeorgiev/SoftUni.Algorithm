using System;

namespace ProtosAuthorSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = int.Parse(Console.ReadLine());
            var adjMatrix = new bool[c, c];

            // Read matrix
            for (int i = 0; i < c; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < c; j++)
                {
                    adjMatrix[i, j] = line[j] == 'Y';
                }
            }

            // Solve task
            int maxNumberOfTwoFriends = 0;
            for (int row = 0; row < c; row++)
            {
                int numberOfTwoFriends = 0;
                for (int col = 0; col < c; col++)
                {
                    bool areTwoFriends = false;

                    if (row == col)
                    {
                        continue;
                    }

                    if (adjMatrix[row, col])
                    {
                        areTwoFriends = true;
                    }
                    else
                    {
                        for (int k = 0; k < c; k++)
                        {
                            if ((k != row) && (k != col))
                            {
                                if (adjMatrix[row, k] && adjMatrix[col, k])
                                {
                                    areTwoFriends = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (areTwoFriends)
                    {
                        numberOfTwoFriends++;
                    }
                }

                maxNumberOfTwoFriends = Math.Max(maxNumberOfTwoFriends, numberOfTwoFriends);
            }

            // Output solution
            Console.WriteLine(maxNumberOfTwoFriends);
        }
    }
}
