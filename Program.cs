namespace ProblemPlecakowy
{
    #region Usings

    using System;

    #endregion

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

        #endregion

        #region Fields

        /// <summary>
        ///     Represents the backpack operations.
        /// </summary>
        private static readonly BackPack backpack = new BackPack();

        #endregion

        #region Methods

        private static void Main()
        {
            var itemsValues = new int[] { 5, 1, 4, 2 };
            var itemsSizes = new int[] { 6, 3, 4, 2 };

            var highestValue = backpack.GetHighestBackpackValue(ref itemsValues, ref itemsSizes, NumberOfItems, ItemsMaxSize);
            Console.WriteLine("Highest backpack value: " + highestValue);

            var lowestSize = backpack.GetLowestBackpackSize(ref itemsValues, ref itemsSizes, NumberOfItems, ItemsMaxSize);
            Console.WriteLine("Lowest bakcpack size: " + lowestSize);
        }

        #endregion
    }
}
