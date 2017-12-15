using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day15
    {
        private const int GenAMultiplier = 16807;
        private const int GenBMultiplier = 48271;
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var count = 0;
            long genA = 618;
            long genB = 814;
            for (var i = 0; i < 40000000; i++)
            {
                genA = CalculateNextValue(genA, GenAMultiplier);
                genB = CalculateNextValue(genB, GenBMultiplier);
                var genABinary = Convert.ToString(genA, 2).PadLeft(32, '0');
                var genBBinary = Convert.ToString(genB, 2).PadLeft(32, '0');
                if (genABinary.Substring(16) == genBBinary.Substring(16))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        private long CalculateNextValue(long initial, long factor)
        {
            return initial * factor % 2147483647;
        }

        private void PartTwo()
        {
            var count = 0;
            long genA = 618;
            long genB = 814;
            var genANumbers = new List<string>();
            var genBNumbers = new List<string>();
            while(genANumbers.Count < 5000000 || genBNumbers.Count < 5000000)
            {
                genA = CalculateNextValue(genA, GenAMultiplier);
                genB = CalculateNextValue(genB, GenBMultiplier);
                if (genA % 4 == 0)
                {
                    var genABinary = Convert.ToString(genA, 2).PadLeft(32, '0');
                    genANumbers.Add(genABinary);
                }
                if (genB % 8 == 0)
                {
                    var genBBinary = Convert.ToString(genB, 2).PadLeft(32, '0');
                    genBNumbers.Add(genBBinary);
                }
            }

            for (var i = 0; i < 5000000; i++)
            {
                if (genANumbers[i].Substring(16) == genBNumbers[i].Substring(16))
                {
                    count++;
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine(count);
        }
    }
}
