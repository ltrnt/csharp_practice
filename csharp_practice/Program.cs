using System;
using System.Collections;
using System.Collections.Generic;

namespace csharp_practice
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //foxlyume.Practice14.Task2_4();
            Practice13.Task_4();

            Regex regex1 = new Regex(@"(((([0][1-9])|([12]\d)|([3][012]))[.](([1][012])|([0][013456789])))|((([0][1-9])|([1]\d)|([2][1-9])[.](([1][012])|([0][2]))))[.](([1][9]\d{2})|([2][0][01][0-8])))");


        }
    }
}
