using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day10
{
    class Program
    {
        class Point
        {
            public int x;
            public int y;
            public int xVelocity;
            public int yVelocity;
            public Point(int _x, int _y, int _xVelocity, int _yVelocity)
            {
                x = _x;
                y = _y;
                xVelocity = _xVelocity;
                yVelocity = _yVelocity;
            }
        }
        static void Move(ref List<Point> points)
        {
            foreach (Point point in points)
            {
                point.x += point.xVelocity;
                point.y += point.yVelocity;
            }
        }
        static void MoveBack(ref List<Point> points)
        {
            foreach (Point point in points)
            {
                point.x -= point.xVelocity;
                point.y -= point.yVelocity;
            }
        }
        static void Part1()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Point> points = new List<Point>();
            foreach (string line in input)
            {
                string[] data = line.Split(',');
                data[0] = data[0].Remove(0, 10);
                int x = Convert.ToInt32(data[0]);
                string[] temp = data[1].Split('>');
                int y = Convert.ToInt32(temp[0]);
                temp[1] = temp[1].Remove(0, 11);
                int xVel = Convert.ToInt32(temp[1]);
                data[2] = data[2].Remove(data[2].Length - 1, 1);
                int yVel = Convert.ToInt32(data[2]);
                points.Add(new Point(x, y, xVel, yVel));
            }
            int height = points.Max(list => list.y) - points.Min(list => list.y);
            int width = points.Max(list => list.x) - points.Min(list => list.x);

            int newWidth, newHeight;

            while (true)
            {
                Move(ref points);
                newHeight = Math.Abs(points.Max(list => list.y) - points.Min(list => list.y));
                newWidth = Math.Abs(points.Max(list => list.x) - points.Min(list => list.x));

                if (newWidth > width || newHeight > height)
                {
                    MoveBack(ref points);
                    points = points.OrderBy(list => list.y).ThenBy(list => list.x).ToList();
                    for (int i = points.Min(list => list.y); i <= points.Max(list => list.y); i++)
                    {
                        for (int j = points.Min(list => list.x); j <= points.Max(list => list.x); j++)
                        {
                            if (points.Any(x => x.y == i && x.x == j))
                            {
                                Console.Write('#');
                            }
                            else
                            {
                                Console.Write(' ');
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                }
                height = newHeight;
                width = newWidth;
            }
            Console.Read();
        }
        static void Part2()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Point> points = new List<Point>();
            foreach (string line in input)
            {
                string[] data = line.Split(',');
                data[0] = data[0].Remove(0, 10);
                int x = Convert.ToInt32(data[0]);
                string[] temp = data[1].Split('>');
                int y = Convert.ToInt32(temp[0]);
                temp[1] = temp[1].Remove(0, 11);
                int xVel = Convert.ToInt32(temp[1]);
                data[2] = data[2].Remove(data[2].Length - 1, 1);
                int yVel = Convert.ToInt32(data[2]);
                points.Add(new Point(x, y, xVel, yVel));
            }
            int height = points.Max(list => list.y) - points.Min(list => list.y);
            int width = points.Max(list => list.x) - points.Min(list => list.x);

            int newWidth, newHeight;
            int seconds = 0;

            while (true)
            {
                seconds++;
                Move(ref points);
                newHeight = Math.Abs(points.Max(list => list.y) - points.Min(list => list.y));
                newWidth = Math.Abs(points.Max(list => list.x) - points.Min(list => list.x));

                if (newWidth > width || newHeight > height)
                {
                    seconds--;
                    break;
                }

                height = newHeight;
                width = newWidth;
            }

            Console.WriteLine(seconds);
            Console.Read();
        }
        static void Main(string[] args)
        {
            Part2();
        }
    }
}
