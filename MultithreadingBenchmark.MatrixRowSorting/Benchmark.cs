using System.Diagnostics;

namespace MultithreadingBenchmark.MatrixRowSorting;

public static class Benchmark
{
    /// <summary>
    /// Generates a matrix with the specified row and column count and fills it with random integers between `matrixMinValue` and `matrixMaxValue`.
    /// Sorts the rows of the matrix on 'numberOfThreads' threads using the specified algorithm and measures the elapsed time in milliseconds.
    /// </summary>
    /// <param name="numberOfThreads">The number of threads to use for sorting the matrix.</param>
    /// <param name="matrixRowCount">The number of rows in the matrix.</param>
    /// <param name="matrixColumnCount">The number of columns in the matrix.</param>
    /// <param name="matrixMinValue">The minimum value for the randomly generated matrix elements.</param>
    /// <param name="matrixMaxValue">The maximum value for the randomly generated matrix elements.</param>
    /// <param name="algorithm">The algorithm to use for sorting the matrix rows.</param>
    /// <returns>The elapsed time in milliseconds.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when numberOfThreads is less than 1 or greater than matrixRowCount.</exception>
    /// <exception cref="ArgumentException">Thrown when matrixColumnCount is less than or equal to 0 or when matrixMinValue is greater than matrixMaxValue.</exception>
    public static long RunSingleTest(int numberOfThreads, int matrixRowCount, int matrixColumnCount, int matrixMinValue, int matrixMaxValue, SortingAlgorithmEnum algorithm)
    {
        #region ImputValidation

        if (numberOfThreads < 1 || numberOfThreads > matrixRowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfThreads), "The number of threads must be between 1 and the number of matrix rows.");
        }

        if (matrixColumnCount <= 0)
        {
            throw new ArgumentException("The matrix column count must be positive.");
        }
        
        if (matrixMinValue > matrixMaxValue)
        {
            throw new ArgumentException("The minimum value cannot be greater than the maximum value.");
        }

        #endregion

        var stopwatch = new Stopwatch();
        var matrix = Matrix.GenerateIntegerMatrix(matrixRowCount, matrixColumnCount, matrixMinValue, matrixMaxValue);

        stopwatch.Start();
        MatrixRowSorting.ParallelSortMatrixRows(matrix, numberOfThreads, algorithm);
        stopwatch.Stop();
        
        return stopwatch.ElapsedMilliseconds;
    }

    /// <summary>
    /// Generates a matrix with the specified row and column count and fills it with random integers between `matrixMinValue` and `matrixMaxValue`.
    /// Sorts the rows of the each copy of the matrix with the specified sorting algorithm using each value in the numbersOfThreads list as the number of threads.
    /// Measures the execution time for each test and returns a list of the results.
    /// </summary>
    /// <param name="numbersOfThreads">A list of integers representing the number of threads to use for each test</param>
    /// <param name="matrixRowCount">The number of rows in the matrix.</param>
    /// <param name="matrixColumnCount">The number of columns in the matrix.</param>
    /// <param name="matrixMinValue">The minimum value for the randomly generated matrix elements.</param>
    /// <param name="matrixMaxValue">The maximum value for the randomly generated matrix elements.</param>
    /// <param name="algorithm">The algorithm to use for sorting the matrix rows.</param>
    /// <returns>List of time measurements in milliseconds for each test.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the list of thread numbers is null.</exception>
    ///  <exception cref="ArgumentException">Thrown when the list of thread numbers is empty or when the matrix column count is not positive or when the minimum value is greater than the maximum value.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when any of the numbers of threads is less than 1 or greater than the number of matrix rows.</exception>
    public static List<long> RunMultipleTests(List<int> numbersOfThreads, int matrixRowCount, int matrixColumnCount, int matrixMinValue, int matrixMaxValue, SortingAlgorithmEnum algorithm)
    {
        #region InputValidation

        if (numbersOfThreads == null)
        {
            throw new ArgumentNullException(nameof(numbersOfThreads));
        }
        
        if (numbersOfThreads.Count == 0)
        {
            throw new ArgumentException("The list of thread numbers must contain at least one element.");
        }
        
        foreach (var numberOfThreads in numbersOfThreads)
        {
            if (numberOfThreads < 1 || numberOfThreads > matrixRowCount)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfThreads), "The number of threads must be between 1 and the number of matrix rows.");
            }
        }

        if (matrixColumnCount <= 0)
        {
            throw new ArgumentException("The matrix column count must be positive.");
        }
        
        if (matrixMinValue > matrixMaxValue)
        {
            throw new ArgumentException("The minimum value cannot be greater than the maximum value.");
        }

        #endregion
        
        var stopwatch = new Stopwatch();
        var results = new List<long>();
        var matrix = Matrix.GenerateIntegerMatrix(matrixRowCount, matrixColumnCount, matrixMinValue, matrixMaxValue);

        foreach (var numberOfThreads in numbersOfThreads)
        {
            var copyOfMatrix = Matrix.DeepCopyMatrix(matrix);
            
            stopwatch.Start();
            MatrixRowSorting.ParallelSortMatrixRows(copyOfMatrix, numberOfThreads, algorithm);
            stopwatch.Stop();
            
            results.Add(stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        
        return results;
    }
}