using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ParticleSwarm
{
    public class ParticleTracker
    {
        private const int DoneThreshold = 200;
        private long _iterations;
        public IList<Particle> Particles { get; }

        public ParticleTracker(string map)
        {
            Particles = ReadData(map);
        }

        private IList<Particle> ReadData(string data)
        {
            var rows = PuzzleInputReader.Read(data);
            var particles = new List<Particle>();
            var id = 0;
            foreach (var row in rows)
            {
                var parts = row.Split(", ");
                var p = ReadValues(parts[0]);
                var v = ReadValues(parts[1]);
                var a = ReadValues(parts[2]);
                var particle = new Particle(id, p[0], p[1], p[2], v[0], v[1], v[2], a[0], a[1], a[2]);
                particles.Add(particle);
                id++;
            }
            return particles;
        }

        private int[] ReadValues(string s)
        {
            return s.TrimEnd('>').Split('<')[1]
                .Split(',')
                .Select(int.Parse)
                .ToArray();
        }

        public void Run(int maxIterations)
        {
            while (_iterations < maxIterations)
            {
                Run();
                _iterations++;
            }
        }

        public int GetClosestParticleInTheLongRun()
        {
            var closest = new List<int>();
            var ids = "";
            
            while (!IsDone(closest))
            {
                UpdateVelocities();
                Move();

                if(closest.Count == DoneThreshold)
                    closest.RemoveAt(0);

                closest.Add(GetClosest());
                ids = string.Join(',', closest);
            }
        
            return closest.First();
        }

        private int GetClosest()
        {
            var byShortestX = Particles.OrderBy(o => o.ManhattanX);
            var byShortestY = Particles.OrderBy(o => o.ManhattanY);
            var byShortestZ = Particles.OrderBy(o => o.ManhattanZ);
            var scores = new Dictionary<int, ParticleScore>();
            foreach (var particle in Particles)
            {
                scores.Add(particle.Id, new ParticleScore(particle.Id));
            }

            var score = 0;
            foreach (var particle in byShortestX)
            {
                scores[particle.Id].ScoreX = score;
                score++;
            }

            score = 0;
            foreach (var particle in byShortestY)
            {
                scores[particle.Id].ScoreY = score;
                score++;
            }
            
            score = 0;
            foreach (var particle in byShortestZ)
            {
                scores[particle.Id].ScoreZ = score;
                score++;
            }
            
            return scores.Values.OrderBy(o => o.Score).First().Id;
        }

        private void Run()
        {
            UpdateVelocities();
            Move();
        }

        private class ParticleScore
        {
            public int Id { get; }
            public int ScoreX { get; set; }
            public int ScoreY { get; set; }
            public int ScoreZ { get; set; }
            public int Score => ScoreX + ScoreY + ScoreZ;

            public ParticleScore(int id)
            {
                Id = id;
            }
        }

        private static bool IsDone(IList<int> lastClosestParticles)
        {
            if (lastClosestParticles.Count < DoneThreshold)
                return false;

            return lastClosestParticles.Distinct().Count() == 1;
        }

        private void Move()
        {
            foreach (var p in Particles)
                p.Move();
        }

        private void UpdateVelocities()
        {
            foreach (var p in Particles)
                p.ChangeVelocity();
        }
    }
}