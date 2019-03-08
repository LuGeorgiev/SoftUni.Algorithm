using System;
using System.Collections.Generic;
using System.Linq;

namespace BestLecturersSchedule
{
    class Lecture: IComparable
    {
        public string Name { get; set; }

        public int Start { get; set; }

        public int End { get; set; }

        public int CompareTo(object obj)
        {
            Lecture item = obj as Lecture;
            int compare = this.End.CompareTo(item.End);
            if (compare==0)
            {
                compare= item.Start.CompareTo(this.Start);
                if (compare==0)
                {
                    return this.Name.CompareTo(item.Name);
                }
            }
            return compare;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var lecturersCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            var sortedLecurers = new SortedSet<Lecture>();
            for (int i = 0; i < lecturersCount; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(' ')
                    .Where(x => x.Length > 0 && x != "-")
                    .ToArray();
                sortedLecurers.Add(new Lecture
                {
                    Name=tokens[0].Substring(0,tokens[0].Length-1),
                    Start = int.Parse(tokens[1]),
                    End = int.Parse(tokens[2])
                });
            }
            if (sortedLecurers.Count==0)
            {
                Console.WriteLine("Lectures (0):");
                return;
            }
            var heldLectures = new List<Lecture>();
            while (sortedLecurers.Count>0)
            {
                var currentLecture = sortedLecurers.First();
                heldLectures.Add(currentLecture);

                var toRemove = sortedLecurers
                    .Where(x=>x.Start<currentLecture.End)
                    .ToList();

                foreach (var lecture in toRemove)
                {
                    sortedLecurers.Remove(lecture);
                }
            }

            Console.WriteLine($"Lectures ({heldLectures.Count}):");
            foreach (var lecture in heldLectures)
            {
                Console.WriteLine($"{lecture.Start}-{lecture.End} -> {lecture.Name}");
            }
        }
    }
}
