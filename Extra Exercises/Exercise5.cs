using System;

namespace Exercise5Application
{
    class Exercise5
    {
        static void Exit()
        {
            Console.WriteLine("The program will now exit...");
        }

        static void Ask()
        {
            Console.WriteLine("Do you want to reverse another string? Y / N");
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key.Equals(ConsoleKey.Y)) {
                StringInput();
            } else if (cki.Key.Equals(ConsoleKey.N)) {
                Exit();
            } else {
                Ask();
            }
        }

        static string ReverseString(string stringToReverse)
        {
            char[] stringToReverseArray = stringToReverse.ToCharArray();
            char[] stringToReverseArrayRev = new char[stringToReverseArray.Length];

            // add string characters in reverse order;
            for (int i = 0; i < stringToReverseArray.Length; i++)
            {
                stringToReverseArrayRev[stringToReverseArray.Length - i - 1] = stringToReverseArray[i];
            }

            // convert reversed array to string
            string stringToReverseRev = new string(stringToReverseArrayRev);

            return stringToReverseRev;
        }

        static void StringInput()
        {
            Console.Write("Write a string so we can print it in reverse: ");
            string stringToReverse = Console.ReadLine();
            string reversedString = ReverseString(stringToReverse);
            Console.WriteLine("The reversed string is: {0}", reversedString);
            Ask();
        }

        static void Main()
        {
            StringInput();
        }
    }
}