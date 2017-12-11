using System;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day10
    {
        private readonly int[] _input = File.ReadAllText(@"Input/Day10.txt").Split(',').Select(int.Parse).ToArray();
        private readonly byte[] _secondInput = Encoding.ASCII.GetBytes(File.ReadAllText(@"Input/Day10.txt")).Concat("17,31,73,47,23".Split(',').Select(byte.Parse).ToArray()).ToArray();
        public void Run()
        {
            PartOne();
            PartTWo();
        }

        private void PartOne()
        {
            var numbers = new int[256];
            var currentPosition = 0;
            var skipSize = 0;
            for(var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            foreach (var length in _input)
            {
                var tempString = "";
                for(var i = currentPosition; i < length + currentPosition; i++)
                {
                    tempString += numbers[i % numbers.Length] + ",";
                }
                var reversedSubsection = tempString.Split(',').Where(x => x != "").Select(int.Parse).ToArray().Reverse().ToArray();
                for(var i = currentPosition; i < length + currentPosition; i++)
                {
                    numbers[i % numbers.Length] = reversedSubsection[i - currentPosition];
                }
                currentPosition = (currentPosition + length + skipSize) % numbers.Length;
                skipSize++;
            }

            Console.WriteLine(numbers[0] * numbers[1]);
        }

        private void PartTWo()
        {
            var numbers = new int[256];
            var currentPosition = 0;
            var skipSize = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }
            for (var j = 0; j < 64; j++)
            {
                foreach (var length in _secondInput)
                {
                    var tempString = "";
                    for (var i = currentPosition; i < length + currentPosition; i++)
                    {
                        tempString += numbers[i % numbers.Length] + ",";
                    }
                    var reversedSubsection = tempString.Split(',').Where(x => x != "").Select(int.Parse).ToArray().Reverse().ToArray();
                    for (var i = currentPosition; i < length + currentPosition; i++)
                    {
                        numbers[i % numbers.Length] = reversedSubsection[i - currentPosition];
                    }
                    currentPosition = (currentPosition + length + skipSize) % numbers.Length;
                    skipSize++;
                }
            }
            var solution = new int[16];
            for(var i = 0; i < 256; i += 16)
            {
                solution[i / 16] = numbers[i] ^ numbers[i + 1] ^ numbers[i + 2] ^ numbers[i + 3] ^ numbers[i + 4] ^ numbers[i + 5] ^ numbers[i + 6] ^ numbers[i + 7] ^ numbers[i + 8] ^ numbers[i + 9] ^ numbers[i + 10] ^ numbers[i + 11] ^ numbers[i + 12] ^ numbers[i + 13] ^ numbers[i + 14] ^ numbers[i + 15];
            }
            Console.WriteLine(String.Join("", solution.Select(x => x.ToString("x")).ToArray()));
        }
    }
}
