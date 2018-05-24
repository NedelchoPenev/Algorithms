using System;
using System.Collections.Generic;
using System.Linq;

class Best_Lectures_Schedule
{
    static void Main(string[] args)
    {
        var lectures = int.Parse(Console.ReadLine().Substring(9));

        List<Lectures> lectureses = new List<Lectures>();
        for (int i = 0; i < lectures; i++)
        {
            var lectureInput = Console.ReadLine().Split(':');
            var lectureName = lectureInput[0];

            var lectureTime = lectureInput[1].Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(e => int.Parse(e)).ToArray();

            var start = lectureTime[0];
            var end = lectureTime[1];

            Lectures newLectures = new Lectures(lectureName, start, end);
            lectureses.Add(newLectures);
        }

        lectureses.Sort();
        var schedule = new List<Lectures>();
        schedule.Add(lectureses.First());

        var currentEndTime = lectureses.First().End;
        foreach (var lecture in lectureses)
        {
            if (currentEndTime <= lecture.Start)
            {
                schedule.Add(lecture);
                currentEndTime = lecture.End;
            }
        }

        Console.WriteLine($"Lectures ({schedule.Count}):");
        foreach (var lecture in schedule)
        {
            Console.WriteLine(lecture);
        }
    }

    class Lectures : IComparable<Lectures>
    {
        public string name;
        public int Start { get; set; }
        public int End { get; set; }

        public Lectures(string name, int start, int end)
        {
            this.name = name;
            this.Start = start;
            this.End = end;
        }

        public int CompareTo(Lectures other)
        {
            return this.End.CompareTo(other.End);
        }

        public override string ToString()
        {
            return $"{this.Start}-{this.End} -> {this.name}";
        }
    }
}