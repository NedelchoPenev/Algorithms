using System;
using System.Collections.Generic;
using System.Linq;

class Processor_Scheduling
{
    static void Main(string[] args)
    {
        int tasksCount = int.Parse(Console.ReadLine().Split(' ')[1]);

        List<Task> tasks = new List<Task>();
        for (int i = 0; i < tasksCount; i++)
        {
            var input = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(e => int.Parse(e))
                .ToArray();

            var value = input[0];
            var deadline = input[1];

            Task task = new Task(i + 1, value, deadline);
            tasks.Add(task);
        }

        tasks.Sort((t1, t2) => t2.Value.CompareTo(t1.Value));
        var maxSteps = tasks.Max(e => e.Deadline);
        var takenTasks = tasks.Take(maxSteps).ToList();
        takenTasks.Sort();
        
        var totalValue = takenTasks.Sum(e => e.Value);
        Console.WriteLine($"Optimal schedule: {string.Join(" -> ", takenTasks)}");
        Console.WriteLine($"Total value: {totalValue}");
    }

    class Task : IComparable<Task>
    {

        public int number;
        public int Value { get; set; }

        public int Deadline { get; set; }

        public Task(int number, int value, int deadline)
        {
            this.number = number;
            this.Value = value;
            this.Deadline = deadline;
        }

        public int CompareTo(Task other)
        {
            int result = this.Deadline.CompareTo(other.Deadline);

            if (result == 0)
            {
                result = other.Value.CompareTo(this.Value);
            }

            return result;
        }

        public override string ToString()
        {
            return this.number.ToString();
        }
    }
}