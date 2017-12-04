using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day4
    {
        private readonly string[] _input = File.ReadAllText(@"Input/Day4.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            Console.WriteLine(_input.Count(x => x.Split(' ').Count(y => x.Split(' ').Count(z => z == y) > 1) == 0));
        }

        private void PartTwo()
        {
            Console.WriteLine(_input.Count(x => x.Split(' ').Count(y => x.Split(' ').Count(z => z.OrderBy(a => a).SequenceEqual(y.OrderBy(b => b))) > 1) == 0));
        }
    }
}
