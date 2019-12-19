namespace ProblemPlecakowy
{
    #region Usings

    using System;

    #endregion Usings

    /// <summary>
    ///     The main execution program.
    /// </summary>
    public class Program
    {
        #region Constants

        /// <summary>
        ///     Represents the number of taken backpack items.
        /// </summary>
        private const int NumberOfItems = 4;

        /// <summary>
        ///     Represents the number of items max size.
        /// </summary>
        private const int ItemsMaxSize = 10;

        /// <summary>
        ///     Represents the limit value of random number.
        /// </summary>
        private const int RandomNumberLimit = 10;

        /// <summary>
        ///     Represents the items at start when checking algorithm complexity.
        /// </summary>
        private const int ItemsAtStart = 4;

        /// <summary>
        ///     Represents the items in the end when checking algorithm complexity.
        /// </summary>
        private const int ItemsInTheEnd = 10;

        #endregion Constants

        #region Methods

        /// <summary>
        ///     The main method.
        /// </summary>
        private static void Main()
        {
            TestExample();

            TestAlgorithmsComplexity();
        }

        /// <summary>
        ///     The test example shown in the tutor.
        /// </summary>
        private static void TestExample()
        {
            var itemsValues = new int[] { 5, 1, 4, 2 };
            var itemsSizes = new int[] { 6, 3, 4, 2 };

            var highestValue = BackPack.GetHighestBackpackValue(ref itemsValues, ref itemsSizes, NumberOfItems, ItemsMaxSize);
            Console.WriteLine("Highest backpack value: " + highestValue);

            var lowestSize = BackPack.GetLowestBackpackSize(ref itemsValues, ref itemsSizes, NumberOfItems, ItemsMaxSize);
            Console.WriteLine("Lowest bakcpack size: " + lowestSize);
        }

        /// <summary>
        ///     The test algorithms time complexity.
        /// </summary>
        private static void TestAlgorithmsComplexity()
        {
            AlgorithmComplexityTester complextityTester = new AlgorithmComplexityTester(RandomNumberLimit);

            complextityTester.TestSequenceOfAlgorithmExectionTime(
                ItemsAtStart,
                ItemsInTheEnd,
                AlgorithmType.DynamicHighestBackpackValue);

            complextityTester.TestSequenceOfAlgorithmExectionTime(
                ItemsAtStart,
                ItemsInTheEnd,
                AlgorithmType.DynamicLowestBackpackSize);
        }

        #endregion Methods
    }
}