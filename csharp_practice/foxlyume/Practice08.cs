using System;
using System.Text;

namespace csharp_practice.foxlyume
{
    public class Practice08
    {

        public static void Task3_5()
        {
            // Дана строка, в которой содержится осмысленное текстовое сообщение. Слова сообщения разделяются пробелами и знаками препинания.
            // 5. Удалить из сообщения все слова, которые заканчиваются на заданный символ.

            /*  
             *  Считываем строку в тип string. Именно в string, а не в StringBuilder, 
             *  потому что в последующем её нужно будет разделить на слова с помощью Split(), который StringBuilder не поддерживает.
             *  
             *  Разделяем строку, слова сохраняем в массив строк.
             *  
             *  Создаем объект StringBuilder, инициализируем его исходной строкой.
             *  В процессе работы, мы можем часто изменять строку. StringBuilder делает это с меньшей затратой памяти,
             *  так как не создает каждый раз новый обьект, в отличие от обычных строк.
             *  
             *  В цикле мы проходим по всем словам в массиве строк и у каждого слова проверяем последнюю букву.
             *  Если последняя буква равна заданному символу, то используем Replace(), чтобы заменить это слово на пустую строку в нашем обьекте.
             * 
             *  Выводим результат.
             */

            Console.WriteLine("Enter line: ");
            string line = Console.ReadLine();

            Console.Write("Enter symbol: ");
            char symbol = Convert.ToChar(Console.ReadLine());

            // Массив разделителей. Нужен для метода Split().
            char[] separators = { '.', ',', '!', '?', ':', ';', ' ' };

            // StringSplitOptions.RemoveEmptyEntries - этот параметр означает, что в полученном массиве не будет пустых обьектов.
            string[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder resultLine = new StringBuilder(line);

            for (int i = 0; i < words.Length; i++)
            {
                // words[i] - это слово по индексу i.
                // words[i][words[i].Length - 1] -  это последняя буква в слове по индексу i.
                if (words[i][words[i].Length - 1].Equals(symbol))
                {
                    resultLine.Replace(words[i], "");
                }
            }

            Console.WriteLine(resultLine.ToString());
        }
    }
}
