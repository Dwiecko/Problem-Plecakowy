namespace ProblemPlecakowy
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion Usings

    /// <summary>
    ///     Represents the backpack.
    /// </summary>
    public class BackPack
    {
        #region Constants

        /// <summary>
        ///     Represents the infitity - the lowest size from subset of the subsets does not exist.
        /// </summary>
        private const int Infinity = short.MaxValue;

        #endregion Constants

        #region Methods

        /// <summary>
        ///     The highest backpack items value for given size.
        /// </summary>
        /// <param name="itemsSizes">
        ///     The backpack items sizes.
        /// </param>
        /// <param name="itemsValues">
        ///     The backpack items sizes.
        /// </param>
        /// <param name="numberOfItems">
        ///     The number of items.
        /// </param>
        /// <param name="itemsMaxSize">
        ///     The maximum size of backpack items.
        /// </param>
        /// <returns>
        ///     The highest backpack value for given size.
        /// </returns>
        public static int GetHighestBackpackValue(ref int[] itemsValues, ref int[] itemsSizes, int numberOfItems, int itemsMaxSize)
        {
            var matrix = new int[numberOfItems, itemsMaxSize + 1];
            for (int i = 0; i < numberOfItems; i++)
            {
                for (int s = 0; s <= itemsMaxSize; s++)
                {
                    if (i == 0)
                    {
                        matrix[0, s] = s < itemsSizes[i] ? 0 : itemsValues[i];
                    }
                    else if (s < itemsSizes[i])
                    {
                        matrix[i, s] = matrix[i - 1, s];
                    }
                    else
                    {
                        var withCurrentItem = matrix[i - 1, s];
                        var withoutCurrentItem = matrix[i - 1, s - itemsSizes[i]] + itemsValues[i];

                        matrix[i, s] = Math.Max(withCurrentItem, withoutCurrentItem);
                    }
                }
            }

            return matrix[numberOfItems - 1, itemsMaxSize];
        }

        /// <summary>
        ///     Get lowest backpack size for given value.
        /// </summary>
        public static int GetLowestBackpackSize(ref int[] itemsValues, ref int[] itemsSizes, int numberOfItems, int itemsMaxSize)
        {
            var valuesSum = itemsValues.Sum() + 1;
            var matrix = new int[numberOfItems, valuesSum];
            for (int i = 0; i < numberOfItems; i++)
            {
                for (int v = 0; v < valuesSum; v++)
                {
                    if (v == 0)
                    {
                        matrix[i, 0] = 0;
                    }
                    else if (i == 0)
                    {
                        matrix[0, v] = itemsValues[i] == v ? itemsSizes[i] : Infinity;
                    }
                    else
                    {
                        if (v < itemsValues[i])
                        {
                            matrix[i, v] = matrix[i - 1, v];
                        }
                        else
                        {
                            matrix[i, v] = Math.Min(matrix[i - 1, v], matrix[i - 1, v - itemsValues[i]] + itemsSizes[i]);
                        }
                    }
                }
            }
            var size = matrix[numberOfItems - 1, itemsMaxSize - 1];

            var rowValues = SliceArrayByRow(matrix, numberOfItems - 1).ToList();
            var maxSize = rowValues.Where(currentValue => currentValue <= itemsMaxSize).Max();

            return rowValues.IndexOf(maxSize);
        }

        #endregion Methods

        #region Extensions

        /// <summary>
        ///     The slice multidimensional array for given row.
        /// </summary>
        /// <param name="array">
        ///     The multidimensional array to slice by row.
        /// </param>
        /// <param name="row">
        ///     The multidimensional array row to get.
        /// </param>
        /// <returns>
        ///     The sliced multidimensional array by given row.
        /// </returns>
        private static IEnumerable<int> SliceArrayByRow(int[,] array, int row)
        {
            for (var i = array.GetLowerBound(1); i <= array.GetUpperBound(1); i++)
            {
                yield return array[row, i];
            }
        }

        #endregion Extensions
    }
}