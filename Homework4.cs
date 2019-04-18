using System;
using System.Text;
using System.Collections.Generic;

namespace Homework4Application
{
    class Homework4
    {
        static void Exit()
        {
            Console.WriteLine("Program will now exit...");
        }
        static void Ask()
        {
            Console.WriteLine("Do you want to perform other operations? Y / N");
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if(cki.Key.Equals(ConsoleKey.Y)) {
                Console.WriteLine();
                UserInput();
            } else if (cki.Key.Equals(ConsoleKey.N)) {
                Console.WriteLine();
                Exit();
            } else {
                Ask();
            }
        }

        static bool CheckPrime(int x)
        {
            bool prime = true;

            if (x == 0 || x == 1) {
                prime = false;
            } else if (x % 2 == 0 && x != 2) {
                prime = false;
            } else {
                for (int i = 3; i <= Math.Sqrt((double)x); i += 2)
                {
                    if (x % i == 0) {
                        prime = false;
                    }
                }
            }
            return prime;
        }

        static void IsItPrime()
        {
            Console.Write("Type in a number to check if it is prime or not: ");
            try {
                int x = Convert.ToInt32(Console.ReadLine());
                if(CheckPrime(x)) {
                    Console.WriteLine("{0} is a prime number", x);
                } else {
                    Console.WriteLine("{0} is not a prime number", x);
                }
            } catch {
                Console.WriteLine("INVALID INPUT VALUE. PLEASE USE AN INTEGER!");
                IsItPrime();
            }
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
            string palindromeStringRev = new string(palindromeStringArrayRev);

            return palindromeStringRev;
        }

        static bool CheckPalindrome(string palindromeString)
        {
            string palindromeStringRev = ReverseString(palindromeString);

            // compare
            if (palindromeString.ToLower().CompareTo(palindromeStringRev.ToLower()) == 0)
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

        static void LinkedListPrint(LinkedList<int> myList)
        {
            // Print the linked list after the elements have been removed elements
            foreach (int node in myList)
            {
                Console.WriteLine(node);
            }
        }

        static void LinkedListDuplicateRemoval(ref LinkedList<int> myList)
        {
            // create node and associate to list
            LinkedListNode<int> llNode = myList.First;

            // Remove duplicates
            while (llNode != null)
            {
                LinkedListNode<int> llNode2 = llNode.Next;
                while (llNode2 != null)
                {
                    if (llNode2.Value == llNode.Value) {
                        myList.Remove(llNode2);
                    }
                    llNode2 = llNode2.Next;
                }
                llNode = llNode.Next;
            }
        }

        static void LinkedListInput(int n, ref int lastFailIndex, ref LinkedList<int> myList)
        {
            // Read values into the linked list
            for (int i = lastFailIndex; i < n; i++)
            {
                try {
                    Console.Write("Element {0}: ", i);
                    int x = Convert.ToInt32(Console.ReadLine());
                    myList.AddFirst(x);
                } catch {
                    Console.WriteLine("INVALID INPUT! USE INTEGERS!");
                    lastFailIndex = i--;
                }
            }
        }

        static void ListLengthInput(ref int n)
        {
            try {
                // Type numbers of elements to add into the linked list
                Console.Write("How many elements do you want to add to the list: ");
                n = Convert.ToInt32(Console.ReadLine());
            } catch {
                Console.WriteLine("INVALID INPUT! USE INTEGERS ONLY!");
                ListLengthInput(ref n);
            }
        }

        static void RemoveDuplicatesFromLinkedList()
        {
            int n = 0;
            int lastFailIndex = 0;
            ListLengthInput(ref n);

            // create a new linked list
            LinkedList<int> myList = new LinkedList<int>();
            LinkedListInput(n, ref lastFailIndex, ref myList);

            LinkedListDuplicateRemoval(ref myList);
            LinkedListPrint(myList);
        }

        static bool CheckString(string duplicateString)
        {
            bool unique = true;

            for (int i = 0; i < duplicateString.Length - 1; i++)
            {
                for (int j = i+1; j < duplicateString.Length; j++)
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
            if (arr3Len != 0) {
                Console.Write("Common Elements: ");
                PrintArray(ref arr3, arr3Len);
            } else {
                Console.WriteLine("The two arrays don't have common elements");
            }
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
                Ask();
            } else if (cki.Key.Equals(ConsoleKey.NumPad2) || cki.Key.Equals(ConsoleKey.D2)) {
                UniqueCharacters();
                Ask();
            } else if (cki.Key.Equals(ConsoleKey.NumPad3) || cki.Key.Equals(ConsoleKey.D3)) {
                RemoveDuplicatesFromLinkedList();
                Ask();
            } else if (cki.Key.Equals(ConsoleKey.NumPad4) || cki.Key.Equals(ConsoleKey.D4)) {
                IsItPrime();
                Ask();
            } else if (cki.Key.Equals(ConsoleKey.NumPad5) || cki.Key.Equals(ConsoleKey.D5)) {
                Palindrome();
                Ask();
            } else if (cki.Key.Equals(ConsoleKey.NumPad6) || cki.Key.Equals(ConsoleKey.D6)) {
                Exit();
            } else {
                UserInput();
            }
        }

        static void Main()
        {
            UserInput();
        }
    }
}