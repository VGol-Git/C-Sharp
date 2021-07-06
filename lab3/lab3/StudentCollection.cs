using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    class StudentCollection<TKey>
    {
        Dictionary<TKey, Student> StudentDictionary = new Dictionary<TKey, Student>();

        KeySelector<TKey> MyKeySelector;

        public StudentCollection(KeySelector<TKey> tempKey)
        {
            this.MyKeySelector = tempKey;
        }

        public void AddDefaults()
        {
            Student tempStud = new Student();
            TKey key = MyKeySelector(tempStud);
            StudentDictionary.Add(key, tempStud);
        }

        public void AddStudents(params Student[] newStud)
        {
            foreach (Student item in newStud)
            {
                TKey key = MyKeySelector(item);
                StudentDictionary.Add(key, item);
            }
        }

        public override string ToString()
        {
            string ret = "";
            foreach (var item in StudentDictionary)
            {
                ret += item.Key.ToString();
                ret += "\n";
                ret += item.Value.ToString();
            }
            return ret;
        }

        public string ToShortString()
        {
            string ret = "";
            foreach (var item in StudentDictionary)
            {
                ret += item.Key.ToString();
                ret += item.Value.ToShortString();
            }
            return ret;
        }

        public double MaxAverageRat
        {
            get
            {
                if (StudentDictionary.Count > 0) return StudentDictionary.Values.Max(x => x.averageGrade);
                return 0;
            }
        }

        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education value)
        {
            return StudentDictionary.Where(x => x.Value.Education == value);
        }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupByEduc
        {
            get
            {
                return StudentDictionary.GroupBy(x => x.Value.Education);
            }
        }
    }
}
