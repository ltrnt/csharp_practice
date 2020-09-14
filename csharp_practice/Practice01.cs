using System;
namespace csharp_practice
{
    public class Practice01
    {
        public Practice01()
        {}


        public static void Task3()
        { 
            Console.Write("a = ");
            int a = Int32.Parse(Console.ReadLine());

            Console.Write("b = ");
            int b = Int32.Parse(Console.ReadLine());

            Console.Write("c = ");
            int c = Int32.Parse(Console.ReadLine());

            Console.WriteLine(String.Format("{0} + {1} + {2} = {3}", a, b, c, a + b + c));
        }

        public static void Task4()
        {        
            Console.Write("a = ");
            double a = Double.Parse(Console.ReadLine());

            Console.Write("b = ");
            double b = Double.Parse(Console.ReadLine());

            Console.WriteLine(String.Format("{0:f1} * {1:f1} = {2:f1}", a, b, a * b));
        }

        public static void Task8()
        {
            Console.Write("Введите сумму вклада = ");
            decimal sum = Decimal.Parse(Console.ReadLine());

            Console.Write("Введите процент по вкладу = ");
            decimal percent = Decimal.Parse(Console.ReadLine());

            Console.WriteLine(String.Format("Через год начислят {0:C} р", ((percent / 100) * sum)));
        }
    }
}
