using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
            IsWeighted = isWeighted;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count <5)
            {
                throw new InvalidOperationException("Ranked GradeBook needs more than 5 students");
            }

            List<Student> SortedList = Students.OrderByDescending(o => o.AverageGrade).ToList();
            
            foreach(var l in SortedList)
            {
                Console.WriteLine(l.AverageGrade);
            }

            switch(averageGrade)
            {
                case var _ when SortedList[Convert.ToInt32(Math.Round(Students.Count * 0.2))].AverageGrade < averageGrade:
                    return 'A';
                case var _ when SortedList[Convert.ToInt32(Math.Round(Students.Count * 0.4))].AverageGrade < averageGrade:
                    return 'B';
                case var _ when SortedList[Convert.ToInt32(Math.Round(Students.Count * 0.6))].AverageGrade < averageGrade:
                    return 'C';
                case var _ when SortedList[Convert.ToInt32(Math.Round(Students.Count * 0.8))].AverageGrade < averageGrade:
                    return 'D'; 
                default:
                    return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }            
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
            
        }
    }
}
