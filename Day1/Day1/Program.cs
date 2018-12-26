using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Part1()
        {
            string[] input = File.ReadAllLines("input.txt");
            int frequency = 0;

            for (int i = 0; i < input.Length; i++)
            {
                frequency += Convert.ToInt32(input[i]);
            }

            Console.WriteLine(frequency);
            Console.Read();
        }       
        static void Part2()
        {
            string[] input = File.ReadAllLines("input2.txt");
            List<int> frequencies = new List<int>();
            int frequency = 0;
            frequencies.Add(frequency);
            bool found = false;

            while (!found)
            {               
                for (int i = 0; i < input.Length; i++)
                {
                    frequency += Convert.ToInt32(input[i]);
                    if (ValueInList(frequency, frequencies))
                    {
                        found = true;
                        break;
                    }
                    else
                    {
                        frequencies.Add(frequency);
                    }
                }
            }
            Console.WriteLine(frequency);
            Console.Read();
        }
        static bool ValueInList(int _frequency, List<int> _frequencies)
        {
            foreach (int f in _frequencies)
            {
                if (f == _frequency)
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Part2();
        }
    }
}
