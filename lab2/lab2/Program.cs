using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{

    class Program
    {
        public static void Main(string[] args)
        {

            //Создать два объекта типа Person с совпадающими данными и проверить, что ссылки на объекты не равны, а объекты равны, вывести значения хэш-кодов для объектов.
            Console.WriteLine("№1");

            Person myPerson1 = new Person();
            Person myPerson2 = new Person();
            if ((object)myPerson1 == (object)myPerson2)
                Console.WriteLine("Ссылки равны. " + "\n");
            else
                Console.WriteLine("Ссылки не равны. " + "\n");

          //  myPerson1.Equals(myPerson2);

            if (myPerson1 == myPerson2)
                Console.WriteLine("Объекты равны. " + "\n");
            else
                Console.WriteLine("Объекты не равны. " + "\n");

            Console.WriteLine("Хеш-код 1: " + myPerson1.GetHashCode().ToString() + "\n");
            Console.WriteLine("Хеш-код 2: " + myPerson2.GetHashCode().ToString() + "\n");

            //Создать объект типа Student, добавить элементы в список экзаменов и зачетов, вывести данные объекта Student.
            Console.WriteLine("№2");

            Student myStudent = new Student();
            myStudent.AddExams(new Exam("Химия", 5, DateTime.Today), new Exam("История", 4, DateTime.Today));
            myStudent.AddTests(new Test("Химия", true), new Test("История", true));
            Console.WriteLine(myStudent.ToString() + " \n" + "\n");

            //Вывести значение свойства типа Person для объекта типа Student.
            Console.WriteLine("№3");
            Console.WriteLine(myStudent.Person.ToString() + " \n" + "\n");

            //С помощью метода DeepCopy() создать полную копию объекта Student. Изменить данные в исходном объекте Student и вывести копию и исходный объект, полная копия исходного объекта должна остаться без изменений.
            Console.WriteLine("№4");
            Student myStudentCopy = (Student) myStudent.DeepCopy();
            if (myStudent == myStudentCopy)
                Console.WriteLine("Объекты равны. " + "\n");
            else
                Console.WriteLine("Объекты не равны. " + "\n");

            Console.WriteLine(myStudent.ToString() + " \n" + "\n");
            Console.WriteLine(myStudentCopy.ToString() + " \n" + "\n");

            myStudent.AddExams(new Exam("Физика", 5, DateTime.Today));

            Console.WriteLine("После изменения исходного объекта: " + "\n");
            Console.WriteLine(myStudent.ToString() + " \n" + "\n");
            Console.WriteLine(myStudentCopy.ToString() + " \n" + "\n");
            if (myStudent == myStudentCopy)
                Console.WriteLine("Объекты равны. " + "\n");
            else
                Console.WriteLine("Объекты не равны. " + "\n");

            //В блоке try/catch присвоить свойству с номером группы некорректное значение, в обработчике исключения вывести сообщение, переданное через объект-исключение.
            Console.WriteLine("№5");
            try
            {
                myStudent.GroupNumber = 100;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            //С помощью оператора foreach для итератора, определенного в классе Student, вывести список всех зачетов и экзаменов.
            Console.WriteLine("№6");
            Console.WriteLine("\n" + "Список всех зачетов и экзаменов. " + "\n");
            foreach (var item in myStudent.GetTestAndExam())
            {
                Console.WriteLine(item.ToString() + "\n");
            }

            //С помощью оператора foreach для итератора с параметром, определенного в классе Student, вывести список всех экзаменов с оценкой выше 3.
            Console.WriteLine("№7");
            Console.WriteLine("\n" + "Список всех экзаменов с оценкой выше указанной. " + "\n");
            foreach (var item in myStudent.GetExamGrade(3))
            {
                Console.WriteLine(item.ToString() + "\n");
            }


            //С помощью оператора foreach для объекта типа Student вывести список предметов, которые есть как в списке зачетов, так и в списке экзаменов.
            Console.WriteLine("№8");
            Console.WriteLine("\n" + "Список предметов, которые есть как в списке зачетов, так и в списке экзаменов. " + "\n");
            foreach (var exam in myStudent)
            {
                Console.WriteLine(((Exam)exam).Subject);
            }



            //С помощью оператора foreach для итератора, определенного в классе Student, вывести список всех сданных зачетов и сданных экзаменов.
            Console.WriteLine("№9");
            Console.WriteLine("\n" + "Список всех сданных зачетов и сданных экзаменов. " + "\n");
            foreach (var item in myStudent.GetExamAndTestDone())
            {
                Console.WriteLine(item.ToString() + "\n");
            }


            //С помощью оператора foreach для итератора, определенного в классе Student, вывести список сданных зачетов, для которых сдан и экзамен.
            Console.WriteLine("№10");
            Console.WriteLine("\n" + "Список сданных зачетов, для которых сдан и экзамен. " + "\n");
            foreach (var item in myStudent.GetTestWhereExamDone())
            {
                Console.WriteLine(item.ToString() + "\n");
            }
        }
    }
}