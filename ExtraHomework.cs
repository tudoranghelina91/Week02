using System;

namespace ExtraHomeworkApplication
{
    class ExtraHomework
    {
        static void Exit()
        {
            Console.WriteLine("Program will now exit...");
        }
        
        static void Ask()
        {
            Console.WriteLine("Do you want to find another string's last word length?");
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if(cki.Key.Equals(ConsoleKey.Y)) {
                StringInput();
            } else if (cki.Key.Equals(ConsoleKey.N)) {
                Exit();
            } else {
                Ask();
            }
        }

        static string SplitString(string s)
        {
            char[] separators = new char[] { ' ', ',', '\t', ';',','};
            string[] words = new string[s.Length];
            words = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string lastWord = "";

            foreach (var word in words)
            {
                lastWord = word;
            }

            return lastWord;
        }

        static void ShowResult(string lastWord)
        {
            if (lastWord.Length > 0) {
                Console.WriteLine("Last word: {0}", lastWord);
                Console.WriteLine("Last word length: {0}", lastWord.Length);
            } else {
                Console.WriteLine(0);
            }
        }

        static void StringInput()
        {
            Console.Write("Type in a string to determine the length of the last word: ");
            string s = Console.ReadLine();
            string lastWord = SplitString(s);
            ShowResult(lastWord);
            Ask();
        }

        static void Main()
        {
            StringInput();
        }
    }
}