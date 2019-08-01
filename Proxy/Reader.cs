using System;

namespace Proxy
{
    public class Book
    {
        public string Name { get; set; }
        public Boolean IsChildrenFriendly { get; set; }
    }

    /// <summary>
    /// The Subject interface that both RealSubject and Proxy will implement
    /// </summary>
    public interface IEReader
    {
        void Read(Book book);
    }

    /// <summary>
    /// RealSubject: Reader for adults
    /// </summary>
    class Reader : IEReader
    {
        public void Read(Book book)
        {
            Console.WriteLine("Reader is reading the book {0}", book.Name);
        }
    }

    /// <summary>
    /// Proxy: control the access to the RealSubject
    /// </summary>
    class ProxyReader : IEReader
    {
        protected Reader _reader = new Reader();
        public void Read(Book book)
        {
            if (book.IsChildrenFriendly)
            {
                _reader.Read(book);
            }
            else
            {
                Console.WriteLine("ProxyReader can't read the children-unfriendly book {0}", book.Name);
            }
        }
    }
}
