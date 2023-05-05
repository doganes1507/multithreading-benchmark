using System.Numerics;

namespace MultithreadingBenchmark.MatrixRowSorting;

internal static class MatrixRowSorting
{
    /// <summary>
    /// Sorts the rows of a matrix using parallelism and the specified sorting algorithm, dividing the work among the given number of threads.
    /// </summary>
    /// <param name="matrix">The matrix whose rows are to be sorted.</param>
    /// <param name="numberOfThreads">The number of threads to use for sorting.</param>
    /// <param name="algorithm">The algorithm to use for sorting the matrix rows.</param>
    /// <typeparam name="T">The type of elements in the matrix. Must implement the INumber interface.</typeparam>
    /// <exception cref="ArgumentNullException">Thrown when the input matrix is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the input number of threads is less than 1, or greater than the number of matrix rows
    /// or when an unsupported SortingAlgorithmEnum value is passed in.</exception>
    public static void ParallelSortMatrixRows<T>(List<List<T>> matrix, int numberOfThreads,
        SortingAlgorithmEnum algorithm) where T: INumber<T>
    {
        #region InputValidation

        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }
        
        if (numberOfThreads < 1 || numberOfThreads > matrix.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfThreads), "The number of threads must be between 1 and the number of matrix rows.");
        }

        #endregion

        var splitMatrix = Matrix.SplitList(matrix, numberOfThreads);
        var tasks = new List<Task>();
        
        switch (algorithm)
        {
            case SortingAlgorithmEnum.BubbleSort:
                tasks.AddRange(splitMatrix.Select(part => Task.Run(() =>
                {
                    foreach (var row in part) SortingAlgorithms.BubbleSort(row);
                })));

                break;
                
            case SortingAlgorithmEnum.ShellSort:
                tasks.AddRange(splitMatrix.Select(part => Task.Run(() =>
                {
                    foreach (var row in part) SortingAlgorithms.ShellSort(row);
                })));

                break;
            
            case SortingAlgorithmEnum.QuickSort:
                tasks.AddRange(splitMatrix.Select(part => Task.Run(() =>
                {
                    foreach (var row in part) SortingAlgorithms.QuickSort(row);
                })));

                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, null);
        }

        Task.WaitAll(tasks.ToArray());
    }
}