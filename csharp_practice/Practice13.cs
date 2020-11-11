using System;
using System.Text.RegularExpressions;

namespace csharp_practice
{
    public class Practice13
    {
        // TODO Нужно протестировать.
        public static void Task_4()
        { // Задание 4

            string line = Console.ReadLine();

            Regex regex = new Regex(@"(((([0][1-9])|([12]\d)|([3][012]))[.](([1][012])|([0][013456789])))|((([0][1-9])|([1]\d)|([2][1-9])[.](([1][012])|([0][2]))))[.](([1][9]\d{2})|([2][0][01][0-8])))");

            MatchCollection targets = regex.Matches(line);

            Console.WriteLine("Количество совпадений: " + targets.Count);

            foreach (var item in targets)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
