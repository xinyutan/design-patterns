using System;


namespace Bridge
{
    /// <summary>
    /// Implementor
    /// </summary>
    public interface IAlgorithm
    {
        void Run(string name);
    }

    /// <summary>
    /// Concrete Implementor A
    /// </summary>
    public class LinearRegression : IAlgorithm
    {
        public void Run(string name)
        {
            Console.WriteLine("Running Linear Regression on {0}", name);
        }
    }

    /// <summary>
    /// Concrete Implementor B
    /// </summary>
    public class RandomForest: IAlgorithm
    {
        public void Run(string name)
        {
            Console.WriteLine("Running Random Forest on {0}", name);
        }
    }

    /// <summary>
    /// Abstraction class which has a reference to the IAlgorithm (Implementor)
    /// </summary>
    public abstract class Dataset
    {
        // reference to Implementer
        public IAlgorithm _algorithm;

        public abstract void ModelData();
    }

    /// <summary>
    /// RefinedAbstraction class 
    /// </summary>
    public class TitanicDataset : Dataset
    {
        public override void ModelData()
        {
            _algorithm.Run("Titanic Dataset");
        }
    }

    public class IrisDataset: Dataset
    {
        public override void ModelData()
        {
            _algorithm.Run("Iris Dataset");
        }
    }
}
