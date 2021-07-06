using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Uni
{
    delegate TKey KeySelector<TKey> (Student st);
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    delegate void StudentsChangedHandler<TKey>(object source, StudentsChangedEventArgs<TKey> args);
    //delegate void PropertyChangedEventHandler(Object sender, PropertyChangedEventArgs e);
    class Program
    {


        static void Main(string[] args)
        {

            KeySelector<string> selector = delegate (Student input)
            {
                return input.GetHashCode().ToString();
            };

            //task 1 | Создать две коллекции StudentCollection<string> с разными названиями
            var col1 = new StudentCollection<string>(selector);
            col1.collectionName = "Collection 1";
            var col2 = new StudentCollection<string>(selector);
            col2.collectionName = "Collection 2";


            Person firstPerson = new Person("Человек", "Первый", new DateTime(2000, 09, 13));
            Person secondPerson = new Person("Человек", "Второй", new DateTime(1998, 10, 14));
            Person thirdPerson = new Person("Человек", "Третий", new DateTime(2000, 09, 13));
            Person fourPerson = new Person("Человек", "Четвертый", new DateTime(1998, 10, 14));

            Student m1 = new Student(firstPerson, new Education(), 110);
            Student m2 = new Student(secondPerson, new Education(), 110);
            Student m3 = new Student(thirdPerson, new Education(), 120);
            Student m4 = new Student(fourPerson, new Education(), 115);
            
            
         
           

            Journal journal = new Journal();

            //task 2 | Создать объект Journal и подписать его на события StudentsChanged из обеих коллекций StudentCollection<string>.
            //Устанавливаем слушателей событий в коллекциях
            col1.StudentsChanged += journal.NewListEntry;
            col2.StudentsChanged += journal.NewListEntry;

            //Устанавливаем слушателей событий в классе Student
            m1.PropertyChanged += journal.NewListEntry;
            m2.PropertyChanged += journal.NewListEntry;
            m3.PropertyChanged += journal.NewListEntry;
            m4.PropertyChanged += journal.NewListEntry;

            //task 3 | Внести изменения в коллекции StudentCollection<string>: 
            // добавить элементы Student в коллекции; изменить значения разных свойств элементов, входящих в коллекцию;
            // удалить элемент из коллекции;
            // изменить данные в удаленном элементе.

            col1.AddDefaults();
            col1.AddStudents(m1, m2);
            col2.AddDefaults();
            col2.AddStudents(m3, m4);

            m3.GroupNumber = 150;
            m4.Education = Education.Specialist;

            col1.Remove(m2);
            m2.GroupNumber = 150;
            //task 4 | Вывести данные объекта Journal.
            Console.WriteLine(journal.ToString());


            Console.ReadLine();

        }

    }
}