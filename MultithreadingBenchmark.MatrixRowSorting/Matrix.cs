namespace MultithreadingBenchmark.MatrixRowSorting;

internal static class Matrix
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
        #region InputValidation

        if (rowCount <= 0 || columnCount <= 0)
        {
            throw new ArgumentException("Row and column count must be greater than zero.");
        }

        if (minValue > maxValue)
        {
            throw new ArgumentException("The minimum value cannot be greater than the maximum value.");
        }

        #endregion

        var matrix = new List<List<int>>();
        var random = new Random();

        for (var i = 0; i < rowCount; i++)
        {
            var line = new List<int>();
            for (var j = 0; j < columnCount; j++)
            {
                line.Add(random.Next(minValue, maxValue));
            }
            matrix.Add(line);
        }
        
        return matrix;
    }

    /// <summary>
    /// Creates a deep copy of a matrix
    /// </summary>
    /// <param name="oldMatrix">The matrix to copy.</param>
    /// <typeparam name="T">The type of the matrix elements.</typeparam>
    /// <returns>A new matrix that is a deep copy of the original matrix.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input matrix is null.</exception>
    /// <remarks>The function does not copy the contents of each element in each row of the matrix if they are variables of reference type.</remarks>
    public static List<List<T>> DeepCopyMatrix<T>(List<List<T>> oldMatrix)
    {
        #region InputValidation

        if (oldMatrix == null)
        {
            throw new ArgumentNullException(nameof(oldMatrix));
        }

        #endregion

        return oldMatrix.Select(row => row.ToList()).ToList();
    }

    /// <summary>
    /// Split a list into a given number of equal or as close to equal parts as possible.
    /// If the number of elements in the list is not divisible by the number of parts, the parts will have a size
    /// as close to equal as possible.
    /// </summary>
    /// <param name="inputList">The list to split into parts.</param>
    /// <param name="numberOfParts">The number of parts to split the list into.</param>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <returns>A list of sub-matrices, each representing a part of the original matrix.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input list is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the number of parts is less than 1 or greater than the number of elements in the list.</exception>
    /// <remarks>The function does not copy the contents of each element in the 'inputList' if they are variables of reference type.</remarks>

    public static List<List<T>> SplitList<T>(List<T> inputList, int numberOfParts)
    {
        #region InputValidation
        
        if (inputList == null)
        {
            throw new ArgumentNullException(nameof(inputList));
        }

        if (numberOfParts < 1 || numberOfParts > inputList.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfParts), "Number of parts must be between 1 and the number of elements in the list.");
        }
        
        #endregion
        
        var chunkedList = new List<List<T>>();
        var maxChunkSize = (int)Math.Ceiling((double)inputList.Count / numberOfParts);
        var minChunkSize = (int)Math.Floor((double)inputList.Count / numberOfParts);

        for (var i = 0; i < inputList.Count; i += maxChunkSize)
        {
            var elementsLeft = inputList.Count - chunkedList.Count * maxChunkSize;
            if (elementsLeft % minChunkSize == 0 && elementsLeft / minChunkSize == numberOfParts - chunkedList.Count)
            {
                maxChunkSize = minChunkSize;
            }
            
            var newChunk = new List<T>();
            for (var j = 0; j < maxChunkSize; j++)
            {
                newChunk.Add(inputList[i + j]);
            }
            chunkedList.Add(newChunk);
        }
        
        return chunkedList;
    }
}