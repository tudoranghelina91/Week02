using System;

namespace Exercise7Application
{
    class Exercise7
    {
        static void Main()
        {
            int x = 0;
            int y = 1;

            Console.Write("{0} {1} ", x, y);

            while (x < 50 && y < 50)
            {
                if (x + y <= 50)
                {
                    x += y;
                    Console.Write(x + " ");
                }

                if (y + x <= 50)
                {
                    y += x;
                    Console.Write(y + " ");
                }
            }
        }
    }
}