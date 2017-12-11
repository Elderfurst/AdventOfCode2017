using System;

namespace AdventOfCode2017
{
    public class Day3
    {
        private const int Input = 289326;
        //private const int Input = 25;

        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private static void PartOne()
        {
            var spiral = new int[(int)Math.Sqrt(Input) + 2, (int)Math.Sqrt(Input) + 2];
            var direction = "right";
            var row = spiral.GetLength(0) / 2;
            var column = spiral.GetLength(1) / 2;
            spiral[row, column] = 1;
            for (var i = 2; i <= Input; i++)
            {
                switch (direction)
                {
                    case "right":
                        column += 1;
                        break;
                    case "left":
                        column -= 1;
                        break;
                    case "up":
                        row -= 1;
                        break;
                    case "down":
                        row += 1;
                        break;
                    default:
                        break;
                }
                spiral[row, column] = i;
                if (direction == "right" && spiral[row - 1, column] == 0)
                {
                    direction = "up";
                }
                else if (direction == "left" && spiral[row + 1, column] == 0)
                {
                    direction = "down";
                }
                else if (direction == "up" && spiral[row, column - 1] == 0)
                {
                    direction = "left";
                }
                else if (direction == "down" && spiral[row, column + 1] == 0)
                {
                    direction = "right";
                }
            }
            Console.WriteLine(Math.Abs(spiral.GetLength(0) / 2 - row) + Math.Abs(spiral.GetLength(1) / 2 - column));
        }

        private static void PartTwo()
        {
            var spiral = new int[(int)Math.Sqrt(Input) + 2, (int)Math.Sqrt(Input) + 2];
            var direction = "right";
            var row = spiral.GetLength(0) / 2;
            var column = spiral.GetLength(1) / 2;
            spiral[row, column] = 1;
            var current = 2;
            while(current <= Input)
            {
                switch (direction)
                {
                    case "right":
                        column += 1;
                        break;
                    case "left":
                        column -= 1;
                        break;
                    case "up":
                        row -= 1;
                        break;
                    case "down":
                        row += 1;
                        break;
                    default:
                        break;
                }
                current = spiral[row - 1, column + 1] + spiral[row - 1, column] + spiral[row - 1, column - 1] +
                          spiral[row, column - 1] + spiral[row, column + 1] + spiral[row + 1, column - 1] +
                          spiral[row + 1, column] + spiral[row + 1, column + 1];
                spiral[row, column] = current;
                if (direction == "right" && spiral[row - 1, column] == 0)
                {
                    direction = "up";
                }
                else if (direction == "left" && spiral[row + 1, column] == 0)
                {
                    direction = "down";
                }
                else if (direction == "up" && spiral[row, column - 1] == 0)
                {
                    direction = "left";
                }
                else if (direction == "down" && spiral[row, column + 1] == 0)
                {
                    direction = "right";
                }
            }
            Console.WriteLine(current);
        }
    }
}
