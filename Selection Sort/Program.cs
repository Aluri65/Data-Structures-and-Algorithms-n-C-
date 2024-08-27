int[] array = { 99, -1, 25, 0, 7, 17, 30 };
Range range = ..7;

void selectSort(int[] array, Range range)
{
    int start = range.Start.Value;
    int end = range.End.Value;

    for (int i = start; i < end - 1; i++)
    {
        for (int j = start; j < end - 1 - (i - start); j++)
        {
            if (array[j + 1] < array[j])
            {
                int temp = array[j + 1];
                array[j + 1] = array[j];
                array[j] = temp;
            }
        }
    }
}

selectSort(array, range);

foreach(int sort in array)
{
    Console.WriteLine($"Sorted: {sort}");
}
