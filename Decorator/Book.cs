using System;

namespace Decorator
{
    /// <summary>
    /// Abstract class for Component
    /// </summary>
    abstract class Print
    {
        public abstract void Display();
    }

    /// <summary>
    /// ConcreteComponent
    /// </summary>
    class Newspaper : Print
    {
        public string Name { get; set; }

        public override void Display()
        {
            Console.WriteLine("{0}: {1}", this.GetType().Name, Name);
        }
    }

    /// <summary>
    /// ConcreteComponent
    /// </summary>
    class Book : Print
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public override void Display()
        {
            Console.WriteLine("{0}: {1} by {2}", this.GetType().Name, Name, Author);
        }
    }

    /// <summary>
    /// Abstract class for Decorator (which has a reference to component and also comply with component's interface)
    /// </summary>
    abstract class Status : Print
    {
        protected Print _print;

        public Status (Print print)
        {
            _print = print;
        }

        public override void Display()
        {
            _print.Display();
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// </summary>
    class Read : Status
    {
        public string Review { get; set; }

        public Read(Print print, string review): base(print)
        {
            Review = review;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("I've already read this book. My review is: \n{0}", Review);
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// </summary>
    class ToRead: Status
    { 
        public string Reason { get; set; }

        public ToRead(Print print, string reason): base(print)
        {
            Reason = reason;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("I want to read this book because: \n{0}", Reason);
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// </summary>
    class Subscribe : Status
    {
        public Subscribe(Print print) : base(print) { }
        public override void Display()
        {
            Console.WriteLine("I subscribed the following:");
            base.Display();
        }
    }
}
