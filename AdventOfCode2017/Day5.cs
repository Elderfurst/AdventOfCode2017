using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day5
    {
        private readonly int[] _input = File.ReadAllLines(@"input/Day5.txt").Select(int.Parse).ToArray();

        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var input = (int[])_input.Clone();
            var pointer = 0;
            var stepCounter = 0;
            while (true)
            {
                stepCounter++;
                var nextPointer = input[pointer];
                if (pointer + nextPointer < 0 || pointer + nextPointer >= input.Length)
                {
                    Console.WriteLine(stepCounter);
                    return;
                }
                input[pointer]++;
                pointer = pointer + nextPointer;
            }
        }

        private void PartTwo()
        {
            var input = (int[])_input.Clone();
            var pointer = 0;
            var stepCounter = 0;
            while (true)
            {
                stepCounter++;
                var nextPointer = input[pointer];
                if (pointer + nextPointer < 0 || pointer + nextPointer >= input.Length)
                {
                    Console.WriteLine(stepCounter);
                    return;
                }
                if (input[pointer] >= 3)
                {
                    input[pointer]--;
                }
                else
                {
                    input[pointer]++;
                }
                pointer = pointer + nextPointer;
            }
        }
    }
}
