using System;

namespace Exercise12Application
{
    class Exercise12
    {
        static void InsertElement(int x, ref int[] arr, ref int arrLen, int position)
        {
            arrLen++;

            for (int i = arrLen-1; i > position; i--)
            {
                arr[i] = arr[i-1];
            }

            arr[position] = x;
        }

        static void ReadPosition(ref int position, int arrLen)
        {
            try {
                Console.Write("Position in array to which element must be added: ");
                position = Convert.ToInt32(Console.ReadLine());
                if (position > arrLen-1)
                {
                    Console.WriteLine("POSTION MUST BE AN INTEGER FROM 0 to ARRAY LENGTH");
                    ReadPosition(ref position, arrLen);
                }
            } catch {
                Console.WriteLine("POSTION MUST BE AN INTEGER FROM 0 to ARRAY LENGTH");
                ReadPosition(ref position, arrLen);
            }
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

        static void PrintArray(ref int[] arr, int arrLen, int x, int position)
        {
            Console.Write("Array after the adding of element with value {0} at position {1}: ", x, position);
            for (int i = 0; i < arrLen; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
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

                int[] arr = new int[arrLen+1];
                int lastFailIndex = 0;
                int x = 0;
                int position = 0;

                ElementsInput(ref arr, arrLen, ref lastFailIndex);
                ReadPosition(ref position, arrLen);
                ReadElement(ref x);
                InsertElement(x, ref arr, ref arrLen, position);
                PrintArray(ref arr, arrLen, x, position);
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