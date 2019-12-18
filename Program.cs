using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProblemPlecakowy
{
    public class Backpack
    {

    }

    public class Program
    {
        #region Constants

        /// <summary>
        ///     Represents the infitity - the lowest size from subset of the subsets does not exist.
        /// </summary>
        private const int Infinity = short.MaxValue;

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
        ///     The backpack items values.
        /// </summary>
        private static readonly int[] vB = { 5, 1, 4, 2 };

        /// <summary>
        ///     The backpack items size.
        /// </summary>
        private static readonly int[] sB = { 6, 3, 4, 2 };

        #endregion

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

        #endregion

        #region Methods
        
        public int RecursiveGetHighestBackpackValue(ref int[] vB, ref int[] sB, int index, int s)
        {
            if (index == 1) return s < sB[1] ? 0 : vB[1];
            if (s < sB[index]) return RecursiveGetHighestBackpackValue(ref vB, ref sB, index - 1, s);

            return Math.Max(RecursiveGetHighestBackpackValue(ref vB, ref sB, index - 1, s), 
                RecursiveGetHighestBackpackValue(ref vB, ref sB, index - 1, s - sB[index]) + vB[index]);
        }

        /// <summary>
        ///     The highest backpack items value for given size.
        /// </summary>
        /// <param name="items">
        ///     The number of items.
        /// </param>
        /// <param name="backPackSize">
        ///     The maximum size of backpack items.
        /// </param>
        /// <returns>
        ///     The highest backpack value for given size.
        /// </returns>
        private static int GetHighestBackpackValue(ref int[] vB, ref int[] sB, int items, int maxSize)
        {
            var matrix = new int[items, maxSize + 1];
            for (int i = 0; i < items; i++)
            {
                for (int s = 0; s <= maxSize; s++)
                {
                    if (i == 0)
                    {
                        matrix[0, s] = s < sB[i] ? 0 : vB[i];
                    }
                    else if (s < sB[i])
                    {
                        matrix[i, s] = matrix[i - 1, s];
                    }
                    else
                    {
                        var withCurrentItem = matrix[i - 1, s];
                        var withoutCurrentItem = matrix[i - 1, s - sB[i]] + vB[i];

                        matrix[i, s] = Math.Max(withCurrentItem, withoutCurrentItem);
                    }
                }
            }

            return matrix[items - 1, step];
        }

        /// <summary>
        ///     Compute lowest backpack size with the highest value.
        /// </summary>
        private static int GetLowestBackpackSize(ref int[] vB, ref int[] sB, int items, int step)
        {
            var valuesSum = vB.Sum() + 1;
            var matrix = new int[items, valuesSum];
            for (int i = 0; i < items; i++)
            {
                for (int v = 0; v < valuesSum; v++)
                {
                    matrix[i, 0] = 0;

                    if (i == 0)
                    {
                        matrix[0, v] = vB[i] == v ? sB[i] : Infinity;
                    }
                    else
                    {
                        if (v < vB[i])
                        {
                            matrix[i, v] = matrix[i - 1, v];
                        }
                        else
                        {
                            matrix[i, v] = Math.Min(matrix[i - 1, v], matrix[i - 1, v - vB[i]] + sB[i]);
                        }
                    }
                }
            }
            var size = matrix[items - 1, step - 1];

            var rowValues = SliceArrayByRow(matrix, items - 1).ToList();
            var maxSize = rowValues.Where(currentValue => currentValue <= size).Max();

            return rowValues.IndexOf(maxSize);
        }

        private static void Main()
        {
            BackpackItem[] backpackItems =
            {
                new BackpackItem()
            }
            Console.WriteLine("Highest backpack value: " + GetHighestBackpackValue(NumberOfItems, ItemsMaxSize));
            Console.WriteLine("Lowest bakcpack size: " + GetLowestBackpackSize(NumberOfItems, ItemsMaxSize));
        }

        private static void Test()
        {
            var stopwatch = new Stopwatch();

        }

        public class BackpackItem
        {
            public int Size { get; set; }
            public int Value { get; set; }

            public BackpackItem(int size, int value)
            {
                Size = size;
                Value = value;
            }
        }

        #endregion
    }
}
