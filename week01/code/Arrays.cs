public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Create a new array of size 'length' to store the multiples.
        // 2. Use a for loop to iterate from 0 up to length-1.
        // 3. On each iteration, calculate the multiple: (i + 1) * number.
        // 4. Store the multiple in the array at index i.
        // 5. After the loop, return the array.

        // Create multiples list
        double[] multiples = new double[length];

        // Iterate and calculate the multiple on each
        for (int i = 0; i < length; i++)
        {
            multiples[i] = (i + 1) * number;
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Determine the starting index of the rotation. This will be data.Count - amount.
        // 2. Use GetRange to slice the last 'amount' elements.
        // 3. Remove those last 'amount' elements from the original list.
        // 4. Insert the sliced elements at the start of the list using InsertRange.
        // 5. The list is now rotated to the right.

        int startIndex = data.Count - amount;

        // Slice last 'amount' elements
        List<int> slice = data.GetRange(startIndex, amount);

        // Remove from original list
        data.RemoveRange(startIndex, amount);

        // Insert at beginning
        data.InsertRange(0, slice);
    }
}
