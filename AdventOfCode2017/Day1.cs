using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day1
    {
        private readonly string _input = File.ReadAllText(@"Input/Day1.txt");
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var total = _input.Where((t, i) => int.Parse(t.ToString()) == int.Parse(_input[(i + 1) % _input.Length].ToString())).Sum(t => int.Parse(t.ToString()));

            Console.WriteLine(total);
        }

        private void PartTwo()
        {
            var half = _input.Length / 2;
            var full = _input.Length;

            var total = _input.Where((t, i) => int.Parse(t.ToString()) == int.Parse(_input[(i + half) % full].ToString())).Sum(t => int.Parse(t.ToString()));

            Console.WriteLine(total);
        }
    }
}
