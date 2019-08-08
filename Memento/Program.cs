using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            BookReview bookReview = new BookReview("I like the book - On the Shortness of Life by Seneca.");
            bookReview.Display();

            PreviousReview previous = new PreviousReview();
            previous.Memento = bookReview.SaveToMemento();

            System.Threading.Thread.Sleep(5000);
            bookReview.Update("I think...ops...I close the file without saving...");
            // notice 5 seconds delay
            bookReview.Display();

            bookReview.RetorePreviousReview(previous.Memento);
            bookReview.Display();
        }
    }
}
