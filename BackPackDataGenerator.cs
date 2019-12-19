namespace ProblemPlecakowy
{
    #region Usings

    using System;
    using System.Linq;

    #endregion Usings

    /// <summary>
    ///     Represents the backpack items data generator.
    /// </summary>
    public class BackPackDataGenerator
    {
        #region Fields

        /// <summary>
        ///     The random data generator.
        /// </summary>
        private static readonly Random Random = new Random();

        #endregion Fields

        #region Methods

        /// <summary>
        ///     The backpack items data generator.
        /// </summary>
        /// <param name="numberOfItems">
        ///     The number of backpack items to generate.
        /// </param>
        /// <param name="randomNumberLimit">
        ///     The random number limit.
        /// </param>
        /// <param name="itemsSizes">
        ///     The random backpack items sizes.
        /// </param>
        /// <param name="itemsValues">
        ///     The random backpack items values.
        /// </param>
        /// <returns>
        ///     The random size of backpack items.
        ///     Random size if gathered from portion of sizes in descending order.
        /// </returns>
        public static int GenerateRandomInput(int numberOfItems, int randomNumberLimit, out int[] itemsValues, out int[] itemsSizes)
        {
            itemsSizes = GenerateRandomArray(numberOfItems, randomNumberLimit);
            itemsValues = GenerateRandomArray(numberOfItems, randomNumberLimit);

            var randomSize = itemsSizes.OrderByDescending(size => size)
                .Take(itemsSizes.Length / 2).OrderBy(r => Random.Next()).First();

            return randomSize;
        }

        /// <summary>
        ///     The generate random array with given limit.
        /// </summary>
        /// <param name="itemsToGenerate">
        ///     The number of items to generate.
        /// </param>
        /// <param name="randomNumberLimit">
        ///     The random number limit.
        /// </param>
        /// <returns>
        ///     The random data array.
        /// </returns>
        private static int[] GenerateRandomArray(int itemsToGenerate, int randomNumberLimit)
        {
            return Enumerable.Range(1, itemsToGenerate).Select(number => Random.Next(1, randomNumberLimit)).ToArray();
        }

        #endregion Methods
    }
}