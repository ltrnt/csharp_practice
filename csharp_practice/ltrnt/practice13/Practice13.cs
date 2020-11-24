using System;
using System.IO;
using System.Text.RegularExpressions;

namespace csharp_practice
{
    public class Practice13
    {
        
        public static void Task_4()
        {
            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice13";

            using (StreamReader fileIn = new StreamReader(path + "/practice13_in.txt"))
            {
                using (StreamWriter fileOut = new StreamWriter(path + "/practice13_out.txt"))
                {
                    string line = fileIn.ReadLine();

                    Regex regex = new Regex(@"(((([0][1-9])|([12]\d)|([3][012]))[.](([1][012])|([0][013456789])))|((([0][1-9])|([1]\d)|([2][1-9])[.](([1][012])|([0][2]))))[.](([1][9]\d{2})|([2][0][01][0-8])))");

                    MatchCollection targets = regex.Matches(line);

                    fileOut.WriteLine("Количество совпадений: " + targets.Count);

                    foreach (var item in targets)
                    {
                        fileOut.WriteLine(item);
                    }

                }
            }  
        }
    }
}
