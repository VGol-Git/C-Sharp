using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Uni
{

    enum Education { Specialist, Bachelor, SecondEducation}

    class Student : Person, IEnumerable, IDateAndCopy
    {



        private Education education;
        private int groupNumber;
        // private Exam[] passedExams;

        private List<Exam> examsList = new List<Exam>();
        public List<Exam> ExamsList { get => examsList; set => examsList = value; }

        

        private List<Test> testsList = new List<Test>();
        public List<Test> TestsList { get => testsList; set => testsList = value; }

        //private ArrayList examsList;
        //private ArrayList testsList;
        //public ArrayList ExamsList { get => examsList; set => examsList = value; }
        //public ArrayList TestsList { get => testsList; set => testsList = value; }
                             
        public Person Person { get => new Person(this.name, this.name, this.date_of_birth); set {this.name = value.Name; this.surname= value.Surname; this.date_of_birth= value.Date_of_birth; } }
        public Education Education { get => education; set => education = value; }
        public int GroupNumber {
            get { return groupNumber; }
            set
            {
                if ((value > 100) && (value <= 599))
                    groupNumber = value;
                else
                    throw new ArgumentOutOfRangeException("Значение должно быть в диапазоне от 101 до 599!");
            }
        }
        //public Exam[] Exams { get => passedExams; set => passedExams = value; }

        public Student(Person person, Education education, int groupNumber)
        {
            this.name = person.Name;
            this.surname = person.Surname;
            this.date_of_birth = person.Date_of_birth;
            this.education = education;
            this.groupNumber = groupNumber;
            this.examsList = new List<Exam>();
            this.testsList = new List<Test>();
        }

        public Student()
        {
            name = "Noname";
            surname = "Nosurname";
            date_of_birth = new DateTime(1, 1, 1);
            this.education = Education.Specialist;
            this.groupNumber = 0;
            this.examsList = new List<Exam>();
            this.testsList = new List<Test>();
        }

        public double averageGrade //
        {
            get
            {
                int sumGrade = 0;
                foreach (Exam exam in examsList)
                    sumGrade += exam.Grade;

                if (sumGrade == 0)
                    return 0;

                return sumGrade / examsList.Count;
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
            foreach (Exam exam in newExams)
                examsList.Add(exam);
        }

        public void AddTests(params Test[] newTest)
        {
            foreach (Test test in newTest)
                testsList.Add(test);
        }

        public override string ToString()
        {
            string str = Person.ToString() + ' ' + education.ToString() + ' ' + groupNumber + ' ';
            foreach (Exam exam in examsList)
                str += (exam.ToString() + ' ');

            return str;
        }

        public virtual string ToShortString()
        {
            return Person.ToString() + ' ' + education.ToString() + ' ' + groupNumber + ' ' + averageGrade;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Student return false.
            Student p = obj as Student;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (obj is Student student)
            {

                return (Person.Equals(student.Person)) && (Education == student.Education) && (groupNumber == student.groupNumber) && (examsList.Equals(student.ExamsList)&& (testsList.Equals(student.testsList)));
            }
            else
                return false;

         
        }

        public static bool operator ==(Student a, object b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Student a, object b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return Person.GetHashCode() + Education.GetHashCode() + groupNumber.GetHashCode() + examsList.GetHashCode() + testsList.GetHashCode();
        }

        public override object DeepCopy()
        {
            Student obj = new Student(this.Person, this.Education, this.GroupNumber);

            foreach (Exam exam in this.examsList)
                obj.examsList.Add(exam);

            foreach (Test test in this.testsList)
                obj.testsList.Add(test);
            return obj;
        }
        public DateTime Date { get; set ; }


        //Итераторы
        public System.Collections.IEnumerable GetTestAndExam()
        {
            
            foreach (var item in this.testsList)
            {
                yield return item;
            }
            foreach (var item in this.examsList)
            {
                yield return item;
            }

        }


        public System.Collections.IEnumerable GetExamGrade(int grade)
        {
            foreach (Exam item in this.examsList)
            {
                if (item.Grade> grade)
                    yield return item;
            }
        }

        public System.Collections.IEnumerable GetExamAndTestDone()
        {
            foreach (var item in this.examsList)
            {
                if (((Exam)item).Grade > 2)
                    yield return item;
            }

            foreach (var item in this.testsList)
            {
                if (((Test)item).PassedTest == true)
                yield return item;
            }
        }


        public System.Collections.IEnumerable GetTestWhereExamDone()
        {
            foreach (var test in this.testsList)
            {
                if (((Test)test).PassedTest == true)
                    foreach (var exam in this.GetExamGrade(2))
                    {
                        if (((Test)test).Subject == ((Exam)exam).Subject)
                            yield return test;
                    }
            }
        }


        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(examsList, testsList);
        }

        public void sortBySubject()
        {
            examsList.Sort();
        }

        public void sortByGrade()
        {
            IComparer<Exam> cmpr = new Exam();
            examsList.Sort(cmpr);
        }

        public void sortByDate()
        {
            //ListArticle.Sort();
            IComparer<Exam> cmpr = new ExamDateComparer();
            examsList.Sort(cmpr);
        }

    }
}
