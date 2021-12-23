using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook{

    public class NamedObject{
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
        public NamedObject(string name){
            this.Name = name;
        }
    }

    public interface IBook {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook {
        public Book(string name) : base(name) {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }

    public delegate void GradeAddedDelegate(object sender, EventArgs args); // a double works here as the args as well,
    // I think EventArgs is mean to be a superclass of custom classes that will contain data to be emitted, or used simply to represent events without values

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if(grade < 0)
                throw new ArgumentException($"Bad grade: '{grade}'");
            // since the stream implements IDisposable, GC will clean up for us
            using( StreamWriter file = new($"./{Name}.gradebook", append: true)){
              file.WriteLine(grade);
            }
            if(GradeAdded != null)
              GradeAdded(this, new EventArgs());
        }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();
            using(StreamReader file = new($"./{Name}.gradebook")){
                while(true){
                    var line = file.ReadLine();
                    if(line == null)
                      break;
                    var value = double.Parse(line);
                    stats.AddGrade(value);
                }
            }
            return stats;
        }
    }

    public class MemoryBook : Book {
        private List<double> grades;
        readonly string subject; // readonly can only be set in constructor, nowhere else
        public const string CAN_NEVER_BE_CHANGED = "xyz";
        public override event GradeAddedDelegate GradeAdded; // event ensures you can only use += or -=, no reassignment, because it may affect others listening

        public MemoryBook(string name) : base(name) {
            this.grades = new List<double>();
            this.subject = "CS";
            this.subject = "CSX";
        }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();
            foreach(var grade in grades){
                stats.AddGrade(grade);
            }
            return stats;
        }

        public override void AddGrade(double grade){
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