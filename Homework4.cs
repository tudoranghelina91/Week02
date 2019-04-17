using System;
using System.Text;
using System.Collections.Generic;

namespace Homework4Application
{
    class Homework4
    {
        static void Ask()
        {
            Console.WriteLine("Do you want to perform other operations? Y / N");
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if(cki.Key.Equals(ConsoleKey.Y)) {
                Console.WriteLine();
                UserInput();
            } else if (cki.Key.Equals(ConsoleKey.N)) {
                Console.WriteLine();
                Console.WriteLine("Program will now exit...");
            } else {
                Ask();
            }
        }

        static void Palindrome()
        {
            string palindromeString = "";
            Console.Write("Type in a string to check if it is a palindrome: ");
            palindromeString = Console.ReadLine();

            if (palindromeString == "") {
                Console.WriteLine("THE STRING CANNOT BE BLANK");
                Palindrome();
            }
        }

        static void RemoveDuplicatesFromLinkedList()
        {

        }

        static bool CheckString(string duplicateString, int duplicateStringLength)
        {
            bool unique = true;

            for (int i = 0; i < duplicateStringLength - 1; i++)
            {
                for (int j = i+1; j < duplicateStringLength; j++)
                {
                    if (duplicateString[i] == duplicateString[j]) {
                        unique = false;
                    }
                }
            }

            return unique;
        }

        static void UniqueCharacters()
        {
            string duplicateString = "";
            Console.Write("Type in a string to check if it has all unique characters: ");
            duplicateString = Console.ReadLine();
            if (duplicateString == "") {
                Console.WriteLine("THE STRING CANNOT BE BLANK");
                UniqueCharacters();
            }

            if (CheckString(duplicateString, duplicateString.Length)) {
                Console.WriteLine("The string \"{0}\" has unique characters", duplicateString);
            } else {
                Console.WriteLine("The string \"{0}\" does not have unique characters", duplicateString);
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

        static void PrintArray(ref int[] arr, int arrLen)
        {
            for (int i = 0; i < arrLen; i++)
            {
                if (i < arr1Len - 1) {
                    Console.Write(arr1[i] + " ,");
                } else {
                    Console.Write(arr1[i]);
                }
            }
            Console.WriteLine();
        }

        static void PrintCommonElements(ref int[] arr1, int arr1Len, ref int[] arr2, int arr2Len, ref int[] arr3, int arr3Len)
        {
            // Print first array
            Console.Write("First Array: ");
            PrintArray(ref arr1, arr1Len);

            // Print second array
            Console.Write("Second Array: ");
            PrintArray(ref arr2, arr2Len);

            // Print third array
            Console.Write("Common Elements: ");
            PrintArray(ref arr3, arr3Len);
        }

        static void RemoveDuplicates(ref int[] arr, ref int arrLen)
        {
            for (int i = 0; i < arrLen-1; i++)
            {
                if (arr[i] == arr[i+1]) {
                    for (int j = i + 1; j < arrLen; i++)
                    {
                        arr[i] = arr[j];
                    }
                    arrLen--;
                }
            }
        }

        static void MergeArrays(ref int[] arr1, int arr1Len, ref int[] arr2, int arr2Len, ref int[] arr3, ref int arr3Len)
        {
            int i = 0, j = 0, arr3Len = 0;

            while (i < arr1Len && j < arr2Len)
            {
                if (arr1[i] < arr2[j]) {
                    arr3[arr3Len++] = arr1[i++];
                } else if (arr2[j] < arr1[i]) {
                    arr3[arr3Len++] = arr2[j++];
                } else {
                    arr3[arr3Len++] = arr1[i++];
                    arr3[arr3Len++] = arr2[j++];
                }
            }

            while (i < arr1Len)
            {
                arr3[arr3Len++] = arr1[i++];
            }

            while (j < arr2Len)
            {
                arr3[arr3Len++] = arr2[j++];
            }
        }

        static void SortArray(ref int[] arr, int arrLen)
        {
            for (int i = 0; i < arrLen - 1; i++)
            {
                for (int j = i + 1; j < arrLen; j++)
                {
                    arr[i] += arr[j];
                    arr[j] = arr[i] - arr[j];
                    arr[i] -= arr[j];
                }
            }
        }

        static int LengthInput()
        {
            int arrLen = 0;
            try {
                arrLen = Convert.ToInt32(Console.ReadLine());
            } catch {
                Console.WriteLine("INVALID INPUT VALUE! MUST BE A INTEGER!");
                LengthInput();
            }

            return arrLen;
        }

        static void CommonElements()
        {
            // Create first array
            int arr1Len = 0;
            Console.Write("Length of first array: ");
            arr1Len = LengthInput();
            int[] arr1 = new int[arr1Len];
            ElementsInput(ref arr1, arr1Len);

            // Create second array
            int arr2Len = 0;
            Console.Write("Length of second array: ");
            arr2Len = LengthInput();
            int[] arr2 = new int[arr2Len];
            ElementsInput(ref arr2, arr2Len);

            // Sort the two arrays
            SortArray(ref arr1, arr1Len);
            SortArray(ref arr2, arr2Len);

            // Merge the two arrays into a third one
            int[] arr3 = new int[200];
            int[] arr3Len = 0;
            MergeArrays(ref arr1, arr1Len, ref arr2, arr2Len, ref arr3, ref arr3Len);

            // Remove duplicates from third array
            RemoveDuplicates(ref arr3, arrLen);

            // Display the array
            PrintCommonElements(ref arr1, arr1Len, ref arr2, arr2Len, ref arr3, arr3Len);
            Ask();
        }

        static void UserInput()
        {
            Console.WriteLine("1 - Common elements between two arrays of integers");
            Console.WriteLine("2 - All unique characters in a string");
            Console.WriteLine("3 - Remove duplicates from an unsorted linked list");
            Console.WriteLine("4 - Determine if a word is a palindrome");

            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key.Equals(ConsoleKey.NumPad1) || cki.Key.Equals(ConsoleKey.D1)) {
                CommonElements();
            } else if (cki.Key.Equals(ConsoleKey.NumPad2) || cki.Key.Equals(ConsoleKey.D2)) {
                UniqueCharacters();
            } else if (cki.Key.Equals(ConsoleKey.NumPad3) || cki.Key.Equals(ConsoleKey.D3)) {
                RemoveDuplicatesFromLinkedList();
            } else if (cki.Key.Equals(ConsoleKey.Numpad4) || cki.Key.Equals(ConsoleKey.D4)) {
                Palindrome();
            } else {
                UserInput();
            }
        }

        static void Main()
        {
            UserInput();
            Ask();
        }
    }
}