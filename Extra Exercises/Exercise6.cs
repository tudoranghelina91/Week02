using System;

namespace Exercise6Application
{
    class Exercise6
    {
        static void Main()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i == 4 || i == 7) {
                    continue;
                }
                Console.WriteLine(i);
            }
        }
    }
}