using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Доказательство работоспособности:\n\n");
            Console.WriteLine("Матрица:\n");
            double[] init = { 4, 2, 3 };
            double[] ans = { 7, 4, 17 };
            double[] solve = C_plus.Solve(init, ans);
            Console.WriteLine(Matrix.ToString(init, ans));
            string T = "Вектор-решение:\n\n";
            foreach (double item in solve)
                T = T + item + "\t";
            Console.WriteLine(T);
         
            Console.WriteLine("\n\n\n");

            TimeList List = new TimeList();

            string filename;
            while (true)
            {
                Console.WriteLine("Введите название файла сохранения:");
                filename = Console.ReadLine();
                if (filename != "")
                    break;
            }

            int load_error = 0;
            if (System.IO.File.Exists(filename))
            {
                if (List.Load(filename))
                    Console.WriteLine(List.ToString() + "\n\n");
                
                else
                {
                    Console.WriteLine("Файл существует, однако возникла ошибка загрузки. Перезаписать файл?");
                    do
                    {
                        Console.WriteLine("1 - Да\t\t2 - Нет");
                        load_error = Convert.ToInt32(Console.ReadLine());
                    } while (load_error != 1 && load_error != 2);
                }
            }
            if (load_error == 2)
            {
                Console.WriteLine("\n\n\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }
            
            int tumb = 1;

            Console.WriteLine("Начало работы\n");
            do
            {
                try
                {
                    Console.WriteLine("Введите порядок матрицы: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите число повторов: ");
                    int times = Convert.ToInt32(Console.ReadLine());

                    List.Add(new TimeItem(n, times));
                }
                catch (Exception e)
                { Console.WriteLine(e.ToString() + '\n'); }

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Для завершения работы введите 0. Чтобы продолжить, введите любое другое число.");
                        Console.WriteLine("Ожидание ввода.");
                        tumb = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    { Console.WriteLine("Ошибка ввода. Попробуйте еще раз."); }
                    
                }
            } while (tumb != 0);
            Console.WriteLine(List.ToString());
            List.Save(filename);
            Console.WriteLine("\n\n\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
