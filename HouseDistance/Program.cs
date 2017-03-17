using System;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace HouseDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "ayy lmao";

            string strippedInput = input.Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty);
            string[] inputArray = Regex.Split(strippedInput, "\r\n");
            double[,] doubleArray = new double[inputArray.Count(), 2];

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < inputArray.Count(); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    string regexString = Regex.Split(inputArray[i], ",")[j];
                    doubleArray[i, j] = (double.Parse(regexString));
                }
            }
            double smallestDistance = double.MaxValue;
            double distance = 0;
            int firstPoint = 0;
            int secondPoint = 0;
            for (int i = 0; i < inputArray.Count(); i++)
            {
                for (int j = 0; j < inputArray.Count(); j++)
                {
                    if (i != j)
                    {
                        distance = Math.Abs(Math.Sqrt(Math.Pow((doubleArray[j, 0] - doubleArray[i, 0]), 2) + Math.Pow((doubleArray[j, 1] - doubleArray[i, 1]), 2)));
                        if (distance < smallestDistance)
                        {
                            smallestDistance = distance;
                            firstPoint = i + 1;
                            secondPoint = j + 1;
                        }
                    }
                }
            }
            sw.Stop();

            Console.WriteLine("The smallest distance has been found between points " + firstPoint + " and " + secondPoint +
                "\n({0}, {1}) and ({2}, {3})\nDistance is: {4}.\nThis measuremeant took {5}ms.",
                doubleArray[firstPoint - 1, 0],
                doubleArray[firstPoint - 1, 1],
                doubleArray[secondPoint - 1, 0],
                doubleArray[secondPoint - 1, 1],
                smallestDistance,
                sw.Elapsed.TotalMilliseconds.ToString());
            Console.ReadLine();
        }
    }
}
