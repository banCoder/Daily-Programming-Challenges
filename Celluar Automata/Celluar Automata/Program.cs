using System;
using System.Text;

namespace Celluar_Automata
{
    class Program
    {
        static void Main(string[] args)
        {
            CelluarAutodata("00000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000",
                '$', ' ');
            Console.ReadLine();
        }
        static void CelluarAutodata(string input, char match, char noMatch, char inputCharMatch = '1', char inputCharNoMatch = '0')
        {
            StringBuilder actualInput = new StringBuilder();
            actualInput.Append(input);
            actualInput.Replace(inputCharMatch, match);
            actualInput.Replace(inputCharNoMatch, noMatch);
            string actualInputString = actualInput.ToString();

            StringBuilder inputBuilder = new StringBuilder();
            inputBuilder.Append(noMatch + actualInputString + noMatch);
            char[] inputArray = inputBuilder.ToString().ToCharArray();
            Console.WriteLine(actualInputString);

            for (int j = 0; j < 25; j++)
            {
                char[] outputArray = new char[actualInputString.Length];
                for (int i = 0; i < actualInputString.Length; i++)
                {
                    if (inputArray[i] != inputArray[i + 2])
                    {
                        outputArray[i] = match;
                    }
                    else
                    {
                        outputArray[i] = noMatch;
                    }
                }
                foreach (char c in outputArray)
                {
                    Console.Write(c);
                }
                Console.Write(Environment.NewLine);
                inputBuilder.Clear();
                inputBuilder.Append(noMatch);
                foreach (char c in outputArray)
                {
                    inputBuilder.Append(c);
                }
                inputBuilder.Append(noMatch);
                inputArray = inputBuilder.ToString().ToCharArray();
            }
        }
    }
}
