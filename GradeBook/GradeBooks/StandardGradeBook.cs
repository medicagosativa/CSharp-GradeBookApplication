﻿using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Standard;
            IsWeighted = false;
        }

        public StandardGradeBook(string name, bool isWeighted) : base(name)
        {
            Type = GradeBookType.Standard;
            IsWeighted = isWeighted;
        }
    }
}
