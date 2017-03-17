using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string inp = @"Was it a car
or a cat
I saw?";
            if (isPalindromeReverse(inp))
            {
                Console.WriteLine(inp + " is a palindrome");
            }
            else
            {
                Console.WriteLine(inp + " is NOT a palindrome");
            }
            
            Console.ReadLine();
        }

        static string normalizeString(string input)
        {
            return new string(input.Where(c => char.IsLetter(c)).Select(c => char.ToUpper(c)).ToArray());
        }
        static bool isPalindromeReverse(string input)
        {
            char[] inp = normalizeString(input).ToCharArray();
            char[] inpReversed = normalizeString(input).ToCharArray();
            Array.Reverse(inpReversed);

            return (new string(inp) == new string(inpReversed));
        }
        static bool isPalindromeIncrement(string input)
        {
            input = normalizeString(input);
            int i = 0;
            int j = input.Length - 1;
            while (i <= j)
            {
                if (input[i] != input[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
    }
}
