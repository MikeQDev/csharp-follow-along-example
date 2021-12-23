using System;
using System.Collections.Generic;

namespace GradeBook{
    public class Book {
        private List<double> grades;
        public string Name;
        public Book(string name){
            this.grades = new List<double>();
            this.Name = name;
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            foreach(var grade in grades){
                result.Low = Math.Min(result.Low, grade);
                result.High = Math.Max(result.High, grade);
                result.Average += grade;
            }

            result.Average /= this.grades.Count;
            return result;
        }

        public void AddGrade(double grade){
            if(grade < 0)
                throw new ArgumentException($"Bad grade: '{grade}'");
            this.grades.Add(grade);
        }

        public override string ToString(){
            return $"{Name}'s GradeBook holds {grades.Count} grades.";
        }
    }
}