using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====Demo for Adapter Pattern=====");

            // non-adpated
            var unknown = new Book("Design Pattern");
            unknown.LoadData();

            // adapted
            var oblomov = new BookDetails("Oblomov");
            oblomov.LoadData();

            var vanGoghLetter = new BookDetails("The Letters of Vincent van Gogh");
            vanGoghLetter.LoadData();

            var designPattern = new BookDetails("Design Patterns");
            designPattern.LoadData();

            _ = Console.ReadKey();
        }
    }
}
