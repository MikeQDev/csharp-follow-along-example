using System;
using System.Collections.Generic;

namespace GradeBook{

    public delegate void GradeAddedDelegate(object sender, EventArgs args); // a double works here as the args as well,
    // I think EventArgs is mean to be a superclass of custom classes that will contain data to be emitted, or used simply to represent events without values
    public class Book {
        private List<double> grades;
        readonly string subject; // readonly can only be set in constructor, nowhere else
        public const string CAN_NEVER_BE_CHANGED = "xyz";
        private string name; // field
        public string Name { // property
            get {
                return name.ToUpper();
            }
            private set {
                if(value.Length > 10 || String.IsNullOrEmpty(value)){
                    throw new ArgumentException($"Name '{value}' too long or empty!");
                }
                this.name = value;
            }
        }
        public event GradeAddedDelegate GradeAdded; // event ensures you can only use += or -=, no reassignment, because it may affect others listening

        public Book(string name){
            this.grades = new List<double>();
            this.Name = name;
            this.subject = "CS";
            this.subject = "CSX";
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
            if(GradeAdded != null)
                GradeAdded(this,new EventArgs());
        }

        public override string ToString(){
            return $"{Name}'s GradeBook holds {grades.Count} grades for subject {subject}.";
        }
    }
}