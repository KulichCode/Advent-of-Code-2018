using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day9
{
    public class Program
    {
        static LinkedList<int> marbles = new LinkedList<int>();
        static List<long> players;
        static LinkedListNode<int> current;
        static void Next()
        {
            current = current.Next ?? marbles.First;
        }
        static void Previous()
        {
            current = current.Previous ?? marbles.Last;
        }
        static void Part()
        {
            int playersAmount = 466;
            int rounds = 71436;
            players = new List<long>(playersAmount);
            for (int i = 0; i < players.Capacity; i++)
            {
                players.Add(new long());
            }
            int value = 0;
            current = marbles.AddFirst(value);
            int currentPlayer = 0;

            while (value <= rounds)
            {
                value++;
                currentPlayer++;
                currentPlayer %= players.Count;

                if (value % 23 != 0)
                {
                    Next();
                    marbles.AddAfter(current, value);
                    Next();
                }
                else
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Previous();
                    }
                    var temp = current;
                    players[currentPlayer] += value;
                    players[currentPlayer] += current.Value;
                    Next();
                    marbles.Remove(temp);
                }

            }

            long highest = 0;
            foreach (long player in players)
            {
                if (player > highest)
                {
                    highest = player;
                }
            }

            Console.WriteLine(highest);
            Console.Read();
        }
        static void Part2()
        {
            int playersAmount = 466;
            int rounds = 71436 * 100;
            players = new List<long>(playersAmount);
            for (int i = 0; i < players.Capacity; i++)
            {
                players.Add(new long());
            }
            int value = 0;
            current = marbles.AddFirst(value);
            int currentPlayer = 0;

            while (value <= rounds)
            {
                value++;
                currentPlayer++;
                currentPlayer %= players.Count;

                if (value % 23 != 0)
                {
                    Next();
                    marbles.AddAfter(current, value);
                    Next();
                }
                else
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Previous();
                    }
                    var temp = current;
                    players[currentPlayer] += value;
                    players[currentPlayer] += current.Value;
                    Next();
                    marbles.Remove(temp);
                }

            }

            long highest = 0;
            foreach (long player in players)
            {
                if (player > highest)
                {
                    highest = player;
                }
            }

            Console.WriteLine(highest);
            Console.Read();
        }
        static void Main(string[] args)
        {
            Part2();
        }
    }
}
