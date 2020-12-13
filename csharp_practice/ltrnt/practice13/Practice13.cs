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

                    
                    Regex regex = new Regex(@"((3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:18|19|20)\d{2})*)");
                    // Regex regex = new Regex(@"(((0[1-9]|[12][0-8])[\.](0[1-9]|1[012]))|((29|30|31)[\.](0[13578]|1[02]))|((29|30)[\.](0[4,6,9]|11)))[\.](19|[2-9][0-9])\d\d|(29[\.]02[\.](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96))");

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
