using System;

namespace Homework2Application
{
    class Homework2
    {
        static void DisplayFrequency(ref int[] freqArray, int freqArrayLen)
        {
            for (int i = 0; i < freqArrayLen; i++)
                if (freqArray[i] > 0) {
                    if (freqArray[i] == 1) {
                        Console.WriteLine("{0} appears {1} time", i, freqArray[i]);
                    } else {
                        Console.WriteLine("{0} appears {1} times", i, freqArray[i]);
                    }
                }
        }

        static void DetermineFrequency(ref int[] arr, int arrLen, ref int[] freqArray, int freqArrayLen)
        {
            for (int i = 0; i < arrLen; i++)
            {
                freqArray[arr[i]]++;
            }
        }

        static int GenerateFrequencyArraySize(ref int[] arr, int arrLen)
        {
            int maxFrequencyArraySize = 0;
            for (int i = 0; i < arrLen; i++)
            {
                if (arr[i] > maxFrequencyArraySize){ 
                    maxFrequencyArraySize = arr[i];
                }
            }

            return maxFrequencyArraySize + 1;
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

            int freqArrayLen = GenerateFrequencyArraySize(ref arr, arrLen);
            int[] freqArray = new int[freqArrayLen];
            DetermineFrequency(ref arr, arrLen, ref freqArray, freqArrayLen);
            DisplayFrequency(ref freqArray, freqArrayLen);
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