using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Bowling_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"X -/ X 5- 8/ 9- X 81 1- 4/X";
            bool[] isStrike = new bool[11];
            bool[] isSpare = new bool[11];
            //string[] theseFrames = frames(input, out isStrike, out isSpare);
            //int[] scores = evaluateFrame(theseFrames);
            //int score = evaluateScores(scores, isStrike, isSpare, theseFrames);
            int ayyLmao = score(input);
        }
        private static int score(string input)
        {
            int score = 0;
            input = input.Replace(" ", "");
            input = input.Replace("-", "0");
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsNumber(input[i]))
                {
                    score += int.Parse(input[i].ToString());
                }
                else if (input[i] == 'X')
                {
                    score += 10;
                    if (input.Length > i + 2)
                    {
                        for (int j = 1; j < 3; j++)
                        {
                            if (input[i + j] == 'X')
                            {
                                score += 10;
                            }
                            else if (input[i + j] == '/')
                            {
                                score += 10 - int.Parse(input[i + j - 1].ToString());
                            }
                            else if (char.IsNumber(input[i + j]))
                            {
                                score += int.Parse(input[i + j].ToString());
                            }
                        }
                    }
                    else if (input.Length > i + 1)
                    {
                        if (input[i + 1] == 'X')
                        {
                            score += 10;
                        }
                        else if (input[i + 1] == '/')
                        {
                            score += 10 - int.Parse(input[i].ToString());
                        }
                        else if (char.IsNumber(input[i + 1]))
                        {
                            score += int.Parse(input[i + 1].ToString());
                        }
                    }
                }
                else if (input[i] == '/')
                {
                    score += 10 - int.Parse(input[i - 1].ToString());
                    if (input.Length > i + 1)
                    {
                        if ((input[i + 1] == 'X' || input[i + 1] == '/') && (i + 2) < input.Length)
                        {
                            score += 10;
                        }
                        else if ((char.IsNumber(input[i + 1])) && (i + 2) < input.Length)
                        {
                            score += int.Parse(input[i + 1].ToString());
                        }
                    }
                }
            }
            return score;
        }
        public static string[] frames(string input, out bool[] isStrike, out bool[] isSpare)
        {
            isStrike = new bool[11];
            isSpare = new bool[11];

            input = string.Concat(input, " 00");
            input = input.Replace("-", "0");
            string[] frame = Regex.Split(input, " ");
            for (int i = 0; i < frame.Length; i++)
            {
                if (i < 10)
                {
                    if (frame[i] == "X")
                    {
                        isStrike[i] = true;
                        isSpare[i] = false;
                    }
                    else if (frame[i].Contains("/"))
                    {
                        isSpare[i] = true;
                        isStrike[i] = false;
                    }
                }
            }
            return frame;
        }
        private static int[] evaluateFrame(string[] frame)
        {
            int[] evaluate = new int[11];
            int j = 0;

            for (int i = 0; i < frame.Length; i++)
            {
                int score = 0;
                if (frame[i] == "X")
                {
                    score = 10;
                    evaluate[j] = score;
                    j++;
                }
                else if (char.IsNumber(frame[i][0]))
                {
                    score = int.Parse(frame[i][0].ToString());
                    if (char.IsNumber(frame[i][1]))
                    {
                        score += int.Parse(frame[i][1].ToString());
                        evaluate[j] = score;
                        j++;
                    }
                    else if (frame[i][1] == '/')
                    {
                        score = 10;
                        evaluate[j] = score;
                        j++;
                    }
                }
                if (i == 9 && frame[i].Length == 3)
                {
                    if (frame[i][2] == 'X' || frame[i][2] == '/')
                    {
                        evaluate[j] += 10;
                    }
                    else if (char.IsNumber(frame[i][2]))
                    {
                        evaluate[9] += int.Parse(frame[i][2].ToString());
                    }
                }
            }
            return evaluate;
        }
        private static int evaluateScores(int[] evaluateFrame, bool[] isStrike, bool[] isSpare, string[] frames)
        {
            int score = 0;
            for (int i = 0; i < evaluateFrame.Length; i++)
            {
                if (!isStrike[i] && !isSpare[i])
                {
                    score += evaluateFrame[i];
                }
                else if (isStrike[i])
                {
                    if (frames[i + 1] == "X")
                    {
                        score += evaluateFrame[i] + evaluateFrame[i + 1];
                        if (char.IsNumber(frames[i + 2][0]))
                        {
                            score += int.Parse(frames[i + 2][0].ToString());
                        }
                        else if (frames[i + 2] == "X")
                        {
                            score += 10;
                        }
                    }
                    else
                    {
                        score += evaluateFrame[i] + evaluateFrame[i + 1];
                    }
                }
                else if (isSpare[i])
                {
                    if (char.IsNumber(frames[i + 1][0]))
                    {
                        score += evaluateFrame[i] + int.Parse(frames[i + 1][0].ToString());
                    }
                    else if (frames[i + 1][0] == 'X')
                    {
                        score += evaluateFrame[i] + 10;
                    }
                    if (frames[i].Length == 3)
                    {
                        if (frames[i][2] == 'X')
                        {
                            score += 10;
                        }
                    }
                }
            }
            return score;
        }
    }
}
