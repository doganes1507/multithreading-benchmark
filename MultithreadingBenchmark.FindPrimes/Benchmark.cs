namespace MultithreadingBenchmark.FindPrimes;

public static class Benchmark
{
    /// <summary>
    /// Runs a single test to measure the time it takes to find prime numbers in the specified range using the specified number of threads.
    /// </summary>
    /// <param name="numberOfThreads">The number of threads to use for the search.</param>
    /// <param name="startRange">The start of the range to search for prime numbers.</param>
    /// <param name="endRange">The end of the range to search for prime numbers.</param>
    /// <returns>The elapsed time in milliseconds.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the number of threads is less than or equal to 0 or the start range is less than 2.</exception>
    /// <exception cref="ArgumentException">Thrown when the endRange is less than the startRange.</exception>
    public static long RunSingleTest(int numberOfThreads, int startRange, int endRange)
    {
        #region InputValidation

        if (numberOfThreads <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfThreads), "The number of threads must be positive.");
        }

        if (startRange < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(startRange), "The start range must be greater than 1.");
        }

        if (endRange < startRange)
        {
            throw new ArgumentException("The end range must be greater than or equal to the start range.");
        }

        #endregion
        
        throw new NotImplementedException();
    }

    /// <summary>
    /// Runs multiple tests to measure the time it takes to find prime numbers in the specified range using different numbers of threads.
    /// </summary>
    /// <param name="numbersOfThreads">List of integers representing the number of threads to use for each test.</param>
    /// <param name="startRange">The start of the range to search for prime numbers.</param>
    /// <param name="endRange">The end of the range to search for prime numbers.</param>
    /// <returns>List of time measurements in milliseconds for each test.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input list of thread numbers is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the input list of thread numbers is empty or the end range is less than the start range.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when any of the input numbers of threads is less than 1, or the start range is less than 2.</exception>
    public static List<long> RunMultipleTests(List<int> numbersOfThreads, int startRange, int endRange)
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
            if (numberOfThreads < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfThreads), "The number of threads must be positive");
            }
        }
        
        if (startRange < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(startRange), "The start range must be greater than 1.");
        }

        if (endRange < startRange)
        {
            throw new ArgumentException("The end range must be greater than or equal to the start range.");
        }

        #endregion
        
        throw new NotImplementedException();
    }
}