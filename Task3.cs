using System;

namespace DigitalRoot
{
    class Task3
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());

            int digitalRoot = DigitalRoot(n);
            Console.WriteLine("The digital root of " + n + " is " + digitalRoot);
        }

        static int DigitalRoot(int n)
        {
            if (n < 10)
            {
                return n;
            }
            else
            {
                int sum = 0;
                while (n > 0)
                {
                    sum += n % 10;
                    n /= 10;
                }
                return DigitalRoot(sum);
            }
        }
    }
}