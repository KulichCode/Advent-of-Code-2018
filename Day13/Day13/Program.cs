using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day13
{
    class Program
    {
        static char[,] track;
        class Cart
        {
            public int x;
            public int y;
            public string facing;
            public int intersectionsPassed = 0;
            public Cart(int _x, int _y, string _facing)
            {
                x = _x;
                y = _y;
                facing = _facing;
            }
        }
        static void MoveCart(Cart cart)
        {
            switch (cart.facing)
            {
                case "left":
                    cart.x--;
                    break;
                case "right":
                    cart.x++;
                    break;
                case "down":
                    cart.y++;
                    break;
                case "up":
                    cart.y--;
                    break;
            }
            switch (track[cart.y, cart.x])
            {
                case '/':
                    switch(cart.facing)
                    {
                        case "right":
                            cart.facing = "up";
                            break;
                        case "left":
                            cart.facing = "down";
                            break;
                        case "down":
                            cart.facing = "left";
                            break;
                        case "up":
                            cart.facing = "right";
                            break;
                    }
                    break;
                case '\\':
                    switch (cart.facing)
                    {
                        case "right":
                            cart.facing = "down";
                            break;
                        case "left":
                            cart.facing = "up";
                            break;
                        case "down":
                            cart.facing = "right";
                            break;
                        case "up":
                            cart.facing = "left";
                            break;
                    }
                    break;
                case '+':
                    switch (cart.intersectionsPassed % 3)
                    {
                        // turn left
                        case 0:
                            switch (cart.facing)
                            {
                                case "right":
                                    cart.facing = "up";
                                    break;
                                case "left":
                                    cart.facing = "down";
                                    break;
                                case "down":
                                    cart.facing = "right";
                                    break;
                                case "up":
                                    cart.facing = "left";
                                    break;
                            }
                            break;
                        // turn right
                        case 2:
                            switch (cart.facing)
                            {
                                case "right":
                                    cart.facing = "down";
                                    break;
                                case "left":
                                    cart.facing = "up";
                                    break;
                                case "down":
                                    cart.facing = "left";
                                    break;
                                case "up":
                                    cart.facing = "right";
                                    break;
                            }
                            break;
                    }
                    cart.intersectionsPassed++;
                    break;
            }
        }
        static void Part1()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Cart> carts = new List<Cart>();
            track = new char[input.Length, input[0].Length];

            for (int i = 0; i < input.Length; i++)
            {                
                for (int j = 0; j < input[i].Length; j++)
                {
                    switch (input[i][j])
                    {
                        case '>':
                            carts.Add(new Cart(j, i, "right"));
                            track[i, j] = '-';
                            break;
                        case '<':
                            carts.Add(new Cart(j, i, "left"));
                            track[i, j] = '-';
                            break;
                        case 'v':
                            carts.Add(new Cart(j, i, "down"));
                            track[i, j] = '|';
                            break;
                        case '^':
                            carts.Add(new Cart(j, i, "up"));
                            track[i, j] = '|';
                            break;
                        default:
                            track[i, j] = input[i][j];
                            break;
                    }
                }
            }

            bool collision = false;
            while (!collision)
            {
                carts.OrderBy(list => list.y).ThenBy(list => list.x);
                for (int i = 0; i < carts.Count; i++)
                {
                    MoveCart(carts[i]);
                    for (int j = 0; j < carts.Count; j++)
                    {
                        if (i != j)
                        {
                            if (carts[i].x == carts[j].x && carts[i].y == carts[j].y)
                            {
                                collision = true;
                                Console.WriteLine(carts[i].x + "," + carts[i].y);
                                break;
                            }
                        }
                    }
                }
            }

            Console.Read();
        }
        static void Part2()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Cart> carts = new List<Cart>();
            track = new char[input.Length, input[0].Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    switch (input[i][j])
                    {
                        case '>':
                            carts.Add(new Cart(j, i, "right"));
                            track[i, j] = '-';
                            break;
                        case '<':
                            carts.Add(new Cart(j, i, "left"));
                            track[i, j] = '-';
                            break;
                        case 'v':
                            carts.Add(new Cart(j, i, "down"));
                            track[i, j] = '|';
                            break;
                        case '^':
                            carts.Add(new Cart(j, i, "up"));
                            track[i, j] = '|';
                            break;
                        default:
                            track[i, j] = input[i][j];
                            break;
                    }
                }
            }

            while (carts.Count > 1)
            {
                carts = carts.OrderBy(list => list.y).ThenBy(list => list.x).ToList();
                carts.Reverse();
                for (int i = carts.Count - 1; i >= 0; i--)
                {
                    MoveCart(carts[i]);
                    for (int j = carts.Count - 1; j >= 0; j--)
                    {
                        if (i != j)
                        {
                            if (carts[i].x == carts[j].x && carts[i].y == carts[j].y)
                            {
                                if (i > j)
                                {
                                    carts.RemoveAt(i);
                                    carts.RemoveAt(j);
                                    i--;
                                }
                                else
                                {
                                    carts.RemoveAt(j);
                                    carts.RemoveAt(i);
                                }
                                break;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(carts[0].x + "," + carts[0].y);
            Console.Read();
        }
        static void Main(string[] args)
        {
            Part2();
        }
    }
}
