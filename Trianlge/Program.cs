using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trianlge
{
    class Program
    {
        static void Main(string[] args)
        {
            drawTriagle(90);
            Console.ReadLine();
        }
        public static void drawTriagle(int n)
        {
            int i = 0;
            int j = 1;
            while (j < n)
            {
                i = j * 2 - 1;
                drawSpace(((n * 2) - 1 - i) / 2);
                drawStarts(i);
                drawSpace(((n * 2) - 1 - i) / 2);
                Console.Write("\n");
                j++;
            }
            drawStarts((n * 2) - 1);
        }
        private static void drawStarts(int number)
        {
            for (int k = 0; k < number; k++)
            {
                Console.Write('*');
            }
        }
        private static void drawSpace(int number)
        {
            for (int k = 0; k < number; k++)
            {
                Console.Write(' ');
            }
        }
    }
}
