using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017
{
    public class Day16
    {
        private readonly string[] _directions = File.ReadAllText(@"Input/Day16.txt").Split(',');
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var dancers = new List<char>
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p'
            };

            foreach(var move in _directions)
            {
                if(move.StartsWith("s"))
                {
                    var number = int.Parse(move.Substring(1));
                    var counter = 0;
                    while(counter < number)
                    {
                        var temp = dancers[dancers.Count - 1];
                        for(var j = dancers.Count - 1; j > 0; j--)
                        {
                            dancers[j] = dancers[j - 1];
                        }
                        dancers[0] = temp;
                        counter++;
                    }
                }
                else if(move.StartsWith("x"))
                {
                    var pair = move.Substring(1);
                    var first = int.Parse(pair.Split('/')[0]);
                    var second = int.Parse(pair.Split('/')[1]);
                    var temp = dancers[second];
                    dancers[second] = dancers[first];
                    dancers[first] = temp;
                }
                else
                {
                    var pair = move.Substring(1);
                    var first = pair.Split('/')[0];
                    var second = pair.Split('/')[1];
                    var firstPosition = dancers.IndexOf(first[0]);
                    var secondPosition = dancers.IndexOf(second[0]);
                    var temp = dancers[secondPosition];
                    dancers[secondPosition] = dancers[firstPosition];
                    dancers[firstPosition] = temp;
                }
            }

            Console.WriteLine(string.Join("", dancers));
        }

        private void PartTwo()
        {
            var dancers = new List<char>
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p'
            };
            var seenPositions = new List<string>();
            while(!seenPositions.Contains(string.Join("", dancers)))
            {
                seenPositions.Add(string.Join("", dancers));
                foreach (var move in _directions)
                {
                    if (move.StartsWith("s"))
                    {
                        var number = int.Parse(move.Substring(1));
                        var counter = 0;
                        while (counter < number)
                        {
                            var temp = dancers[dancers.Count - 1];
                            for (var j = dancers.Count - 1; j > 0; j--)
                            {
                                dancers[j] = dancers[j - 1];
                            }
                            dancers[0] = temp;
                            counter++;
                        }
                    }
                    else if (move.StartsWith("x"))
                    {
                        var pair = move.Substring(1);
                        var first = int.Parse(pair.Split('/')[0]);
                        var second = int.Parse(pair.Split('/')[1]);
                        var temp = dancers[second];
                        dancers[second] = dancers[first];
                        dancers[first] = temp;
                    }
                    else
                    {
                        var pair = move.Substring(1);
                        var first = pair.Split('/')[0];
                        var second = pair.Split('/')[1];
                        var firstPosition = dancers.IndexOf(first[0]);
                        var secondPosition = dancers.IndexOf(second[0]);
                        var temp = dancers[secondPosition];
                        dancers[secondPosition] = dancers[firstPosition];
                        dancers[firstPosition] = temp;
                    }
                }
            }
            Console.WriteLine(seenPositions[1000000000 % seenPositions.Count]);
        }
    }
}
