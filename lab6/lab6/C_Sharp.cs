using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab6
{
    static class C_Sharp
    {
        public static double[] Solve(Matrix A, double[] solve_vector)
        {
            return A.solve(solve_vector);
        }
        public static double[] Solve(double[] init_vector, double[] solve_vector)
        {
            Matrix A = new Matrix(init_vector);
            return A.solve(solve_vector);
        }
        public static double Timer(int size, int times)
        {
            Matrix A = new Matrix(size);
            double[] vector = new double[size];
            for (int i = 0; i < size; i++)
                vector[i] = (double)i;

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 0; i < times; i++)
                A.solve(vector);
            stopWatch.Stop();

            return (double)stopWatch.ElapsedMilliseconds/1000;
        }
    }
}
