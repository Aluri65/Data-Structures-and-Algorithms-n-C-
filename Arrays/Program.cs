using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArrays
{
    public class Program
    {
        public class CArray
        {
            private int[] array;
            private int length;

            public CArray(int size)
            {
                array = new int[size];
                length = 0;
            }
            public void Insert(int index, int value)
            {
                if((index < 0) || (index > length))
                {
                    throw new ArgumentOutOfRangeException( nameof(index), "Index out of range.");
                } 
                //Resize if full

                if(length >= array.Length)
                {
                    Resize(array.Length * 2);
                }

                //shift elements to the right to make room

                for (int i = length; i > index; i--)
                {
                    array[i] = array[i - 1];         
                }
                //Insert new value 
                array[index] = value;
                length++;
            }

            public void Delete(int index)
            { 
                if(index < 0 || index >= length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index out of bounds of array");
                }
                //Shift elements to fill the gap
                for (int i = index; i < length-1 ; i++)
                {
                    array[i] = array[i + 1];
                } 
                length--;
            }  

            public void Clear()
            {
                length = 0;
            }
            //Indexer to get or set the element at a specific index
            public int this[int index]
            {
                get
                {
                    if(index < 0 || index >= length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), "Index out of bounds of the array");
                    }
                    return array[index];
                }
                set
                {
                    if (index < 0 || index >= length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), "Index out of bounds of the array");
                    }
                    array[index] = value;
                }
            } 

            //Resize the internal Array
            private void Resize(int newSize)
            {
                int[] newArray = new int[newSize];
                for(int i = 0; i < length; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
            } 

            public void Display()
            {
                for(int i = 0; i < length; i++)
                {
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine();
            }
            public int Length
            {
                get { return length; }
            }
        }

        public class Timing
        {
            private TimeSpan startingTime;
            private TimeSpan Duration;

            public Timing()
            {
                startingTime = new TimeSpan(0);
                Duration = new TimeSpan(0);
            } 

            public void Start()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                startingTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
            }

            public void Stop()
            {
                Duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startingTime);
            } 
            public TimeSpan Result()
            {
                return Duration;
            }

        }
        static void Main(string[] args)
        {
            int numItems = 10000;
            CArray myArray = new CArray(numItems);

            Random random= new Random();
            Timing timing = new Timing();
            Program program = new Program();


           
            for (int i = 0; i < numItems; i++) {
                int randomValues = random.Next(0,1000);
                myArray.Insert(i, randomValues);
               
             
            }
            timing.Start();
            program.InsertionSort(myArray);
          //  myArray.Display(); 
            timing.Stop();
            Console.WriteLine($"Duration for InsertionSort:  {timing.Result().TotalMilliseconds}");
            myArray.Clear();

            for (int i = 0; i < numItems; i++)
            {
                int randomValues = random.Next(0, 100);
                myArray.Insert(i, randomValues);
              ;

            }
            timing.Start();
            program.BubbleSort(myArray);
           // myArray.Display();
            timing.Stop();
            Console.WriteLine($"Duration for BubbleSort:  {timing.Result().TotalMilliseconds}");
            myArray.Clear();

            for (int i = 0; i < numItems; i++)
            {
                int randomValues = random.Next(0, 100);
                myArray.Insert(i, randomValues);
           

            }
            timing.Start();
            program.SelectionSort(myArray);
            //myArray.Display();
            timing.Stop();
            Console.WriteLine($"Duration for SelectionSort:  {timing.Result().TotalMilliseconds}");
        }
        public void BubbleSort(CArray array)
        {
            for(int i = 0; i < array.Length-1; i++)
            {
                for (int j = 0; j < array.Length-i-1; j++)
                {
                    if (array[j] > array[j+1])
                    {
                        Swap(array, j, j+1);
                    } 
                }
                
            }
        } 

        public void SelectionSort(CArray array)
        {
            for(int i = 0; i< array.Length - 1; i++)
            {
                int minValue = i;

                for(int j = i+1; j < array.Length; j++)
                {
                    if(array[j] < array[minValue])
                    {
                        minValue = j;
                    }
                } 
                if(minValue != i)
                {
                    Swap(array, i, minValue);
                }
            }
        }

        public void InsertionSort(CArray array)
        {
            int start = 1;
            int end = array.Length;

         for(int i =start ; i< end; i++)
            {
                int tempValue = array[i];

                int j = i - 1;

                while(j>= 0 && array[j] > tempValue)
                {
                    array[j+1] = array[j];
                    j--;
                } 
                array[j+1] = tempValue;
            }
        }
        public void Swap(CArray array, int a, int b)
        {
            int tempValue;
                tempValue = array[a];
                array[a] = array[b];
                array[b] = tempValue;
            
        }
    } 

    }

