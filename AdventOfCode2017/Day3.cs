using System;

namespace AdventOfCode2017
{
    public class Day3
    {
        private static readonly int _input = 289326;
        //private static readonly int _input = 25;

        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            int[,] _spiral = new int[(int)Math.Sqrt(_input) + 2, (int)Math.Sqrt(_input) + 2];
            int _row = 0;
            int _column = 0;
            var direction = "right";
            var row = _spiral.GetLength(0) / 2;
            var column = _spiral.GetLength(1) / 2;
            _spiral[row, column] = 1;
            for (var i = 2; i <= _input; i++)
            {
                if (direction == "right")
                {
                    column += 1;
                }
                else if (direction == "left")
                {
                    column -= 1;
                }
                else if (direction == "up")
                {
                    row -= 1;
                }
                else if (direction == "down")
                {
                    row += 1;
                }
                _spiral[row, column] = i;
                if (direction == "right" && _spiral[row - 1, column] == 0)
                {
                    direction = "up";
                }
                else if (direction == "left" && _spiral[row + 1, column] == 0)
                {
                    direction = "down";
                }
                else if (direction == "up" && _spiral[row, column - 1] == 0)
                {
                    direction = "left";
                }
                else if (direction == "down" && _spiral[row, column + 1] == 0)
                {
                    direction = "right";
                }
            }
            Console.WriteLine(Math.Abs(_row - _spiral.GetLength(0) / 2) + Math.Abs(_column - _spiral.GetLength(1) / 2));
        }

        private void PartTwo()
        {
            int[,] _spiral = new int[(int)Math.Sqrt(_input) + 2, (int)Math.Sqrt(_input) + 2];
            int _row = 0;
            int _column = 0;
            var direction = "right";
            var row = _spiral.GetLength(0) / 2;
            var column = _spiral.GetLength(1) / 2;
            _spiral[row, column] = 1;
            var current = 2;
            while(current <= _input)
            {
                if (direction == "right")
                {
                    column += 1;
                }
                else if (direction == "left")
                {
                    column -= 1;
                }
                else if (direction == "up")
                {
                    row -= 1;
                }
                else if (direction == "down")
                {
                    row += 1;
                }
                current = _spiral[row - 1, column + 1] + _spiral[row - 1, column] + _spiral[row - 1, column - 1] +
                          _spiral[row, column - 1] + _spiral[row, column + 1] + _spiral[row + 1, column - 1] +
                          _spiral[row + 1, column] + _spiral[row + 1, column + 1];
                _spiral[row, column] = current;
                if (direction == "right" && _spiral[row - 1, column] == 0)
                {
                    direction = "up";
                }
                else if (direction == "left" && _spiral[row + 1, column] == 0)
                {
                    direction = "down";
                }
                else if (direction == "up" && _spiral[row, column - 1] == 0)
                {
                    direction = "left";
                }
                else if (direction == "down" && _spiral[row, column + 1] == 0)
                {
                    direction = "right";
                }
            }
            Console.WriteLine(current);
        }
    }
}
