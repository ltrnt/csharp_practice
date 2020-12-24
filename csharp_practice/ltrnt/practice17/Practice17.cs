using System;

using System.Collections.Generic;
using System.Text;

namespace csharp_practice.ltrnt.practice17
{
    public class Practice17
    {
        public static void Task8()
        {
            // Testing

            MyString obj1 = new MyString('r', 20);
            MyString obj2 = new MyString();
            MyString obj3 = "hello123 world12345";

            Console.WriteLine(obj1);
            Console.WriteLine(obj2);
            Console.WriteLine(obj3);


            Console.WriteLine(obj3.CountDigits());

            obj3.FindLongestChars();

            Console.WriteLine();
            obj3.PrintOneChar();
            Console.WriteLine();

            Console.WriteLine(obj3[3]);

            Console.WriteLine(!obj3);
            Console.WriteLine();

            if (obj3) Console.WriteLine("1 done");

            if (obj3 & obj1) Console.WriteLine("& true");
            else Console.WriteLine("& false");


            string line = obj1;

            Console.WriteLine(line);

        }

        public class MyString
        {
            private string line;

            public MyString()
            {
            }

            public MyString(char a, int n)
            {
                StringBuilder sb = new StringBuilder(n + 1);

                for (int i = 0; i < n; i++)
                {
                    sb.Append(a);
                }

                Line = sb.ToString();
            }

            public string Line { get => line; set => line = value; }
            public int Length { get => line.Length; }

            public char this[int i]
            {
                get
                {
                    if(i >= 0 && i < line.Length)
                    {
                        return line[i];
                    }
                    else
                    {
                        Console.WriteLine("Недопустимый индекс");
                        return ' ';
                    }
                }
            }

            public static bool operator !(MyString myString)
            {
                return myString != null && myString.Length != 0;
            }

            public static bool operator true(MyString myString)
            {
                int i = 0;
                int j = myString.Length - 1;

                while(i <= j)
                {
                    if (myString[i] != myString[j]) return false;

                    i++;
                    j--;
                }

                return true;
            }

            public static bool operator false(MyString myString)
            {
                int i = 0;
                int j = myString.Length - 1;

                while (i <= j)
                {
                    if (myString[i] != myString[j]) return true;

                    i++;
                    j--;
                }

                return false;
            }

            public static bool operator &(MyString str1, MyString str2)
            {
                if(str1.Length == str2.Length)
                {
                    for (int i = 0; i < str1.Length; i++)
                    {
                        if (char.ToLower(str1[i]) != char.ToLower(str2[i])) return false;
                    }

                    return true;
                }

                return false;
            }

            public static implicit operator string(MyString str)
            {
                if (str.Line != null)
                {
                    return string.Copy(str.Line);
                }
                else return "";
                
            }

            public static implicit operator MyString(string str)
            {
                MyString newString = new MyString();
                newString.Line = str;

                return newString;
            }

            // Количество цифр в строке
            public int CountDigits()
            {
                int counter = 0;

                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsDigit(line[i])) counter++;
                }

                return counter;
            }

            public void PrintOneChar()
            {
                Dictionary<char, int> map = new Dictionary<char, int>();

                for (int i = 0; i < line.Length; i++)
                {
                    if (map.ContainsKey(line[i]))
                    {
                        map[line[i]] = map[line[i]] + 1;
                    }
                    else
                    {
                        map.Add(line[i], 1);
                    }
                }

                foreach (var item in map)
                {
                    if (item.Value == 1) Console.Write(item.Key + " ");
                }
            }

            public void FindLongestChars()
            {
                if (line.Length == 0) return;
                else if (line.Length == 1)
                {
                    Console.WriteLine(line[0]);
                    return;
                }


                int maxLenght = 0;
                int maxIndex = 0;

                int currentLenght = 1;
                int currentIndex = 0;

                for (int i = 1; i < line.Length; i++)
                {
                    if(line[i] == line[i - 1])
                    {
                        currentLenght++;
                    }
                    else
                    {
                        if(currentLenght > maxLenght)
                        {
                            maxLenght = currentLenght;
                            maxIndex = currentIndex;
                        }

                        currentLenght = 1;
                        currentIndex = i;
                    }
                }

                for (int i = maxIndex; i < maxIndex+maxLenght; i++)
                {
                    Console.Write(line[i]);
                }
            }
        }
    }
}
