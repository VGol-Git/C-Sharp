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

            // Создать один объект типа Student, преобразовать данные в текстовый вид с помощью метода ToShortString() и вывести данные.
            Console.WriteLine("№5");
            Student Student_1 = new Student();
            Console.WriteLine(Student_1.ToShortString());
            //Вывести значения индексатора для значений индекса Education.Specialist, Education.Bachelor и Education.SecondEducation.
            Console.WriteLine("№6");

            Console.WriteLine(Student_1[Education.Bachelor]);
            Console.WriteLine(Student_1[Education.Specialist]);
            Console.WriteLine(Student_1[Education.SecondEducation]);
            //Присвоить значения всем определенным в типе Student свойствам, преобразовать данные в текстовый вид с помощью метода ToString() и вывести данные.
            Console.WriteLine("№7");

            Student_1.Person = new Person("Vova", "Trutrutovich", new DateTime(2000, 1, 1));
            Student_1.Education = Education.Bachelor;
            Student_1.GroupNumber = 34;
            Exam[] ExList = new Exam[2];
            ExList[0] = new Exam("Physics", 4, new DateTime(2020, 1, 5));
            ExList[1] = new Exam("History", 5, new DateTime(2020, 1, 10));
            Student_1.Exams = ExList;
            Console.WriteLine(Student_1.ToString());
            //C помощью метода AddExams( params Exam[] ) добавить элементы в список экзаменов и вывести данные объекта Student, используя метод ToString().
            Console.WriteLine("№8");

            Exam Ex1 = new Exam("Math", 5, new DateTime(2020, 1, 15));
            Student_1.AddExams(Ex1);
            Console.WriteLine(Student_1.ToString());

            //Сравнить время выполнения операций с элементами одномерного, двумерного прямоугольного и двумерного ступенчатого массивов с одинаковым числом элементов типа Exam.
            Console.WriteLine("№9");

            int nrow = 0, ncolumn = 0;
            Console.WriteLine("Введите число столбцов и строк");
            nrow = int.Parse(Console.ReadLine());
            ncolumn = int.Parse(Console.ReadLine());

            int size = nrow * ncolumn, size1 = ncolumn + nrow;

            Exam[] Mas1 = new Exam[size];
            for (int i = 0; i < size; i++)
                Mas1[i] = new Exam(); //создаем одномерный массив

            Exam[,] Mas2 = new Exam[nrow, ncolumn];
            for (int i = 0; i < nrow; i++)
                for (int j = 0; j < ncolumn; j++)
                    Mas2[i, j] = new Exam(); // создаем двумерный массив

            int k = 0;
            Exam[,] Mas3 = new Exam[size1, size1];
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < i; j++)
                {

                    Mas3[i, j] = new Exam();
                    k++;
                    if (k == size)
                        break; //если достаточное количество элементов, то прерываем
                }
                if (k == size)
                    break;
            } // создаем ступенчатый массив

            double Begin, End; // переменные для хранения времени

            //1) одномерный
            Begin = Environment.TickCount;
            for (int i = 0; i < size; i++)
            {
                Mas1[i].Subject= "Mathematics";
                Mas1[i].Grade= 5;
            }
            End = Environment.TickCount;
            Console.WriteLine("Время выполнения операции для одномерного массива: {0}", End - Begin);

            //2) двумерный
            Begin = Environment.TickCount;
            for (int i = 0; i < nrow; i++)
                for (int j = 0; j < ncolumn; j++)
                {
                    Mas2[i, j].Subject = "Mathematics";
                    Mas2[i, j].Grade = 5;
                }
            End = Environment.TickCount;
            Console.WriteLine("Время выполнения операции для двумерного массива: {0}", End - Begin);

            //3) ступенчатый
            k = 0;
            Begin = Environment.TickCount;
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < i; j++)
                {

                    Mas3[i, j].Subject = "Mathematics";
                    Mas3[i, j].Grade = 5;
                    k++;
                    if (k == size)
                        break; //если достаточное количество элементов, то прерываем
                }
                if (k == size)
                    break;
            }

            End = Environment.TickCount;
            //Console.WriteLine(k);
            Console.WriteLine("Время выполнения операции для ступенчатого массива: {0}", End - Begin);



            Console.WriteLine("Нажмите любую кнопку, чтобы выйти");
            Console.ReadKey();
        }
    }
}