using System;
using System.Collections.Generic;
using System.Linq;

namespace ListFilterer
{
    public static class ListFilterer
    {
        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
        {
            return listOfItems.OfType<int>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a list of integers and strings, separated by spaces:");
            var input = Console.ReadLine();
            var listOfItems = input.Split(' ').Select(x =>
            {
                int n;
                if (int.TryParse(x, out n))
                {
                    return (object)n;
                }
                else
                {
                    return x;
                }
            }).ToList();

            var integers = ListFilterer.GetIntegersFromList(listOfItems);
            Console.WriteLine("Original list: " + input);
            Console.Write("Filtered list: ");
            foreach (var integer in integers)
            {
                Console.Write(integer + " ");
            }
            Console.WriteLine();
        }
    }
}