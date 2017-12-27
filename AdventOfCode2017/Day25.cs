using System;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day25
    {
        public void Run()
        {
            PartOne();
        }
        private void PartOne()
        {
            var state = "A";
            var iterations = 12523873;
            var tape = new int[iterations * 2];
            var marker = iterations;

            for(var i = 0; i < iterations; i++)
            {
                switch(state)
                {
                    case "A":
                        if(tape[marker] == 0)
                        {
                            tape[marker] = 1;
                            marker++;
                            state = "B";
                        }
                        else
                        {
                            tape[marker] = 1;
                            marker--;
                            state = "E";
                        }
                        break;
                    case "B":
                        if (tape[marker] == 0)
                        {
                            tape[marker] = 1;
                            marker++;
                            state = "C";
                        }
                        else
                        {
                            tape[marker] = 1;
                            marker++;
                            state = "F";
                        }
                        break;
                    case "C":
                        if (tape[marker] == 0)
                        {
                            tape[marker] = 1;
                            marker--;
                            state = "D";
                        }
                        else
                        {
                            tape[marker] = 0;
                            marker++;
                            state = "B";
                        }
                        break;
                    case "D":
                        if (tape[marker] == 0)
                        {
                            tape[marker] = 1;
                            marker++;
                            state = "E";
                        }
                        else
                        {
                            tape[marker] = 0;
                            marker--;
                            state = "C";
                        }
                        break;
                    case "E":
                        if (tape[marker] == 0)
                        {
                            tape[marker] = 1;
                            marker--;
                            state = "A";
                        }
                        else
                        {
                            tape[marker] = 0;
                            marker++;
                            state = "D";
                        }
                        break;
                    case "F":
                        if (tape[marker] == 0)
                        {
                            tape[marker] = 1;
                            marker++;
                            state = "A";
                        }
                        else
                        {
                            tape[marker] = 1;
                            marker++;
                            state = "C";
                        }
                        break;
                }
            }
            Console.WriteLine(tape.Count(x => x == 1));
        }
    }
}
