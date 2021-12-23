using System;

namespace GradeBook {
    public class Statistics{
        public double Average {
            get {
                return sum / count;
            }
        }
        public double High;
        public double Low;
        private double sum;
        private int count;

        public Statistics(){
            High = double.MinValue;
            Low = double.MaxValue;
            count = 0;
            sum = 0;
        }
        public void AddGrade(double grade){
            High = Math.Max(High, grade);
            Low = Math.Min(Low, grade);
            sum += grade;
            count += 1;
        }
    }
}