using System;
using System.Linq;

namespace PairSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the array of numbers (separated by spaces): ");
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.Write("Enter the target sum: ");
            int target = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == target)
                    {                       
                        count++;
                    }
                }
            }          
            Console.WriteLine("Number of pairs: " + count);
        }
    }
}