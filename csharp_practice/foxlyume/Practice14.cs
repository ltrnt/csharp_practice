using System;
using System.IO;
using System.Collections.Generic;

namespace csharp_practice.foxlyume
{
    public class Practice14
    {

        // ЧАСТЬ 1. ЗАДАЧА 4
        struct SPoint
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

            public double Distance()
            {
                return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(y, 2));
            }
        }

        public static void Task1_4()
        {
            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/foxlyume";
 
            using (StreamReader fileIn = new StreamReader(path + "/practice14_1in.txt"))
            {
                using (StreamWriter fileOut = new StreamWriter(path + "/practice14_1out.txt"))
                {
                    List<SPoint> points = new List<SPoint>();
                    SPoint target = new SPoint();

                    string line;
                    string[] values;
                    double min = -1;

                    while((line = fileIn.ReadLine()) != null)
                    {
                        values = line.Split(' ');
                        points.Add(new SPoint(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), Convert.ToInt32(values[2])));
                    }


                    foreach (var item in points)
                    {
                        if (min < 0)
                        {
                            min = item.Distance();
                            target = item;
                        }
                        else if (min > item.Distance())
                        {
                            min = item.Distance();
                            target = item;
                        }
                    }


                    fileOut.WriteLine(target);
                }
            }
        }


        // ЧАСТЬ 2. ЗАДАЧА 4
        struct Car: IComparable<Car>
        {
            public string brend;
            public string number;
            public string ownerLastname;
            public int year;
            public int mileage;

            public Car(string brend, string number, string ownerLastname, int year, int mileage)
            {
                this.brend = brend;
                this.number = number;
                this.ownerLastname = ownerLastname;
                this.year = year;
                this.mileage = mileage;
            }

            public int CompareTo(Car other)
            {
                if (this.mileage == other.mileage) return 0;
                else if (this.mileage > other.mileage) return 1;
                else return -1;
            }

            override
            public string ToString()
            {
                return String.Format("{0} {1} {2} {3} {4}", brend, number, ownerLastname, year, mileage);
            }
        }

        public static void Task2_4()
        {
            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/foxlyume";

            int target_year;

            Console.WriteLine("Введите год: ");
            target_year = Convert.ToInt32(Console.ReadLine());

            using (StreamReader fileIn = new StreamReader(path + "/practice14_2in.txt"))
            {
                using (StreamWriter fileOut = new StreamWriter(path + "/practice14_2out.txt"))
                {
                    List<Car> list = new List<Car>();
                    string line;
                    string[] values;

                    while((line = fileIn.ReadLine()) != null)
                    {
                        values = line.Split(' ');
                        list.Add(new Car(values[0], values[1], values[2], Convert.ToInt32(values[3]), Convert.ToInt32(values[4])));
                    }

                    list.Sort();

                    foreach (Car item in list)
                    {
                        if (item.year < target_year)
                        {
                            fileOut.WriteLine(item);
                        }
                    }
                }
            }
        }
    }
}
