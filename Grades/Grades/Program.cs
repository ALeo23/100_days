using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();

            book.NameChanged += OnNameChanged;

            book.Name = "Alex's Grade Book";

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Highest Grade", stats.HighestGrade);
            WriteResult("Average Grade", stats.AverageGrade);
            WriteResult("Lowest Grade", stats.LowestGrade);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book name changing from {args.ExistingName} to {args.NewName}.");
        }
    }
}
