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
    public static List<List<int>> GenerateIntegerMatrix(int rowCount, int columnCount, int minValue, int maxValue)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a deep copy of a matrix
    /// </summary>
    /// <param name="oldMatrix">The matrix to copy.</param>
    /// <typeparam name="T">The type of the matrix elements.</typeparam>
    /// <returns>A new matrix that is a deep copy of the original matrix.</returns>
    public static List<List<T>> DeepCopyMatrix<T>(List<List<T>> oldMatrix)
    {
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
    public static List<List<List<T>>> SplitMatrix<T>(List<List<T>> matrix, int numberOfParts)
    {
        throw new NotImplementedException();
    }
}