using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    class Program
    {
        static void Part1()
        {
            int[,] grid = new int[300, 300];
            int gridSN = 5791;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int rackID = j + 11;
                    int powerLevel = rackID * (i + 1);
                    powerLevel += gridSN;
                    powerLevel *= rackID;
                    string temp = powerLevel.ToString();
                    try
                    {
                        temp = temp.Substring(temp.Length - 3, 1);
                    }
                    catch
                    {
                        temp = "0";
                    }
                    powerLevel = Convert.ToInt32(temp);
                    powerLevel -= 5;
                    grid[i, j] = powerLevel;
                }
            }

            int max = 0, Y = 0, X = 0;            

            for (int i = 0; i < grid.GetLength(0) - 3; i++)
            {
                for (int j = 0; j < grid.GetLength(1) - 3; j++)
                {
                    int total = 0;
                    for (int x = j; x < j + 3; x++)
                    {
                        for (int y = i; y < i + 3; y++)
                        {
                            total += grid[x, y];
                        }
                    }
                    if (total > max)
                    {
                        max = total;
                        X = i;
                        Y = j;
                    }
                }
            }
            

            Console.WriteLine((X + 1) + "," + (Y + 1));
            Console.Read();
        }
        static void Part2()
        {
            int[,] grid = new int[300, 300];
            int gridSN = 5791;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int rackID = j + 11;
                    int powerLevel = rackID * (i + 1);
                    powerLevel += gridSN;
                    powerLevel *= rackID;
                    string temp = powerLevel.ToString();
                    try
                    {
                        temp = temp.Substring(temp.Length - 3, 1);
                    }
                    catch
                    {
                        temp = "0";
                    }
                    powerLevel = Convert.ToInt32(temp);
                    powerLevel -= 5;
                    grid[i, j] = powerLevel;
                }
            }

            int max = 0, Y = 0, X = 0, size = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    for (int s = 1; s <= Math.Min(300 - i, 300 - j); s++)
                    {
                        int total = 0;
                        for (int x = j; x < j + s; x++)
                        {
                            for (int y = i; y < i + s; y++)
                            {
                                total += grid[x, y];
                            }
                        }
                        if (total > max)
                        {
                            max = total;
                            X = i;
                            Y = j;
                            size = s;
                        }
                    }
                }
            }

            Console.WriteLine((X + 1) + "," + (Y + 1) + "," + size);
            Console.Read();
        }
        static void Main(string[] args)
        {
            Part2();
        }
    }
}
