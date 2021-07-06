using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    class Person : IDateAndCopy
    {
        protected string name;
        protected string surname;
        protected DateTime date_of_birth;

        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Date_of_birth_Year { get => date_of_birth.Year; set => date_of_birth.AddYears(value); }

        public Person(string name, string surname, DateTime date_of_birth)
        {
            this.name = name;
            this.surname = surname;
            this.date_of_birth = date_of_birth;
        }
        public Person()
        {
            name = "Noname";
            surname = "Nosurname";
            date_of_birth.AddDays(0);
            date_of_birth.AddMonths(0);
            date_of_birth.AddYears(0);
        }



        public override string ToString() => name + ' ' + surname + ' ' + date_of_birth;


        public virtual string ToShortString()
        {
            return name + ' ' + surname;
        }

        public override bool Equals(object obj)
        {
         //   var person = obj as Person;
         ////   Boolean bb = person != null && name == person.name && surname == person.surname && date_of_birth == person.date_of_birth;

         //   return person != null &&
         //          name == person.name &&
         //          surname == person.surname &&
         //          date_of_birth == person.date_of_birth;

            if (obj is Person person)
                return (name == person.Name) && (surname == person.surname) && (date_of_birth == person.date_of_birth);
            else
                return false;

        }

    
        public static bool operator ==(Person a, object b)
        {
            return a.Equals(b);
        }


        public static bool operator !=(Person a, object b)
        {
            return !(a == b);
        }


        public override int GetHashCode()
        {
            return surname.GetHashCode() + name.GetHashCode() + date_of_birth.GetHashCode();
        }

        public virtual object DeepCopy()
        {
            return new Person(this.Name, this.Surname, this.Date_of_birth);
        }

        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
