using System;
using System.Collections.Generic;

namespace Composite
{
    /// <summary>
    /// Component abstract class
    /// </summary>
    public abstract class Task
    {
        public string Name { get; set; }
        public List<Task> SubTasks { get; set; }

        public Task(string name)
        {
            Name = name;
            SubTasks = new List<Task>();
        }

        public void Print(int num = 0)
        {
            string printString = "";
            for(var i=0; i<num; i++)
            {
                printString = String.Concat(printString, "====");
            }
            printString = String.Concat(printString, " ", this.GetType().Name, ": ", Name);

            Console.WriteLine(printString);
            foreach(var subtask in SubTasks)
            {
                subtask.Print(num + 1);
            }
        }
    }

    /// <summary>
    /// Composite class, the root
    /// </summary>
    public class Destination : Task
    {
        public Destination(string name) : base(name) { }
    }

    /// <summary>
    /// Leaf
    /// </summary>
    public class Restaurant : Task
    {
        public Restaurant(string name) : base(name) { }
    }

    /// <summary>
    /// Composite
    /// </summary>
    public class Auditorium : Task
    {
        public Auditorium(string name) : base(name) { }
    }

    /// <summary>
    ///  Leaf (for Composite Auditorium)
    /// </summary>
    public class ChoralUnion : Task
    {
        public ChoralUnion(string name): base(name) { }
    }

    /// <summary>
    ///  Composite (for Composite Auditorium)
    /// </summary>
    public class Theater : Task
    {
        public Theater(string name) : base(name) { }
    }

    public class RenegadePerformance : Task
    {
        public RenegadePerformance(string name) : base(name) { }
    }
}
