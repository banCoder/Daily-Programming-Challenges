using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ASCII_House
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = "   * \n  *** \n******";
            //string[] inputArray = Regex.Split(input, "\n");
            //StringBuilder sb = new StringBuilder();
            //StringBuilder sb2 = new StringBuilder();
            //string previous = "";
            //string before = "";

            //for (int k = 0; k < inputArray.Length; k++)
            //{
            //    for (int m = 0; m < inputArray[k].Length; m++)
            //    {
            //        if (inputArray[k][m] == ' ')
            //        {
            //            previous = "    ";
            //            sb.Append(previous);
            //            Console.Write(previous);
            //        }
            //        else if (previous == "+---+" || previous == "---+")
            //        {
            //            previous = "---+";
            //            sb.Append(previous);
            //            Console.Write(previous);
            //        }
            //        else
            //        {
            //            previous = "+---+";
            //            sb.Append(previous);
            //            Console.Write(previous);
            //        }
            //    }
            //    previous = "";
            //    Console.Write(Environment.NewLine);
            //    int l = 1;
            //    if (k == inputArray.Length - 1)
            //    {
            //        l = 2;
            //    }
            //    for (int i = 0; i < l; i++)
            //    {
            //        char[] sbCharArray = sb.ToString().ToCharArray();
            //        foreach (char d in sbCharArray)
            //        {
            //            if (d == '+' && l != 2 && i != 1)
            //            {
            //                before = "|";
            //                Console.Write(before);
            //            }
            //            else if (d == '+' && l == 2 && i != 1)
            //            {
            //                before = "|";
            //                Console.Write(before);
            //            }
            //            else if (d == '+' && l == 2 && i == 1)
            //            {
            //                before = "+";
            //                Console.Write(before); ;
            //            }
            //            else if (d == '-' && l == 2 && i == 1)
            //            {
            //                before = "-";
            //                Console.Write(before);
            //            }
            //            else
            //            {
            //                before = " ";
            //                Console.Write(before);
            //            }
            //        }
            //        Console.Write(Environment.NewLine);
            //        if (k != inputArray.Length - 1 && l != 2)
            //        {
            //            sb2 = sb;
            //            sb.Clear();
            //        }
            //    }
            //}

            string input = "    *   \n   ***  \n ****** ";
            string[] inputArray = Regex.Split(input, "\n");
            bool[] previousLine = new bool[] { false, false, false, false, false, false, false, false };
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            bool twoPrevious = false;
            int count = 0;

            for (int i = 0; i < inputArray.Count(); i++)
            {
                char[] inputCharArray = inputArray[i].ToString().ToCharArray();
                for (int j = 1; j < inputCharArray.Length - 1; j++)
                {
                    if (inputCharArray[j] == '*')
                    {
                        //+---+
                        //if previous AND next aren't * OR if previous isn't AND next is in line above OR previous is in line above AND next isn't
                        if ((inputCharArray[j - 1] != '*' && inputCharArray[j + 1] != '*') || (inputCharArray[j - 1] != '*' && previousLine[j + 1] == true) ||
                            (inputCharArray[j + 1] != '*' && previousLine[j - 1] == true))
                        {
                            Console.Write("+---+");
                            sb1.Append("+---+");
                            previousLine[j - 1] = twoPrevious;
                            twoPrevious = true;
                            count = 0;
                        }
                        //if previous is AND next one isn't
                        //---+
                        else if (inputCharArray[j - 1] == '*' && (inputCharArray[j + 1] != '*' || (previousLine[j + 1] == true && previousLine[j] == false)))
                        {
                            Console.Write("---+");
                            sb1.Append("---+");
                            previousLine[j - 1] = twoPrevious;
                            twoPrevious = true;
                            count = 0;
                        }
                        //+----
                        //if previous isn't AND next one is AND next one isn't in line above
                        else if (inputCharArray[j - 1] != '*' && inputCharArray[j + 1] == '*' && previousLine[j + 1] == false)
                        {
                            Console.Write("+----");
                            sb1.Append("+----");
                            previousLine[j - 1] = twoPrevious;
                            twoPrevious = true;
                            count = 0;
                        }
                        //-----
                        //if previous is AND next one is AND current isn't in the line above
                        else if (inputCharArray[j - 1] == '*' && inputCharArray[j + 1] == '*' && previousLine[j] == false)
                        {
                            Console.Write("-----");
                            sb1.Append("-----");
                            previousLine[j - 1] = twoPrevious;
                            twoPrevious = true;
                            count = 0;
                        }
                        else
                        {
                            count++;
                            if (count > 1)
                            {
                                Console.Write("    ");
                                sb1.Append("    ");
                            }
                            else
                            {
                                Console.Write("   ");
                                sb1.Append("   ");
                            }
                            previousLine[j - 1] = twoPrevious;
                            twoPrevious = true;
                        }
                    }
                    else
                    {
                        Console.Write("    ");
                        sb1.Append("    ");
                        previousLine[j - 1] = twoPrevious;
                        twoPrevious = false;
                        count = 0;
                    }
                }
                Console.Write(Environment.NewLine);
                for (int k = 0; k < sb1.Length; k++)
                {
                    //if it's + then write | else add space
                    if (sb1.ToString()[k] == '+')
                    {
                        Console.Write('|');
                        sb2.Append('|');
                    }
                    else
                    {
                        Console.Write(' ');
                        sb2.Append(' ');
                    }
                }
                sb1.Clear();
                Console.Write(Environment.NewLine);
            }

            Console.ReadLine();
        }
    }
}
