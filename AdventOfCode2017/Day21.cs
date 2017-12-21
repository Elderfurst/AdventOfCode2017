using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day21
    {
        private const string Start = ".#./..#/###";
        private readonly string[] _directions = File.ReadAllLines(@"Input/Day21.txt");

        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var grid = Start.Split('/').Select(x => x.ToCharArray().Select(y => y.ToString()).ToArray()).ToArray();
            for (var i = 0; i < 5; i++)
            {
                var grids = Split(grid);
                var newGrids = new List<string[][]>();
                foreach (var solo in grids)
                {
                    newGrids.Add(Transform(solo));
                }
                grid = Combine(newGrids);
            }
            Console.WriteLine(grid.Sum(x => x.Count(y => y == "#")));
        }

        private static List<string[][]> Split(string[][] grid)
        {
            var grids = new List<string[][]>();
            if (grid.GetLength(0) % 2 == 0)
            {
                for (var i = 0; i < grid.GetLength(0); i += 2)
                {
                    for (var j = 0; j < grid.GetLength(0); j += 2)
                    {
                        var smallGrid = new string[2][];
                        smallGrid[0] = new[]
                        {
                            grid[i][j], grid[i][j + 1]
                        };
                        smallGrid[1] = new[]
                        {
                            grid[i + 1][j], grid[i + 1][j + 1]
                        };
                        grids.Add(smallGrid);
                    }
                }
            }
            else
            {
                for (var i = 0; i < grid.GetLength(0); i += 3)
                {
                    for (var j = 0; j < grid.GetLength(0); j += 3)
                    {
                        var smallGrid = new string[3][];
                        smallGrid[0] = new[]
                        {
                            grid[i][j], grid[i][j + 1],grid[i][j + 2]
                        };
                        smallGrid[1] = new[]
                        {
                            grid[i + 1][j], grid[i + 1][j + 1], grid[i + 1][j + 2]
                        };
                        smallGrid[2] = new[]
                        {
                            grid[i + 2][j], grid[i + 2][j + 1], grid[i + 2][j + 2]
                        };
                        grids.Add(smallGrid);
                    }
                }
            }
            return grids;
        }
        private string[][] Transform(string[][] grid)
        {
            foreach (var direction in _directions)
            {
                var parts = direction.Split(' ');
                var directionSplit = parts[0].Split('/').Select(x => x.ToCharArray().Select(y => y.ToString()).ToArray()).ToArray();
                if (Matches(grid, directionSplit))
                {
                    return parts[2].Split('/').Select(x => x.ToCharArray().Select(y => y.ToString()).ToArray()).ToArray();
                }
            }
            return grid;
        }

        private static string[][] Combine(List<string[][]> grids)
        {
            if (grids.Count == 1)
            {
                return grids[0];
            }
            var grid = new string[(int)Math.Sqrt(grids.Count) * grids[0][0].Length][];
            var amount = (int) Math.Sqrt(grids.Count);
            var originalAmount = amount;
            var counter = 0;
            var previousCounter = 0;
            for (var i = 0; i < (int)Math.Sqrt(grids.Count) * grids[0][0].Length; i++)
            {
                var row = "";
                while (counter < amount)
                {
                    row += string.Join("", grids[counter][i % grids[0][0].Length]);
                    counter++;
                }
                if ((i + 1) % grids[0][0].Length == 0)
                {
                    previousCounter = counter;
                    amount += originalAmount;
                }
                else
                {
                    counter = previousCounter;
                }
                grid[i] = row.ToCharArray().Select(x => x.ToString()).ToArray();
            }
            return grid;
        }

        private static bool Matches(string[][] grid, string[][] direction)
        {
            if (grid.GetLength(0) != direction.GetLength(0))
            {
                return false;
            }
            if (Equals(grid, direction))
            {
                return true;
            }

            var gridNinety = Rotate(grid);
            if (Equals(gridNinety, direction))
            {
                return true;
            }

            var gridOneEighty = Rotate(gridNinety);
            if (Equals(gridOneEighty, direction))
            {
                return true;
            }

            var gridTwoSeventy = Rotate(gridOneEighty);
            if (Equals(gridTwoSeventy, direction))
            {
                return true;
            }

            var gridFlip = Flip(grid);
            if (Equals(gridFlip, direction))
            {
                return true;
            }

            var gridFlipNinety = Rotate(gridFlip);
            if (Equals(gridFlipNinety, direction))
            {
                return true;
            }

            var gridFlipOneEighty = Rotate(gridFlipNinety);
            if (Equals(gridFlipOneEighty, direction))
            {
                return true;
            }

            var gridFlipTwoSeventy = Rotate(gridFlipOneEighty);
            if (Equals(gridFlipTwoSeventy, direction))
            {
                return true;
            }

            return false;
        }

        private static bool Equals(string[][] first, string[][] second)
        {
            if (first.GetLength(0) != second.GetLength(0))
            {
                return false;
            }
            for (var i = 0; i < first.GetLength(0); i++)
            {
                for (var j = 0; j < first[i].Length; j++)
                {
                    if (first[i][j] != second[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static string[][] Rotate(string[][] grid)
        {
            var newGrid = new string[grid.GetLength(0)][];
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                var row = "";
                for (var j = grid[i].Length - 1; j >= 0; j--)
                {
                    row += grid[j][i];
                }
                newGrid[i] = row.ToCharArray().Select(x => x.ToString()).ToArray();
            }
            return newGrid;
        }

        private static string[][] Flip(string[][] grid)
        {
            return grid.Select(x => x.Reverse().ToArray()).ToArray();
        }

        private void PartTwo()
        {
            var grid = Start.Split('/').Select(x => x.ToCharArray().Select(y => y.ToString()).ToArray()).ToArray();
            for (var i = 0; i < 18; i++)
            {
                var grids = Split(grid);
                var newGrids = new List<string[][]>();
                foreach (var solo in grids)
                {
                    newGrids.Add(Transform(solo));
                }
                grid = Combine(newGrids);
            }
            Console.WriteLine(grid.Sum(x => x.Count(y => y == "#")));
        }
    }
}
