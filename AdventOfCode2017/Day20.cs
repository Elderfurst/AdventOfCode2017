using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day20
    {
        private readonly string[] _particles = File.ReadAllLines(@"Input/Day20.txt");
        public void Run()
        {
            PartOne();
            PartTwo();
        }

        private void PartOne()
        {
            var particles = new List<Particle>();
            foreach (var particle in _particles)
            {
                var split = particle.Replace("p", "").Replace("v", "").Replace("a", "").Replace("=", "").Replace("<", "").Replace(">", "").Replace(" ", "").Split(',');
                var temp = new Particle
                {
                    PosX = int.Parse(split[0]),
                    PosY = int.Parse(split[1]),
                    PosZ = int.Parse(split[2]),
                    VelX = int.Parse(split[3]),
                    VelY = int.Parse(split[4]),
                    VelZ = int.Parse(split[5]),
                    AccX = int.Parse(split[6]),
                    AccY = int.Parse(split[7]),
                    AccZ = int.Parse(split[8])
                };
                particles.Add(temp);
            }
            for (var i = 0; i < 1000; i++)
            {
                foreach (var particle in particles)
                {
                    particle.Update();
                }
            }
            Console.WriteLine(particles.IndexOf(particles.First(x => x.ManhattanDistance() == particles.Min(y => y.ManhattanDistance()))));
        }

        private void PartTwo()
        {
            var particles = new List<Particle>();
            foreach (var particle in _particles)
            {
                var split = particle.Replace("p", "").Replace("v", "").Replace("a", "").Replace("=", "").Replace("<", "").Replace(">", "").Replace(" ", "").Split(',');
                var temp = new Particle
                {
                    PosX = int.Parse(split[0]),
                    PosY = int.Parse(split[1]),
                    PosZ = int.Parse(split[2]),
                    VelX = int.Parse(split[3]),
                    VelY = int.Parse(split[4]),
                    VelZ = int.Parse(split[5]),
                    AccX = int.Parse(split[6]),
                    AccY = int.Parse(split[7]),
                    AccZ = int.Parse(split[8])
                };
                particles.Add(temp);
            }
            for (var i = 0; i < 1000; i++)
            {
                foreach (var particle in particles)
                {
                    particle.Update();
                }
                particles.RemoveAll(x => particles.Any(y =>
                    x.PosX == y.PosX && x.PosY == y.PosY && x.PosZ == y.PosZ &&
                    particles.IndexOf(x) != particles.IndexOf(y)));
            }
            Console.WriteLine(particles.Count);
        }
    }

    internal class Particle
    {
        public int PosX;
        public int PosY;
        public int PosZ;
        public int VelX;
        public int VelY;
        public int VelZ;
        public int AccX;
        public int AccY;
        public int AccZ;

        public void Update()
        {
            VelX += AccX;
            VelY += AccY;
            VelZ += AccZ;
            PosX += VelX;
            PosY += VelY;
            PosZ += VelZ;
        }

        public int ManhattanDistance()
        {
            return Math.Abs(PosX) + Math.Abs(PosY) + Math.Abs(PosZ);
        }
    }
}
