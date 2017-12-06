using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day6
    {
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var pastStates = new List<string>();
            var steps = 0;
            var banks = new int[]
            {
                4, 10, 4, 1, 8, 4, 9, 14, 5, 1, 14, 15, 0, 15, 3, 5
            };
            while (!pastStates.Contains(string.Join(",", banks.Select(x => x.ToString()))))
            {
                pastStates.Add(string.Join(",", banks.Select(x => x.ToString())));
                var distributeAmount = banks.Max();
                var workingIndex = Array.IndexOf(banks, distributeAmount);
                banks[workingIndex] = 0;
                for (var i = 1; i <= distributeAmount; i++)
                {
                    banks[(workingIndex + i) % banks.Length]++;
                }
                steps++;
            }
            Console.WriteLine(steps);
        }

        private void PartTwo()
        {
            var pastStates = new List<string>();
            //This is the end result of banks from PartOne
            var banks = new int[]
            {
                1, 0, 14, 14, 12, 11, 10, 9, 9, 7, 5, 5, 4, 3, 7, 1
            };
            var solution = string.Join(",", banks.Select(x => x.ToString()));
            var steps = 0;
            do
            {
                var distributeAmount = banks.Max();
                var workingIndex = Array.IndexOf(banks, distributeAmount);
                banks[workingIndex] = 0;
                for (var i = 1; i <= distributeAmount; i++)
                {
                    banks[(workingIndex + i) % banks.Length]++;
                }
                steps++;
            }
            while (string.Join(",", banks.Select(x => x.ToString())) != solution);
            Console.WriteLine(steps);
        }
    }
}
