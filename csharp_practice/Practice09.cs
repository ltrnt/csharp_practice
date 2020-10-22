using System;
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
            string path = "/Users/ltrnt/Projects/csharp_practice/csharp_practice";

            char check_symbol = Convert.ToChar(Console.Read());

            using (FileStream fileIn = new FileStream(path + "/file05_20_in", FileMode.Open, FileAccess.Read))
            {
                using (FileStream fileOut = new FileStream(path + "/file05_20_out", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    int symbol = -1;
                    int current_symbol = -1;
                    while ((current_symbol = fileIn.ReadByte()) != -1)
                    {
                        if (symbol < 0)
                        {
                            continue;
                        }
                        else if ((char)current_symbol == check_symbol)
                        {
                            fileOut.WriteByte((byte)symbol);
                        }

                        symbol = current_symbol;
                    }
                }
            }
        }

    }
}
