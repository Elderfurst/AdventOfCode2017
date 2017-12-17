using System;
using System.Collections.Generic;

namespace AdventOfCode2017
{
    public class Day17
    {
        private readonly int _input = 335;
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var currentPosition = 0;
            var buffer = new List<int>
            {
                0
            };
            for (var i = 1; i < 2018; i++)
            {
                var newPosition = ((currentPosition + _input) % buffer.Count) + 1;
                buffer.Insert(newPosition, i);
                currentPosition = newPosition;
            }
            Console.WriteLine(buffer[currentPosition + 1]);
        }

        private void PartTwo()
        {
            var currentPosition = 0;
            var size = 1;
            var value = 0;
            for (var i = 1; i < 50000001; i++)
            {
                var newPosition = ((currentPosition + _input) % size) + 1;
                if(newPosition == 1)
                {
                    value = i;
                }
                currentPosition = newPosition;
                size++;
            }
            Console.WriteLine(value);
        }
    }
}
