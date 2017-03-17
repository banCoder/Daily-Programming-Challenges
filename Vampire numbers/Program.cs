using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vampire_numbers
{
    static class Program
    {
        static void Main(string[] args)
        {
            int l = 0;
            int[] numbers = new int[999];
            for (int i = 1111; i < 10000; i++)
            {
                char[] charArray = i.ToString().ToCharArray();
                for (int j = 0; j < charArray.Count(); j++)
                {
                    StringBuilder sb = new StringBuilder();
                    int m = 0;
                    while (m < charArray.Count())
                    {
                        if (charArray[m] != charArray[j] || (charArray[m] == charArray[j] && charArray.Count(s => s == charArray[j]) > 1))
                        {
                            sb.Append(charArray[m]);
                            sb.Append(charArray[j]);
                            if (int.Parse(sb.ToString()) != 0)
                            {
                                float result = i / float.Parse(sb.ToString());
                                int ayy = charArray.Count(s => s == charArray[m]);
                                int lmao = charArray.Count(s => s == charArray[j]);
                                int ayyLmao = charArray.Count(s => s == result.ToString()[0]);
                                if (result.ToString().Length == 2 && charArray.Contains(result.ToString()[0]) && charArray.Contains(result.ToString()[1]) &&
                                    !numbers.Contains(i) &&
                                    (result.ToString()[0] != result.ToString()[1] || (result.ToString()[0] == result.ToString()[1] && ayyLmao > 1)) &&
                                    (((result.ToString()[0] != charArray[m] || (result.ToString()[0] == charArray[m] && ayy > 1))) &&
                                     ((result.ToString()[0] != charArray[j] || (result.ToString()[0] == charArray[j] && lmao > 1)))) &&
                                    (((result.ToString()[1] != charArray[m] || (result.ToString()[1] == charArray[m] && ayy > 1))) &&
                                     ((result.ToString()[1] != charArray[j] || (result.ToString()[1] == charArray[j] && lmao > 1)))))
                                {
                                    numbers[l] = i;
                                    l++;
                                }
                            }
                        }
                        sb.Clear();
                        m++;
                    }
                }
            }
            Console.ReadLine();

            //int length = int.Parse(args[0]), numFangs = int.Parse(args[1]), fangLength = length / numFangs;

            //// This gives us all possible "fangs." So for 2 digit fangs, we would get 10...99
            //int lowerBound = (int)Math.Pow(10, fangLength - 1);
            //int upperBound = (int)Math.Pow(10, fangLength); // shouldn't this be -1 so it would be 99 and not 100
            //var allPossibleFangs = Enumerable.Range(lowerBound, upperBound - lowerBound); // gives from 10 to 100

            //// Now we can combine these using the custom extension method
            //var allCombinations = allPossibleFangs.Combinations(numFangs);

            //string final = "";

            //// For each of these combination
            //foreach (var combination in allCombinations)
            //{
            //    // Calculate the product and convert its string representation to char array
            //    int product = combination.Aggregate((workingProduct, nextNumber) => workingProduct * nextNumber);
            //    char[] productStringAsChars = product.ToString().ToCharArray();

            //    // Join up all the numbers in the combination into a string and convert to char array
            //    char[] combinationAsChars = string.Join("", combination);

            //    // Sort the arrays
            //    Array.Sort(productStringAsChars);
            //    Array.Sort(combinationAsChars);

            //    // Compare the strings. If they match, then this combination works.
            //    if (string.Join("", productStringAsChars).Equals(string.Join("", combinationAsChars)))
            //        final += product + "=" + string.Join("*", combination) + "\n";
            //}


            //Console.WriteLine(final);
        }
        //public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int i)
        //{
        //    return i == 0 ? new[] { new T[0] } :
        //        elements.SelectMany((element, index) =>
        //            elements.Skip(index + 1).Combinations(i - 1).Select(c => (new[] { e }).Concat(c)));
        //}
    }
}
