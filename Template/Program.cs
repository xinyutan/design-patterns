using System;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            var biology = new CellBiology();
            biology.Study();

            Console.WriteLine();

            var ml = new MachineLearning();
            ml.Study();
        }
    }
}
