using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;


namespace Uni
{
    delegate TKey KeySelector<TKey> (Student st);
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    delegate void StudentsChangedHandler<TKey>(object source, StudentsChangedEventArgs<TKey> args);
    //delegate void PropertyChangedEventHandler(Object sender, PropertyChangedEventArgs e);
    class Program
    {
        public static string filenameExtension = ".dat";

        static void Main(string[] args)
        {

            //task 1
            //Создать объект типа T с непустым списком элементов, для которого
            //предусмотрен ввод данных с консоли.Создать полную копию объекта с
            //помощью метода, использующего сериализацию, и вывести исходный
            //объект и его копию.
            Person person = new Person("Человек", "Первый", new DateTime(2000, 09, 13));
            Student student1 = new Student(person , Education.Bachelor , 34);

            student1.AddTests(new Test("Math", true), new Test("Philosophy", false), new Test("PIUS", true));

            student1.AddExams(new Exam("T1", 5, new DateTime(2021, 7, 20)), new Exam("T2", 2, new DateTime(2020, 7, 20)));

            Student student2 = student1.DeepCopy(true);
            Console.WriteLine(student1);
            Console.WriteLine(student2);

            //task 2
            //Предложить пользователю ввести имя файла:
            // если файла с введенным именем нет, приложение должно
            //сообщить об этом и создать файл;
            // если файл существует, вызвать метод Load(string filename) для
            //инициализации объекта T данными из файла.
            Student student3 = new Student();
            Console.WriteLine("Write file name");
            string filename = Console.ReadLine();
            if (File.Exists(filename + ".dat"))
            {
                bool isLoadSucces = student3.Load(filename);
                if (!isLoadSucces)
                {
                    Console.WriteLine("load from clear file");
                }
            }
            else
            {
                Console.WriteLine("File didn\'t found but create now");
                File.Create(filename + ".dat");
            }

            //task 3
            //Вывести объект T.
            Console.WriteLine(student3);

            //task 4
            //Для этого же объекта T сначала вызвать метод AddFromConsole(), затем
            //метод Save(string filename). Вывести объект T.
            student3.AddFromConsole();
            student3.Save(filename + ".dat");
            Console.WriteLine(student3);

            //task 5
            //Вызвать последовательно
            // статический метод Load(string filename, T obj), передав как
            //параметры ссылку на тот же самый объект T и введенное ранее имя
            //файла;
            // метод AddFromConsole();
            // статический метод Save(string filename, T obj).
            Student.Load(filename + ".dat", student3);
            student3.AddFromConsole();
            Student.Save(filename + ".dat", student3);

            //task 6
            //Вывести объект T.
            Console.WriteLine(student3);

            Console.ReadLine();

        }

    }
}