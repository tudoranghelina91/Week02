using System;

namespace ReverseArrayApplication
{
    class ReverseArray
    {
        static void ArrayReverse(ref int[] arr, int arrLen)
        {
            int j = 0;
            for (int i = 0; i < arrLen/2; i++)
            {
                j = arrLen-i-1;
                arr[i] += arr[j];
                arr[j] = arr[i] - arr[j];
                arr[i] -= arr[j];
            }
        }

        static void Ask(ref int arrLen)
        {
            Console.WriteLine("Do you want to reverse another array? Y - Yes, N - No");
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key.Equals(ConsoleKey.Y)) {
                LengthInput(ref arrLen);
            } else if (cki.Key.Equals(ConsoleKey.N)) {
                Console.WriteLine("Program will now exit...");
            } else if (!cki.Key.Equals(ConsoleKey.N) && !cki.Key.Equals(ConsoleKey.Y)) {
                Ask(ref arrLen);
            }
        }
        
        static void PrintArray(ref int[] arr, int arrLen)
        {
            Console.WriteLine("The values you have entered are as per below after the reversal...");
            for (int i = 0; i < arrLen; i++)
            {
                Console.WriteLine("[{0}]: {1}", i, arr[i]);
            }

            Ask(ref arrLen);
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

            ArrayReverse(ref arr, arrLen);
            PrintArray(ref arr, arrLen);
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