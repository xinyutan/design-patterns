using System;

namespace Flyweight
{
    /// <summary>
    /// Client for Flyweight
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var itemsRepository = new ItemsRepository();

            string stop = "a";
            while (stop != "e")
            {
                Console.WriteLine("Enter an item you are interested: war&peace/friends");
                string itemChoice = Console.ReadLine();

                Console.WriteLine("What do you plan to do? R(eturn)/B(orrow)/P(ut on hold)?");
                string planChoice = Console.ReadLine();

                Item item = itemsRepository.GetItem(itemChoice);
                item.Display();
                Console.WriteLine("");

                switch (planChoice)
                {
                    case "B":
                        item.Borrow();
                        item.Display();
                        break;
                    case "P":
                        item.PutOnHold();
                        item.Display();
                        break;
                    case "R":
                        item.Reset();
                        item.Display();
                        break;
                    default:
                        break;

                }

                Console.WriteLine("\nPress 'e' to stop and other keys to continue: ");
                stop = Console.ReadLine();
            }
        }

    }
}
