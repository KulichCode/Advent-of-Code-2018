using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day4
{
    class Program
    {
        class Guard
        {
            public int id;
            public int asleep = 0;
            public int[] minutes = new int[60];
            public Guard(int _id)
            {
                id = _id;
            }
        }
        static void Part1()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Guard> guards = new List<Guard>();
            Array.Sort(input);
            string[] data;

            int currentGuardID = -1;
            int currentGuardIndex = -1;
            bool guardFound = false;
            int fallAsleep = 0; // the minute the guard falls asleep
            int minute;

            foreach (string line in input)
            {
                data = line.Split(' ');
                data[0] = data[0].Remove(0, 1);
                data[1] = data[1].Remove(5, 1);
                data[3] = data[3].Remove(0, 1);
                minute = Convert.ToInt32(data[1].Remove(0, 3));

                if (data[2] == "Guard")
                {
                    guardFound = false;
                    currentGuardID = Convert.ToInt32(data[3]);
                    for (int i = 0; i < guards.Count; i++)
                    {
                        if (guards[i].id == currentGuardID)
                        {
                            currentGuardIndex = i;
                            guardFound = true;
                            break;
                        }
                    }
                    if (!guardFound)
                    {
                        guards.Add(new Guard(currentGuardID));
                        currentGuardIndex = guards.Count - 1;
                        currentGuardID = guards[currentGuardIndex].id;
                        continue;
                    }
                }
                else if (data[2] == "falls")
                {
                    fallAsleep = minute;
                }
                else if (data[2] == "wakes")
                {
                    guards[currentGuardIndex].asleep += minute - fallAsleep;
                    for (int i = fallAsleep; i < minute; i++)
                    {
                        guards[currentGuardIndex].minutes[i]++;
                    }
                }
            }

            int mostAsleepGuard = 0;
            int mostAsleepMinute = 0;

            for (int i = 1; i < guards.Count; i++)
            {
                if (guards[i].asleep > guards[mostAsleepGuard].asleep)
                {
                    mostAsleepGuard = i;
                }
            }

            for (int i = 1; i < guards[mostAsleepGuard].minutes.Length; i++)
            {
                if (guards[mostAsleepGuard].minutes[i] > guards[mostAsleepGuard].minutes[mostAsleepMinute])
                {
                    mostAsleepMinute = i;
                }
            }

            Console.WriteLine(guards[mostAsleepGuard].id * mostAsleepMinute);
            Console.Read();
        }
        static void Part2()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Guard> guards = new List<Guard>();
            Array.Sort(input);
            string[] data;

            int currentGuardID = -1;
            int currentGuardIndex = -1;
            bool guardFound = false;
            int fallAsleep = 0; // the minute the guard falls asleep
            int wakesUp = 0; // the minute the guard wakes up
            int minute;

            foreach (string line in input)
            {
                data = line.Split(' ');
                data[0] = data[0].Remove(0, 1);
                data[1] = data[1].Remove(5, 1);
                data[3] = data[3].Remove(0, 1);
                minute = Convert.ToInt32(data[1].Remove(0, 3));

                if (data[2] == "Guard")
                {
                    guardFound = false;
                    currentGuardID = Convert.ToInt32(data[3]);
                    for (int i = 0; i < guards.Count; i++)
                    {
                        if (guards[i].id == currentGuardID)
                        {
                            currentGuardIndex = i;
                            guardFound = true;
                            break;
                        }
                    }
                    if (!guardFound)
                    {
                        guards.Add(new Guard(currentGuardID));
                        currentGuardIndex = guards.Count - 1;
                        currentGuardID = guards[currentGuardIndex].id;
                        continue;
                    }
                }
                else if (data[2] == "falls")
                {
                    fallAsleep = minute;
                }
                else if (data[2] == "wakes")
                {
                    wakesUp = minute;
                    guards[currentGuardIndex].asleep += minute - fallAsleep;
                    for (int i = fallAsleep; i < minute; i++)
                    {
                        guards[currentGuardIndex].minutes[i]++;
                    }
                }
            }

            int mostAsleepGuard = 0;
            int mostAsleepMinute = 0;
            int timesAsleep = 0;

            for (int i = 0; i < guards.Count; i++)
            {
                for (int j = 0; j < guards[i].minutes.Length; j++)
                {
                    if (guards[i].minutes[j] > timesAsleep)
                    {
                        timesAsleep = guards[i].minutes[j];
                        mostAsleepGuard = guards[i].id;
                        mostAsleepMinute = j;
                    }
                }
            }

            Console.WriteLine(mostAsleepGuard * mostAsleepMinute);
            Console.Read();
        }
        static void Main(string[] args)
        {
            Part2();
        }
    }
}
