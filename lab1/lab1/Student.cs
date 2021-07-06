using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{

    enum Education { Specialist, Bachelor, SecondEducation}

    class Student
    {
        private Person person;
        private Education education;
        private int groupNumber;
        private Exam[] passedExams;

        public Person Person { get => person; set => person = value; }
        public Education Education { get => education; set => education = value; }
        public int GroupNumber { get => groupNumber; set => groupNumber = value; }
        public Exam[] Exams { get => passedExams; set => passedExams = value; }

        public Student(Person person, Education education, int groupNumber , Exam[] passedExams)
        {
            this.person = person;
            this.education = education;
            this.groupNumber = groupNumber;
            this.passedExams = passedExams;
        }

        public Student()
        {
            this.person = new Person();
            this.education = Education.Specialist;
            this.groupNumber = 0;
            passedExams = new Exam[0];
        }

        public double averageGrade //
        {
            get
            {
                int sumGrade = 0;
                foreach (Exam exam in passedExams)
                    sumGrade += exam.Grade;

                if (sumGrade == 0)
                    return 0;

                return sumGrade / passedExams.Length;
            }
        }


        public bool this[Education index]
        {
            get
            {
                return education == index;
            }
        }



        public void AddExams(params Exam[] newExams)
        {
            int numberExams = passedExams.Length;
            Array.Resize<Exam>(ref passedExams, numberExams + newExams.Length);
            for (int i = 0; i < newExams.Length; i++)
                passedExams[numberExams + i] = newExams[i];
        }



        public override string ToString()
        {
            string str = person.ToString() + ' ' + education.ToString() + ' ' + groupNumber + ' ';
            foreach (Exam exam in passedExams)
                str += (exam.ToString() + ' ');

            return str;
        }

        public virtual string ToShortString()
        {
            return person.ToString() + ' ' + education.ToString() + ' ' + groupNumber + ' ' + averageGrade;
        }
    }
}
