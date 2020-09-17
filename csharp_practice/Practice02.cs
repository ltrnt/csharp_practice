using System;
namespace csharp_practice
{
    public class Practice02
    {
        public Practice02()
        {}

        public static void Task2_20()
        {
            // Гарантируется, что пользователь способен ввести ровно три числа через пробел
            Console.Write("Введите длину трех сторон треугольника через пробел: ");
            string[] numbers = Console.ReadLine().Split(' ');

            int a = Convert.ToInt32(numbers[0]);
            int b = Convert.ToInt32(numbers[1]);
            int c = Convert.ToInt32(numbers[2]);

            Console.WriteLine("Треугольник " + ((a == b && b == c) ? "равносторонний" : "не равносторонний"));
        }

        public static void Task3_20()
        { // Натуральное трехзначное число
            int y = Convert.ToInt32(Console.ReadLine());
            int z = Convert.ToInt32(Console.ReadLine());

            int x = z * 100 + y;

            Console.WriteLine("Исходное число {0}", x);
        }
    }
}
