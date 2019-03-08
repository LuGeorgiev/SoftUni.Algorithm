using System;
using System.Linq;
using System.Collections.Generic;

namespace ProcessorScheduling
{
    class Task
    {
        public int Index { get; set; }

        public int Value { get; set; }

        public int DeadLine { get; set; }

        public bool IsPerformed { get; set; } = false;
    }

    class Program
    {

        static void Main(string[] args)
        {
            var nemberOfTask =int.Parse(Console.ReadLine()
                .Split(' ')
                .Last());

            var allTasks = new LinkedList<Task>();
            int maxSteps = int.MinValue;

            for (int i = 1; i <= nemberOfTask; i++)
            {
                var tokens = Console.ReadLine().Split(" - ");
                var value = int.Parse(tokens[0]);
                var deadLine = int.Parse(tokens[1]);
                if (deadLine > maxSteps)
                {
                    maxSteps = deadLine;
                }
                allTasks.AddLast(new Task
                {
                    Index=i,
                    Value=value,
                    DeadLine=deadLine
                });
            }

            for (int i = 1; i <= maxSteps; i++)
            {
                var unfinishedTask = allTasks
                    .Where(x => x.IsPerformed == false 
                        && x.DeadLine >= 1)
                    .OrderByDescending(x => x.Value)
                    .First();
                unfinishedTask.IsPerformed = true;
            }

            var finishedTasks = allTasks
                .Where(x => x.IsPerformed == true)
                .OrderBy(x => x.DeadLine)
                .ThenByDescending(x => x.Value)
                .ToList();
            var totalValue = 0;
            Console.Write("Optimal schedule:  ");
            for (int i = 0; i < finishedTasks.Count()-1; i++)
            {
                Console.Write($"{finishedTasks[i].Index} -> ");
                totalValue += finishedTasks[i].Value;
            }
            if (finishedTasks[finishedTasks.Count-1]!=null)
            {
                Console.WriteLine($"{finishedTasks[finishedTasks.Count - 1].Index}");
                totalValue += finishedTasks[finishedTasks.Count - 1].Value;

            }
            Console.WriteLine($"Total value: {totalValue}");
        }
    }
}
