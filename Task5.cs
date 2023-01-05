using System;
using System.Collections.Generic;
using System.Linq;

namespace Meeting
{
    class Task5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a list of names in the format 'FirstName:LastName;' ('Alice:Smith;Bob:Jones;'):");
            string s = Console.ReadLine();

            Console.WriteLine(Meeting(s));
        }

        static string Meeting(string s)
        {
            s = s.ToUpper();
            string[] names = s.Split(';');

            List<(string, string)> nameTuples = new List<(string, string)>();
            foreach (string name in names)
            {
                string[] splitName = name.Split(':');
                string firstName = splitName[0];
                string lastName = splitName[1];
                nameTuples.Add((firstName, lastName));
            }

            nameTuples.Sort((x, y) =>
            {
                if (x.Item2 != y.Item2)
                {
                    return x.Item2.CompareTo(y.Item2);
                }
                else
                {
                    return x.Item1.CompareTo(y.Item1);
                }
            });
            return string.Join("", nameTuples.Select(t => $"({t.Item2}, {t.Item1})"));
        }
    }
}