using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    [Serializable]
    class TimeItem
    {
        public int size { get; }
        public int repeat { get; }
        public double time_sharp { get; }
        public double time_plus { get; }
        double multiplier { get; }
        
        public TimeItem(int n, int times)
        {
            if (n <= 0 || times <= 0)
                throw new ArgumentException("Ошибка. Введено отрицательное число."); 

            size = n;
            repeat = times;
            time_sharp = C_Sharp.Timer(size, repeat);
            time_plus = C_plus.Timer(size, repeat);
            multiplier = time_sharp / time_plus;
        }

        public override string ToString()
        {
            return Convert.ToString(size) + "\t\t\t" + repeat + "\t\t\t" + time_sharp + "\t\t\t" + time_plus + "\t\t\t" + multiplier;
        }
    }
}
