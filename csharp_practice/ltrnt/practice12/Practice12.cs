using System;
using System.Text;

namespace csharp_practice
{
    public class Practice12
    {
        public static void Task_5()
        {
            Random rand = new Random();

            int n = 10000;
            int m = 3;
            char a;
            char b;

            StringBuilder t = new StringBuilder();
            StringBuilder s = new StringBuilder();
            Console.Write("T = ");
            for (int i = 0; i < n; i++)
            {
                a = (char)rand.Next(0x0430, 0x43B);
                t.Append(a);
            }

            Console.Write(t);
            Console.WriteLine();
            Console.Write("S = ");

            for (int i = 0; i < m; i++)
            {
                b = (char)rand.Next(0x0430, 0x43B);
                s.Append(b);
            }

            Console.Write(s);
            Console.WriteLine();
            const long P = 37;
            t.Length = t.Length;

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
                    Console.Write("{0} ", i); // выводим позицию i, с которой начинается повторение 
                }
            }
        }
    }
}
