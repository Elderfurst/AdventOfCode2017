using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day2
    {
        private readonly string[] _input = File.ReadAllLines(@"Input/Day2.txt");
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var total = 0;
            foreach (var row in _input)
            {
                var splitRow = row.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                total += splitRow.Max() - splitRow.Min();
            }
            //var total = _input.Select(row => row.Split(new string[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()).Select(splitRow => splitRow.Max() - splitRow.Min()).Sum();
            Console.WriteLine(total);
        }

        private void PartTwo()
        {
            var total = 0;
            foreach (var row in _input)
            {
                var splitRow = row.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                for (var i = 0; i < splitRow.Count; i++)
                {
                    for (var j = i + 1; j < splitRow.Count; j++)
                    {
                        if (splitRow[i] % splitRow[j] == 0)
                        {
                            total += splitRow[i] / splitRow[j];
                        }
                        else if (splitRow[j] % splitRow[i] == 0)
                        {
                            total += splitRow[j] / splitRow[i];
                        }
                    }
                }
            }
            Console.WriteLine(total);
        }
    }
}
