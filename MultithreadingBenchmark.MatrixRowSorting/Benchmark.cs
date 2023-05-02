namespace MultithreadingBenchmark.MatrixRowSorting;

public static class Benchmark
{
    /// <summary>
    /// Generates a matrix with the specified row and column count and fills it with random integers between `matrixMinValue` and `matrixMaxValue`. 
    /// Sorts the rows of the matrix on `numberOfThreads` threads and measures the elapsed time in milliseconds.
    /// </summary>
    /// <param name="numberOfThreads">The number of threads to use for sorting the matrix.</param>
    /// <param name="matrixRowCount">The number of rows in the matrix.</param>
    /// <param name="matrixColumnCount">The number of columns in the matrix.</param>
    /// <param name="matrixMinValue">The minimum value for the randomly generated matrix elements.</param>
    /// <param name="matrixMaxValue">The maximum value for the randomly generated matrix elements.</param>
    /// <returns>The elapsed time in milliseconds.</returns>
    public static int RunSingleTest(int numberOfThreads, int matrixRowCount, int matrixColumnCount, int matrixMinValue, int matrixMaxValue)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Generates a matrix with the given number of rows and columns and fills it with random integer values within the given range. 
    /// Runs the ParallelSortMatrixRows method on each copy of the matrix using each value in the numbersOfThreads list as the number of threads.
    /// Measures the execution time for each test and returns a list of the results.
    /// </summary>
    /// <param name="numbersOfThreads">A list of integers representing the number of threads to use for each test</param>
    /// <param name="matrixRowCount">The number of rows in the matrix.</param>
    /// <param name="matrixColumnCount">The number of columns in the matrix.</param>
    /// <param name="matrixMinValue">The minimum value for the randomly generated matrix elements.</param>
    /// <param name="matrixMaxValue">The maximum value for the randomly generated matrix elements.</param>
    /// <returns>List of time measurements in milliseconds for each test.</returns>
    public static List<int> RunMultipleTests(List<int> numbersOfThreads, int matrixRowCount, int matrixColumnCount, int matrixMinValue, int matrixMaxValue)
    {
        throw new NotImplementedException();
    }
}