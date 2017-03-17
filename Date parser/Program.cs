using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Date_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] instructions = File.ReadAllLines(@"D:\Documents\dateparser.txt");
            string[] instructionsComplicated = File.ReadAllLines(@"D:\Documents\complicateddateparser.txt");
            //dateParser(instructions);
            complicatedDateParser(instructionsComplicated);
            Console.ReadLine();
        }
        private static void dateParser(string[] input)
        {
            foreach (string line in input)
            {
                DateTime date;
                int firstPart = int.Parse(new string(line.TakeWhile(c => char.IsDigit(c)).ToArray()));
                int secondPart = int.Parse(new string(line
                    .SkipWhile(c => char.IsDigit(c))
                    .SkipWhile(c => !char.IsDigit(c))
                    .TakeWhile(c => char.IsDigit(c)).ToArray()));
                int thirdPart = int.Parse(new string(line
                    .SkipWhile(c => char.IsDigit(c))
                    .SkipWhile(c => !char.IsDigit(c))
                    .SkipWhile(c => char.IsDigit(c))
                    .SkipWhile(c => !char.IsDigit(c))
                    .TakeWhile(c => char.IsDigit(c)).ToArray()));
                date = firstPart > 999 ? new DateTime(firstPart, secondPart, thirdPart) : new DateTime(thirdPart + 2000, firstPart, secondPart);
                Console.WriteLine(date.ToShortDateString());
            }
        }
        private static void complicatedDateParser(string[] input)
        {
            foreach (string line in input)
            {
                DateTime date = DateTime.Now;
                string firstWord = new string(line
                    .SkipWhile(c => !char.IsLetter(c))
                    .TakeWhile(c => char.IsLetter(c)).ToArray()).ToLower();
                int firstNumber = 0;
                bool ayyLmao = int.TryParse(new string(line
                    .SkipWhile(c => !char.IsDigit(c))
                    .TakeWhile(c => char.IsDigit(c)).ToArray()), out firstNumber);
                string secondWord = new string(line
                    .SkipWhile(c => !char.IsLetter(c))
                    .SkipWhile(c => char.IsLetter(c))
                    .SkipWhile(c => !char.IsLetter(c))
                    .TakeWhile(c => char.IsLetter(c)).ToArray()).ToLower();
                string thirdWord = new string(line
                    .SkipWhile(c => !char.IsLetter(c))
                    .SkipWhile(c => char.IsLetter(c))
                    .SkipWhile(c => !char.IsLetter(c))
                    .SkipWhile(c => char.IsLetter(c))
                    .SkipWhile(c => !char.IsLetter(c))
                    .TakeWhile(c => char.IsLetter(c)).ToArray()).ToLower();
                if (firstWord.Length == line.Length)
                {
                    switch (firstWord)
                    {
                        case "today":
                            date = DateTime.Today;
                            break;
                        case "tomorrow":
                            date = DateTime.Today.AddDays(1);
                            break;
                        case "yesterday":
                            date = DateTime.Today.AddDays(-1);
                            break;
                        default:
                            break;
                    }
                }
                else if (firstWord.Contains("day") || firstWord.Contains("month") || firstWord.Contains("year") || firstWord.Contains("week"))
                {
                    if (line.ToLower().Contains("ago"))
                    {
                        switch (firstWord)
                        {
                            case "day":
                                date = DateTime.Today.AddDays(-1);
                                break;
                            case "week":
                                date = DateTime.Today.AddDays(-7);
                                break;
                            case "month":
                                date = DateTime.Today.AddMonths(-1);
                                break;
                            case "year":
                                date = DateTime.Today.AddYears(-1);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (line.ToLower().Contains("from"))
                    {
                        if (firstWord.Contains("day"))
                        {
                            if (thirdWord == "tomorrow")
                            {
                                date = DateTime.Today.AddDays(firstNumber + 1);
                            }
                            else if (thirdWord == "today")
                            {
                                date = DateTime.Today.AddDays(firstNumber);
                            }
                            else if (thirdWord == "yesterday")
                            {
                                date = DateTime.Today.AddDays(firstNumber - 1);
                            }
                        }
                        else if (firstWord.Contains("week"))
                        {
                            if (thirdWord == "tomorrow")
                            {
                                date = DateTime.Today.AddDays(firstNumber * 7 + 1);
                            }
                            else if (thirdWord == "today")
                            {
                                date = DateTime.Today.AddDays(firstNumber * 7);
                            }
                            else if (thirdWord == "yesterday")
                            {
                                date = DateTime.Today.AddDays(firstNumber * 7 - 1);
                            }
                        }
                        else if (firstWord.Contains("month"))
                        {
                            if (thirdWord == "tomorrow")
                            {
                                date = DateTime.Today.AddMonths(firstNumber).AddDays(1);
                            }
                            else if (thirdWord == "today")
                            {
                                date = DateTime.Today.AddMonths(firstNumber);
                            }
                            else if (thirdWord == "yesterday")
                            {
                                date = DateTime.Today.AddMonths(firstNumber).AddDays(-1);
                            }
                        }
                        else if (firstWord.Contains("year"))
                        {
                            if (thirdWord == "tomorrow")
                            {
                                date = DateTime.Today.AddYears(firstNumber).AddDays(1);
                            }
                            else if (thirdWord == "today")
                            {
                                date = DateTime.Today.AddYears(firstNumber);
                            }
                            else if (thirdWord == "yesterday")
                            {
                                date = DateTime.Today.AddYears(firstNumber).AddDays(-1);
                            }
                        }
                    }
                }
                else if (firstWord == "next")
                {
                    switch (secondWord)
                    {
                        case "week":
                            date = DateTime.Today.AddDays(7);
                            break;
                        case "day":
                            date = DateTime.Today.AddDays(1);
                            break;
                        case "month":
                            date = DateTime.Today.AddMonths(1);
                            break;
                        case "year":
                            date = DateTime.Today.AddYears(1);
                            break;
                        case "monday":
                            date = DateTime.Today.AddDays(1);
                            while (date.DayOfWeek != DayOfWeek.Monday)
                                date = date.AddDays(1);
                            break;
                        case "tuesday":
                            date = DateTime.Today.AddDays(1);
                            while (date.DayOfWeek != DayOfWeek.Tuesday)
                                date = date.AddDays(1);
                            break;
                        case "wednesday":
                            date = DateTime.Today.AddDays(1);
                            while (date.DayOfWeek != DayOfWeek.Wednesday)
                                date = date.AddDays(1);
                            break;
                        case "thursday":
                            date = DateTime.Today.AddDays(1);
                            while (date.DayOfWeek != DayOfWeek.Thursday)
                                date = date.AddDays(1);
                            break;
                        case "friday":
                            date = DateTime.Today.AddDays(1);
                            while (date.DayOfWeek != DayOfWeek.Friday)
                                date = date.AddDays(1);
                            break;
                        case "saturday":
                            date = DateTime.Today.AddDays(1);
                            while (date.DayOfWeek != DayOfWeek.Saturday)
                                date = date.AddDays(1);
                            break;
                        case "sunday":
                            date = DateTime.Today.AddDays(1);
                            while (date.DayOfWeek != DayOfWeek.Sunday)
                                date = date.AddDays(1);
                            break;
                        default:
                            break;
                    }
                }
                else if (firstWord == "last")
                {
                    switch (secondWord)
                    {
                        case "week":
                            date = DateTime.Today.AddDays(-7);
                            break;
                        case "day":
                            date = DateTime.Today.AddDays(-1);
                            break;
                        case "month":
                            date = DateTime.Today.AddMonths(-1);
                            break;
                        case "year":
                            date = DateTime.Today.AddYears(-1);
                            break;
                        case "monday":
                            date = DateTime.Today.AddDays(-1);
                            while (date.DayOfWeek != DayOfWeek.Monday)
                                date.AddDays(-1);
                            break;
                        case "tuesday":
                            date = DateTime.Today.AddDays(-1);
                            while (date.DayOfWeek != DayOfWeek.Tuesday)
                                date = date.AddDays(-1);
                            break;
                        case "wednesday":
                            date = DateTime.Today.AddDays(-1);
                            while (date.DayOfWeek != DayOfWeek.Wednesday)
                                date = date.AddDays(-1);
                            break;
                        case "thursday":
                            date = DateTime.Today.AddDays(-1);
                            while (date.DayOfWeek != DayOfWeek.Thursday)
                                date = date.AddDays(-1);
                            break;
                        case "friday":
                            date = DateTime.Today.AddDays(-1);
                            while (date.DayOfWeek != DayOfWeek.Friday)
                                date = date.AddDays(-1);
                            break;
                        case "saturday":
                            date = DateTime.Today.AddDays(-1);
                            while (date.DayOfWeek != DayOfWeek.Saturday)
                                date = date.AddDays(-1);
                            break;
                        case "sunday":
                            date = DateTime.Today.AddDays(-1);
                            while (date.DayOfWeek != DayOfWeek.Sunday)
                                date = date.AddDays(-1);
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine(date.ToShortDateString());
            }
        }
    }
}
