using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day13
    {
        private readonly string[] _input = File.ReadAllLines(@"Input/Day13.txt");
        public void Run()
        {
            PartOne();
            PartTwo();
        }
        public void PartOne()
        {
            var layers = _input.Select(x => new FirewallLayer(x)).ToList();

            var severity = 0;

            foreach (var layer in layers)
            {
                if (layer.IsCaught(layer.Depth))
                {
                    severity += layer.Depth * layer.Range;
                }
            }
            Console.WriteLine(severity);
        }

        public void PartTwo()
        {
            var layers = _input.Select(x => new FirewallLayer(x)).ToList();

            var delay = 0;

            while (true)
            {
                var caught = false;

                foreach (var layer in layers)
                {
                    if (layer.IsCaught(layer.Depth + delay))
                    {
                        caught = true;
                        break;
                    }
                }

                if (!caught)
                {
                    Console.WriteLine(delay);
                    return;
                }

                delay++;
            }
        }
    }

    public class FirewallLayer
    {
        public int Depth;
        public int Range;
        public int RangeMultiple;

        public FirewallLayer(string input)
        {
            var words = input.Split(' ').Select(x => x.Trim()).ToArray();

            Depth = int.Parse(words[0].Replace(":", ""));
            Range = int.Parse(words[1]);

            RangeMultiple = (Range - 1) * 2;
        }

        public bool IsCaught(int seconds)
        {
            return (seconds % RangeMultiple) == 0;
        }
    }
}
