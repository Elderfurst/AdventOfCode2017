using System;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day14
    {
        private const string Input = "amgozmfv";

        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var total = 0;
            for (var i = 0; i < 128; i++)
            {
                var temp = KnotHash(Input + "-" + i);
                total += temp.Where(x => x == 1).Sum();
            }
            Console.WriteLine(total);
        }

        private void PartTwo()
        {
            var grid = new int[128][];
            for (var i = 0; i < 128; i++)
            {
                grid[i] = KnotHash(Input + "-" + i).Select(x => x == 1 ? -1 : 0).ToArray();
            }

            var currentRegion = 0;
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == -1)
                    {
                        currentRegion++;
                        CreateRegion(ref grid, i, j, currentRegion);
                    }
                }
            }
            Console.WriteLine(currentRegion);
        }

        private void CreateRegion(ref int[][] grid, int i, int j, int currentRegion)
        {
            grid[i][j] = currentRegion;
            if (i == 0 && j == 0)
            {
                if (grid[i][j + 1] == -1)
                {
                    CreateRegion(ref grid, i, j + 1, currentRegion);
                }
                if (grid[i + 1][j] == -1)
                {
                    CreateRegion(ref grid, i + 1, j, currentRegion);
                }
            }
            else if (i == 0 && j == grid[i].Length - 1)
            {
                if(grid[i + 1][j] == -1)
                {
                    CreateRegion(ref grid, i + 1, j, currentRegion);
                }
                if (grid[i][j - 1] == -1)
                {
                    CreateRegion(ref grid, i, j - 1, currentRegion);
                }
            }
            else if (i == 0 && j != 0)
            {
                if (grid[i][j + 1] == -1)
                {
                    CreateRegion(ref grid, i, j + 1, currentRegion);
                }
                if (grid[i + 1][j] == -1)
                {
                    CreateRegion(ref grid, i + 1, j, currentRegion);
                }
                if (grid[i][j - 1] == -1)
                {
                    CreateRegion(ref grid, i, j - 1, currentRegion);
                }
            }
            else if (i == grid.GetLength(0) - 1 && j == 0)
            {
                if (grid[i - 1][j] == -1)
                {
                    CreateRegion(ref grid, i - 1, j, currentRegion);
                }
                if (grid[i][j + 1] == -1)
                {
                    CreateRegion(ref grid, i, j + 1, currentRegion);
                }
            }
            else if (i != 0 && j == 0)
            {
                if (grid[i - 1][j] == -1)
                {
                    CreateRegion(ref grid, i - 1, j, currentRegion);
                }
                if (grid[i][j + 1] == -1)
                {
                    CreateRegion(ref grid, i, j + 1, currentRegion);
                }
                if (grid[i + 1][j] == -1)
                {
                    CreateRegion(ref grid, i + 1, j, currentRegion);
                }
            }
            else if (i == grid.GetLength(0) - 1 && j == grid[i].Length - 1)
            {
                if (grid[i][j - 1] == -1)
                {
                    CreateRegion(ref grid, i, j - 1, currentRegion);
                }
                if (grid[i - 1][j] == -1)
                {
                    CreateRegion(ref grid, i - 1, j, currentRegion);
                }
            }
            else if (i != 0 && j == grid[i].Length - 1)
            {
                if (grid[i - 1][j] == -1)
                {
                    CreateRegion(ref grid, i - 1, j, currentRegion);
                }
                if (grid[i][j - 1] == -1)
                {
                    CreateRegion(ref grid, i, j - 1, currentRegion);
                }
                if (grid[i + 1][j] == -1)
                {
                    CreateRegion(ref grid, i + 1, j, currentRegion);
                }
            }
            else if (i == grid.GetLength(0) - 1 && j != 0)
            {
                if (grid[i][j - 1] == -1)
                {
                    CreateRegion(ref grid, i, j - 1, currentRegion);
                }
                if (grid[i - 1][j] == -1)
                {
                    CreateRegion(ref grid, i - 1, j, currentRegion);
                }
                if (grid[i][j + 1] == -1)
                {
                    CreateRegion(ref grid, i, j + 1, currentRegion);
                }
            }
            else
            {
                if (grid[i - 1][j] == -1)
                {
                    CreateRegion(ref grid, i - 1, j, currentRegion);
                }
                if (grid[i][j - 1] == -1)
                {
                    CreateRegion(ref grid, i, j - 1, currentRegion);
                }
                if (grid[i][j + 1] == -1)
                {
                    CreateRegion(ref grid, i, j + 1, currentRegion);
                }
                if (grid[i + 1][j] == -1)
                {
                    CreateRegion(ref grid, i + 1, j, currentRegion);
                }
            }
        }

        private int[] KnotHash(string input)
        {
            var encodedInput = Encoding.ASCII.GetBytes(input).Concat("17,31,73,47,23".Split(',').Select(byte.Parse).ToArray()).ToArray();
            var numbers = new int[256];
            var currentPosition = 0;
            var skipSize = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }
            for (var j = 0; j < 64; j++)
            {
                foreach (var length in encodedInput)
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
            for (var i = 0; i < 256; i += 16)
            {
                solution[i / 16] = numbers[i] ^ numbers[i + 1] ^ numbers[i + 2] ^ numbers[i + 3] ^ numbers[i + 4] ^ numbers[i + 5] ^ numbers[i + 6] ^ numbers[i + 7] ^ numbers[i + 8] ^ numbers[i + 9] ^ numbers[i + 10] ^ numbers[i + 11] ^ numbers[i + 12] ^ numbers[i + 13] ^ numbers[i + 14] ^ numbers[i + 15];
            }
            var hexSolution = string.Join("", solution.Select(x => x.ToString("x").PadLeft(2, '0')).ToArray()).ToCharArray().Select(x => x.ToString()).ToArray();
            var binarySolution = "";
            foreach (var character in hexSolution)
            {
                switch (character)
                {
                    case "0":
                        binarySolution += "0000";
                        break;
                    case "1":
                        binarySolution += "0001";
                        break;
                    case "2":
                        binarySolution += "0010";
                        break;
                    case "3":
                        binarySolution += "0011";
                        break;
                    case "4":
                        binarySolution += "0100";
                        break;
                    case "5":
                        binarySolution += "0101";
                        break;
                    case "6":
                        binarySolution += "0110";
                        break;
                    case "7":
                        binarySolution += "0111";
                        break;
                    case "8":
                        binarySolution += "1000";
                        break;
                    case "9":
                        binarySolution += "1001";
                        break;
                    case "a":
                        binarySolution += "1010";
                        break;
                    case "b":
                        binarySolution += "1011";
                        break;
                    case "c":
                        binarySolution += "1100";
                        break;
                    case "d":
                        binarySolution += "1101";
                        break;
                    case "e":
                        binarySolution += "1110";
                        break;
                    case "f":
                        binarySolution += "1111";
                        break;
                }
            }
            var binaryArray = binarySolution.ToCharArray().Select(x => x.ToString()).Select(int.Parse).ToArray();
            return binaryArray;
        }
    }
}
