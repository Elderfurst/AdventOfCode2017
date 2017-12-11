using System;
using System.IO;

namespace AdventOfCode2017
{
    public class Day11
    {
        private readonly string[] _directions = File.ReadAllText(@"Input/Day11.txt").Split(',');
        public void Run()
        {
            PartOneAndTwo();
        }

        private void PartOneAndTwo()
        {

            var x = 0;
            var y = 0;
            var z = 0;
            var max = 0;
            foreach (var direction in _directions)
            {
                switch (direction)
                {
                    case "n":
                        y++;
                        z--;
                        break;
                    case "ne":
                        z--;
                        x++;
                        break;
                    case "se":
                        x++;
                        y--;
                        break;
                    case "s":
                        y--;
                        z++;
                        break;
                    case "sw":
                        z++;
                        x--;
                        break;
                    case "nw":
                        x--;
                        y++;
                        break;
                    default:
                        break;
                }
                if ((Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2 > max)
                {
                    max = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
                }
            }

            Console.WriteLine((Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2);
            Console.WriteLine(max);
        }
    }
}
