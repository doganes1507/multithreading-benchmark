using System.Numerics;

namespace MultithreadingBenchmark.MatrixRowSorting;

public static class MatrixRowSorting
{
    /// <summary>
    /// Sorts the rows of a matrix using parallelism, dividing the work among the given number of threads.
    /// </summary>
    /// <param name="matrix">The matrix whose rows are to be sorted.</param>
    /// <param name="numberOfThreads">The number of threads to use for sorting.</param>
    /// <typeparam name="T">The type of elements in the matrix. Must implement the INumber interface.</typeparam>
    /// <returns>The sorted matrix.</returns>
    public static List<List<T>> ParallelSortMatrixRows<T>(List<List<T>> matrix, int numberOfThreads) where T: INumber<T>
    {
        throw new NotImplementedException();
    }
}