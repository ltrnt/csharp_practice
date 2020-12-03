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

                    //Regex regex = new Regex(@"(((([0][1-9])|([12]\d)|([3][012]))[.](([1][012])|([0][013456789])))|((([0][1-9])|([1]\d)|([2][1-9])[.](([1][012])|([0][2]))))[.](([1][9]\d{2})|([2][0][01][0-8])))");
                    //Regex regex = new Regex(@"(0?[1-9]|[12][0-9]|3[01])\.(0?[1-9]|1[012])\.((19|20)\\d\\d)$");
                    Regex regex = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");

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
