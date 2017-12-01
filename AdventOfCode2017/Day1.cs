using System;
using System.IO;

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
            var total = 0;

            for (var i = 0; i < _input.Length; i++)
            {
                if (int.Parse(_input[i].ToString()) == int.Parse(_input[(i + 1) % _input.Length].ToString()))
                {
                    total += int.Parse(_input[i].ToString());
                }
            }
            Console.WriteLine(total);
        }

        private void PartTwo()
        {
            var total = 0;
            var half = _input.Length / 2;
            var full = _input.Length;
            for (var i = 0; i < _input.Length; i++)
            {
                if (int.Parse(_input[i].ToString()) == int.Parse(_input[(i + half) % full].ToString()))
                {
                    total += int.Parse(_input[i].ToString());
                }
            }

            Console.WriteLine(total);
        }
    }
}
