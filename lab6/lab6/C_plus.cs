using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace lab6
{
    public static class C_plus
    {
        const string filename = "..\\..\\..\\C_file\\Debug\\C_file.dll";
        [DllImport(filename, EntryPoint = "Timer", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Timer(int size, int times);

        [DllImport(filename, EntryPoint = "Solve", CallingConvention = CallingConvention.Cdecl)]
        public static extern int A();


        [DllImport(filename, EntryPoint = "solve", CallingConvention = CallingConvention.Cdecl)]
        static extern void solve(double[] init_vector, double[] solve_vector, int size, double[] Ans);


        public static double[] Solve(double[] init_vector, double[] solve_vector)
        {
            if (init_vector.Length != solve_vector.Length)
                throw new ArgumentException("Аргументами должны являться векторы одинакогого размера");

            int size = init_vector.Length;

            double[] Ans = new double[size];

            solve(init_vector, solve_vector, size, Ans);

            return Ans;
        }
    }
}
