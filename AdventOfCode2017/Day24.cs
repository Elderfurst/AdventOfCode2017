using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day24
    {
        private readonly string[] _input = File.ReadAllLines(@"Input/Day24.txt");
        public void Run()
        {
            RedditSolution();
            //PartOne();
            //PartTwo();
        }

        private void RedditSolution()
        {
            var lines = _input.ToList();

            IImmutableList<(int, int)> edges = ImmutableList<(int, int)>.Empty;

            foreach (var line in lines)
            {
                var nums = line.Split('/');
                edges = edges.Add((int.Parse(nums[0]), int.Parse(nums[1])));
            }

            int Search(IImmutableList<(int, int)> e, int cur = 0, int strength = 0)
            {
                return e.Where(x => x.Item1 == cur || x.Item2 == cur).Select(x => Search(e.Remove(x), x.Item1 == cur ? x.Item2 : x.Item1, strength + x.Item1 + x.Item2)).Concat(Enumerable.Repeat(strength, 1)).Max();
            }

            (int, int) Search2(IImmutableList<(int, int)> e, int cur = 0, int strength = 0, int length = 0)
            {
                return e.Where(x => x.Item1 == cur || x.Item2 == cur).Select(x => Search2(e.Remove(x), x.Item1 == cur ? x.Item2 : x.Item1, strength + x.Item1 + x.Item2, length + 1)).Concat(Enumerable.Repeat((strength, length), 1)).OrderByDescending(x => x.Item2).ThenByDescending(x => x.Item1).First();
            }

            Console.WriteLine(Search(edges));
            Console.WriteLine(Search2(edges).Item1);
        }

        private void PartOne()
        {
            var pieces = new List<Piece>();
            var maxBridge = 0;
            foreach(var piece in _input)
            {
                var splitPiece = piece.Split('/');
                pieces.Add(new Piece
                {
                    First = int.Parse(splitPiece[0]),
                    Second = int.Parse(splitPiece[1])
                });
            }
            var startingPieces = pieces.Where(x => x.First == 0 || x.Second == 0);
            foreach(var piece in startingPieces)
            {
                var currentBridge = CreateBridge(piece, pieces.Where(x => (x.First != 0 && x.Second != 0) && x != piece).ToList());
                Console.WriteLine(piece.First + "/" + piece.Second + ": " + currentBridge);
                if (currentBridge > maxBridge)
                {
                    maxBridge = currentBridge;
                }
            }
            Console.WriteLine(maxBridge);
        }

        private void PartTwo()
        {

        }

        private int CreateBridge(Piece current, List<Piece> available)
        {
            if(available.Count == 0)
            {
                return current.First + current.Second;
            }
            var possiblePieces = available.Where(x => x.First == current.First || x.Second == current.First || x.First == current.Second || x.Second == current.Second).ToList();
            if(possiblePieces.Count == 0)
            {
                return current.First + current.Second;
            }

            var max = 0;
            foreach (var piece in possiblePieces)
            {
                var availablePieces = available.Where(x => x != piece).ToList();
                var currentBridge = CreateBridge(piece, available.Where(x => x != piece).ToList());
                if (currentBridge > max)
                {
                    max = currentBridge;
                }
            }
            return current.First + current.Second + max;
        }
    }

    internal class Piece
    {
        public int First;
        public int Second;

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Piece) && ((Piece)obj).First == First && ((Piece)obj).Second == Second;
        }

        public override int GetHashCode()
        {
            var hashCode = 43270662;
            hashCode = hashCode * -1521134295 + First.GetHashCode();
            hashCode = hashCode * -1521134295 + Second.GetHashCode();
            return hashCode;
        }
    }
}
