using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            // composite 1, child for root
            var hill = new Auditorium("Hill Auditorium");
            // leaf for composite 1
            hill.SubTasks.Add(new ChoralUnion("Beethoven Symphony No.5"));

            // composite 2, child for composite 1
            var theater = new Theater("Theater Perforance");
            // two leaves for composite 2
            theater.SubTasks.Add(new Theater("Hamlet"));
            theater.SubTasks.Add(new RenegadePerformance("The Great Tamer"));

            hill.SubTasks.Add(theater);

            // leaf for root
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
