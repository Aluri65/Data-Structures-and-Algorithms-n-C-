int[] array = { 9, -1, 8, 0, -2, 7, 3, 1, -4, 5, -3 };
Range range =..11;

void InsertionSort(int[] array, Range range)
{
    //The range.Start.GetOffset(array.Length) and range.End.GetOffset(array.Length) are used to properly calculate the starting and ending indices from the Range object, especially if you decide to change the range dynamically.
   
    int start = range.Start.GetOffset(array.Length);
    int end = range.End.GetOffset(array.Length);

    int first = start+1;
    int last = end ;

    //The outer loop starts from start + 1 to the end, and the inner loop decrements j to find the correct insertion point.

    for (int i = first; i < end; i++)
    {
        int tempValue = array[i];

     //The inner loop shifts elements to the right to make space for the tempValue to be inserted in the correct position.
        int j = i - 1;

        while (j >= start && array[j] > tempValue)
        {
            array[j+1] = array[j];
            j--;
        }
        array[j+1] = tempValue;

    }
}
   
InsertionSort(array, range);

    foreach (int sort in array)
    {
        Console.WriteLine($"Sorted: {sort}");
    }
