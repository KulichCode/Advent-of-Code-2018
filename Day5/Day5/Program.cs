using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day5
{
    class Program
    {
        static void Part1()
        {
            string input = File.ReadAllText("input.txt");

            bool complete = false;

            while (!complete)
            {
                complete = true;
                for (int i = 0; i < input.Length - 1; i++)
                {

                    if ((char.ToLower(input[i]) == input[i + 1] && char.ToUpper(input[i]) == input[i]) || char.ToUpper(input[i]) == input[i + 1] && char.ToLower(input[i]) == input[i])
                    {
                        input = input.Remove(i, 2);
                        complete = false;
                    }
                }
            }

            Console.WriteLine(input.Length);
            Console.Read();
        }
        static int React(string str)
        {
            bool complete = false;

            while (!complete)
            {
                complete = true;
                for (int i = 0; i < str.Length - 1; i++)
                {

                    if ((char.ToLower(str[i]) == str[i + 1] && char.ToUpper(str[i]) == str[i]) || char.ToUpper(str[i]) == str[i + 1] && char.ToLower(str[i]) == str[i])
                    {
                        str = str.Remove(i, 2);
                        complete = false;
                    }
                }
            }

            return str.Length;
        }
        static void Part2()
        {
            string input = File.ReadAllText("input.txt");
            List<char> units = new List<char>();

            foreach (char unit in input)
            {
                if (!units.Contains(char.ToLower(unit)))
                {
                    units.Add(char.ToLower(unit));
                }
            }
            units.Sort();

            string removed;
            int shortest = input.Length;

            foreach(char unit in units)
            {
                removed = input;
                for (int i = removed.Length - 1; i >= 0; i--)
                {
                    if (char.ToLower(removed[i]) == unit)
                    {
                        removed = removed.Remove(i, 1);
                    }
                }
                if (React(removed) < shortest)
                {
                    shortest = React(removed);
                }
            }

            Console.WriteLine(shortest);
            Console.Read();
        }
        static void Main(string[] args)
        {
            Part2();

        }
    }
}
