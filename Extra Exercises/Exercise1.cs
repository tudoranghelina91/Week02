using System;

namespace Exercise1Application
{
    class Exercise1
    {
        static void Main()
        {
            for (int i = 15; i <= 97; i++)
            {
                if (i % 2 == 0) {
                    Console.WriteLine(i);
                }
            }
        }
    }
}