using System;
namespace csharp_practice.Lerunchekshomework
{
    public class Practice02
    {
        public Practice02()
        {
        }


        public static void Task2_11()
        {
            Console.Write("Введите число: ");
            string number = Console.ReadLine();

            int a = Convert.ToInt32(number[0]);
            int b = Convert.ToInt32(number[1]);
            int c = Convert.ToInt32(number[2]);

            Console.WriteLine("Цифры в числе " + ((a == b && b == c) ? "одинаковые" : "разные"));
        }

        public static void Task3_11()
        {
            //В числе Х поменяли местами первую и последнюю цифру, вторую и третью цифру.
            //Получилось число У. Зная значение числа У, найдите исходное число Х.
            // Число 4-х значное.
            // Решение через строки, возможно Кудриной не понравится.

            Console.Write("Введите число: ");
            string number = Console.ReadLine();

            string source_number = number[3].ToString() + number[2].ToString() + number[1].ToString() + number[0].ToString();

            Console.WriteLine(source_number);
        }
    }
}
