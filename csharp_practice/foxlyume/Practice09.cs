using System;
using System.IO;
using System.Text;

namespace csharp_practice.foxlyume
{
    public class Practice09
    {
        public static void Task2_5()
        {
            // Работа с символьными потоками.
            // Даны два файла с числами. Получить новый файл, каждый компонент которого равен
            // наибольшему из соответствующих компонентов заданных файлов
            // (количеств компонентов в исходных файлах одинаковое).

            /*
             * ВАЖНО:
             *      1) Создать три файла с именами practice09_file1.txt, practice09_file2.txt и practice09_file3.txt в текущей папке.
             *      2) Указать адрес в перменной path до ТЕКУЩЕЙ папки.
             *      3) В случае, если будет ошибка связанная с тем, что файл не найден - замени / на \.
             * 
             *  С помощью using создаем потоки для чтения и записи файлов.
             *  
             *  Считываем из двух файлов полностью всю строку.
             *  
             *  Разбиваем её по пробелу методом Split().
             *  
             *  В цикле сравниваем элементы из двух файлов, наибольший из пары записываем в результирующий файл.
             */

            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/foxlyume";

            using (StreamReader file1 = new StreamReader(path + "/practice09_file1.txt"))
            {
                using (StreamReader file2 = new StreamReader(path + "/practice09_file2.txt"))
                {
                    using (StreamWriter file3 = new StreamWriter(path + "/practice09_file3.txt", false))
                    {
                        string[] arr1 = file1.ReadToEnd().Split(' ');
                        string[] arr2 = file2.ReadToEnd().Split(' ');

                        int a, b;

                        for (int i = 0; i < arr1.Length; i++)
                        {
                            a = Convert.ToInt32(arr1[i]);
                            b = Convert.ToInt32(arr2[i]);

                            if (a > b) file3.Write(a);
                            else file3.Write(b);

                            file3.Write(" ");
                        }
                    }
                }
            }
        }
    }
}
