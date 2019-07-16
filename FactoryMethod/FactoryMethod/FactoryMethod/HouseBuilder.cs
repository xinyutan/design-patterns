using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    /// <summary>
    /// Abstract Product
    /// </summary>
    abstract class Room
    {
        private readonly int _count;

        protected Room(int count)
        {
            _count = count;
        }

        protected Room()
        {
            _count = 1;
        }

        public int Count => _count;
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    class LivingRoom : Room
    {
        public LivingRoom()
        {
        }

        public LivingRoom(int count) : base(count) { }
    }

    class Bedroom: Room
    {
        public Bedroom()
        {
        }

        public Bedroom(int count) : base(count) { }
    }

    class LibraryRoom: Room
    {
        public LibraryRoom()
        {
        }

        public LibraryRoom(int count) : base(count) { }
    }

    class DiningRoom: Room
    {
        public DiningRoom()
        {
        }

        public DiningRoom(int count): base(count) { }
    }

    class BathRoom: Room
    {
        public BathRoom(int count): base(count) { }
    }

    /// <summary>
    /// Abstract Creator
    /// </summary>
    abstract class House
    {
        protected List<Room> _rooms = new List<Room>();

        protected House() => BuildHouse();

        public abstract void BuildHouse();

        public void ShowRooms()
        {
            Console.WriteLine("--------------------------");
            foreach (var room in _rooms)
            {
                Console.WriteLine("Room: {0} x {1}", room.GetType().Name, room.Count);
            }
        }
    }

    /// <summary>
    /// Concrete Creator
    /// </summary>
    class MyHouse : House
    {
        public override void BuildHouse()
        {
            _rooms.Add(new LibraryRoom());
            _rooms.Add(new DiningRoom());
            _rooms.Add(new Bedroom(2));
            _rooms.Add(new BathRoom(2));
        }
    }

    /// <summary>
    /// Concrete Creator
    /// </summary>
    class CommonHouse : House
    {
        public override void BuildHouse()
        {
            _rooms.Add(new LivingRoom());
            _rooms.Add(new DiningRoom());
            _rooms.Add(new Bedroom(3));
            _rooms.Add(new BathRoom(2));
        }
    }

}
