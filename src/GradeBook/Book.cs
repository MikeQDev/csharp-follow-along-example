using System;
using System.Collections.Generic;

namespace GradeBook{
    public class Book {
        private List<double> grades;
        private string name;
        public Book(string name){
            this.grades = new List<double>();
            this.name = name;
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
            this.grades.Add(grade);
        }

        public override string ToString(){
            return $"{name}'s GradeBook holds {grades.Count} grades.";
        }
    }
}