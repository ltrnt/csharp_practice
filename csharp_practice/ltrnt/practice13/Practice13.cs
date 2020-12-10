using System;
using System.IO;
using System.Text.RegularExpressions;

namespace csharp_practice.ltrnt.practice13
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

                    // TODO Добавить проверку для февраля
                    // TODO Добавить провеку для високосного года
                    Regex regex = new Regex(@"((3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:18|19|20)\d{2})*)");

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
