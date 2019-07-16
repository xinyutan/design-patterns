using System;
using System.Collections.Generic;

namespace Prototype
{
    /// <summary>
    /// The prototype abstract class
    /// </summary>
    abstract class HousePrototype
    {
        protected List<Room> _rooms = new List<Room>();
        public abstract HousePrototype Clone();

        public string GetRoomDescription()
        {
            var roomDescription = "The house contains: ";
            foreach(var room in _rooms)
            {
                roomDescription += room.GetType().Name + ", ";
            }
            return roomDescription.Substring(0, roomDescription.Length-2) + "\n";
        }
    }

    abstract class Room { }
    class LivingRoom : Room { }
    class Bedroom : Room { }
    class Library: Room { }
    class Bathroom : Room { }
    class Diningroom : Room { }

    /// <summary>
    /// ConcretePrototype
    /// </summary>
    class House : HousePrototype
    {
        public House(List<Room> rooms)
        {
            _rooms = rooms;
        }

        public override HousePrototype Clone()
        {
            Console.WriteLine("Clone House: \n" + GetRoomDescription());
            return MemberwiseClone() as HousePrototype;
        }
    }

    class HouseSelection
    {
        private Dictionary<string, HousePrototype> _houses = new Dictionary<string, HousePrototype>();

        public HousePrototype this[string name]
        {
            set { _houses.Add(name, value); }
            get => _houses[name];
        }
    }
}
