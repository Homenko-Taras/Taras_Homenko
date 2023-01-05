using System;
using System.Linq;

namespace NextBiggerNumber
{
    class Task6
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive integer: ");
            int num = int.Parse(Console.ReadLine());

            int nextBigger = FindNextBigger(num);

            if (nextBigger == -1)
            {
                Console.WriteLine("There is no bigger number with the same digits.");
            }
            else
            {
                Console.WriteLine($"The next bigger number is {nextBigger}.");
            }
        }

        static int FindNextBigger(int num)
        {            
            int[] digits = num.ToString().Select(c => c - '0').ToArray();
            int i;

            for (i = digits.Length - 1; i > 0; i--)
            {
                if (digits[i - 1] < digits[i])
                {
                    break;
                }
            }

            if (i == 0)
            {
                return -1;
            }

            int j = Array.FindIndex(digits, i, d => d > digits[i - 1]);

            int temp = digits[i - 1];
            digits[i - 1] = digits[j];
            digits[j] = temp;

            Array.Reverse(digits, i, digits.Length - i);

            return int.Parse(new string(digits.Select(d => (char)(d + '0')).ToArray()));
        }
    }
}