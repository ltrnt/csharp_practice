﻿using System;
using System.IO;

namespace csharp_practice.ltrnt.practice14
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

            override
            public string ToString()
            {
                return String.Format("{0} {1} {2}", x, y, z);
            }

            public static double Perimeter(SPoint p1, SPoint p2, SPoint p3)
            {

                double a = Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2) + Math.Pow(p1.z - p2.z, 2));
                double b = Math.Sqrt(Math.Pow(p1.x - p3.x, 2) + Math.Pow(p1.y - p3.y, 2) + Math.Pow(p1.z - p3.z, 2));
                double c = Math.Sqrt(Math.Pow(p2.x - p3.x, 2) + Math.Pow(p2.y - p3.y, 2) + Math.Pow(p2.z - p3.z, 2));

                if (a + b < c && a + c < b && b + c < a)
                    return 0;

                return a + b + c;
            }
        }

        public static SPoint[] input1(ref int n)
        {
            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice14";
            SPoint[] arr;

            using (StreamReader fileIn = new StreamReader(path + "/practice14_2in.txt"))
            {
                
                n = Convert.ToInt32(fileIn.ReadLine());

                string[] line;

                arr = new SPoint[n];

                for (int i = 0; i < n; i++)
                {
                    line = fileIn.ReadLine().Split(' ');

                    arr[i] = new SPoint(Convert.ToInt32(line[0]), Convert.ToInt32(line[1]), Convert.ToInt32(line[2]));
                }
                
            }

            return arr;
        }

        public static void Task01_18()
        {
            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice14";

            using (StreamWriter fileOut = new StreamWriter(path + "/practice14_2out.txt"))
            {
                int n = 0;
                SPoint[] arr = input1(ref n);

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
                    fileOut.WriteLine("Точки не найдены");
                }
                else
                {
                    fileOut.WriteLine("Максимальный периметр: " + max);
                    fileOut.WriteLine(arr[i1]);
                    fileOut.WriteLine(arr[i2]);
                    fileOut.WriteLine(arr[i3]);
                }
             }
        }

        // NEXT
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

        public static void Task02_8()
        {
            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice14";

            Console.Write("Введите год поиска: ");
            int current_year = Convert.ToInt32(Console.ReadLine());

            int n = 0;
            BankAccount[] bankAccounts;

            using (StreamReader fileIn = new StreamReader(path + "/practice14_in.txt"))
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

            using (StreamWriter fileOut = new StreamWriter(path + "/practice14_out.txt"))
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
