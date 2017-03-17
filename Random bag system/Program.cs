using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_bag_system
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(generate(15));
            Console.WriteLine(generateFromList(15, "OISZLJT"));
            Console.ReadLine();
        }
        private static Random _r = new Random();
        private static int RNG(int min, int max)
        {
            return _r.Next(min, max + 1);
        }
        private static char[] genUniqueRN(int length, int min, int max)
        {
            StringBuilder sb = new StringBuilder();
            while (sb.Length != length)
            {
                int n = RNG(min, max);
                if (!sb.ToString().Contains(n.ToString()))
                {
                    sb.Append(n);
                }
            }
            return sb.ToString().ToCharArray();
        }
        private static string generate(int length)
        {
            char[] inputChars = new char[] { 'O', 'I', 'S', 'Z', 'L', 'J', 'T' };
            StringBuilder sb = new StringBuilder();
            int n = length;
            int idk = 0;
            if (length % 7 != 0)
                idk = 1;
            for (int i = 0; i < (length / 7) + idk; i++)
            {
                char[] cA = genUniqueRN(7, 0, 6);
                foreach (char c in cA)
                {
                    int k = int.Parse(c.ToString());
                    sb.Append(inputChars[k]);
                    n--;
                    if (n == 0)
                        break;
                }
            }
            return sb.ToString();
        }
        private static List<char> generateCharList(string input)
        {
            List<char> list = new List<char>();
            foreach (char c in input)
            {
                list.Add(c);
            }
            return list;
        }
        private static string generateFromList(int length, string input)
        {
            string gen = "";
            int count = length;

            for (int i = length; i > 0;)
            {
                var list = generateCharList(input);
                while (list.Count > 0)
                {
                    int rn = RNG(0, list.Count - 1);
                    gen += list[rn];
                    list.RemoveAt(rn);
                    i--;
                    if (i == 0)
                    {
                        break;
                    }
                }
            }

            return gen;
        }
    }
}
