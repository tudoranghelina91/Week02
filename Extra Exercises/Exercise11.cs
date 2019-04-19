using System;

namespace Exercise11Application
{
    class Exercise11
    {
        static void Exit()
        {
            Console.WriteLine("Program will now exit...");
        }
        static void Ask(ref int arrLen)
        {
            Console.WriteLine("Do you want to perform other operations? Y / N");
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if(cki.Key.Equals(ConsoleKey.Y)) {
                Console.WriteLine();
                LengthInput(ref arrLen);
            } else if (cki.Key.Equals(ConsoleKey.N)) {
                Console.WriteLine();
                Exit();
            } else {
                Ask(ref arrLen);
            }
        }

        static void PrintArray(ref int[] arr, int arrLen)
        {
            Console.Write("Array after removal of elements: ");
            for (int i = 0; i < arrLen; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }

        static void ReadElement(ref int x)
        {
            try {
                Console.Write("Value to be removed: ");
                x = Convert.ToInt32(Console.ReadLine());
            } catch {
                Console.WriteLine("INVALID INPUT VALUE! USE AN INTEGER");
            }
        }

        static void RemoveElement(int x, ref int[] arr, ref int arrLen)
        {
            for (int i = 0; i < arrLen; i++)
            {
                if (arr[i] == x) {
                    if (i != arrLen-1) {
                        for (int j = i + 1; j < arrLen; j++)
                        {
                            arr[j-1] = arr[j];
                        }
                    }
                    arrLen--;
                }
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
            try {
                Console.Write("Array Length: ");
                arrLen = Convert.ToInt32(Console.ReadLine());
                if (arrLen == 0) {
                    Console.WriteLine("TYPE AN INTEGER GREATER THAN 0");
                    LengthInput(ref arrLen);

                }
                int[] arr = new int[arrLen];
                int lastFailIndex = 0;
                int x = 0;
                ElementsInput(ref arr, arrLen, ref lastFailIndex);
                ReadElement(ref x);
                RemoveElement(x, ref arr, ref arrLen);
                PrintArray(ref arr, arrLen);
                Ask(ref arrLen);
            } catch {
                Console.WriteLine("INVALID INPUT VALUE! MUST BE A INTEGER!");
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