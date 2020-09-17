using System;
namespace csharp_practice
{
    public class Practice04
    {
        public Practice04()
        {
        }

        public static void Task6_20()
        {
            // Для заданного натурального числа N:
            // Даны три натуральных числа a, b и c. Найти НОД(а, b, c).

            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(NOD(NOD(a, b), c));

        }

        // For Task6_20
        public static int NOD(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else if (a < b)
                    b -= a;
            }
            return a;
        }

        public static void Task7_20()
        {
            // На отрезке [a, b] найти все пары соседних чисел:
            // произведение которых является палиндромом.

            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            if(a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            for (int i = a; i < b; i++)
            {
                if (checkPalindrom(i * (i + 1)))
                {
                    Console.WriteLine("Произведение чисел {0} и {1} является палиндромом ({2})", i, i + 1, i * (i + 1));
                }
            }
        }

        // Проверяет, является ли переданное число палиндромом
        public static bool checkPalindrom(int mul)
        {
            string mul_str = Convert.ToString(mul);

            for(int i = 0; i < mul_str.Length / 2; i++)
                if (mul_str[i] != mul_str[mul_str.Length - 1 - i])
                    return false;
            return true;
        }
    }
}
