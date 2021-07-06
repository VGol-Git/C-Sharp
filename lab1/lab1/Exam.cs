using System;

namespace Uni
{
    public class Exam
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

    }
}