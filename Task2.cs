using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Task2
    {
        public static char FirstNonRepeatingLetter(string s)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in s)
            {
                char lowerC = char.ToLower(c);
                if (charCount.ContainsKey(lowerC))
                {
                    charCount[lowerC]++;
                }
                else
                {
                    charCount[lowerC] = 1;
                }
            }

            foreach (char c in s)
            {
                char lowerC = char.ToLower(c);
                if (charCount[lowerC] == 1)
                {
                    return c;
                }
            }
            return ' ';
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            char result = FirstNonRepeatingLetter(input);
            if (result == ' ')
            {
                Console.WriteLine("There are no non-repeating characters in the string.");
            }
            else
            {
                Console.WriteLine($"The first non-repeating character in the string is: {result}");
            }

            Console.WriteLine("Press any key to close the console...");
            Console.ReadKey();
        }
    }
}