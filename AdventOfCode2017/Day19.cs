using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day19
    {
        private readonly string[][] _path = File.ReadAllLines(@"Input/Day19.txt")
            .Select(x => x.ToCharArray().Select(y => y.ToString()).ToArray()).ToArray();
        public void Run()
        {
            PartOneAndTwo();
        }

        private void PartOneAndTwo()
        {
            var direction = "down";
            var letters = "";
            var startingSpace = Array.IndexOf(_path[0], "|");
            var i = 0;
            var j = startingSpace;
            var finished = false;
            var steps = 0;
            while (!finished)
            {
                steps++;
                switch (direction)
                {
                    case "down":
                        i++;
                        if (_path[i][j] != "|")
                        {
                            if (_path[i][j] != "-" && _path[i][j] != "+")
                            {
                                letters += _path[i][j];
                            }
                            if (_path[i + 1][j] != "|" && _path[i + 1][j] == " " && _path[i + 1][j] != "+")
                            {
                                if (_path[i][j - 1] != " ")
                                {
                                    direction = "left";
                                }
                                else if(_path[i][j + 1] != " ")
                                {
                                    direction = "right";
                                }
                                else
                                {
                                    finished = true;
                                }
                            }
                        }
                        break;
                    case "left":
                        j--;
                        if (_path[i][j] != "-")
                        {
                            if (_path[i][j] != "|" && _path[i][j] != "+")
                            {
                                letters += _path[i][j];
                            }
                            if (_path[i][j - 1] != "-" && _path[i][j - 1] == " " && _path[i][j - 1] != "+")
                            {
                                if (_path[i - 1][j] != " ")
                                {
                                    direction = "up";
                                }
                                else if (_path[i + 1][j] != " ")
                                {
                                    direction = "down";
                                }
                                else
                                {
                                    finished = true;
                                }
                            }
                        }
                        break;
                    case "right":
                        j++;
                        if (_path[i][j] != "-")
                        {
                            if (_path[i][j] != "|" && _path[i][j] != "+")
                            {
                                letters += _path[i][j];
                            }
                            if (_path[i][j + 1] != "-" && _path[i][j + 1] == " " && _path[i][j + 1] != "+")
                            {
                                if (_path[i - 1][j] != " ")
                                {
                                    direction = "up";
                                }
                                else if (_path[i + 1][j] != " ")
                                {
                                    direction = "down";
                                }
                                else
                                {
                                    finished = true;
                                }
                            }
                        }
                        break;
                    case "up":
                        i--;
                        if (_path[i][j] != "|")
                        {
                            if (_path[i][j] != "-" && _path[i][j] != "+")
                            {
                                letters += _path[i][j];
                            }
                            if (_path[i - 1][j] != "|" && _path[i - 1][j] != "+" && _path[i - 1][j] == " ")
                            {
                                if (_path[i][j - 1] != " ")
                                {
                                    direction = "left";
                                }
                                else if (_path[i][j + 1] != " ")
                                {
                                    direction = "right";
                                }
                                else
                                {
                                    finished = true;
                                }
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(letters);
            Console.WriteLine(steps);
        }
    }
}
