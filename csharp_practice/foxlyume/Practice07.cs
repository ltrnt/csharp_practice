﻿using System;
namespace csharp_practice.foxlyume
{
    public class Practice07
    {
        public static void Task6_5()
        {
            // В массиве размером n×n, элементы которого – целые числа, произвести следующие действия:
            // Вставить строку из нулей после всех строк, в которых нет ни одного нуля.

            /* 
             * В решении используется ступенчатый массив, т.к. с его помощью проще переставлять строки местами. (Нужно изменить лишь ссылки)
             * Создаем массив с количеством строк в два раза больше n, чтобы хватило места, если придется вставлять новую строку после каждой исходной строки.
             * Заполняем массив.
             * Проходим по массиву и ищем строки, в которых нет ни одного нуля.
             * В случае нахождения такой строки, сдвигаем все последующие строки на единицу. вставляем на свободное место нулевую строку.
             * Выводим результирующий массив.
             */


            // n - количество строк. Может изменяться.
            // m - количество столбцов. Остается неизменным всю программу.

            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = n;

            int[][] arr = new int[n * 2][];

            for (int i = 0; i < n; i++)
            {
                arr[i] = new int[m];

                // Для каждой строчки значения записываются через пробел.
                string[] values = Console.ReadLine().Split(' ');

                for (int j = 0; j < m; j++)
                {
                    arr[i][j] = Convert.ToInt32(values[j]);
                }
            }

            // Поиск строк без нулей и вставка нулевой строки после них.
            bool check; // Флаг. Будет равен true, если строка без нулей.
            for (int i = 0; i < n; i++)
            {
                check = true;

                for (int j = 0; j < m; j++)
                {
                    if(arr[i][j] == 0)
                    {
                        check = false;
                        break;
                    }
                }

                // Смещение строк на единицу и вставка нулевой строки.
                if (check)
                {

                    // Смещение.
                    for (int j = n; j > i; j--)
                    {
                        arr[j] = arr[j - 1];
                    }

                    // Создание нового подмассива, который заполнится нулями.
                    arr[i + 1] = new int[m];

                    // Вставка.
                    for (int j = 0; j < m; j++)
                    {
                        arr[i + 1][j] = 0;
                    }

                    // Увеличение счетчика количества строк.
                    n++;
                }
            }


            // Вывод результата.
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
