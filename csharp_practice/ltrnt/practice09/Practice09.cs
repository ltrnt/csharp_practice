using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace csharp_practice
{
    public class Practice09
    {
        public Practice09()
        {
        }

        public static void Task2_20()
        {
            // Дан файл, компонентами которого являются символы.
            // Переписать в новый файл все символы, за которыми в первом файле следует данная буква.
            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice09";

            Console.Write("Enter target symbol: ");
            char target = Convert.ToChar(Console.ReadLine());

            using(StreamReader fileIn = new StreamReader(path + "/file09_20_in.txt"))
            {
                using (StreamWriter fileOut = new StreamWriter(path + "/file09_20_out.txt"))
                {
                    char[] sep = { ' ', '\n', '\t', '\r'};
                    string[] values = fileIn.ReadToEnd().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    char last = Convert.ToChar(values[0]);

                    for (int i = 1; i < values.Length; i++)
                    {
                        if (Convert.ToChar(values[i]).Equals(target))
                        {
                            fileOut.Write(last);
                            fileOut.Write(" ");
                        }

                        last = Convert.ToChar(values[i]);
                    }
                }
            }
           
        }

    }
}
