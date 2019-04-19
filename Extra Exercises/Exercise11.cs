using System;

namespace Exercise11Application
{
    class Exercise1
    {
        static void PrintArray(ref int[] arr, int arrLen)
        {
            for (int i = 0; i < arrLen; i++)
            {
                if (i < arrLen - 1) {
                    Console.Write(arr[i] + " ");
                } else {
                    Console.Write(arr[i]);
                }
            }
            Console.WriteLine();
        }
        static void RemoveElement(int index, ref int[] arr, ref int arrLen, ref int[] arrOfIndexes, ref int arrOfIndexesLen)
        {
            for (int i = 0; i < arrOfIndexesLen; i++)
            {
                for (int j = arrOfIndexes[i]; j < arrLen-1; j++)
                {
                    arr[j] = arr[j+1];
                }
                arrLen--;
            }
        }

        static void Exit()
        {
            Console.WriteLine("The program will now exit...");
        }

        static void Ask(ref int arrLen)
        {
            Console.WriteLine("Do you want to delete another element from another array's? Y - Yes, N - No");
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key.Equals(ConsoleKey.Y)) {
                LengthInput(ref arrLen);
            } else if (cki.Key.Equals(ConsoleKey.N)) {
                Exit();
            } else {
                Ask(ref arrLen);
            }
        }

        static void FindIndex (int index, int arrValue, ref int[] arr, ref int[] arrOfIndexes, int arrLen, ref int arrOfIndexesLen)
        {
            for (int i = 0; i < arrLen; i++)
            {
                if (arr[i] == arrValue)
                {
                    arrOfIndexes[arrOfIndexesLen] = i;
                    arrOfIndexesLen++;
                }
            }
        }

        static void ReadElement(ref int index, ref int arrValue)
        {
            Console.Write("Type in the name of the element that you want to retrieve the index(es) for: ");
            try {
                arrValue = Convert.ToInt32(Console.ReadLine());
            } catch {
                Console.WriteLine("INVALID INPUT! MUST BE A INTEGER!");
                ReadElement(ref index, ref arrValue);
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
            int[] arrOfIndexes = new int[100];
            int lastFailIndex = 0;
            int arrOfIndexesLen = 0;
            int index = 0;
            int arrValue = 0;

            try {
                Console.Write("Array Length: ");
                arrLen = Convert.ToInt32(Console.ReadLine());
                ElementsInput(ref arr, arrLen, ref lastFailIndex);
                ReadElement(ref index, ref arrValue);
                FindIndex(index, arrValue, ref arr, ref arrOfIndexes, arrLen, ref arrOfIndexesLen);
                RemoveElement(index, ref arr, ref arrLen, ref arrOfIndexes, ref arrOfIndexesLen);
                PrintArray(ref arr, arrLen);
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