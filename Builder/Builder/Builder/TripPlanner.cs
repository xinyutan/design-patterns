using System;
using System.Collections.Generic;

namespace Builder
{
    /// <summary>
    /// Product class
    /// </summary>
    class Trip
    {
        private readonly string _tripDestination;
        private readonly Dictionary<string, string> _logistics = new Dictionary<string, string>();

        public Trip(string tripDestination)
        {
            _tripDestination = tripDestination;
        }

        public string this[string key]
        {
            get { return _logistics[key]; }
            set { _logistics[key] = value; }
        }

        public void Display()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("This trip is to {0}", _tripDestination);
            Console.WriteLine("Flight company: {0}", _logistics["flight"]);
            Console.WriteLine("Car rental company: {0}", _logistics["car"]);
            Console.WriteLine("Hotel: {0}", _logistics["hotel"]);
        }

    }

    /// <summary>
    /// Builder class
    /// </summary>
    abstract class TripBuilder
    {
        protected Trip trip;

        public Trip Trip
        {
            get { return trip; }
        }

        public abstract void BookFlight();
        public abstract void BookHotel();
        public abstract void BookCar();
    }

    /// <summary>
    /// Concrete Builder class
    /// </summary>
    class TripToBeijing : TripBuilder
    {
        public TripToBeijing()
        {
            trip = new Trip("Bejing");
        }

        public override void BookCar()
        {
            trip["car"] = "China Auto Rental";
        }

        public override void BookFlight()
        {
            trip["flight"] = "China Airlines";
        }

        public override void BookHotel()
        {
            trip["hotel"] = "The Peninsula Beijing";
        }
    }

    /// <summary>
    /// Concrete Builder class
    /// </summary>
    class TripToDetroit : TripBuilder
    {
        public TripToDetroit()
        {
            trip = new Trip("Detroit");
        }

        public override void BookCar()
        {
            trip["car"] = "Hertz";
        }

        public override void BookFlight()
        {
            trip["flight"] = "Delta Airline";
        }

        public override void BookHotel()
        {
            trip["hotel"] = "Holiday Inn";
        }
    }

    /// <summary>
    /// Director
    /// </summary>
    class TripPlanner
    {
        public void Plan(TripBuilder tripBuilder)
        {
            tripBuilder.BookFlight();
            tripBuilder.BookHotel();
            tripBuilder.BookCar();
        }
    }
}
