﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeTracker book = CreateGradeBook();

            //GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static GradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(GradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Highest Grade", stats.HighestGrade);
            WriteResult("Average Grade", stats.AverageGrade);
            WriteResult("Lowest Grade", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
            WriteResult("Grade Description", stats.Description);
        }

        private static void SaveGrades(GradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
                outputFile.Close();
            }
        }

        private static void AddGrades(GradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(GradeTracker book)
        {
            try
            {
                Console.WriteLine("Please enter a name");
                book.Name = Console.ReadLine();
            }

            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }
    }
}
