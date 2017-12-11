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

            for(var i = 0; i < _input.Length; i++)
            {
                var letter = _input[i];
                if(letter == '!')
                {
                    i++;
                }
                else
                {
                    switch (letter)
                    {
                        case '{' when !garbage:
                            depth++;
                            score += depth;
                            break;
                        case '}' when !garbage:
                            depth--;
                            break;
                        case '>':
                            garbage = false;
                            break;
                        default:
                            break;
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
