using System;

namespace Exercise3Application
{
    class Exercise3
    {
        static void Main()
        {
            int count = 0;
            for (int i = 1400; i <= 2300; i++)
            {
                if (i % 7 == 0 || ((i % 10 == 0 || i % 10 == 5) && i != 5)) {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}