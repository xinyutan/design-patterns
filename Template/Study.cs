using System;
namespace Template
{
    /// <summary>
    /// abstract class that defines: 1) abstract operations 2) template method defining the skelton of an algorithm
    /// </summary>
    public abstract class Subject
    {
        public abstract void Read();
        public abstract void Practice();
        public abstract void ListenToLecture();

        public void Study()
        {
            Console.WriteLine("Studying subject: {0}", this.GetType().Name);
            ListenToLecture();
            Read();
            Practice();
        }
    }

    /// <summary>
    /// concrete class
    /// </summary>
    public class MachineLearning : Subject
    {
        public override void Read() => Console.WriteLine("Read Pattern Recognition and Machine Learning by Christopher M. Bishop");

        public override void ListenToLecture() => Console.WriteLine("Listen to Machine Learning course by Andrew Ng on Coursera");

        public override void Practice() => Console.WriteLine("Do some toy project on Kaggle");

    }

    /// <summary>
    /// concrete class
    /// </summary>
    public class CellBiology : Subject
    {
        public override void Read() => Console.WriteLine("Read Molecular Biology of the Cell by Bruce Alberts et al");

        public override void ListenToLecture() => Console.WriteLine("Listen to open course here: https://ocw.mit.edu/courses/biology/7-012-introduction-to-biology-fall-2004/video-lectures/");

        public override void Practice() => Console.WriteLine("Run some westernblots and PCR at a biology lab");
    }
}
