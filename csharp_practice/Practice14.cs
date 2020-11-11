using System;
using System.IO;

namespace csharp_practice
{
    public class Practice14
    {
        public struct SPoint
        {
            public int x, y, z;

            public SPoint(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public string ToString()
            {
                return String.Format("{0} {1} {2}", x, y, z);
            }



            public static double Perimeter(SPoint p1, SPoint p2, SPoint p3)
            {

                double a = Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2) + Math.Pow(p1.z - p2.z, 2));
                double b = Math.Sqrt(Math.Pow(p1.x - p3.x, 2) + Math.Pow(p1.y - p3.y, 2) + Math.Pow(p1.z - p3.z, 2));
                double c = Math.Sqrt(Math.Pow(p2.x - p3.x, 2) + Math.Pow(p2.y - p3.y, 2) + Math.Pow(p2.z - p3.z, 2));

                if (a + b <= c || a + c <= b || a + c <= b)
                    return 0;

                return a + b + c;
            }
        }

        // TODO Нужно протестировать.
        public static void Task01_18()
        {
            // Решить задачу, используя структуру SPoint для хранения координат точки:
            // Замечание.В задачах с нечетными номерами множество точек задано на плоскости,
            // в задачах с четными номерами множество точек задано в пространстве.

            // Найти три различные точки из заданного множества точек, образующих треугольник наибольшего периметра.

            Console.Write("Введите количество точек: ");
            int n = Convert.ToInt32(Console.ReadLine());

            string []line;

            SPoint[] arr = new SPoint[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите координаты точки через пробел (x y z): ");
                line = Console.ReadLine().Split(' ');

                arr[i] = new SPoint(Convert.ToInt32(line[0]), Convert.ToInt32(line[1]), Convert.ToInt32(line[2]));
            }

            double max = 0;
            double p;

            int i1 = -1;
            int i2 = -1;
            int i3 = -1;


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == i) continue;

                    for (int k = 0; k < n; k++)
                    {
                        if (k == j || k == i) continue;

                        p = SPoint.Perimeter(arr[i], arr[j], arr[k]);
                        if (p > max)
                        {
                            max = p;
                            i1 = i;
                            i2 = j;
                            i3 = k;
                        }
                    }
                }
            }

            if (max < 0.5)
            {
                Console.WriteLine("Точки не найдены");
            } else
            {
                Console.WriteLine("Максимальный периметр: " + max);
                Console.WriteLine(arr[i1]);
                Console.WriteLine(arr[i2]);
                Console.WriteLine(arr[i3]);
            }
        }


        struct BankAccount : IComparable<BankAccount>
        {
            public string name;
            public string lastname;
            public string patronymic;
            public int number;
            public int sum;
            public int year;

            public BankAccount(string lastname, string name, string patronymic, int number, int sum, int year)
            {
                this.lastname = lastname;
                this.name = name;
                this.patronymic = patronymic;
                this.number = number;
                this.sum = sum;
                this.year = year;
            }

            public int CompareTo(BankAccount other)
            {
                if (this.sum == other.sum) return 0;
                else if (this.sum > other.sum) return 1;
                else return -1;
            }

            override
            public String ToString()
            {
                return String.Format("{0} {1} {2}. Номер счета: {3}. Сумма: {4}. Год открытия счета: {5}.",
                    patronymic, name, lastname, number, sum, year);
            }
        }

        // TODO Нужно протестировать.
        public static void Task02_8()
        {
            // Решить задачу, разработав собственную структуру для хранения информации
            // На основе данных входного файла составить список вкладчиков банка, включив следующие данные:
            // ФИО, No счета, сумма, год открытия счета.
            // Вывести в новый файл информацию о тех вкладчиках, которые открыли вклад в текущем году, отсортировав их по сумме вклада.


            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice";

            Console.Write("Введите год поиска: ");
            int current_year = Convert.ToInt32(Console.ReadLine());

            int n = 0;
            BankAccount[] bankAccounts;

            using (StreamReader fileIn = new StreamReader(path + "/input14_08.txt"))
            {
                n = Convert.ToInt32(fileIn.ReadLine());
                bankAccounts = new BankAccount[n];

                string[] line;

                for (int i = 0; i < n; i++)
                {
                    line = fileIn.ReadLine().Split(' ');

                    bankAccounts[i] = new BankAccount(line[0], line[1], line[2],
                                                        Convert.ToInt32(line[3]),
                                                        Convert.ToInt32(line[4]),
                                                        Convert.ToInt32(line[5]));
                }
            }

            Array.Sort(bankAccounts);

            using (StreamWriter fileOut = new StreamWriter(path + "/output14_08.txt"))
            {
                foreach (var item in bankAccounts)
                {
                    if(item.year == current_year)
                    {
                        fileOut.WriteLine(item);
                    }
                }
            }
        }
    }
}
