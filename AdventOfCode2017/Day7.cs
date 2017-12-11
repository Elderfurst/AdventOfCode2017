using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day7
    {
        public void Run()
        {
            PartOne();
            PartTwo();
        }
        public static void PartOne()
        {
            var lines = File.ReadAllLines(@"Input/Day7.txt");

            var discs = lines.Select(x => new Disc(x)).ToList();
            discs.ForEach(x => x.AddChildDiscs(discs));

            Console.WriteLine(GetBaseDisc(discs).Name);
        }

        public static Disc GetBaseDisc(IEnumerable<Disc> discs)
        {
            var disc = discs.First();

            while (disc.Parent != null)
            {
                disc = disc.Parent;
            }

            return disc;
        }

        public static void PartTwo()
        {
            var lines = File.ReadAllLines(@"Input/Day7.txt");

            var discs = lines.Select(x => new Disc(x)).ToList();
            discs.ForEach(x => x.AddChildDiscs(discs));

            var disc = GetBaseDisc(discs);
            var targetWeight = 0;

            while (!disc.IsBalanced())
            {
                (disc, targetWeight) = disc.GetUnbalancedChild();
            }

            var weightDiff = targetWeight - disc.GetTotalWeight();
            Console.WriteLine(disc.Weight + weightDiff);
        }
    }

    public class Disc
    {
        public int Weight;
        public string Name;
        public List<string> ChildNames;
        public List<Disc> ChildDiscs;
        public Disc Parent;

        public Disc(string input)
        {
            var words = input.Split(' ').ToList();

            Name = words[0];
            Weight = int.Parse(words[1].Replace("(", "").Replace(")", ""));
            ChildNames = new List<string>();

            for (var i = 3; i < words.Count; i++)
            {
                ChildNames.Add(words[i].Replace(",", ""));
            }
        }

        public void AddChildDiscs(IEnumerable<Disc> discs)
        {
            ChildDiscs = ChildNames.Select(x => discs.First(y => y.Name == x)).ToList();
            ChildDiscs.ForEach(x => x.Parent = this);
        }

        public int GetTotalWeight()
        {
            var childSum = ChildDiscs.Sum(x => x.GetTotalWeight());
            return childSum + Weight;
        }

        public bool IsBalanced()
        {
            var groups = ChildDiscs.GroupBy(x => x.GetTotalWeight());
            return groups.Count() == 1;
        }

        public (Disc disc, int targetWeight) GetUnbalancedChild()
        {
            var groups = ChildDiscs.GroupBy(x => x.GetTotalWeight());
            var targetWeight = groups.First(x => x.Count() > 1).Key;
            var unbalancedChild = groups.First(x => x.Count() == 1).First();

            return (unbalancedChild, targetWeight);
        }
    }
}
