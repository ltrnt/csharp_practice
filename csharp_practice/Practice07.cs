using System;
namespace csharp_practice
{
    public class Practice07
    {
        public static void Task4_20()
        {
            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] arr = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string[] numbers = Console.ReadLine().Split(' ');

                for (int j = 0; j < n; j++) arr[i, j] = Convert.ToInt32(numbers[j]);
            }

            int[,] result = new int[n, 2];

            for (int i = 0; i < n; i++) result[i, 0] = result[i, 1] = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j, i] == arr[j + 1, i])
                    {
                        result[i, 0] = j;
                        result[i, 1] = j + 1;
                        break;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i + "-й столбец: " + result[i, 0] + " " + result[i, 1]);
            }
        }

        public static void Task5_9()
        {
            // В одномерном массиве, элементы которого – целые числа, произвести следующие действия:
            // Вставить новый элемент перед всеми четными элементами.

            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n * 2];

            string[] numbers = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
                arr[i] = Convert.ToInt32(numbers[i]);

            for (int i = 0; i < n; i++)
            {
                if(arr[i] % 2 == 0)
                {
                    for (int j = n; j > i; j--)
                        arr[j] = arr[j - 1];

                    arr[i + 1] = -1;
                    n++;
                    i++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }


        public static void Task6_5()
        {
            // В массиве размером n×n, элементы которого – целые числа, произвести следующие действия:
            // Вставить строку из нулей после всех строк, в которых нет ни одного нуля.

            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = n;

            int[][] arr = new int[n * 2][];

            bool check;

            for (int i = 0; i < n; i++)
            {
                check = false;

                string[] values = Console.ReadLine().Split(' ');

                arr[i] = new int[m];

                for (int j = 0; j < m; j++)
                {
                    arr[i][j] = Convert.ToInt32(values[j]);
                    if (arr[i][j] == 0) check = true;
                }

                if (!check)
                {
                    arr[i + 1] = new int[m];

                    for (int j = 0; j < m; j++)
                        arr[i + 1][j] = 0;

                    n++;
                    i++;
                }
            }

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
