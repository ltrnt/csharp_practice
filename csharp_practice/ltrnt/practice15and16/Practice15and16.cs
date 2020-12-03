using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace csharp_practice.ltrnt.practice15and16
{
    public class Practice15and16
    { // 18

        private static string pathInput1 = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice15and16/input1.txt";
        private static string pathInput2 = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice15and16/input2.txt";
        private static string pathOutput = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice15and16/output.txt";


        // Задача 1
        private static List<Int32> Input1()
        {
            List<Int32> list = new List<Int32>();

            using(StreamReader reader = new StreamReader(pathInput1))
            {
                char[] separators = {' ', '\n', '\r', '\t'};
                string[] numbers = reader.ReadToEnd().Split(separators);

                foreach(var number in numbers)
                {
                    list.Add(Convert.ToInt32(number));
                }
            }

            return list;
        }


        public static void Task1()
        {
            List<Int32> list = Input1();

            // LINQ
            var resultLINQ = from n in list
                         orderby n
                         where n < 0
                         select n * -1;

            foreach(var number in resultLINQ)
            {
                Console.Write(number + " ");
            }

            Console.Write("\n\n\n");


            // Ext

            var resultExt = list.OrderBy(n => n).Where(n => n < 0).Select(n => n * -1);

            foreach (var number in resultExt)
            {
                Console.Write(number + " ");
            }
        }


        // Задача 2

        struct Student
        {
            string lastname;
            string department;
            public int course;
            int group;

            public int exMath;
            public int exCS;
            public int exEconomy;

            public Student(string lastname, string department, int course, int group, int exMath, int exCS, int exEconomy)
            {
                this.lastname = lastname;
                this.department = department;
                this.course = course;
                this.group = group;
                this.exMath = exMath;
                this.exCS = exCS;
                this.exEconomy = exEconomy;
            }

            override
            public string ToString()
            {
                return String.Format("{0} {1} {2} {3} {4} {5} {6}",
                    lastname, department, course, group, exMath, exCS, exEconomy);
            }
        }

        private static List<Student> Input2()
        {
            List<Student> list = new List<Student>();

            using (StreamReader reader = new StreamReader(pathInput2))
            {
                char[] sep = { ' ', '\t' };
                string line;
                string[] args;

                while((line = reader.ReadLine()) != null)
                {
                    args = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                    list.Add(new Student(args[0], args[1], Convert.ToInt32(args[2]), Convert.ToInt32(args[3]),
                        Convert.ToInt32(args[4]), Convert.ToInt32(args[5]), Convert.ToInt32(args[6])));
                }
            }

            return list;
        }

        public static void Task2()
        {
            List<Student> list = Input2();

            var resultLINQ = from n in list
                             orderby n.course
                             where (n.exMath == 2 || n.exCS == 2 || n.exEconomy == 2)
                             select n;

            var resultExt = list.OrderBy(n => n.course).Where(n => (n.exMath == 2 || n.exCS == 2 || n.exEconomy == 2)).Select(n => n);

            using(StreamWriter writer = new StreamWriter(pathOutput))
            {
                writer.WriteLine("LINQ:");

                foreach (var item in resultLINQ)
                {
                    writer.WriteLine(item);
                }

                writer.WriteLine("\nExt:");

                foreach (var item in resultExt)
                {
                    writer.WriteLine(item);
                }
            }

        }
    }
}
