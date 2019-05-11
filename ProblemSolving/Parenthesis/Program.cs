using System;

namespace Parenthesis
{
    class Program
    {
        static int parentesisCount;
        static void Main(string[] args)
        {
            parentesisCount = int.Parse(Console.ReadLine());
            int openParentesis = parentesisCount;
            int closeParentesis = parentesisCount;
            string result = "";
            int count = 0;
            GenerateParentesis(count, result, openParentesis, closeParentesis);
        }

        private static void GenerateParentesis(int count, string result, int openParentesis, int closeParentesis)
        {
            if (result.Length==parentesisCount*2)
            {
                Console.WriteLine(result);
                return;
            }

            if (openParentesis > 0 )
            {
                openParentesis--;
                count++;
                GenerateParentesis(count,result + "(", openParentesis, closeParentesis);
                openParentesis++;
                count--;
                if (result.Length>0)
                {

                result.Substring(0, result.Length - 1);
                }
            }
            if (closeParentesis>0 && count>0)
            {
                closeParentesis--;
                count--;
                GenerateParentesis(count,result + ")", openParentesis, closeParentesis);                
            }
        }
    }
}
