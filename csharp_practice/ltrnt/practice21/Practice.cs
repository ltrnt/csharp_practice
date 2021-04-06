using System;
using System.IO;

namespace csharp_practice.ltrnt.practice21
{
    public class Practice
    {
        public static string pathToInput = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice21/input.txt";

        public Practice()
        {
        }

        public static void Task2()
        {
            BinaryTree tree = new BinaryTree();
            Input(ref tree);

            Console.WriteLine(tree.IsPerfectlyBalancedTree());

            tree.IsPossibleToAddValueToPerfectlyBalancedTree();
        }

        private static void Input(ref BinaryTree tree)
        {
            // Start of reading data
            using (StreamReader reader = new StreamReader(pathToInput))
            {
                string line = "";
                string[] values;
                char[] separators = { ' ', '\t', '\r', '\n' };

                while ((line = reader.ReadLine()) != null)
                {
                    values = line.Split(separators);

                    foreach (var value in values)
                    {
                        tree.Add(Convert.ToInt32(value));
                    }
                }
            }
            // End of reading data
        }

    }
}
