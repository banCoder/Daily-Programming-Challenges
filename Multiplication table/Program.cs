using System;
using System.Text;

namespace Multiplication_table
{
    class Program
    {
        const int N = 9;
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            //for (int i = 1; i <= N; i++)
            //{
            //    for (int j = 1; j <= N; j++)
            //    {
            //        sb.Append(j * i);
            //        sb.Append("\t");
            //    }
            //    Console.WriteLine(sb.ToString());
            //    sb.Clear();
            //}

            int ii = 1, jj = 1;
            while (ii <= N)
            {
                while (jj <= N)
                {
                    sb.Append(jj * ii);
                    sb.Append("\t");
                    jj++;
                }
                Console.WriteLine(sb.ToString());
                sb.Clear();
                jj = 1;
                ii++;
            }

            int number = N;
            int rampCount = 0;
            while (number > 0)
            {
                char[] intArray = number.ToString().ToCharArray();
                bool isRamp = true;
                for (int i = 0; i < intArray.Length - 1; i++)
                {
                    if (intArray[i] > intArray[i + 1])
                    {
                        isRamp = false;
                        break;
                    }
                }
                if (isRamp)
                    rampCount++;
                number--;
            }
            Console.WriteLine(rampCount.ToString());
            
            Console.ReadLine();
        }
    }
}
