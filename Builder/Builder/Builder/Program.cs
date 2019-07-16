using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // director
            TripPlanner tripPlanner = new TripPlanner();

            TripBuilder builder;

            builder = new TripToBeijing();
            tripPlanner.Plan(builder);
            builder.Trip.Display();

            builder = new TripToDetroit();
            tripPlanner.Plan(builder);
            builder.Trip.Display();

            // Wait for user
            Console.ReadKey();
        }
    }
}
