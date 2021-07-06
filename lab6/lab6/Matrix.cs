using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Matrix
    {
        List<double> mass;
        public Matrix(int n)
        {
            mass = new List<double>();
            mass.Add(16);
            for (int i = 1; i < n; i++)
                mass.Add(1);
        }
        public Matrix(double[] vector)
        {
            mass = new List<double>();
            for (int i = 0; i < vector.Count(); i++)          
                mass.Add(vector[i]);

        }

        static double Scb(double[][] b, double[][] c, int k0, int n, int i, int j)
        {
            double sum = 0;
            for (int k = k0; k <= n; k++)
                sum += b[i][k] * c[k][j - k];

            return sum;
        }

        public double[] solve(double[] solution)
        {
            int size = mass.Count;

            double[][] b = new double[size][];
            for (int i = 1; i <= size; i++)
                b[i - 1] = new double[i];

            double[][] c = new double[size][];
            for (int i = size; i > 0; i--)
                c[size - i] = new double[i];


            for (int k = 0; k < size; k++)
            {
                b[k][0] = mass[k];
                c[0][k] = mass[k] / mass[0];
            }

            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    if (i >= j)
                        b[i][j] = mass[Math.Abs(i - j)] - Matrix.Scb(b, c, 0, j-1, i, j);
                    if (i <= j)
                        c[i][j - i] = (mass[Math.Abs(i - j)] - Matrix.Scb(b, c, 0, i - 1, i, j)) / b[i][i];
                }
            }

            double[] y = new double[size];
            double[] x = new double[size];

            y[0] = solution[0] / b[0][0];
            for (int i = 1; i < size; i++)
            {
                double sum = 0;
                for (int k = 0; k <= i - 1; k++)
                    sum += b[i][k] * y[k];
                y[i] = (solution[i] - sum) / b[i][i];
            }

            x[size - 1] = y[size - 1];
            for (int i = size - 2; i >= 0; i--)
            {
                double sum = 0;
                for (int k = i+1; k < size; k++) 
                    sum += x[k] * c[i][k - i];
                x[i] = y[i] - sum;
            }

            return x;
        }






        public override string ToString()
        {
            string T = "";
            for (int i = 0; i < mass.Count; i++)
            {
                for (int j = 0; j < mass.Count; j++)
                    T = T + mass[Math.Abs(i - j)] + '\t';

                T = T + "\n\n\n";
            }
            return T;
        }
        public static string ToString(double[] init, double[] ans)
        {
            string T = "";
            for (int i = 0; i < init.Length; i++)
            {
                for (int j = 0; j < init.Length; j++)
                    T = T + init[Math.Abs(i - j)] + '\t';

                T = T + '\t' + ans[i] + "\n\n\n";
            }
            return T;
        }
    }

}



//            if (solution.Count() != mass.Count)
//                throw new FormatException("\nОшибка. Неверный формат\n");