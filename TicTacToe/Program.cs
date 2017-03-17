using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> lines = new List<List<int>>();
            List<List<int>> rows = new List<List<int>>();
            List<List<int>> across = new List<List<int>>();
            for (int i = 0; i < 3; i++)
            {
                var line = Console.ReadLine().Split(' ').ToList().Select(s => int.Parse(s)).ToList();
                lines.Add(line);
            }
            for (int i = 0; i < 3; i++)
            {
                rows.Add(new List<int>());
                for (int j = 0; j < 3; j++)
                    rows[i].Add(lines[j][i]);
            }
            across.Add(new List<int>());
            across.Add(new List<int>());
            for (int j = 0; j < 3; j++)
            {
                across[0].Add(lines[j][j]);
                across[1].Add(lines[2 - j][j]);
            }
            // win if you can
            if (canSomeoneWin(1, 2, lines, rows, across))
            {
                ;
            }
            // prevent him from winning
            else if (canSomeoneWin(2, 1, lines, rows, across))
            {
                ;
            }
            else
            {
                int hor = _r.Next(3);
                int ver = _r.Next(3);
                while (lines[hor][ver] != 0)
                {
                    hor = _r.Next(3);
                    ver = _r.Next(3);
                }
                Console.WriteLine($"{ver} {hor}");
            }          
            Console.ReadLine();
        }
        static Random _r = new Random();
        private static bool canSomeoneWin(int someone, int otherGuy, List<List<int>> lines, List<List<int>> rows, List<List<int>> across)
        {
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].Where(t => t == someone).Count() == 2 && lines[i].Where(t => t == otherGuy).Count() == 0)
                {
                    nextMove(someone, otherGuy, lines, 1, i);
                    return true;
                }                    
                if (rows[i].Where(t => t == someone).Count() == 2 && rows[i].Where(t => t == otherGuy).Count() == 0)
                {
                    nextMove(someone, otherGuy, rows, 2, i);
                    return true;
                }
                if (i < 2)
                {
                    if (across[i].Where(t => t == someone).Count() == 2 && across[i].Where(t => t == otherGuy).Count() == 0)
                    {
                        nextMove(someone, otherGuy, across, 3, i);
                        return true;
                    }
                }
            }
            return false;
        }
        private static void nextMove(int someone, int otherGuy, List<List<int>> lra, int lineRowAcross, int second)
        {
            int[] nextMove = new int[2];
            switch (lineRowAcross)
            {
                case 1:
                    nextMove[0] = second;
                    nextMove[1] = lra[second].IndexOf(0);                    
                    break;
                case 2:
                    nextMove[1] = second;
                    nextMove[0] = lra[second].IndexOf(0);
                    break;
                case 3:
                    nextMove[1] = lra[second].IndexOf(0);
                    nextMove[0] = second == 0 ? lra[second].IndexOf(0) : 2 - lra[second].IndexOf(0);                  
                    break;
                default:
                    break;
            }
            Console.WriteLine($"{nextMove[1]} {nextMove[0]}");
        }
    }
}
