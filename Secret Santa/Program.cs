using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Secret_Santa
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] instructions = File.ReadAllLines(@"D:\Documents\secretsanta.txt");
            secretSanta(instructions);
            Console.ReadLine();
        }
        private static Random _r = new Random();
        private static void secretSanta(string[] input)
        {
            List<string> giftRecepients = new List<string>();
            List<string> everybody = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                var matches = Regex.Matches(input[i], @"\w+");
                for (int j = 0; j < matches.Count; j++)
                {
                    Console.Write($"{matches[j].Value} -> ");
                    everybody.Add(matches[j].Value);
                    int randomLine, randomName, index;
                    string recepient;
                    MatchCollection lineMatches;
                    do
                    {
                        do
                        {
                            randomLine = _r.Next(input.Length);
                        } while (randomLine == i);
                        lineMatches = Regex.Matches(input[randomLine], @"\w+");
                        randomName = _r.Next(lineMatches.Count);
                        recepient = lineMatches[randomName].Value;
                        index = everybody.IndexOf(recepient);
                    } while (giftRecepients.Contains(recepient) ||
                             (index % 2 == 0 &&
                             everybody[index + 1] == matches[j].Value));
                    giftRecepients.Add(recepient);
                    everybody.Add(recepient);
                    Console.WriteLine(recepient);
                }
            }
        }
    }
}
