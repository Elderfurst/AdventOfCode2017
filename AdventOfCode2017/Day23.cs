using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017
{
    public class Day23
    {
        private readonly string[] _instructions = File.ReadAllLines(@"Input/Day23.txt");
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var registers = new Dictionary<string, long>();
            long mulCount = 0;
            for (long i = 0; i < _instructions.Length; i++)
            {
                var split = _instructions[i].Split(' ');
                if (!long.TryParse(split[1], out var reg))
                {
                    if (!registers.ContainsKey(split[1]))
                    {
                        registers.Add(split[1], 0);
                    }
                }
                switch (split[0])
                {
                    case "set":
                        if (long.TryParse(split[2], out var setValue))
                        {
                            registers[split[1]] = setValue;
                        }
                        else
                        {
                            registers[split[1]] = registers[split[2]];
                        }
                        break;
                    case "sub":
                        if (long.TryParse(split[2], out var addValue))
                        {
                            registers[split[1]] -= addValue;
                        }
                        else
                        {
                            registers[split[1]] -= registers[split[2]];
                        }
                        break;
                    case "mul":
                        if (long.TryParse(split[2], out var mulValue))
                        {
                            registers[split[1]] *= mulValue;
                        }
                        else
                        {
                            registers[split[1]] *= registers[split[2]];
                        }
                        mulCount++;
                        break;
                    case "jnz":
                        if (long.TryParse(split[1], out var regValue))
                        {
                            if (regValue != 0)
                            {
                                if (long.TryParse(split[2], out var jumpValue))
                                {
                                    i += (jumpValue - 1);
                                }
                                else
                                {
                                    i += (registers[split[2]] - 1);
                                }
                            }
                        }
                        else
                        {
                            if (registers[split[1]] != 0)
                            {
                                if (long.TryParse(split[2], out var jumpValue))
                                {
                                    i += (jumpValue - 1);
                                }
                                else
                                {
                                    i += (registers[split[2]] - 1);
                                }
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(mulCount);
        }

        private void PartTwo()
        {
            int a = 1;
            int b = 0;
            int c = 0;
            int d = 0;
            int f = 0;
            int g = 0;
            int h = 0;
            b = 57;
            c = b;

            if (a != 0)
            {
                b *= 100;
                b += 100000;
                c = b;
                c += 17000;
            }
            do
            {
                f = 1;
                d = 2;

                for (d = 2; d < b; d++)
                {
                    if (b % d == 0)
                    {
                        f = 0;
                        break;
                    }
                }
                if (f == 0)
                {
                    h++;
                }
                g = b - c;
                b += 17;
            } while (g != 0);
            Console.WriteLine(h);
        }
    }
}
