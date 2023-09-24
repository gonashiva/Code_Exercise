using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n) => Factorial(n);

        public static string FormatSeparators(params string[] items)
        {
            if (items == null || items.Length == 0)
            {
                return string.Empty; //TO-DO: to be updated as per requirement.
            }

            string lastItem = items[items.Length - 1];
            string output = string.Join(", ", items.Take(items.Length - 1));
            string finalString = string.Concat(output, " and ", lastItem);
            return finalString;
        }

        private static int Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}