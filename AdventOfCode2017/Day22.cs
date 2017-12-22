using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day22
    {
        private readonly string[][] _map = File.ReadAllLines(@"Input/Day22.txt").Select(x => x.ToCharArray().Select(y => y.ToString()).ToArray()).ToArray();
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var extendedMap = new string[75][];
            for(var i = 0; i < 75; i++)
            {
                if(i < 25 || i >= 50)
                {
                    extendedMap[i] = new string[75];
                }
                else
                {
                    extendedMap[i] = new string[25].Concat(_map[i - 25]).Concat(new string[25]).ToArray();
                }
            }
            for(var i = 0; i < 75; i++)
            {
                for(var j = 0; j < 75; j++)
                {
                    if(extendedMap[i][j] == null)
                    {
                        extendedMap[i][j] = ".";
                    }
                }
            }
            var x = 37;
            var y = 37;
            var direction = "up";
            var infectionCount = 0;
            for(var i = 0; i < 10000; i++)
            {
                if(extendedMap[y][x] == "#")
                {
                    switch(direction)
                    {
                        case "up":
                            direction = "right";
                            break;
                        case "right":
                            direction = "down";
                            break;
                        case "down":
                            direction = "left";
                            break;
                        case "left":
                            direction = "up";
                            break;
                    }
                    extendedMap[y][x] = ".";
                }
                else
                {
                    switch (direction)
                    {
                        case "up":
                            direction = "left";
                            break;
                        case "left":
                            direction = "down";
                            break;
                        case "down":
                            direction = "right";
                            break;
                        case "right":
                            direction = "up";
                            break;
                    }
                    extendedMap[y][x] = "#";
                    infectionCount++;
                }
                switch (direction)
                {
                    case "up":
                        y--;
                        break;
                    case "right":
                        x++;
                        break;
                    case "down":
                        y++;
                        break;
                    case "left":
                        x--;
                        break;
                }
            }
            Console.WriteLine(infectionCount);
        }

        private void PartTwo()
        {
            var extendedMap = new string[575][];
            for (var i = 0; i < 575; i++)
            {
                if (i < 275 || i >= 300)
                {
                    extendedMap[i] = new string[575];
                }
                else
                {
                    extendedMap[i] = new string[275].Concat(_map[i - 275]).Concat(new string[275]).ToArray();
                }
            }
            for (var i = 0; i < 575; i++)
            {
                for (var j = 0; j < 575; j++)
                {
                    if (extendedMap[i][j] == null)
                    {
                        extendedMap[i][j] = ".";
                    }
                }
            }
            var x = 287;
            var y = 287;
            var direction = "up";
            var infectionCount = 0;
            for (var i = 0; i < 10000000; i++)
            {
                if (extendedMap[y][x] == "#")
                {
                    switch (direction)
                    {
                        case "up":
                            direction = "right";
                            break;
                        case "right":
                            direction = "down";
                            break;
                        case "down":
                            direction = "left";
                            break;
                        case "left":
                            direction = "up";
                            break;
                    }
                    extendedMap[y][x] = "f";
                }
                else if(extendedMap[y][x] == ".")
                {
                    switch (direction)
                    {
                        case "up":
                            direction = "left";
                            break;
                        case "left":
                            direction = "down";
                            break;
                        case "down":
                            direction = "right";
                            break;
                        case "right":
                            direction = "up";
                            break;
                    }
                    extendedMap[y][x] = "w";
                }
                else if(extendedMap[y][x] == "w")
                {
                    extendedMap[y][x] = "#";
                    infectionCount++;
                }
                else if(extendedMap[y][x] == "f")
                {
                    switch (direction)
                    {
                        case "up":
                            direction = "down";
                            break;
                        case "left":
                            direction = "right";
                            break;
                        case "down":
                            direction = "up";
                            break;
                        case "right":
                            direction = "left";
                            break;
                    }
                    extendedMap[y][x] = ".";
                }
                switch (direction)
                {
                    case "up":
                        y--;
                        break;
                    case "right":
                        x++;
                        break;
                    case "down":
                        y++;
                        break;
                    case "left":
                        x--;
                        break;
                }
            }
            Console.WriteLine(infectionCount);
        }
    }
}
