using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Chapter3Ex
{
    public class Program
    { 
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
            Program program = new Program();    
            Timing timing = new Timing();

            //BubbleSort
            timing.Start();
            List<string> Data1 = GenerateRandomStrings(20000);

            string filepath1 = "stringData1.txt";

            WritingStringsToFile(Data1, filepath1);

            Console.WriteLine($"Data file created successfully: {Path.GetFullPath(filepath1)}");

            List<string> readStrings1 = ReadingStringsFromFile(filepath1);

            //Display Original Data
           // Console.WriteLine("Original Data");
          //  DisplayData(readStrings);

            
           
            program.BubbleSort(readStrings1);

            //Display Sorted Data
            Console.WriteLine("\nSorted Data");
            // DisplayData(readStrings);
            timing.Stop();
            Console.WriteLine($" BubbleSort Process Time in Milliseconds: {timing.Result().Milliseconds}");


            //SelectionSort
            timing.Start();
            List<string> Data2 = GenerateRandomStrings(20000);

            string filepath2 = "stringData2.txt";

            WritingStringsToFile(Data2, filepath2);

            Console.WriteLine($"Data file created successfully: {Path.GetFullPath(filepath2)}");

            List<string> readStrings2 = ReadingStringsFromFile(filepath2);
            

          
            program.SelectionSort(readStrings2);

            //Display Sorted Data
           // Console.WriteLine("\nSorted Data");
           // DisplayData(readStrings);
            timing.Stop();
            Console.WriteLine($" SelectionSort Process Time in Milliseconds: {timing.Result().Milliseconds}");

            //InsertionSort
            timing.Start();
            List<string> Data3= GenerateRandomStrings(20000);

            string filepath3 = "stringData3.txt";

            WritingStringsToFile(Data3, filepath3);

            Console.WriteLine($"Data file created successfully: {Path.GetFullPath(filepath3)}");

            List<string> readStrings3 = ReadingStringsFromFile(filepath3);
       
            
            program.InsertionSort(readStrings3);

            //Display Sorted Data
            Console.WriteLine("\nSorted Data");
            // DisplayData(readStrings);
            timing.Stop();
            Console.WriteLine($" InsertionSort Process Time in Milliseconds: {timing.Result().Milliseconds}");


        }
        static List<string> GenerateRandomStrings(int count)
        {
            List<string> strings = new List<string>();
            Random random = new Random();
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < count; i++)
            {
                int stringLength = random.Next(8, 16);
                char[] randomstring = new char[stringLength];

                for (int j = 0; j < stringLength; j++)
                {
                    randomstring[j] = Chars[random.Next(Chars.Length)];
                }
                strings.Add(new string(randomstring));
            }
            return strings;
        }

        static void WritingStringsToFile(List<string> Data, string Filepath)
        {
            using (StreamWriter writer = new StreamWriter(Filepath))
            {
                try
                {
                    foreach (string value in Data)
                    {
                        writer.WriteLine(value);
                    }

                }
                catch (Exception ex) { 
                    Console.WriteLine($"Error Message: {ex.Message}");
                }
            }
        }

        static List<string> ReadingStringsFromFile(string Filepath)
        {
            List<string> data = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(Filepath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                            data.Add(line);
                     
                    }

                }

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return data;
        }

        public void BubbleSort(List<string> Data)
        {
            int n = Data.Count;
            string tempValue;

            for (int i = 0; i < n-1; i++) {
                for (int j = 0; j <n-i-1; j++) {
                    if (String.Compare(Data[j], Data[j+1]) > 0 )
                    {
                        tempValue = Data[j];
                        Data[j] = Data[j+1];
                        Data[j+1] = tempValue;
                    }
               }
            }

        }

        public void SelectionSort(List<string> Data) { 
         
            int n = Data.Count;
            string tempValue;

            for (int i = 0; i < n - 1; i++) {
               
                int minIndex = i;

                for (int j = i+1; j < n ; j++) {

                    if (String.Compare(Data[j], Data[minIndex]) < 0)
                    {
                        minIndex = j;
                    }

                    if (minIndex != i)
                    {
                        tempValue = Data[minIndex];
                        Data[minIndex] = Data[i];
                        Data[i] = tempValue;
                    }
                }
            }
        }

        public void InsertionSort(List<string> Data) {

            int n = Data.Count;

            for (int i = 1; i < n - 1; i++)
            {
                string tempValue = Data[i];

                int j = i - 1;

                while (j >= 0 && String.Compare(tempValue, Data[j]) < 0)
                {
                    Data[j + 1] = Data[j];
                    j--;
                }
                Data[j + 1] = tempValue;
            }
        }

        static void DisplayData(List<string> data)
        {
            foreach(string value in data)
            {
                Console.WriteLine(value +" ");
            } 
            Console.WriteLine();
        }
    }
}