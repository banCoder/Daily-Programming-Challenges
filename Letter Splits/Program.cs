using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Letter_Splits
{
    class Program
    {
        static void Main(string[] args)
        {
            split(8242311111);
            Console.ReadLine();
        }
        private static void split(long input)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int[] array = input.ToString().Select(c => int.Parse(c.ToString())).ToArray();
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                if (i + 1 < array.Length)
                {
                    sum = int.Parse($"{array[i]}{array[i + 1]}");
                    if (sum < 27)
                        count++;
                }
            }
            string[] combinations = findCombinations(count);
            List<string> possibilities = new List<string>();
            foreach (string combo in combinations)
            {
                StringBuilder sb = new StringBuilder();
                int j = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (i + 1 < array.Length)
                    {
                        int sum = int.Parse($"{array[i]}{array[i + 1]}");
                        if (i + 2 < array.Length && int.Parse($"{array[i + 1]}{array[i + 2]}") % 10 == 0)
                        {
                            sb.Append((char)(array[i] + 96));
                            sum = int.Parse($"{array[i + 1]}{array[i + 2]}");
                            sb.Append((char)(sum + 96));
                            i += 2;
                            continue;
                        }
                        if (sum < 27)
                        {
                            if (combo[j] == '1' || sum % 10 == 0)
                            {
                                i++;
                                sb.Append((char)(sum + 96));
                                continue;
                            }
                            j++;
                        }
                    }
                    sb.Append((char)(array[i] + 96));
                }
                if (!possibilities.Contains(sb.ToString()))
                    possibilities.Add(sb.ToString());
            }
            foreach (string pos in possibilities)
                Console.WriteLine(pos.ToString().ToUpper());
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        private static string[] findCombinations(int input)
        {
            if (input == 1)
            {
                return new string[] { "0", "1" };
            }
            List<string> possibilities = new List<string>();
            int leftOver = int.Parse(new string(Enumerable.Repeat('1', input - 1).ToArray()));
            for (int i = 0; i <= Math.Pow(10, input - 1) + leftOver; i++)
            {
                string iString = i.ToString();
                bool cont = false;
                for (int j = 0; j < iString.Length; j++)
                {
                    if (iString[j] != '0' && iString[j] != '1')
                    {
                        cont = true;
                        break;
                    }
                }
                if (cont) continue;
                StringBuilder sb = new StringBuilder();
                int l = input - iString.Length;
                if (l > 0)
                    sb.Append(new string(Enumerable.Repeat('0', l).ToArray()));
                sb.Append(i);
                possibilities.Add(sb.ToString());
            }
            return possibilities.ToArray();
        }
    }
}
