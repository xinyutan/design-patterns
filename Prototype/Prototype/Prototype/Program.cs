using System;
using System.Collections.Generic;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var houseSelection = new HouseSelection();
            // add some templates
            houseSelection["template1"] = new House(new List<Room> { new LivingRoom(), new Bedroom(), new Bathroom(), new Diningroom() });
            houseSelection["template2"] = new House(new List<Room> { new Library(), new Bathroom() });

            // clone
            var house1 = houseSelection["template1"].Clone();
            var house2 = houseSelection["template2"].Clone();

            Console.ReadKey();
        }
    }
}
