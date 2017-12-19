using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day19
    {
        private readonly string[][] _path = File.ReadAllLines(@"Input/Day19.txt")
            .Select(x => x.ToCharArray().Select(y => y.ToString()).ToArray()).ToArray();
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var direction = "down";
            var letters = "";
            var startingSpace = Array.IndexOf(_path[0], "|");
            var i = 0;
            var j = startingSpace;
            var finished = false;
            while (!finished)
            {
                switch (direction)
                {
                    case "down":
                        i++;
                        if (_path[i][j] != "|")
                        {
                            
                        }
                        break;
                }
            }
        }

        private void PartTwo()
        {
            
        }
    }
}
