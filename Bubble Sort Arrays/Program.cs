using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;

Console.WriteLine("Input your  numbers separated by commas \n");
string arrayInput = Console.ReadLine();

int[] array = arrayInput.Split(',').Select(int.Parse).ToArray();

Console.WriteLine("Enter start index of your array:\n");
int startIndex = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter end index of your array:\n");
int endIndex = Convert.ToInt32(Console.ReadLine());

Range range = startIndex..endIndex;

int[] subArray = array[range];

Console.WriteLine("Sub-array to be sorted:\n");
foreach (int num in subArray)
{
    Console.WriteLine($":{num}");
} 


void bubbleSortArrays(int[] array, Range range)
{  
    for(int i = startIndex; i < endIndex-1; i++)
    {
        for (int j = startIndex; j < (endIndex-1)- (i-startIndex); j++)
        {
            if (array[j] > array[j+1])
            {
                int temp = array[j];
                array[j] = array[j+1];
                array[j+1] = temp;    

            }
        }
    }

}

bubbleSortArrays(array, range);

Console.WriteLine("Sorted Arrays");

foreach(int score in array)
{
    Console.WriteLine($"Sorted: {score}");
}
