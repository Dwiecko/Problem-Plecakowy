namespace ProblemPlecakowy
{
    #region Usings

    using System;
    using System.Diagnostics;

    #endregion Usings

    /// <summary>
    ///     The backpack algorithms time complexity tester.
    /// </summary>
    public class AlgorithmComplexityTester
    {
        #region Fields

        /// <summary>
        ///     The lower bound of iterations.
        /// </summary>
        public int IterationsLowerBound;

        /// <summary>
        ///     The higher bound of iterations.
        /// </summary>
        public int IterationsHigherBound;

        /// <summary>
        ///     The stopwatch used in algorithm complexity calculation.
        /// </summary>
        private readonly Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        ///     The stopwatch used in algorithm complexity calculation.
        /// </summary>
        private readonly int randomNumberLimit;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///     Creates a new istance of the class which tests backpack algorithms time complexity.
        /// </summary>
        /// <param name="randomNumberLimit">
        ///     The generated random number limit.
        /// </param>
        public AlgorithmComplexityTester(int randomNumberLimit)
        {
            this.randomNumberLimit = randomNumberLimit;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     The get algorithm backpack algorith execution time in clock ticks.
        /// </summary>
        /// <param name="numberOfItems">
        ///     The nubmer of tested items.
        /// </param>
        /// <param name="backpackAlgorithm">
        ///     The type of tested backpack algorithm.
        /// </param>
        public void TestSingleAlgorithmExectionTime(int numberOfItems, AlgorithmType backpackAlgorithm)
        {
            int randomMaxSize = BackPackDataGenerator.GenerateRandomInput(numberOfItems, randomNumberLimit, out int[] itemsSizes, out int[] itemsValues);

            stopwatch.Start();
            switch (backpackAlgorithm)
            {
                case AlgorithmType.DynamicHighestBackpackValue:
                    {
                        BackPack.GetHighestBackpackValue(ref itemsValues, ref itemsSizes, itemsSizes.Length, randomMaxSize);
                        break;
                    }
                case AlgorithmType.DynamicLowestBackpackSize:
                    {
                        BackPack.GetLowestBackpackSize(ref itemsValues, ref itemsSizes, itemsSizes.Length, randomMaxSize);
                        break;
                    }
            }
            stopwatch.Stop();

            var elapsedTicks = stopwatch.ElapsedTicks;

            Console.WriteLine("{0}: {1} items, tested size: {2} ticks - {3}",
                backpackAlgorithm, itemsSizes.Length, randomMaxSize, elapsedTicks);
        }

        /// <summary>
        ///     The test sequence of algorithm execution for given items size.
        /// </summary>
        /// <param name="testedItems">
        ///     The number of tested items in the start.
        /// </param>
        /// <param name="testeditemsLimit">
        ///     The number of tested items in the end.
        /// </param>
        /// <param name="backpackAlgorithm">
        ///     The type of tested backpack algorithm.
        /// </param>
        public void TestSequenceOfAlgorithmExectionTime(int testedItems, int testeditemsLimit, AlgorithmType backpackAlgorithm)
        {
            for (var i = testedItems; i <= testeditemsLimit; i++)
            {
                TestSingleAlgorithmExectionTime(i, backpackAlgorithm);
            }
        }

        #endregion Methods
    }
}