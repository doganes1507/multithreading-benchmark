namespace MultithreadingBenchmark.MatrixRowSorting;

public static class Matrix
{
    /// <summary>
    /// Generates a matrix of random integers.
    /// </summary>
    /// <param name="rowCount">The number of rows in the matrix.</param>
    /// <param name="columnCount">The number of columns in the matrix.</param>
    /// <param name="minValue">The minimum value for the randomly generated matrix elements.</param>
    /// <param name="maxValue">The maximum value for the randomly generated matrix elements.</param>
    /// <returns>A matrix of integers with dimensions specified by rowCount and columnCount, where each element is a random integer between minValue and maxValue.</returns>
    /// <exception cref="ArgumentException">Thrown when rowCount or columnCount are less than or equal to 0 or when maxValue is less than minValue.</exception>
    public static List<List<int>> GenerateIntegerMatrix(int rowCount, int columnCount, int minValue, int maxValue)
    {
        if (rowCount <= 0 || columnCount <= 0)
        {
            throw new ArgumentException("Row and column count must be greater than zero.");
        }

        if (minValue > maxValue)
        {
            throw new ArgumentException("The minimum value cannot be greater than the maximum value.");
        }
        
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a deep copy of a matrix
    /// </summary>
    /// <param name="oldMatrix">The matrix to copy.</param>
    /// <typeparam name="T">The type of the matrix elements.</typeparam>
    /// <returns>A new matrix that is a deep copy of the original matrix.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input matrix is null.</exception>
    public static List<List<T>> DeepCopyMatrix<T>(List<List<T>> oldMatrix)
    {
        if (oldMatrix == null)
        {
            throw new ArgumentNullException(nameof(oldMatrix));
        }
        
        throw new NotImplementedException();
    }

    /// <summary>
    /// Split a matrix into a given number of equal or as close to equal parts as possible.
    /// If the number of rows in the matrix is not divisible by the number of parts, the parts will have a size
    /// as close to equal as possible.
    /// </summary>
    /// <param name="matrix">The matrix to split into parts.</param>
    /// <param name="numberOfParts">The number of parts to split the matrix into.</param>
    /// <typeparam name="T">The type of elements in the matrix.</typeparam>
    /// <returns>A list of sub-matrices, each representing a part of the original matrix.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input matrix is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the number of parts is less than 1 or greater than the number of rows in the matrix.</exception>
    public static List<List<List<T>>> SplitMatrix<T>(List<List<T>> matrix, int numberOfParts)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        if (numberOfParts < 1 || numberOfParts > matrix.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfParts), "Number of parts must be between 1 and the number of rows in the matrix.");
        }
        
        throw new NotImplementedException();
    }
}