using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            // client call abstraction
            var titanic = new TitanicDataset();
            
            titanic._algorithm = new LinearRegression();
            titanic.ModelData();

            Console.WriteLine("Change to another algorithm: ");
            titanic._algorithm = new RandomForest();
            titanic.ModelData();


            Console.WriteLine("\n=================\n");
            var iris = new IrisDataset();

            iris._algorithm = new LinearRegression();
            iris.ModelData();

            Console.WriteLine("Change to another algorithm: ");
            iris._algorithm = new RandomForest();
            iris.ModelData();

            _ = Console.ReadKey();
        }
    }
}
