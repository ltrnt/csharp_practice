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
    }
}
