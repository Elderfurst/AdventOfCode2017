using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day12
    {
        private readonly string[] _pipes = File.ReadAllLines(@"Input/Day12.txt");
        private readonly List<Node> _nodes = new List<Node>();
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            foreach (var pipe in _pipes)
            {
                var half = pipe.Split(new string[] {"<->"}, StringSplitOptions.None);
                var main = int.Parse(half[0].Trim());
                var connections = half[1].Split(',').Select(x => new Node(int.Parse(x.Trim()), new List<Node>())).ToList();
                var tempNode = new Node(main, connections);
                _nodes.Add(tempNode);
            }
            var connects = new List<Node>();

            foreach (var node in _nodes)
            {
                if (ConnectsToNode(0, node, new List<int>()))
                {
                    connects.Add(node);
                }
            }

            Console.WriteLine(connects.Count);
        }

        private void PartTwo()
        {
            var accountedFor = new List<int>();
            var groups = new List<int>();
            while (accountedFor.Count < _nodes.Count)
            {
                var nextNode = _nodes.First(x => !accountedFor.Contains(x.Value));
                groups.Add(nextNode.Value);
                accountedFor.Add(nextNode.Value);
                foreach (var node in _nodes.Where(x => !accountedFor.Contains(x.Value)))
                {
                    if (ConnectsToNode(nextNode.Value, node, new List<int>()))
                    {
                        accountedFor.Add(node.Value);
                    }
                }
            }
            Console.WriteLine(groups.Count);
        }

        private bool ConnectsToNode(int value, Node node, List<int> previousValues)
        {
            if (node.Value == value)
            {
                return true;
            }
            if(node.Connections.Contains(new Node(value, new List<Node>())))
            {
                return true;
            }
            previousValues.Add(node.Value);
            return _nodes.Where(x => node.Connections.Contains(x) && x.Value != node.Value && !previousValues.Contains(x.Value)).Select(x => ConnectsToNode(value, x, previousValues)).Any(x => x);
        }
    }

    internal class Node
    {
        public int Value;
        public List<Node> Connections;

        public Node(int value, List<Node> connections)
        {
            Value = value;
            Connections = connections;
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj.GetType() == typeof(Node) && Value == ((Node)obj).Value;
        }

        public override int GetHashCode()
        {
            var hashCode = -1302046152;
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Node>>.Default.GetHashCode(Connections);
            return hashCode;
        }
    }
}
