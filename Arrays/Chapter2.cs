using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_2
{
    public class Timing
    {
        TimeSpan startingTime;
        TimeSpan Duration;

        public Timing()
        {
            startingTime = new TimeSpan(0);
            Duration = new TimeSpan(0);
        }
        public void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            startingTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime; }
        public void Stop()
        {
            Duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startingTime);
        }

        public TimeSpan Result()
        { return Duration; }
    }
        class Chapter2
        {
            static void Main(string[] args)
            {
                Timing timing = new Timing();
                timing.Start();
            Console.WriteLine();
            Console.WriteLine("Input the students grade for each unit and separate units using a semi-colon(;) and grades using comma(,)");
                string? gradesInput = Console.ReadLine();

                int[][] grades = (int[][])gradesInput.Split(';').Select(row => row.Split(',').Select(int.Parse).ToArray()).ToArray();

                Engineering civil = new Engineering(grades);

                timing.Stop();
            Console.WriteLine();
            Console.WriteLine($"Processing Duration: {timing.Result().TotalMilliseconds}");
            }

        }

        public class Engineering
        {
            string course = "Civil Engineering";

            public int[][] Grades { get; private set; }

            public Engineering(int[][] grades)
            {
                Grades = grades;

                double average = gradeAverage(grades);
            }


            public double gradeAverage(int[][] grades)
            {
                for (int unit = 0; unit < grades.Length; unit++)
                {
                    int total = 0;
                    for (int students = 0; students < grades[unit].Length; students++)
                    {
                        total += grades[unit][students];

                    }
                    double average = (double)total / grades[unit].Length;
                Console.WriteLine($"{course.ToUpper()}\n");
                Console.WriteLine($"unit{unit + 1} : Total {total}");
                Console.WriteLine();
                Console.WriteLine($"unit {unit + 1} : Average{average}");

                    highScores(grades[unit], average);
                    lowScores(grades[unit], average);
                }
                return 0;
            }

            public void highScores(int[] Grades, double average)
            {


                Console.WriteLine("HighScores");
                foreach (var grade in Grades)
                {
                    if (grade > average)
                {
                    Console.WriteLine();
                        Console.WriteLine($"{grade}");
                    }
                }
            }

            public void lowScores(int[] Grades, double average)
            {

                Console.WriteLine("LowScores");
                foreach (var grade in Grades)
                {
                    if (grade < average)
                    {
                    Console.WriteLine();
                    Console.WriteLine($"{grade}");
                    }
                }
            }

        }
    }

