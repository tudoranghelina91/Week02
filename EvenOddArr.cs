using System;

namespace EvenOddArrApplication
{
    class EvenOddArr
    {
        static void PrintEvenOddArrays(ref int[] evenArr, int evenArrLen, ref int[] oddArr, int oddArrLen, ref int arrLen)
        {
            Console.Write("Even: ");
            for (int i = 0; i < evenArrLen; i++)
            {
                Console.Write(evenArr[i] + " ");
            }

            Console.WriteLine();

            Console.Write("Odd: ");
            for (int i = 0; i < oddArrLen; i++)
            {
                Console.Write(oddArr[i] + " ");
            }

            Console.WriteLine();
        }

        static void SeparateArrays(ref int[] arr, int arrLen, ref int[] evenArr, ref int evenArrLen, ref int[] oddArr, ref int oddArrLen)
        {
            for (int i = 0; i < arrLen; i++)
            {
                if (arr[i] % 2 == 0) {
                    evenArr[evenArrLen++] = arr[i];
                } else {
                    oddArr[oddArrLen++] = arr[i];
                }
            }
        }
        static void Ask(ref int arrLen)
        {
            Console.WriteLine("Do you want to print another array? Y - Yes, N - No");
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key.Equals(ConsoleKey.Y)) {
                LengthInput(ref arrLen);
            } else if (cki.Key.Equals(ConsoleKey.N)) {
                Console.WriteLine("Program will now exit...");
            } else if (!cki.Key.Equals(ConsoleKey.N) && !cki.Key.Equals(ConsoleKey.Y)) {
                Ask(ref arrLen);
            }
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
        }

        static void LengthInput(ref int arrLen)
        {
            int[] arr = new int[100];
            int[] evenArr = new int[100];
            int[] oddArr = new int[100];
            int lastFailIndex = 0;
            int evenArrLen = 0, oddArrLen = 0; 

            try {
                Console.Write("Array Length: ");
                arrLen = Convert.ToInt32(Console.ReadLine());
                ElementsInput(ref arr, arrLen, ref lastFailIndex);
                SeparateArrays(ref arr, arrLen, ref evenArr, ref evenArrLen, ref oddArr, ref oddArrLen);
                PrintEvenOddArrays(ref evenArr, evenArrLen, ref oddArr, oddArrLen, ref arrLen);
                Ask(ref arrLen);
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