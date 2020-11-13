using System;
namespace csharp_practice
{
    public class Practice03
    {
        public Practice03()
        {
        }


        public static void Task4_20()
        {
            int a = 100;
            int b = 999;

            bool check = false;
            int num;

            for(int i = a; i <= b; i++)
            {
                num = i;


                // Проверка, что есть хоть одна четная цифра
                while(num != 0)
                {
                    if ((num % 2) == 0)
                    {
                        check = true;
                        break;
                    }

                    num /= 10;
                }

                if (check) Console.WriteLine(i);

                check = false;
            }
        }
    }
}
