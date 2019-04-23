using System;

namespace Exercise13Application
{
    class Exercise13
    {
        static int MinValue(ref int[] arr, int arrLen)
        {
            int min = arr[0];

            for (int i = 1; i < arrLen; i++)
            {
                if (arr[i] < min) {
                    min = arr[i];
                }
            }

            return min;
        }

        static int MaxValue(ref int[] arr, int arrLen)
        {
            int max = arr[0];
            for (int i = 1; i < arrLen; i++)
            {
                if (arr[i] > max) {
                    max = arr[i];
                }
            }

            return max;
        }

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

        static void ReadElement(ref int x)
        {
            try {
                Console.Write("Value to be added: ");
                x = Convert.ToInt32(Console.ReadLine());
            } catch {
                Console.WriteLine("INVALID INPUT VALUE! USE AN INTEGER");
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

                ElementsInput(ref arr, arrLen, ref lastFailIndex);
                Console.WriteLine("The minimum value in the array is {0} and the maximum value is {1}", MinValue(ref arr, arrLen), MaxValue(ref arr, arrLen));
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