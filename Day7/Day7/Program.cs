using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day7
{
    class Program
    {
        class Step
        {
            public char id;
            public List<char> previous = new List<char>();
            public int duration;
            public Step(char _id)
            {
                id = _id;
            }
            public Step(char _id, int _duration)
            {
                id = _id;
                duration = _duration;
            }
        }
        static List<Step> SortByID(List<Step> list)
        {
            List<char> ids = new List<char>();
            foreach (Step st in list)
            {
                ids.Add(st.id);
            }
            ids.Sort();
            List<Step> returnList = new List<Step>();
            foreach (char id in ids)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (id == list[i].id)
                    {
                        returnList.Add(list[i]);
                    }
                }
            }
            return returnList;
        }
        static int GetIndex(List<Step> list, char id)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        static void Part1()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Step> steps = new List<Step>();
            string[] data;
            bool found;

            foreach(string line in input)
            {
                data = line.Split(' ');
                found = false;
                foreach (Step st in steps)
                {
                    if (Convert.ToChar(data[1]) == st.id)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    steps.Add(new Step(Convert.ToChar(data[1])));
                }
            }

            foreach (string line in input)
            {
                data = line.Split(' ');
                found = false;
                foreach (Step st in steps)
                {
                    if (Convert.ToChar(data[7]) == st.id)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    steps.Add(new Step(Convert.ToChar(data[7])));
                }
            }

            for (int i = 0; i < steps.Count; i++)
            {
                foreach (string line in input)
                {
                    data = line.Split(' ');
                    if (Convert.ToChar(data[7]) == steps[i].id)
                    {
                        steps[i].previous.Add(Convert.ToChar(data[1]));
                    }
                }
            }

            List<Step> available = new List<Step>();
            List<Step> undone = new List<Step>(steps);
            string order = "";

            while (true)
            {
                available.Clear();
                foreach (Step step in undone)
                {
                    if (step.previous.Count == 0)
                    {
                        available.Add(step);
                    }
                }
                if (available.Count == 0)
                {
                    break;
                }
                available = SortByID(available);
                undone.RemoveAt(GetIndex(undone, available[0].id));
                foreach (Step step in undone)
                {
                    for (int i = 0; i < step.previous.Count; i++)
                    {
                        if (step.previous[i] == available[0].id)
                        {
                            step.previous.RemoveAt(i);
                            break;
                        }
                    }
                }
                order += available[0].id;
            }

            Console.WriteLine(order);
            Console.Read();
        }
        static void Part2()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Step> steps = new List<Step>();
            string[] data;
            bool found;

            foreach (string line in input)
            {
                data = line.Split(' ');
                found = false;
                foreach (Step st in steps)
                {
                    if (Convert.ToChar(data[1]) == st.id)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    steps.Add(new Step(Convert.ToChar(data[1]), Convert.ToInt32(Convert.ToChar(data[1])) - 4));
                }
            }

            foreach (string line in input)
            {
                data = line.Split(' ');
                found = false;
                foreach (Step st in steps)
                {
                    if (Convert.ToChar(data[7]) == st.id)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    steps.Add(new Step(Convert.ToChar(data[7]), Convert.ToInt16(Convert.ToChar(data[7])) - 4));
                }
            }

            for (int i = 0; i < steps.Count; i++)
            {
                foreach (string line in input)
                {
                    data = line.Split(' ');
                    if (Convert.ToChar(data[7]) == steps[i].id)
                    {
                        steps[i].previous.Add(Convert.ToChar(data[1]));
                    }
                }
            }

            List<Step> undone = new List<Step>(steps);
            List<Step> available = new List<Step>();
            List<Step> working = new List<Step>();
            int seconds = 0;
            int workers = 5;

            while (true)
            {
                if (undone.Count == 0 && working.Count == 0 && available.Count == 0)
                {
                    break;
                }
                seconds++;
                for (int i = undone.Count - 1; i >= 0; i--)
                {
                    if (undone[i].previous.Count == 0)
                    {
                        available.Add(undone[i]);
                        undone.RemoveAt(i);
                    }
                }
                available = SortByID(available);
                available.Reverse();

                for (int i = available.Count - 1; i >=0; i--)
                {
                    if (working.Count < workers)
                    {
                        working.Add(available[i]);
                        available.RemoveAt(i);
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = 0; i < working.Count; i++)
                {
                    working[i].duration--;
                }
                for (int i = working.Count - 1; i >= 0; i--)
                {
                    if (working[i].duration == 0)
                    {
                        foreach (Step step in undone)
                        {
                            step.previous.Remove(working[i].id);
                        }
                        working.RemoveAt(i);
                    }
                }               
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
