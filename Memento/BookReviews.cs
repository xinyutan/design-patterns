using System;
namespace Memento
{
    public class Review
    {
        public string Content;
        public DateTime LastUpdateTime;
    }

    /// <summary>
    /// Originator
    /// </summary>
    public class BookReview : Review
    {
        public BookReview(string content)
        {
            Content = content;
            LastUpdateTime = DateTime.Now;
        }

        public BookReviewMemento SaveToMemento()
        {
            Console.WriteLine("Saving the current review...\n");
            return new BookReviewMemento(this);
        }

        public void Update(string updateContent)
        {
            Content = updateContent;
            LastUpdateTime = DateTime.Now;
        }

        public void ResetReview()
        {
            Content = "";
            LastUpdateTime = DateTime.Now;
        }

        public void RetorePreviousReview(BookReviewMemento bookReviewMemento)
        {
            Console.WriteLine("Restoring to previous review...\n");
            Content = bookReviewMemento.Content;
            LastUpdateTime = bookReviewMemento.LastUpdateTime;
        }

        public void Display()
        {
            Console.WriteLine("Last Update Time: {0}\nContent: {1}\n", LastUpdateTime.ToString(), Content);
        }
    }

    /// <summary>
    /// Memento
    /// </summary>
    public class BookReviewMemento : Review
    {
        public BookReviewMemento(BookReview bookReview)
        {
            Content = bookReview.Content;
            LastUpdateTime = bookReview.LastUpdateTime;
        }
    }

    /// <summary>
    /// Caretaker: save and retrieve the memento 
    /// </summary>
    class PreviousReview
    {
        public BookReviewMemento Memento { get; set; }
    }
}
