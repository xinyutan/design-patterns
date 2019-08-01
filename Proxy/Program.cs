using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxyReader = new ProxyReader();

            var book1 = new Book() { Name = "The Origin of Species by Charles Darwin", IsChildrenFriendly = true };
            var book2 = new Book() { Name = "Lolita by Vladimir Nabokov", IsChildrenFriendly = false };

            Console.WriteLine("===================\nShould read: ");
            proxyReader.Read(book1);

            Console.WriteLine("===================\nShould not read: ");
            proxyReader.Read(book2);
        }
    }
}
