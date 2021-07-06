using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    class Person
    {
        private string name;
        private string surname;
        private DateTime date_of_birth;

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

    }
}
