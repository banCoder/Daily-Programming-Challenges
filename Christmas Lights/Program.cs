using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christmas_Lights
{
    class Program
    {
        static void Main(string[] args)
        {
            // part 1
            Console.WriteLine(maxLights(1));
            Console.WriteLine(maxLights(4));
            Console.WriteLine(maxLights(8));
            Console.WriteLine(maxLights(12));

            // part 2
            Console.WriteLine("\nNext:\n");
            drawCircut(maxLights(12));
            Console.WriteLine("\nNext:\n");
            drawCircut(maxLights(6));
            Console.WriteLine("\nNext:\n");
            drawCircut(maxLights(100));
            
            // part 3
            Console.WriteLine(resistance(1));
            Console.WriteLine(resistance(4));
            Console.WriteLine(resistance(8));

            Console.ReadLine();
        }
        private static float maxLights(int h)
        {
            return ((Battery.Capacity / h) / Light.Current) * (int)(Battery.Voltage / Light.Voltage);
        }
        private static void drawCircut(float lights)
        {
            int j = (int)lights / 5;
            for (int i = 0; i < j; i++)
            {
                string write = i == 0 || i == j - 1 ?
                    "*-|>| ---|>| ---|>| ---|>| ---|>| -*" :
                    "--|>| ---|>| ---|>| ---|>| ---|>| --";
                Console.WriteLine(write);
                if (i + 1 < j)
                    Console.WriteLine("   |                           |");
            }
        }
        private static float resistance(int h)
        {
            return 0.5f / (1.2f / h);
        }
        public static class Battery
        {
            public static int Voltage = 9;
            public static int Capacity = 1200;
        }
        public static class Light
        {
            public static float Voltage = 1.7f;
            public static int Current = 20;
        }

    }
}
