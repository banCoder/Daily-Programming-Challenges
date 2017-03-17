using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jennys_Fruit_Basket
{
    static class Program
    {
        static void Main(string[] args)
        {
            // we have 500
            // each fruit costs XX
            // calculcate fruits so it's exactly 500
            calculateMoney();
            List<string> ayyLmao = combinations("1234");
            Console.ReadLine();
        }
        private static void calculateMoney()
        {
            int money = 500;
            buy(3, Fruit.pineapple, ref money);
        }
        private static void buy(int quantity, Fruit fruit, ref int money)
        {
            money -= quantity * (int)fruit;
        }
        private static List<string> combinations(string input)
        {
            List<string> combos = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i]);
                for (int j = 0; j < input.Length; j++)
                {
                    sb.Append(input[j]);
                    for (int k = 0; k < input.Length; k++)
                    {
                        sb.Append(input[k]);
                        for (int l = 0; l < input.Length; l++)
                        {
                            sb.Append(input[l]);
                        }
                    }
                }
            }
            return combos;
        }
    }
    enum Fruit
    {
        banana = 32,
        kiwi = 41,
        mango = 97,
        papaya = 254,
        pineapple = 399
    }
}
