using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var hill = new Auditorium("Hill Auditorium");
            hill.SubTasks.Add(new ChoralUnion("Beethoven Symphony No.5"));

            var theater = new Theater("Theater Perforance");
            theater.SubTasks.Add(new Theater("Hamlet"));
            theater.SubTasks.Add(new RenegadePerformance("The Great Tamer"));

            hill.SubTasks.Add(theater);

            var restaurant = new Restaurant("Zingerman's Bakehouse");

            // the root
            var trip = new Destination("Ann Arbor");
            trip.SubTasks.Add(restaurant);
            trip.SubTasks.Add(hill);

            Console.Write("We are going to visit ");
            trip.Print();

            Console.ReadKey();
        }
    }
}
