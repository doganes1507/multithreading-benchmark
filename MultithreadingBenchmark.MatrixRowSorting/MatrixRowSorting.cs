using System.Numerics;

namespace MultithreadingBenchmark.MatrixRowSorting;

public static class MatrixRowSorting
{
    /// <summary>
    /// Sorts the rows of a matrix using parallelism and the specified sorting algorithm, dividing the work among the given number of threads.
    /// </summary>
    /// <param name="matrix">The matrix whose rows are to be sorted.</param>
    /// <param name="numberOfThreads">The number of threads to use for sorting.</param>
    /// <param name="algorithm">The algorithm to use for sorting the matrix rows.</param>
    /// <typeparam name="T">The type of elements in the matrix. Must implement the INumber interface.</typeparam>
    /// <returns>The sorted matrix.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input matrix is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the input number of threads is less than 1, or greater than the number of matrix rows.</exception>
    public static List<List<T>> ParallelSortMatrixRows<T>(List<List<T>> matrix, int numberOfThreads, SortingAlgorithmEnum algorithm) where T: INumber<T>
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }
        
        if (numberOfThreads < 1 || numberOfThreads > matrix.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfThreads), "The number of threads must be between 1 and the number of matrix rows.");
        }
        
        throw new NotImplementedException();
    }
}