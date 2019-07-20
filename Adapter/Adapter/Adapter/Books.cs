using System;
namespace Adapter
{
    /// <summary>
    /// Adaptee class: legacy API
    /// </summary>
    class BookDatabase
    {
        public double GetStars(string bookName)
        {
            switch (bookName)
            {
                case "Oblomov":
                    return 5.0;

                case "The Letters of Vincent van Gogh":
                    return 5.0;

                case "Design Patterns":
                    return 3.0;

                default:
                    return -1.0;
            }
        }

        public string GetReview(string bookName)
        {
            switch (bookName)
            {
                case "Oblomov":
                    return "This book lets me see myself in a deeper way, as through the Mirror of Erised.";

                case "The Letters of Vincent van Gogh":
                    return "I felt so sad and touch reading these letters. van Gogh was 'fighting a losing battle', and yet he was so devoted and courageous.";

                case "Design Patterns":
                    return "I think authors could have made this book much more intuitive and simpler to understand.";

                default:
                    return "";
            }
        }
    }

    /// <summary>
    /// Target class
    /// </summary>
    public class Book
    {
        public string Name { get; set; }
        public float Stars { get; set; }
        public string Review { get; set; }

        public Book(string name)
        {
            Name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Stars: {0}", Stars);
            Console.WriteLine("How do I think of the book?\n{0}", Review);
        }

        public virtual void LoadData()
        {
            Console.WriteLine("\nBook {0}---------------", Name);
        }
    }

    /// <summary>
    /// Adapter class: the wrapper for BookDatabase
    /// </summary>
    public class BookDetails : Book
    {
        private BookDatabase _bookDatabase;

        public BookDetails(string name):
            base(name)
        {

        }

        public override void LoadData()
        {
            _bookDatabase = new BookDatabase();
            Stars = (float)_bookDatabase.GetStars(Name);
            Review = _bookDatabase.GetReview(Name);

            base.LoadData();
            ShowInfo();
        }
    }
}
