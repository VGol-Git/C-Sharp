using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    class ExamDateComparer : IComparer<Exam>
    {
        public int Compare(Exam x, Exam y)
        {
            return (x.DateExam > y.DateExam) ? 1 : (x.DateExam < y.DateExam) ? -1 : 0;
        }
    }
}
