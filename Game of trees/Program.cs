using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game_of_trees
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 829234580;
            //treesWithFor(ref i);
            treesWithSwitch(ref i);
            Console.ReadLine();
        }
        private static void treesWithFor(ref int n)
        {
            while (n != 1)
            {
                if (n % 3 == 0)
                {
                    Console.WriteLine(n + " + 0 = {0}", n);
                    n /= 3;
                }
                else if ((n - 1) % 3 == 0)
                {
                    Console.WriteLine(n + " - 1 = {0}", n - 1);
                    n -= 1;
                    n /= 3;
                }
                else
                {
                    Console.WriteLine(n + " + 1 = {0}", n + 1);
                    n += 1;
                    n /= 3;
                }
            }
            Console.WriteLine(n);
        }
        private static void treesWithSwitch(ref int n)
        {
            while (n != 1)
            {
                switch (n % 3)
                {
                    case 0:
                        Console.WriteLine(n + " + 0 = {0}", n);
                        n /= 3;
                        break;
                    case 1:
                        Console.WriteLine(n + " - 1 = {0}", n - 1);
                        n -= 1;
                        n /= 3;
                        break;
                    case 2:
                        Console.WriteLine(n + " + 1 = {0}", n + 1);
                        n += 1;
                        n /= 3;
                        break;
                }
            }
            Console.WriteLine(n);
        }
    }
}
