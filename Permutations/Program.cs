using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            makePermtations("1234");
            Console.ReadLine();
        }
        private static void makePermtations(string input)
        {
            // 123
            // 132
            // 213
            // 231
            // 312
            // 321
            List<string> permutations = new List<string>();
            // each char needs to be at each place 2x
            // maybe make a stringbuilder, add chars together
            for (int i = 0; i < input.Length; i++)
            {
                int idkOne = 0;
                int idkTwo = input.Length - 1;
                StringBuilder sb = new StringBuilder();
                sb.Append(input[i]);
                while (idkOne < input.Length && idkTwo > -1)
                {
                    if (i != idkOne)
                    {
                        sb.Append(input[idkOne]);
                    }
                    idkOne++;
                }
                permutations.Add(sb.ToString());
                sb.Clear();
                sb.Append(input[i]);
                while (idkTwo > -1)
                {
                    if (i != idkTwo)
                    {
                        sb.Append(input[idkTwo]);
                    }
                    idkTwo--;
                }
                permutations.Add(sb.ToString());
                //StringBuilder sb = new StringBuilder();
                //sb.Append(word[i]);
                //for (int j = 0; j < word.Length; j++)
                //{
                //    if (j != i)
                //    {
                //        sb.Append(word[j]);
                //    }
                //}
                //permutations.Add(sb.ToString());
                //sb.Clear();
                //sb.Append(word[i]);
                //for (int j = word.Length - 1; j >= 0; j--)
                //{
                //    if (j != i)
                //    {
                //        sb.Append(word[j]);
                //    }
                //}
                //permutations.Add(sb.ToString());
            }
        }
    }
}
