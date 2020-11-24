using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace csharp_practice.ltrnt.practice12
{
    public class Practice12
    {
        // Задача 5

        // Generator() - запускать для генерации 3-х файлов(10000 символов, 100 символов, 3 символа)
        // TimeChecker(int fileSize) - Запускать для замера скорости выполнения. В параметре передать количество символов в подстроке (3 или 100).

        public static int Algorithm(string t, string s) {
            int counter = 0;

            const long P = 37;

            //вычисляем массив степеней P 
            long[] pwp = new long[t.Length];
            pwp[0] = 1;

            for (int i = 1; i < t.Length; i++)
            {
                pwp[i] = pwp[i - 1] * P;
            }
            //вычисляем массив хэш-значение для всех префиксов строки T 
            long[] h = new long[t.Length];
            for (int i = 0; i < t.Length; i++)
            {
                h[i] = (t[i] - 'a' + 1) * pwp[i]; //1 
                if (i > 0)
                    h[i] += h[i - 1];
            }
            // вычисляем хэш-значение для подстроки S 
            long h_s = 0;
            for (int i = 0; i < s.Length; i++)
            {
                h_s += (s[i] - 'a' + 1) * pwp[i];
            }
            //проводим поиск по хеш-значениям 
            for (int i = 0; i + s.Length - 1 < t.Length; i++)
            {
                // находим хэш-значение подстроки T начиная с позиции i длиною s.Length 
                long cur_h = h[i + s.Length - 1];
                if (i > 0)
                {
                    cur_h -= h[i - 1];
                }
                //приводим хэш-значения двух подстрок к одной степени 
                if (cur_h == h_s * pwp[i]) // если хеш-значения равны, то и подстроки равны 
                {
                    //Console.Write("{0} ", i); // выводим позицию i, с которой начинается повторение
                    counter++;
                }
            }

            return counter;
        }

        public static void Generator()
        {
            //random.Next(1072, 1103);
            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice12";

            Random random = new Random();

            int low = 1072;
            int high = 1087;


            using (StreamWriter file10000 = new StreamWriter(path + "/10000.txt"))
            {
                char symbol;

                for (int i = 0; i < 10000; i++)
                {
                    symbol = (char)random.Next(low, high);
                    file10000.Write(symbol);
                }
            }

            using (StreamWriter file3 = new StreamWriter(path + "/3.txt"))
            {
                char symbol;

                for (int i = 0; i < 3; i++)
                {
                    symbol = (char)random.Next(low, high);
                    file3.Write(symbol);
                }
            }

            using (StreamWriter file100 = new StreamWriter(path + "/100.txt"))
            {
                char symbol;

                for (int i = 0; i < 100; i++)
                {
                    symbol = (char)random.Next(low, high);
                    file100.Write(symbol);
                }
            }
        }

        public static void TimeChecker(int fileSize)
        {
            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice12";

            string T;
            string S;

            using (StreamReader fileT = new StreamReader(path + "/10000.txt"))
            {
                T = fileT.ReadToEnd();
            }

            using (StreamReader fileS = new StreamReader(path + "/" + fileSize + ".txt"))
            {
                S = fileS.ReadToEnd();
            }

            Stopwatch timer = new Stopwatch();

            timer.Start();
            int counter = Algorithm(T, S);
            timer.Stop();

            Console.WriteLine("For {0} is {1}", fileSize, counter);

            using (StreamWriter fileOut = new StreamWriter(path + "/out.txt", true))
            {
                fileOut.WriteLine("Для {0} символов: {1} мс, {2} тактов, найденно {3} совпадение(й)", fileSize, timer.ElapsedMilliseconds, timer.ElapsedTicks, counter);
            }
        }
    }
}
