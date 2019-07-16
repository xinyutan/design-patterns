using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            List<House> builders = new List<House>
            {
                new MyHouse(),
                new CommonHouse()
            };

            foreach (var builder in builders)
            {
                Console.WriteLine("\nBuilding {0}", builder.GetType().Name);
                builder.ShowRooms();
            }

            _ = Console.ReadKey();
        }
    }
}
