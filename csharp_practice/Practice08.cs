using System;
namespace csharp_practice
{
    public class Practice08
    {
        static int CompareLength(string a, string b)
        {
            return a.Length.CompareTo(b.Length);
        }

        public static void Task3_20()
        {
            // Дана строка, в которой содержится осмысленное текстовое сообщение. Слова сообщения разделяются пробелами и знаками препинания.
            // Вывести слова сообщения в порядке возрастания их длин.

            char[] separators = {'.', ',', ' ', '!', '?', ':', ';'};

            string[] words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Comparison<string> comparison = new Comparison<string>(CompareLength);

            Array.Sort(words, comparison);

            foreach (var item in words)
                Console.Write(item + " ");
            
        }
    }
}
