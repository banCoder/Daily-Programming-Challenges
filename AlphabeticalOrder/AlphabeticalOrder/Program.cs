using System;
using System.Linq;

namespace AlphabeticalOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[] { "billowy", "biopsy", "chinos", "defaced", "chintz", "sponged", "bijoux", "abhors", "fiddle", "begins", "chimps", "wronged" };
            orderWithAlphabetNumbers(input);
            orderWithArraySort(input);
            orderWithLINQ(input);
            
            Console.ReadLine();
        }
        static bool isAlpha(string s)
        {
            char prev = char.MinValue;
            foreach (char c in s)
            {
                if (c < prev)
                {
                    return false;
                }
                prev = c;
            }
            return true;
        }
        static void orderWithArraySort(string[] input)
        {
            foreach (var item in input)
            {
                if (item == alphabetize(item))
                {
                    Console.WriteLine(item + " IN ORDER");
                }
                else if (item == alphabetize(item, true))
                {
                    Console.WriteLine(item + " IN REVERSE ORDER");
                }
                else
                {
                    Console.WriteLine(item + " NOT IN ORDER");
                }
            }
        }
        static void orderWithLINQ(string[] input)
        {
            foreach (var item in input)
            {
                if (item == string.Concat(item.OrderBy(c => c)))
                {
                    Console.WriteLine(item + " IN ORDER");
                }
                else if (item == string.Concat(item.OrderByDescending(c => c)))
                {
                    Console.WriteLine(item + " IN REVERSE ORDER");
                }
                else
                {
                    Console.WriteLine(item + " NOT IN ORDER");
                }
            }
        }
        static string alphabetize(string s, bool reverse = false)
        {
            char[] a = s.ToCharArray();
            Array.Sort(a);
            if (reverse)
            {
                Array.Reverse(a);
            }
            return new string(a);
        }
        static void orderWithAlphabetNumbers(string[] input)
        {
            string[] alOrder = new string[input.Count()];
            for (int j = 0; j < input.Count(); j++)
            {
                char[] inputChar = input[j].ToCharArray();
                bool inReverseOrder = false;
                for (int i = 0; i < inputChar.Length - 2; i++)
                {
                    if (numberInAlphabet(inputChar[i + 1]) < numberInAlphabet(inputChar[i]))
                    {
                        inReverseOrder = true;
                    }
                    else
                    {
                        break;
                    }
                }
                if (inReverseOrder)
                {
                    alOrder[j] = input[j] + " IN REVERSE ORDER";
                }
                else
                {
                    for (int i = 0; i < inputChar.Length - 2; i++)
                    {
                        if (numberInAlphabet(inputChar[i + 1]) < numberInAlphabet(inputChar[i]))
                        {
                            alOrder[j] = input[j] + " NOT IN ORDER";
                            break;
                        }
                        else
                        {
                            alOrder[j] = input[j] + " IN ORDER";
                        }
                    }
                }
            }
            foreach (var item in alOrder)
            {
                Console.WriteLine(item);
            }
        }
        static int numberInAlphabet(char c)
        {
            switch (c.ToString().ToUpper())
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
                case "I":
                    return 9;
                case "J":
                    return 10;
                case "K":
                    return 11;
                case "L":
                    return 12;
                case "M":
                    return 13;
                case "N":
                    return 14;
                case "O":
                    return 15;
                case "P":
                    return 16;
                case "Q":
                    return 17;
                case "R":
                    return 18;
                case "S":
                    return 19;
                case "T":
                    return 20;
                case "U":
                    return 21;
                case "V":
                    return 22;
                case "W":
                    return 23;
                case "X":
                    return 24;
                case "Y":
                    return 25;
                case "Z":
                    return 26;
                default:
                    return 0;
            }
        }
    }
}
