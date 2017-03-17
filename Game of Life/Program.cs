using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int lol = 0; lol < 20; lol++)
            {
                string input = "";
                if (lol == 0)
                {
                    input = @" **
**
 *";
                }
                else
                {
                    input = sb.ToString();
                }
                int neighbours = 0;
                string[] idk = Regex.Split(input, "\r\n");
                idk = appendWhitespace(idk);
                char character = new char();
                for (int i = 0; i < idk.Count(); i++)
                {
                    for (int j = 0; j < idk[i].Length; j++)
                    {
                        if (idk[i][j] != ' ')
                        {
                            neighbours = countNeighbours(i, j, idk, character);
                            if (neighbours < 2)
                            {
                                sb.Append(" ");
                            }
                            else if (neighbours == 2 || neighbours == 3)
                            {
                                sb.Append(returnCharacter(i, j, idk, character));
                            }
                            else if (neighbours > 3)
                            {
                                sb.Append(" ");
                            }
                            neighbours = 0;
                        }
                        else
                        {
                            neighbours = countNeighbours(i, j, idk, character);
                            if (neighbours == 3)
                            {
                                sb.Append(returnCharacter(i, j, idk, character));
                            }
                            else
                            {
                                sb.Append(" ");
                            }
                            neighbours = 0;
                        }
                    }
                    sb.Append(" ");
                    sb.Append(Environment.NewLine);
                }
                Console.WriteLine(sb.ToString());
                Console.ReadLine();
            }
        }
        private static bool checkNeighbours(int i, int j, string[] idk)
        {
            return j >= 0 && i >= 0 && i <= idk.Count() - 1 && j <= idk[i].Length - 1 && idk[i][j] != ' ';
        }
        private static int countNeighbours(int i, int j, string[] idk, char character)
        {
            int neighbours = 0;
            for (int m = -1; m < 2; m++)
            {
                for (int k = 1; k > -2; k--)
                {
                    if (checkNeighbours(i + m, j + k, idk))
                    {
                        if (k != 0 || m != 0)
                        {
                            neighbours++;
                            if (idk[i][j] != ' ')
                            {
                                character = idk[i][j];
                            }
                            else
                            {
                                character = idk[i + m][j + k];
                            }
                        }
                    }
                }
            }
            return neighbours;
        }
        private static char returnCharacter(int i, int j, string[] idk, char character)
        {
            for (int m = -1; m < 2; m++)
            {
                for (int k = 1; k > -2; k--)
                {
                    if (checkNeighbours(i + m, j + k, idk))
                    {
                        if (k != 0 || m != 0)
                        {
                            if (idk[i][j] != ' ')
                            {
                                character = idk[i][j];
                            }
                            else
                            {
                                character = idk[i + m][j + k];
                            }
                        }
                    }
                }
            }
            return character;
        }
        private static string[] appendWhitespace(string[] idk)
        {
            int max = 0;
            for (int i = 0; i < idk.Count(); i++)
            {
                if (idk[i].Length > max)
                {
                    max = idk[i].Length;
                }
            }
            for (int i = 0; i < idk.Count() - 1; i++)
            {
                if (idk[i].Length < max)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(idk[i]);
                    for (int j = 0; j < (max - idk[i].Length); j++)
                    {
                        sb.Append(" ");
                    }
                    idk[i] = sb.ToString();
                }
            }
            return idk;
        }
    }
}
