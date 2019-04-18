using System;

namespace Exercise2Application
{
    class Exercise2
    {
        static void Main()
        {
            for (int i = 20; i <= 65; i++)
            {
                if (i % 3 == 0) {
                    Console.WriteLine(i);
                }
            }
        }
    }
}