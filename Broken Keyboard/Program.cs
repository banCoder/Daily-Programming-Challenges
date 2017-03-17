using System;
using System.Linq;
using System.IO;

namespace Broken_Keyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = readFile(@"D:\Documents\enable1.txt");
            string[] lines2 = readFile(@"D:\Documents\words.txt");
            //Console.WriteLine(longestWord(lines, "edcf") + "\t" + longestWord(lines2, "edcf"));
            //Console.WriteLine(longestWord(lines, "bnik") + "\t" + longestWord(lines2, "bnik"));
            //Console.WriteLine(longestWord(lines, "poil") + "\t" + longestWord(lines2, "poil"));
            //Console.WriteLine(longestWord(lines, "vybu") + "\t" + longestWord(lines2, "vybu"));
            //
            float ayy = 0.01268335f;
            float count = 0;
            for (float i = 0; i < 20; i++)
            {
                if (i < 12)
                {
                    ayy += i / 1000;
                    Console.WriteLine(ayy);
                }
                else if (i < 15)
                {
                    ayy += i / 1500;
                    Console.WriteLine(ayy);
                }
                else if (i < 17)
                {
                    ayy -= i / 1200;
                    Console.WriteLine(ayy);
                }
                else
                {
                    ayy -= i / 800;
                    Console.WriteLine(ayy);
                }
                count += ayy;
            }
            Console.WriteLine("Count: " + count);
            Console.ReadLine();
            //
            //float ayy = 2.189585f;
            //float count = 0;
            //for (float i = 0; i < 20; i++)
            //{
            //    if (i < 9)
            //    {
            //        ayy += i / 8;
            //        Console.WriteLine(ayy);
            //    }
            //    else if (i < 11)
            //    {
            //        ayy += i / 12;
            //        Console.WriteLine(ayy);
            //    }
            //    else if (i < 13)
            //    {
            //        ayy -= i / 40;
            //        Console.WriteLine(ayy);
            //    }
            //    else
            //    {
            //        ayy -= i / 21;
            //        Console.WriteLine(ayy);
            //    }
            //    count += ayy;
            //}
            //Console.WriteLine("Count: " + count);
            //Console.ReadLine();
        }
        private static string[] readFile(string path)
        {
            string[] fileRead = File.ReadAllLines(path);
            return fileRead;
        }
        private static string longestWord(string[] lines, string keys)
        {
            string word = "";
            foreach (string line in lines)
            {
                string lowerCaseLine = line.ToLower(); // not necesseary
                var wrongChars = lowerCaseLine.Where(c => !keys.Contains(c)); // collection of all chars that aren't keys
                if (line.Length > word.Length && wrongChars.Count() == 0)
                {
                    word = line;
                }
            }
            return word;
        }
    }
}
