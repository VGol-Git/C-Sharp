using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    delegate TKey KeySelector<TKey> (Student st);
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);

    class Program
    {


        static void Main(string[] args)
        {

            Console.WriteLine("№1 Создание Student ");
            Student firstStudent = new Student();
            Person firstPerson = new Person("Человек", "Первый", new DateTime(2000, 09, 13));
            Person secondPerson = new Person("Человек", "Второй", new DateTime(1998, 10, 14));
            firstStudent.ExamsList.Add(new Exam("Rus", 5, new DateTime(2021, 06, 15)));
            firstStudent.ExamsList.Add(new Exam("Math", 4, new DateTime(2021, 06, 20)));


            Console.WriteLine("_______________Без сортировки");
            Console.WriteLine(firstStudent.ToString());

            Console.WriteLine("_______________Сортировка по названию предмета");
            firstStudent.sortBySubject();
            Console.WriteLine(firstStudent.ToString());

            Console.WriteLine("_______________Сортировка по оценке за экзамен");
            firstStudent.sortByGrade();
            Console.WriteLine(firstStudent.ToString());

            Console.WriteLine("_______________Сортировка по дате экзамена");
            firstStudent.sortByDate();
            Console.WriteLine(firstStudent.ToString());



            Console.WriteLine("№2 Создание StudentCollection ");

            KeySelector<string> selector = delegate (Student input)
            {
                return input.GetHashCode().ToString();
            };

            var obj = new StudentCollection<string>(selector);
            obj.AddDefaults();
            Student m1 = new Student(firstPerson, new Education(), 10);
            Student m2 = new Student(secondPerson, new Education(), 11);
            obj.AddStudents(m1, m2);
            Console.WriteLine(obj.ToString());



            Console.WriteLine("№3 Вызов методов StudentCollection ");

            Console.WriteLine(obj.MaxAverageRat);
            Console.WriteLine();

            foreach (var item in obj.EducationForm(Education.Bachelor))
                Console.WriteLine(item.ToString());
            Console.WriteLine();

            foreach (var item in obj.GroupByEduc)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine();
                foreach (var name in item)
                    Console.WriteLine(name);
            }



            Console.WriteLine("№4 Создание TestCollection ");

            GenerateElement<Person, Student> d = delegate (int j)
            {
                var key = new Person("Человек", "Номер: " + j, new DateTime(1990 + j, 09, 13));
                var value = new Student(key, (Education)(j % 3 + 1), 10 + j);
                return new KeyValuePair<Person, Student>(key, value);
            };

            int c = Convert.ToInt32(Console.ReadLine());
            var testObj = new TestCollections<Person, Student>(c, d);
            testObj.searchInTKeyList();
            testObj.searchInStrList();
            testObj.searcInTKeyDictionary();
            testObj.searcInStrDictionary();
            testObj.searcInTKeyDictionaryByValue();
        }

    }
}