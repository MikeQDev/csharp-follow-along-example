using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("My grade book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            Console.WriteLine(book);
            var stats = book.GetStatistics();
            Console.WriteLine($"Stats -> Low: {stats.Low}, High: {stats.High}, Avg: {stats.Average}");
        }
    }
}