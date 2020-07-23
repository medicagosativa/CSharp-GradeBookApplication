using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
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
                case var _ when SortedList[Convert.ToInt32(Students.Count * 0.2)].AverageGrade < averageGrade:
                    return 'A';
                case var _ when SortedList[Convert.ToInt32(Students.Count * 0.2) * 2].AverageGrade < averageGrade:
                    return 'B';
                case var _ when SortedList[Convert.ToInt32(Students.Count * 0.2) * 3].AverageGrade < averageGrade:
                    return 'C';
                case var _ when SortedList[Convert.ToInt32(Students.Count * 0.2) * 4].AverageGrade < averageGrade:
                    return 'D'; 
                default:
                    return 'F';
            }
        }
    }
}
