using System;
namespace csharp_practice
{
    public class Practice05
    {
        public Practice05()
        {
        }

        // TASK START __________________________________________________________

        // Рекурсивный поиск ближайшего числа с суммой нечетных цифр равной А

        public static int findNearest(int startNumber, int sum, int step = 1)
        {
            int numberP = startNumber + step;
            int numberM = startNumber - step;

            if (sumOfDigitsBy1(numberP) == sum) return numberP;
            if (sumOfDigitsBy1(numberM) == sum) return numberM;

            return findNearest(startNumber, sum, ++step);
        }

        // Проверка, является ли число простым.
        public static bool checkSimpleNumber(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        // Нахождение суммы нечетных цифр числа
        public static int sumOfDigitsBy1(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                if ((number % 10) % 2 == 1)
                {
                    sum += number % 10;
                }

                number /= 10;
            }

            return sum;
        }

        public static void Task2_5()
        {

            /*
                Разработать метод, который для заданного натурального числа N возвращает сумму его нечетных цифр.
                С помощью данного метода:

                a) для каждого целого числа на отрезке [a, b] вывести на экран сумму его нечетных цифр;
                b) вывести на экран только те целые числа отрезка [a, b], у которых сумма нечетных цифр числа равна заданному значению С;
                c) вывести на экран только те целые числа отрезка [a, b], у которых сумма нечетных цифр является простым числом.
                d) для заданного числа А вывести на экран ближайшее следующее по отношению к нему число, сумма нечетных цифр которого равна сумме нечетных цифр числа А.
             */

            Console.Write("Введите число а: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите число b: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите число C: ");
            int c = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите число A: ");
            int aBIG = Convert.ToInt32(Console.ReadLine());

            // A
            if(a > b)
            {
                int temp = b;
                b = a;
                a = temp;
            }

            for(int i = a; i <= b; i++)
            {
                Console.Write(i + ": " + sumOfDigitsBy1(i));
                Console.Write(", ");
            }

            Console.WriteLine();
            Console.WriteLine();

            // B
            for (int i = a; i <= b; i++)
            {
                int sum = sumOfDigitsBy1(i);
                if (sum == c)
                {
                    Console.Write(i + ": " + sum);
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // C
            for (int i = a; i <= b; i++)
            {
                int sum = sumOfDigitsBy1(i);
                if (sum != 0 && checkSimpleNumber(sum))
                {
                    Console.Write(i + ": " + sum);
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // D
            int sumA = sumOfDigitsBy1(aBIG);

            Console.WriteLine(findNearest(aBIG, sumA));
        }

        // TASK END ____________________________________________________________
        

        public static void Task3_5()
        {

        }

    }
}
