using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace lab6
{
    [Serializable]
    class TimeList
    {

        List<TimeItem> items;

        public TimeList()
        {
            items = new List<TimeItem>();
        }


        public void Add(TimeItem item)
        {
            items.Add(item);
        }



        public bool Save(string filename)
        {
            try
            {
                BinaryFormatter saver = new BinaryFormatter();
                FileStream fs = new FileStream(filename, FileMode.Create);
                saver.Serialize(fs, items);
                fs.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


        public bool Load(string filename)
        {
            List<TimeItem> save = items;
            try
            {
                BinaryFormatter saver = new BinaryFormatter();
                FileStream fs = new FileStream(filename, FileMode.Open);
                items = (List<TimeItem>)saver.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                items = save;
                return false;
            }
        }


        public override string ToString()
        {
            string T = "Порядок матрицы \tКол-во повторений \tВремя на шарпах \tВремя в плюсах \t\tКоеффицент";
            for (int i = 0; i < items.Count; i++)
            {
                T = T + "\n" + items[i].ToString();
            }
            return T;
        }



    }
}
