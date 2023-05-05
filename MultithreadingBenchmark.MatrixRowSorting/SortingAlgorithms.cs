using System.Numerics;

namespace MultithreadingBenchmark.MatrixRowSorting;

internal static class SortingAlgorithms
{
    /// <summary>
    /// Sorts the elements in the given list using the Bubble sort algorithm.
    /// </summary>
    /// <param name="list">The list of numbers to sort.</param>
    /// <typeparam name="T">The type of numbers in the list. Must implement the INumber interface.</typeparam>
    /// <remarks>
    /// In the average case, the time complexity of the Bubble sort algorithm is O(n^2).
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the list is null.</exception>
    public static void BubbleSort<T>(List<T> list) where T: INumber<T>
    {
        #region InputValidation

        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        #endregion

        for (var i = 0; i < list.Count - 1; i++)
        {
            for (var j = 0; j < list.Count - i - 1; j++)
            {
                if (list[j].CompareTo(list[j + 1]) > 0)
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }
        }
    }

    /// <summary>
    /// Sorts the elements in the given list using the Insertion sort algorithm.
    /// </summary>
    /// <param name="list">The list of numbers to sort.</param>
    /// <typeparam name="T">The type of numbers in the list. Must implement the INumber interface.</typeparam>
    /// <remarks>
    /// In the average case, the time complexity of the Insertion sort algorithm is O(n^2).
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the list is null.</exception>
    public static void InsertionSort<T>(List<T> list) where T : INumber<T>
    {
        #region InputValidation

        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        #endregion
        
        for (var i = 1; i < list.Count; i++)
        {
            var x = list[i];
            var j = i - 1;

            while (j >= 0 && list[j].CompareTo(x) > 0)
            {
                list[j + 1] = list[j];
                j--;
            }

            list[j + 1] = x;
        }
    }

    /// <summary>
    /// Sorts the elements in the given list using the Shell sort algorithm.
    /// </summary>
    /// <param name="list">The list of numbers to sort.</param>
    /// <typeparam name="T">The type of numbers in the list. Must implement the INumber interface.</typeparam>
    /// <remarks>
    /// The time complexity of the Shell sort algorithm is estimated to be from O(n log n) to O(n^(3/2)).
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the list is null.</exception>
    public static void ShellSort<T>(List<T> list) where T : INumber<T>
    {
        #region InputValidation

        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        #endregion

        var interval = list.Count / 2;

        while (interval > 0)
        {
            for (var i = interval; i < list.Count; i++)
            {
                var temp = list[i];
                var j = i;

                while (j >= interval && list[j - interval].CompareTo(temp) > 0)
                {
                    list[j] = list[j - interval];
                    j -= interval;
                }

                list[j] = temp;
            }
            interval /= 2;
        }
    }
}