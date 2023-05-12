namespace MultithreadingBenchmark.FindPrimes;

public static class Primes
{
    /// <summary>
    /// Checks if the given number is a prime number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if the number is prime, false otherwise.</returns>
    /// <exception cref="ArgumentException">Thrown when the number is less than 2.</exception>
    public static bool IsPrime(int number)
    {
        #region InputValidation

        if (number < 2)
        {
            throw new ArgumentException("The number must be greater than 1");
        }

        #endregion

        if (number == 2)
            return true;
        
        if (number % 2 == 0) 
            return false;

        for (var i = 3; i <= (int)Math.Sqrt(number); i += 2)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Finds all prime numbers in the given range in parallel using multiple threads.
    /// </summary>
    /// <param name="numberOfThreads">The number of threads to use for the parallel search.</param>
    /// <param name="startRange">The lower bound of the range to search for prime numbers.</param>
    /// <param name="endRange">The upper bound of the range to search for prime numbers.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the number of threads is less than or equal to 0 or the start range is less than 2</exception>
    /// <exception cref="ArgumentException">Thrown when the endRange is lower than startRange</exception>
    public static void ParallelFindPrimes(int numberOfThreads, int startRange, int endRange)
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

        var tasks = new List<Task>();
        var partSize = (int)Math.Ceiling((endRange - startRange + 1) / (double)numberOfThreads);

        for (var i = 0; i < numberOfThreads; i++)
        {
            var i1 = i;
            tasks.Add(Task.Run(() =>
            {
                for (var j = startRange + i1 * partSize; j < startRange + (i1 + 1) * partSize; j++)
                {
                    if (j <= endRange)
                        IsPrime(j);
                }
            }));
        }
        
        Task.WaitAll(tasks.ToArray());
    }
}