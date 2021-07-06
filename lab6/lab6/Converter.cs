using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Converter
    {
        public static double[] ToInt(string[] vs)
        {
            double[] reter = new double[vs.Count()];
            int i = 0;
            try
            {
                foreach (string num in vs)
                {
                    reter[i] = Convert.ToDouble(num);
                    i++;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка. Неверный формат\n");
            }
            return reter;
        }
    }
}
