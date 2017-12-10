using System;
using System.IO;

namespace AdventOfCode2017
{
    public class Day9
    {
        private readonly string _input = File.ReadAllText(@"Input/Day9.txt");
        public void Run()
        {
            PartOneAndTwo();
        }

        private void PartOneAndTwo()
        {
            var score = 0;
            var depth = 0;
            var garbageCount = 0;
            var garbage = false;
            char letter;

            for(var i = 0; i < _input.Length; i++)
            {
                letter = _input[i];
                if(letter == '!')
                {
                    i++;
                }
                else
                {
                    if(letter == '{' && !garbage)
                    {
                        depth++;
                        score += depth;
                    }
                    if(letter == '}' && !garbage)
                    {
                        depth--;
                    }
                    if (letter == '>')
                    {
                        garbage = false;
                    }
                    if (garbage)
                    {
                        garbageCount++;
                    }
                    if (letter == '<')
                    {
                        garbage = true;
                    }
                }
            }
            Console.WriteLine(score);
            Console.WriteLine(garbageCount);
        }
    }
}
