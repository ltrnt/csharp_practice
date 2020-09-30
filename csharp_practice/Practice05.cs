using System;
using System.Threading;

namespace csharp_practice
{
    public class Practice05
    {
        // Finding the nearest number with the same sum of odd digits
        public static int FindSameSumOfOddDigits(int number, int counter = 1, int sumOfOddDigits = -1)
        {
            if (sumOfOddDigits < 0) sumOfOddDigits = SumOfOddDigits(number);

            if (SumOfOddDigits(number + counter) == sumOfOddDigits) return number + counter;
            if (SumOfOddDigits(number - counter) == sumOfOddDigits) return number - counter;

            return FindSameSumOfOddDigits(number, ++counter, sumOfOddDigits);
        }

        public static bool IsPrimeNumber(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0)
                    return false;

            return number != 0;
        }

        public static int SumOfOddDigits(int number)
        {
            int sum = 0;

            for (; number != 0; number /= 10)
                if (number % 2 == 1) sum += number % 10;

            return sum;
        }

        public static void Task2_5()
        {
            const int numberOfValues = 4;
            int[] values = new int[numberOfValues]; // [0] = a, [1] = b, [2] = C, [3] = A

            Console.Write("Enter a, b, C, A separated by space: ");
            string[] enteredValues = Console.ReadLine().Split(' ');

            for (int i = 0; i < numberOfValues; i++) values[i] = Convert.ToInt32(enteredValues[i]);

            int a = values[0], b = values[1], C = values[2], A = values[3];

            if (a > b) a = Interlocked.Exchange(ref b, a);

            // Solution 'A'
            for (int i = a; i <= b; i++)
                Console.Write(i + " - " + SumOfOddDigits(i) + "; ");

            Console.Write("\n\n");

            // Solution 'B'
            for (int i = a; i <= b; i++)
                if (SumOfOddDigits(i) == C)
                    Console.Write(i + "; ");

            Console.Write("\n\n");

            // Solution 'C'
            for (int i = a; i <= b; i++)
                if (IsPrimeNumber(SumOfOddDigits(i)))
                    Console.Write(i + "; ");

            Console.Write("\n\n");

            // Solution 'D'
            Console.WriteLine(FindSameSumOfOddDigits(A));
        }
    }
}
