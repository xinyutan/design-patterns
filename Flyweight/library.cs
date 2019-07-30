using System;
using System.Collections.Generic;

namespace Flyweight
{
    public enum Availability
    {
        Available,
        Borrowed,
        OnHold
    }

    /// <summary>
    /// Abstract class Flyweight
    /// </summary>
    abstract class Item
    {
        protected string Name;
        protected DateTime DueDate;

        //extrinsic state
        protected Availability _availability;

        public abstract void Borrow();

        public Boolean IsAvailable()
        {
            switch (_availability)
            {
                case Availability.Available:
                    return true;
                case Availability.Borrowed:
                    return false;
                case Availability.OnHold:
                    return false;
                default:
                    throw new Exception("Invalid option");
            }
        }

        public void PutOnHold()
        {
            if (_availability == Availability.Available)
            {
                _availability = Availability.OnHold;
            }
            else
            {
                Console.WriteLine("Can't put on hold for {0} item.", _availability.ToString());
            }
        }

        public void Reset()
        {
            _availability = Availability.Available;
            DueDate = new DateTime();
        }

        public void Display()
        {
            Console.WriteLine("Item Name: {0}", Name);
            Console.WriteLine("Due Date: {0}", DueDate.ToString());
            Console.WriteLine("Availability: {0}", _availability.ToString());
        }
    }

    /// <summary>
    /// concrete flyweight
    /// </summary>
    class WarAndPeace : Item
    {
        public WarAndPeace()
        {
            Name = "Book - War and Peace";
            _availability = Availability.Available;
        }

        public override void Borrow()
        {
            DueDate = DateTime.Now.AddDays(30);
            _availability = Availability.Borrowed;
            Console.WriteLine("The due date for {0} is {1}", Name, DueDate.ToString());
        }
    }

    class Friends : Item
    {
        public Friends()
        {
            Name = "DVD - Friends";
            _availability = Availability.Available;
        }

        public override void Borrow()
        {
            DueDate = DateTime.Now.AddDays(7);
            _availability = Availability.Borrowed;
            Console.WriteLine("The due date for {0} is {1}", Name, DueDate.ToString());
        }
    }

    /// <summary>
    /// The FlyweightFactory class
    /// </summary>
    class ItemsRepository
    {
        private Dictionary<string, Item> _items = new Dictionary<string, Item>();

        public Item GetItem(string choice)
        {
            Item item = null;

            if (_items.ContainsKey(choice))
            {
                return _items[choice];
            }

            if (choice == "friends")
            {
                _items.Add("friends", new Friends());
                item = _items["friends"];
            } else if (choice == "war&peace")
            {
                _items.Add("war&peace", new WarAndPeace());
                item = _items["war&peace"];
            } else
            {
                Console.WriteLine("Please select between `friends` and `war&peace`");
            }

            return item;
        }
    }
}
