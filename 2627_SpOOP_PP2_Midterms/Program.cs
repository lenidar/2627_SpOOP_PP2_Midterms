using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2627_SpOOP_PP2_Midterms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BINGO();
        }

        static void BINGO()
        {
            DisplayCard(GenerateCard());
        }

        static int[][] GenerateCard()
        {
            int[][] card = new int[5][];
            Random rnd = new Random();

            for (int x = 0; x < card.Length; x++)
            {
                //card[x] = GenerateColumn(rnd);
                card[x] = GenerateColumn(rnd, x);
            }

            return card;
        }

        static int[] GenerateColumn(Random rnd)
        {
            List<int> values = new List<int>();
            int[] col = new int[5];

            for(int x = 1; x < 16; x++)
                values.Add(x);

            for(int x = 0; x < col.Length; x++)
            {
                col[x] = values[rnd.Next(col.Length)];
                values.Remove(col[x]);
            }

            return col;
        }
        
        static int[] GenerateColumn(Random rnd, int place)
        {
            List<int> values = new List<int>();
            int[] col = new int[5];

            for (int x = 1; x < 16; x++)
                values.Add(x);

            for (int x = 0; x < col.Length; x++)
            {
                col[x] = values[rnd.Next(col.Length)];
                values.Remove(col[x]);
                col[x] = col[x] + (place * 15);
            }

            return col;
        }

        static void DisplayCard(int[][] card)
        {
            string temp = "";
            Console.WriteLine("+-----+-----+-----+-----+-----+");
            Console.WriteLine("|  B  |  I  |  N  |  G  |  O  |");
            Console.WriteLine("+-----+-----+-----+-----+-----+");
            for (int y = 0; y < 5; y++) // y is row
            {
                Console.Write("| ");
                for(int x = 0; x < 5; x++) // x is col
                {
                    if (x == 2 && y == 2)
                        Console.Write("FRE | ");
                    else
                    {
                        //Console.Write(card[x][y] + "\t");
                        temp = card[x][y] + "";

                        while (temp.Length < 3)
                            temp = "0" + temp;

                        Console.Write(temp + " | ");
                    }

                }
                Console.WriteLine("");
                Console.WriteLine("+-----+-----+-----+-----+-----+");
            }
        }
    }
}
