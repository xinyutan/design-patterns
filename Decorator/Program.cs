using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book() { Author = "Friedrich Nietzsche", Name = "The Birth of Tragedy" };
            var book2 = new Book() { Author = "Aldous Huxley", Name = "Brave New World" };
            var newspaper1 = new Newspaper() { Name = "The New York Times" };

            var toRead = new ToRead(book1, "I am interested in knowing more about Nietzsche's philosophy.");
            toRead.Display();

            Console.WriteLine("==========================");
            var alreadyRead = new Read(book2, "I really enjoyed this book. The brave new world lets me think about the meaning of life and nature of humanity in this world.");
            alreadyRead.Display();

            Console.WriteLine("==========================");
            var subscribe = new Subscribe(newspaper1);
            subscribe.Display();
        }
    }
}
