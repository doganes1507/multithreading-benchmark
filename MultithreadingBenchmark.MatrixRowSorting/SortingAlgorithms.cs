using System.Numerics;

namespace MultithreadingBenchmark.MatrixRowSorting;

public static class SortingAlgorithms
{
    /// <summary>
    /// Sorts the elements in the given list using the Bubble sort algorithm.
    /// </summary>
    /// <param name="list">The list of numbers to sort.</param>
    /// <typeparam name="T">The type of numbers in the list. Must implement the INumber interface.</typeparam>
    /// <remarks>
    /// In the average case, the time complexity of the Bubble sort algorithm is O(n^2).
    /// </remarks>
    public static void BubbleSort<T>(List<T> list) where T: INumber<T>
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Sorts the elements in the given list using the Shell sort algorithm.
    /// </summary>
    /// <param name="list">The list of numbers to sort.</param>
    /// <typeparam name="T">The type of numbers in the list. Must implement the INumber interface.</typeparam>
    /// <remarks>
    /// The time complexity of the Shell sort algorithm is estimated to be from O(n log n) to O(n^(3/2)).
    /// </remarks>
    public static void ShellSort<T>(List<T> list) where T : INumber<T>
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sorts the elements in the given list using the Quick sort algorithm.
    /// </summary>
    /// <param name="list">The list of numbers to sort.</param>
    /// <typeparam name="T">The type of numbers in the list. Must implement the INumber interface.</typeparam>
    /// <remarks>
    /// In the average case, the time complexity of the Quick sort algorithm is O(n log n).
    /// </remarks>
    public static void QuickSort<T>(List<T> list) where T : INumber<T>
    {
        throw new NotImplementedException();
    }
}