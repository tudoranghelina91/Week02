using System;

namespace FizzBuzzApplication
{
    class FizzBuzz
    {
        static void Main()
        {
            for (int i = 1; i <= 1000; i++)
            {
                if (i % 5 == 0 && i % 3 == 0) {
                    Console.WriteLine("FizzBuzz");
                } else if (i % 5 == 0) {
                    Console.WriteLine("Buzz");
                } else if (i % 3 == 0) {
                    Console.WriteLine("Fizz");
                } else {
                    Console.WriteLine(i);
                }
            }
        }
    }
}