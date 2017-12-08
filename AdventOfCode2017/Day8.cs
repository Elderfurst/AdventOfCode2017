using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day8
    {
        private readonly string[] _input = File.ReadAllLines(@"Input/Day8.txt");
        public void Run()
        {
            PartOneAndTwo();
        }

        private void PartOneAndTwo()
        {
            var maxValue = 0;
            var registers = new List<Register>();
            foreach(var entry in _input)
            {
                var splitEntry = entry.Split(' ');
                if(!registers.Contains(new Register() { Name = splitEntry[0]}))
                {
                    registers.Add(new Register()
                    {
                        Name = splitEntry[0],
                        Value = 0
                    });
                }
            }
            foreach(var entry in _input)
            {
                var splitEntry = entry.Split(' ');
                var operation = splitEntry[5];
                var direction = splitEntry[1];
                var currentRegister = registers.First(x => x.Name == splitEntry[0]);
                switch(operation)
                {
                    case "<":
                        if(registers.First(x => x.Name == splitEntry[4]).Value < int.Parse(splitEntry[6]))
                        {
                            currentRegister.Value = direction == "dec" ? currentRegister.Value - int.Parse(splitEntry[2]) : currentRegister.Value + int.Parse(splitEntry[2]);
                        }
                        break;
                    case ">":
                        if (registers.First(x => x.Name == splitEntry[4]).Value > int.Parse(splitEntry[6]))
                        {
                            currentRegister.Value = direction == "dec" ? currentRegister.Value - int.Parse(splitEntry[2]) : currentRegister.Value + int.Parse(splitEntry[2]);
                        }
                        break;
                    case "<=":
                        if (registers.First(x => x.Name == splitEntry[4]).Value <= int.Parse(splitEntry[6]))
                        {
                            currentRegister.Value = direction == "dec" ? currentRegister.Value - int.Parse(splitEntry[2]) : currentRegister.Value + int.Parse(splitEntry[2]);
                        }
                        break;
                    case ">=":
                        if (registers.First(x => x.Name == splitEntry[4]).Value >= int.Parse(splitEntry[6]))
                        {
                            currentRegister.Value = direction == "dec" ? currentRegister.Value - int.Parse(splitEntry[2]) : currentRegister.Value + int.Parse(splitEntry[2]);
                        }
                        break;
                    case "==":
                        if (registers.First(x => x.Name == splitEntry[4]).Value == int.Parse(splitEntry[6]))
                        {
                            currentRegister.Value = direction == "dec" ? currentRegister.Value - int.Parse(splitEntry[2]) : currentRegister.Value + int.Parse(splitEntry[2]);
                        }
                        break;
                    case "!=":
                        if (registers.First(x => x.Name == splitEntry[4]).Value != int.Parse(splitEntry[6]))
                        {
                            currentRegister.Value = direction == "dec" ? currentRegister.Value - int.Parse(splitEntry[2]) : currentRegister.Value + int.Parse(splitEntry[2]);
                        }
                        break;
                    default:
                        break;
                }
                if(currentRegister.Value > maxValue)
                {
                    maxValue = currentRegister.Value;
                }
            }
            Console.WriteLine(registers.OrderByDescending(x => x.Value).First().Value);
            Console.WriteLine(maxValue);
        }
    }

    public class Register
    {
        public string Name;
        public int Value;

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Register) && ((Register)obj).Name == Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -244751520;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            return hashCode;
        }
    }
}
