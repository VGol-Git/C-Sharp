using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uni
{
    [Serializable]
    public class Exam : IDateAndCopy, IComparable, IComparer<Exam>
    {

        public string Subject { get; set; }
        public int Grade { get; set; }
        public DateTime DateExam { get; set; }

        public Exam(String subject, int assessment, DateTime dateExam)
        {
            this.Subject = subject;
            this.Grade = assessment;
            this.DateExam = dateExam;
        }

        public Exam()
        {
            this.Subject = "NoSubject";
            this.Grade = 0;
            this.DateExam.AddDays(0);
            this.DateExam.AddMonths(0);
            this.DateExam.AddYears(0);
        }

        public override string ToString() => Subject + ' ' + Grade + ' ' + DateExam;

        public object DeepCopy()
        {
            throw new NotImplementedException();
        }


        public override bool Equals(System.Object obj)
        {
            if (obj is Exam exam)
                return (Subject== exam.Subject) && (Grade== exam.Grade) && (DateExam== exam.DateExam);
            else
                return false;
        }

        public static bool operator ==(Exam a, object b)
        {
            return a.Equals(b);
        }


        public static bool operator !=(Exam a, object b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Subject.GetHashCode() + Grade.GetHashCode() + DateExam.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            Exam p = obj as Exam;
            if (p != null)
                return this.Subject.CompareTo(p.Subject);
            else
                throw new ArgumentException("Невозможно сравнить два объекта");
        }

        public int Compare(Exam x, Exam y)
        {
            return (x.Grade >= y.Grade) ? 1 : -1;
        }

        public DateTime Date { get ; set ; }



    }

}