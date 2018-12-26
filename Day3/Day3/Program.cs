using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day3
{
    class Program
    {
        class Square
        {
            public int id;
            public int x;
            public int y;
            public int width;
            public int height;
        }
        static void Part1()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Square> squares = new List<Square>();
            int[,] grid = new int[1000, 1000];
            string[] line, positions, sizes;

            for (int i = 0; i < input.Length; i++)
            {
                squares.Add(new Square());

                line = input[i].Split(' ');
                positions = line[2].Split(',');
                sizes = line[3].Split('x');

                squares[i].id = Convert.ToInt32(line[0].Remove(0, 1));
                squares[i].x = Convert.ToInt32(positions[0]);
                squares[i].y = Convert.ToInt32(positions[1].Remove(positions[1].Length - 1, 1));
                squares[i].width = Convert.ToInt32(sizes[0]);
                squares[i].height = Convert.ToInt32(sizes[1]);

                //Console.WriteLine(squares[i].x);
                //Console.WriteLine(squares[i].y);
                //Console.WriteLine(squares[i].width);
                //Console.WriteLine(squares[i].height);

            }

            foreach (Square sqr in squares)
            {
                for (int i = sqr.x; i < sqr.x + sqr.width; i++)
                {
                    for (int j = sqr.y ; j < sqr.y + sqr.height; j++)
                    {
                        grid[i, j]++;
                    }
                }
            }

            int claims = 0;

            foreach (int i in grid)
            {
                if (i >= 2)
                {
                    claims++;
                }
            }

            Console.WriteLine(claims);
            Console.Read();
        }
        static void Part2()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Square> squares = new List<Square>();
            int[,] grid = new int[1000, 1000];
            string[] line, positions, sizes;

            for (int i = 0; i < input.Length; i++)
            {
                squares.Add(new Square());

                line = input[i].Split(' ');
                positions = line[2].Split(',');
                sizes = line[3].Split('x');

                squares[i].id = Convert.ToInt32(line[0].Remove(0, 1));
                squares[i].x = Convert.ToInt32(positions[0]);
                squares[i].y = Convert.ToInt32(positions[1].Remove(positions[1].Length - 1, 1));
                squares[i].width = Convert.ToInt32(sizes[0]);
                squares[i].height = Convert.ToInt32(sizes[1]);
            }

            foreach (Square sqr in squares)
            {
                for (int i = sqr.x; i < sqr.x + sqr.width; i++)
                {
                    for (int j = sqr.y; j < sqr.y + sqr.height; j++)
                    {
                        grid[i, j]++;
                    }
                }
            }

            bool overlap;

            foreach (Square sqr in squares)
            {
                overlap = false;
                for (int i = sqr.x; i < sqr.x + sqr.width; i++)
                {
                    if (!overlap)
                    {
                        for (int j = sqr.y; j < sqr.y + sqr.height; j++)
                        {
                            if (grid[i, j] != 1)
                            {
                                overlap = true;
                                break;
                            }
                            else
                            {
                                overlap = false;
                            }
                        }
                    }
                }
                if (!overlap)
                {
                    Console.WriteLine(sqr.id);
                    break;
                }
            }
            Console.Read();
        }
        static void Main(string[] args)
        {
            Part2();
        }
    }
}
