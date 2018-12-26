using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day2
{
    class Program
    {
        class Letter
        {
            public char letter;
            public int count = 1;
            public Letter(char _let)
            {
                letter = _let;
            }
        }
        static int CharInListIndex(char _c, List<Letter> _letters)
        {
            for (int i = 0; i < _letters.Count; i++)
            {
                if (_c == _letters[i].letter)
                {
                    return i;
                }
            }
            return -1;
        }
        static void Part1()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Letter> letters = new List<Letter>();

            int two = 0, three = 0;
            int index;

            foreach (string line in input)
            {                
                for (int i = 0; i < line.Length; i++)
                {
                    index = CharInListIndex(line[i], letters);
                    if (index >= 0)
                    {                        
                        letters[index].count++;
                    }
                    else if (index == -1)
                    {
                        letters.Add(new Letter(line[i]));
                    }
                }
                foreach (Letter let in letters)
                {
                    if (let.count == 2)
                    {
                        two++;
                        break;
                    }           
                }
                foreach (Letter let in letters)
                {
                    if (let.count == 3)
                    {
                        three++;
                        break;
                    }
                }
                letters.Clear();
            }

            Console.WriteLine(two * three);
            Console.Read();
        }
        static void Part2()
        {
            string[] input = File.ReadAllLines("input.txt");
            int differences;
            string output;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    differences = 0;
                    output = "";
                    for (int k = 0; k < input[i].Length; k++)
                    {
                        if (input[i][k] != input[j][k])
                        {
                            differences++;
                        }
                        else
                        {
                            output += input[i][k];
                        }
                    }
                    if (differences == 1)
                    {
                        Console.WriteLine(output);
                    }
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
