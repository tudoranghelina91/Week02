using System;

namespace Exercise9Application
{
    class Exercise9
    {
        static void Exit()
        {
            Console.WriteLine("The program will now exit...");
        }

        static void Ask(ref int arrLen)
        {
            Console.WriteLine("Do you want to calculate the average of another array's elements? Y - Yes, N - No");
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key.Equals(ConsoleKey.Y)) {
                LengthInput(ref arrLen);
            } else if (cki.Key.Equals(ConsoleKey.N)) {
                Exit();
            } else {
                Ask(ref arrLen);
            }
        }

        static void ShowResult (decimal average)
        {
            Console.WriteLine("The average of all of the array elements is {0}", average);
        }

        static decimal CalculateAverage(decimal sum, decimal arrLen)
        {
            return sum/arrLen;
        }

        static int CalculateSum(ref int[] arr, int arrLen)
        {
            int sum = 0;

            for (int i = 0; i < arrLen; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        static void ElementsInput(ref int[] arr, int arrLen, ref int lastFailIndex)
        {
            for (int i = lastFailIndex; i < arrLen; i++)
            {
                try
                {
                    Console.Write("Element [{0}]: ", i);
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                } catch {
                    Console.WriteLine("INVALID INPUT VALUE! PLEASE USE AN INTEGER!");
                    lastFailIndex = i--;
                }
            }

            int sum = CalculateSum(ref arr, arrLen);
            decimal avg = CalculateAverage((decimal)sum, (decimal)arrLen);
            ShowResult(avg);
            Ask(ref arrLen);
        }

        static void LengthInput(ref int arrLen)
        {
            int[] arr = new int[100];
            int lastFailIndex = 0;

            try {
                Console.Write("Array Length: ");
                arrLen = Convert.ToInt32(Console.ReadLine());
                ElementsInput(ref arr, arrLen, ref lastFailIndex);
            } catch {
                Console.WriteLine("INVALID INPUT! LENGTH MUST BE AN INTEGER");
                LengthInput(ref arrLen);
            }
        }

        static void Main()
        {
            int arrLen = 0;
            LengthInput(ref arrLen);
        }
    }
}