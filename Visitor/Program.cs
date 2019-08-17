using System;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new YouthUser { Name = "Jane" };
            User user2 = new YouthUser { Name = "Ron" };
            User user3 = new AdultUser { Name = "Zoe" };
            User user4 = new AdultUser { Name = "Wendy" };

            InterestsGroup book = new Book();
            InterestsGroup music = new Music();

            user1.Accept(book);
            user1.Accept(music);

            user2.Accept(book);

            user3.Accept(music);

            user4.Accept(music);

            book.Display();
            Console.WriteLine();
            music.Display();
        }
    }
}
