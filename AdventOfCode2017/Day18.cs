using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day18
    {
        private readonly string[] _instructions = File.ReadAllLines(@"Input/Day18.txt");
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var registers = new Dictionary<string, long>();
            long lastSoundPlayed = 0;
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
                    case "snd":
                        lastSoundPlayed = registers[split[1]];
                        break;
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
                    case "add":
                        if (long.TryParse(split[2], out var addValue))
                        {
                            registers[split[1]] += addValue;
                        }
                        else
                        {
                            registers[split[1]] += registers[split[2]];
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
                        break;
                    case "mod":
                        if (long.TryParse(split[2], out var modValue))
                        {
                            registers[split[1]] %= modValue;
                        }
                        else
                        {
                            registers[split[1]] %= registers[split[2]];
                        }
                        break;
                    case "rcv":
                        if (registers[split[1]] > 0)
                        {
                            Console.WriteLine(lastSoundPlayed);
                            return;
                        }
                        break;
                    case "jgz":
                        if (long.TryParse(split[1], out var regValue))
                        {
                            if (regValue > 0)
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
                            if (registers[split[1]] > 0)
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
        }

        private void PartTwo()
        {
            
        }
    }
}
