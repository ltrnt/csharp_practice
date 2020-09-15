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

            Console.WriteLine("Треугольник " +
                (numbers[0].Equals(numbers[1]) && numbers[1].Equals(numbers[2]) ? "равносторонний" : "не равносторонний"));
        }

        public static void Task3_20()
        {
            // TODO Попросить обьяснить, что вообще нужно делать
        }
    }
}
