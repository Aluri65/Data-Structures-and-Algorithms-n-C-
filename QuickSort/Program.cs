using System;
{ 
int[] array = { 916, 16, 816, 116, 716, 216, 616, 316, 516, 416 };

Range range = ..10;

    // Call QuickSort
    quickSort(array, range.Start.GetOffset(array.Length), range.End.GetOffset(array.Length) - 1);

    // Display the sorted array
    Console.WriteLine("Sorted array:");
    foreach (int num in array)
    {
        Console.WriteLine(num);
    }

    int partitionSort(int[] array, int low, int high)
{
    // Select the rightmost element as pivot
    int pivot = array[high];
        Console.WriteLine($"pivot: {pivot}");
    // Index of smaller element
    int i = low - 1;

    for (int j = low; j < high; j++)
    {
        // If current element is smaller than or equal to pivot
        if(array[j] <= pivot)
        {
                Console.WriteLine($"Current Element: {array[j]}");
            i++; //increment index of smaller element

                Console.WriteLine($"Elemnt i: {i}");
            Swap(array,i,j);    
        }
        }
        // Swap the pivot element with the element at i+1 position
        Swap(array, i + 1, high);
        return i + 1;   //Return the partion index;


    }
void quickSort(int[] array, int low, int high)
    {
        if (low < high)
        {// Partition the array and get the pivot index
            int  pivotIndex = partitionSort(array, low, high);

            // Recursively apply QuickSort to subarrays

            quickSort(array,low, pivotIndex-1); //Left sub-array
            quickSort(array, pivotIndex + 1, high); //Right sub-array 
        }

    } 

void Swap(int[] array, int a, int b)
    {
        int tempValue = array[a];
        array[a] = array[b];
        array[b] = tempValue;
    }
}