using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day6
{
    class Program
    {
        class Point
        {
            public int x;
            public int y;
            public int id = 0;
            public List<int> distances = new List<int>();
            public Point(int _x, int _y, int _id)
            {
                x = _x;
                y = _y;
                id = _id;
            }
            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }
        static int Distance(Point A, Point B)
        {
            return Math.Abs(A.x - B.x) + Math.Abs(A.y - B.y);
        }
        static bool HasDuplicates(List<int> list)
        {
            for (int i = 0; i < list.Count -1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static int ContainsAmount(List<int> list, int number)
        {
            int count = 0;
            foreach (int i in list)
            {
                if (i == number)
                {
                    count++;
                }
            }
            return count;
        }
        static void Part1()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Point> points = new List<Point>();
            int id = 1;
            string[] coordinates;

            foreach (string line in input)
            {
                coordinates = line.Split(',', ' ');
                points.Add(new Point(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[2]), id));
                id++;
            }

            int left = points[0].x;
            int right = points[0].x;
            int down = points[0].y;
            int up = points[0].y;

            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].x < left)
                {
                    left = points[i].x;
                }
                else if (points[i].x > right)
                {
                    right = points[i].x;
                }
                if (points[i].y < up)
                {
                    up = points[i].y;
                }
                else if (points[i].y > down)
                {
                    down = points[i].y;
                }
            }

            for (int i = 0; i < points.Count; i++) // translate the coordinates, so that the upper left edge of the rectangle they define is [1,1]
            {
                points[i].x -= left - 1;
                points[i].y -= up - 1;
            }

            int width = right - left;
            int height = down - up;

            Point[,] grid = new Point[height + 3, width + 3];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Point(i, j)
                    {
                        x = j,
                        y = i
                    };
                    foreach (Point pt in points)
                    {
                        grid[i, j].distances.Add(Distance(grid[i, j], pt)); // count the distance to each point from the input values
                    }
                }
            }

            foreach(Point p in points)
            {
                grid[p.y, p.x].id = p.id;
            }

            int shortestPath;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j].distances.Contains(0))
                    {
                        continue;
                    }
                    shortestPath = grid[i, j].distances.Min();
                    if (ContainsAmount(grid[i, j].distances, shortestPath) == 1)
                    {
                        grid[i, j].id = points[grid[i, j].distances.IndexOf(shortestPath)].id;
                    }
                    else
                    {
                        grid[i, j].id = 0;
                    }
                }
            }

            List<int> valid = new List<int>();

            for (int i = 0; i < points.Count; i++)
            {
                valid.Add(points[i].id);
            }

            for (int i = 0; i < grid.GetLength(0); i++)  // remove ids that have infinite area
            {
                valid.Remove(grid[i, 0].id);
                valid.Remove(grid[i, grid.GetLength(1) - 1].id);
            }

            for (int i = 0; i < grid.GetLength(1); i++) // remove ids that have infinite area
            {
                valid.Remove(grid[0, i].id);
                valid.Remove(grid[grid.GetLength(0) - 1, i].id);
            }

            int largestArea = 0;
            int area;

            foreach (int val in valid)
            {
                area = 0;
                for (int i = 1; i < grid.GetLength(0) - 1; i++)
                {
                    for (int j = 1; j < grid.GetLength(1) - 1; j++)
                    {
                        if (grid[i, j].id == val)
                        {
                            area++;
                        }
                    }
                }
                if (area > largestArea)
                {
                    largestArea = area;
                }
            }

            Console.WriteLine(largestArea);
            Console.Read();
        }
        static void Part2()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Point> points = new List<Point>();
            int id = 1;
            string[] coordinates;

            foreach (string line in input)
            {
                coordinates = line.Split(',', ' ');
                points.Add(new Point(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[2]), id));
                id++;
            }

            int left = points[0].x;
            int right = points[0].x;
            int down = points[0].y;
            int up = points[0].y;

            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].x < left)
                {
                    left = points[i].x;
                }
                else if (points[i].x > right)
                {
                    right = points[i].x;
                }
                if (points[i].y < up)
                {
                    up = points[i].y;
                }
                else if (points[i].y > down)
                {
                    down = points[i].y;
                }
            }

            for (int i = 0; i < points.Count; i++) // translate the coordinates, so that the upper left edge of the rectangle they define is [1,1]
            {
                points[i].x -= left - 1;
                points[i].y -= up - 1;
            }

            int width = right - left;
            int height = down - up;

            Point[,] grid = new Point[height + 3, width + 3];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Point(i, j)
                    {
                        x = j,
                        y = i
                    };
                    foreach (Point pt in points)
                    {
                        grid[i, j].distances.Add(Distance(grid[i, j], pt)); // count the distance to each point from the input values
                    }
                }
            }

            foreach (Point p in points)
            {
                grid[p.y, p.x].id = p.id;
            }

            int area = 0;

            foreach (Point pt in grid)
            {
                if (pt.distances.Sum() < 10000)
                {
                    area++;
                }
            }

            Console.WriteLine(area);
            Console.Read();
        }
        static void Main(string[] args)
        {
            Part2();
        }
    }
}
