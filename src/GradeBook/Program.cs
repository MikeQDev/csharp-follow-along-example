using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }
        private Program(){
            Book book = null;
            try{
                book = new Book("xyz");
            }catch(ArgumentException){
                Console.WriteLine("Bad book name entered; ensure 0 < name.Length <= 10 ");
                Environment.Exit(5);
            }
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            Console.WriteLine("Enter grades, separated by Enter, followed by 'Done' when complete:");
            while(true){
                var grade = Console.ReadLine();
                if(grade == "Done")
                  break;
                try{
                    book.AddGrade(double.Parse(grade));
                }catch(ArgumentException){
                    Console.WriteLine("Unacceptable grade; skipping");
                }catch(FormatException){
                    Console.WriteLine("That doesn't look like a grade; skipping");
                }
            }
            Console.WriteLine(book);
            var stats = book.GetStatistics();
            Console.WriteLine($"Stats -> Low: {stats.Low}, High: {stats.High}, Avg: {stats.Average}");
        }
        private void OnGradeAdded(object sender, EventArgs events){
            Console.WriteLine($"New grade added.");
        }
    }
}