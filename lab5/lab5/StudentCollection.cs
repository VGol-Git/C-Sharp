using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace Uni
{
    class StudentCollection<TKey>
    {
        Dictionary<TKey, Student> StudentDictionary = new Dictionary<TKey, Student>();

        KeySelector<TKey> MyKeySelector;

        public string collectionName { get; set; }
        public StudentCollection(KeySelector<TKey> tempKey)
        {
            this.MyKeySelector = tempKey;
            // StudentDictionary = new Dictionary<TKey, Student>();
        }

    

        public void AddDefaults()
        {
            Student tempStud = new Student();
            TKey key = MyKeySelector(tempStud);
            StudentDictionary.Add(key, tempStud);
            StudentPropertyChanged(Action.Add, "collection", key);
            //Устанавливаем слушателей событий в классе Student
            tempStud.PropertyChanged += translateEvent;
        }

        public void AddStudents(params Student[] newStud)
        {
            foreach (Student item in newStud)
            {
                TKey key = MyKeySelector(item);
                StudentDictionary.Add(key, item);
                StudentPropertyChanged(Action.Add, "collection", key);
                //Устанавливаем слушателей событий в классе Student
                item.PropertyChanged += translateEvent;
            }
        }

        public bool Remove(Student stud)
        {
            TKey key = MyKeySelector(stud);
            if (StudentDictionary.ContainsKey(key) == true)
            {
                StudentDictionary.Remove(key);
                StudentPropertyChanged(Action.Remove, "collection", key);
                stud.PropertyChanged -= translateEvent;
                return true;
            }
            return false;
        }

        public event StudentsChangedHandler<TKey> StudentsChanged;

        private void StudentPropertyChanged(Action act, string name, TKey key)
        {
            if (StudentsChanged != null)
            {
                StudentsChanged(this, new StudentsChangedEventArgs<TKey>(collectionName, act, name, key));
            }
        }
        public void translateEvent(object subject, EventArgs e)
        {
            var me = (PropertyChangedEventArgs)e;
            var st = (Student)subject;
            TKey key = MyKeySelector(st);
            StudentPropertyChanged(Action.Property, me.PropertyName.ToString(), key);
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
