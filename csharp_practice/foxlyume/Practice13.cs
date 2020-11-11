using System;
using System.IO;
using System.Text.RegularExpressions;

namespace csharp_practice.foxlyume
{
    public class Practice13
    {
        public static void Task_2()
        {
            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/foxlyume";

            Regex regex = new Regex(@"(?<=[^\d\.])(-?(([1-9]\d*)|[0-9])(?:\.\d*[1-9])?)(?=[^\d\.])");

            using (StreamReader fileIn = new StreamReader(path + "/practice13_in.txt"))
            {
                String line = fileIn.ReadLine();

                MatchCollection targets = regex.Matches(line);

                using (StreamWriter fileOut = new StreamWriter(path + "/practice13_out.txt"))
                {
                    fileOut.WriteLine("Количество совпадений: " + targets.Count);

                    foreach (var item in targets)
                    {
                        fileOut.Write(item + " ");
                    }
                }
            }
        }
    }
}
