using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day8
{
    class Program
    {
        public static string[] input;
        public static int i = 0;
        public static List<Node> nodes = new List<Node>();

        public class Node
        {
            public int childs;
            public int metadataAmount;
            public List<int> metadata = new List<int>();
            public List<int> childIndexes = new List<int>();
            public int value = 0;
        }
        static void AnalyzeNode()
        {
            nodes.Add(new Node());
            int index = nodes.Count - 1;
            nodes[index].childs = Convert.ToInt32(input[i]);
            i++;
            nodes[index].metadataAmount = Convert.ToInt32(input[i]);
            i++;

            for (int j = 0; j < nodes[index].childs; j++)
            {
                nodes[index].childIndexes.Add(nodes.Count);
                AnalyzeNode();
            }
            for (int j = 0; j < nodes[index].metadataAmount; j++)
            {
                nodes[index].metadata.Add(Convert.ToInt32(input[i]));
                i++;
            }
        }
        static void Part1()
        {
            string inp = File.ReadAllText("input.txt");
            input = inp.Split(' ');

            AnalyzeNode();

            int sum = 0;

            foreach (Node node in nodes)
            {
                foreach (int data in node.metadata)
                {
                    sum += data;
                }
            }

            Console.WriteLine(sum);
            Console.Read();
        }
        static int CalculateValue(Node node)
        {
            if (node.childs == 0)
            {
                int sum = 0;
                foreach (int data in node.metadata)
                {
                    sum += data;
                }
                node.value = sum;
            }
            else
            {
                int sum = 0;
                for (int j = 0; j < node.metadata.Count; j++)
                {
                    if (node.metadata[j] <= node.childs && node.metadata[j] != 0)
                    {
                        sum += CalculateValue(nodes[node.childIndexes[node.metadata[j] - 1]]);
                    }
                }
                node.value = sum;
            }
            return node.value;
        }
        static void Part2()
        {
            string inp = File.ReadAllText("input.txt");
            input = inp.Split(' ');

            AnalyzeNode();

            Console.WriteLine(CalculateValue(nodes[0]));
            Console.Read();
        }
        static void Main(string[] args)
        {
            Part2();
        }
    }
}
