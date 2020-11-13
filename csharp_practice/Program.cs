using System;
using System.Collections;
using System.Collections.Generic;

namespace csharp_practice
{
    //class MainClass
    //{
    //    public static void Main(string[] args)
    //    {
    //        SortedList list = new SortedList();

    //        list.Add("B", 2);
    //        list.Add("A", 1);

    //        list["D"] = 4;
    //        list["C"] = 3;

    //        foreach(DictionaryEntry entry in list)
    //        {
    //            Console.WriteLine("{0}\t{1}", entry.Key, entry.Value);
    //        }

    //        // Вывод:
    //        // A   1
    //        // B   2
    //        // C   3
    //        // D   4
    //    }
    //}

    class MainClass
    {
        public static void Main(string[] args)
        {
            SortedList<String, Int32> list = new SortedList<String, Int32>();

            list.Add("B", 2);
            list.Add("A", 1);

            list["D"] = 4;
            list["C"] = 3;

            foreach (KeyValuePair<String, Int32> entry in list)
            {
                Console.WriteLine("{0}\t{1}", entry.Key, entry.Value);
            }

            // Вывод:
            // A   1
            // B   2
            // C   3
            // D   4
        }
    }

}
