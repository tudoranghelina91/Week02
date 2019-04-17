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

        static void IsItPrime()
        {

        }

        static string ReverseString(string palindromeString)
        {
            char[] palindromeStringArray = palindromeString.ToCharArray();
            char[] palindromeStringArrayRev = new char[palindromeStringArray.Length];

            // add string characters in reverse order;
            for (int i = 0; i < palindromeStringArray.Length; i++)
            {
                palindromeStringArrayRev[palindromeStringArray.Length - i - 1] = palindromeStringArray[i];
            }

            // convert reversed array to string
            string palindromeStringRev = palindromeStringArrayRev.ToString();

            return palindromeStringRev;
        }

        static bool CheckPalindrome(string palindromeString)
        {
            string palindromeStringRev = ReverseString(palindromeString);

            // compare
            if (palindromeString.Equals(palindromeStringRev))
                return true;

            return false;
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

            if (CheckPalindrome(palindromeString)) {
                Console.WriteLine("The string \"{0}\" is a palindrome", palindromeString);
            } else {
                Console.WriteLine("The string \"{0}\" is not a palindrome", palindromeString);
            }
        }

        static void RemoveDuplicatesFromLinkedList()
        {

        }

        static bool CheckString(string duplicateString)
        {
            bool unique = true;
            char[] duplicateStringArray = duplicateString.ToCharArray();

            for (int i = 0; i < duplicateStringArray.Length - 1; i++)
            {
                for (int j = i+1; j < duplicateStringArray.Length; j++)
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

            if (CheckString(duplicateString)) {
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
                if (i < arrLen - 1) {
                    Console.Write(arr[i] + " ");
                } else {
                    Console.Write(arr[i]);
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

        static void MergeArrays(ref int[] arr1, int arr1Len, ref int[] arr2, int arr2Len, ref int[] arr3, ref int arr3Len)
        {
            arr3Len = 0;

            for (int i = 0; i < arr1Len; i++)
            {
                for (int j = 0; j < arr2Len; j++)
                {
                    if (arr1[i] == arr2[j]) {
                        arr3[arr3Len++] = arr1[i];
                    }
                }
            }
        }

        static void SortArray(ref int[] arr, int arrLen)
        {
            for (int i = 0; i < arrLen - 1; i++)
            {
                for (int j = i + 1; j < arrLen; j++)
                {
                    if (arr[i] > arr[j]) {
                        arr[i] += arr[j];
                        arr[j] = arr[i] - arr[j];
                        arr[i] -= arr[j];
                    }
                }
            }
        }

        static void LengthInput(ref int arrLen)
        {
            try {
                arrLen = Convert.ToInt32(Console.ReadLine());
                if (arrLen == 0) {
                    Console.WriteLine("TYPE AN INTEGER GREATER THAN 0");
                    LengthInput(ref arrLen);
                }
            } catch {
                Console.WriteLine("INVALID INPUT VALUE! MUST BE A INTEGER!");
                LengthInput(ref arrLen);
            }
        }

        static void RemoveDuplicates(ref int[] arr, ref int arrLen)
        {
            for (int i = 0; i < arrLen - 1; i++)
            {
                if (arr[i] == arr[i+1]) {
                    for (int j = i + 1; j < arrLen; j++)
                    {
                        arr[i] = arr[j];
                    }

                    arrLen--;
                }
            }
        }
        
        static void CommonElements()
        {
            int lastFailIndex = 0;

            // Create first array
            int arr1Len = 0;
            Console.Write("Length of first array: ");
            LengthInput(ref arr1Len);
            int[] arr1 = new int[arr1Len];
            ElementsInput(ref arr1, arr1Len, ref lastFailIndex);

            lastFailIndex = 0;

            // Create second array
            int arr2Len = 0;
            Console.Write("Length of second array: ");
            LengthInput(ref arr2Len);
            int[] arr2 = new int[arr2Len];
            ElementsInput(ref arr2, arr2Len, ref lastFailIndex);

            // Sort the two arrays
            SortArray(ref arr1, arr1Len);
            SortArray(ref arr2, arr2Len);

            // Merge the two arrays into a third one
            int[] arr3 = new int[200];
            int arr3Len = 0;
            MergeArrays(ref arr1, arr1Len, ref arr2, arr2Len, ref arr3, ref arr3Len);

            // Remove duplicates from arr3
            RemoveDuplicates(ref arr3, ref arr3Len);

            // Display the array
            PrintCommonElements(ref arr1, arr1Len, ref arr2, arr2Len, ref arr3, arr3Len);
        }

        static void UserInput()
        {
            Console.WriteLine("1 - Common elements between two arrays of integers");
            Console.WriteLine("2 - All unique characters in a string");
            Console.WriteLine("3 - Remove duplicates from an unsorted linked list");
            Console.WriteLine("4 - Check if a number is prime");
            Console.WriteLine("5 - Determine if a word is a palindrome");
            Console.WriteLine("6 - Exit");

            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key.Equals(ConsoleKey.NumPad1) || cki.Key.Equals(ConsoleKey.D1)) {
                CommonElements();
            } else if (cki.Key.Equals(ConsoleKey.NumPad2) || cki.Key.Equals(ConsoleKey.D2)) {
                UniqueCharacters();
            } else if (cki.Key.Equals(ConsoleKey.NumPad3) || cki.Key.Equals(ConsoleKey.D3)) {
                RemoveDuplicatesFromLinkedList();
            } else if (cki.Key.Equals(ConsoleKey.NumPad4) || cki.Key.Equals(ConsoleKey.D4)) {
                IsItPrime();
            } else if (cki.Key.Equals(ConsoleKey.NumPad5) || cki.Key.Equals(ConsoleKey.D5)) {
                Palindrome();
            } else if (cki.Key.Equals(ConsoleKey.NumPad6) || cki.Key.Equals(ConsoleKey.D6)) {
                Console.WriteLine("Program will now exit...");
            } else {
                UserInput();
            }
            Ask();
        }

        static void Main()
        {
            UserInput();
        }
    }
}