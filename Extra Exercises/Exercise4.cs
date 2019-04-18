using System;

namespace Exercise4Application
{
    class Exercise4
    {
        static void PlayGame()
        {
            int randomNumber = 0;
            GenerateRandomNumber(ref randomNumber);
            Guess(randomNumber);
            Ask(ref randomNumber);
        }

        static void Exit()
        {
            Console.WriteLine("The program will now exit...");
        }

        static void Ask(ref int randomNumber)
        {
            Console.WriteLine("Do you want to guess another number? Y / N");
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key.Equals(ConsoleKey.Y)) {
                PlayGame();
            } else if (cki.Key.Equals(ConsoleKey.N)) {
                Exit();
            } else {
                Ask(ref randomNumber);
            }
        }

        static void Guess(int randomNumber)
        {
            Console.Write("Guess the number: ");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x == randomNumber) {
                Console.WriteLine("YOU GUESSED IT!");
            } else {
                Console.WriteLine("YOU DID NOT GUESS THE NUMBER! THE NUMBER WAS {0}", randomNumber);
            }
        }

        static void GenerateRandomNumber(ref int randomNumber)
        {
            Random rnd = new Random();
            randomNumber = rnd.Next(1, 10);
        }

        static void Main()
        {
            PlayGame();
        }
    }
}