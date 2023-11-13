using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2017.Aoc201720;

public class ParticleTracker
{
    private long _iterations;
    public IList<Particle> Particles { get; private set; }

    public ParticleTracker(string map)
    {
        Particles = ReadData(map);
    }

    private IList<Particle> ReadData(string data)
    {
        var rows = PuzzleInputReader.ReadLines(data);
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

    public int GetRemainingParticleCount()
    {
        const int maxIterations = 100;
        while (_iterations < maxIterations)
        {
            Run();

            var particles = new List<Particle>();
            foreach (var particle in Particles)
            {
                if (Particles.Count(o => o.IsColliding(particle)) == 1)
                    particles.Add(particle);
            }

            Particles = particles;

            _iterations++;
        }

        return Particles.Count;
    }

    public int GetClosestParticleInTheLongRunSimple()
    {
        return Particles
            .OrderBy(o => Math.Abs(o.Ax) + Math.Abs(o.Ay) + Math.Abs(o.Az))
            .First().Id;
    }

    private void Run()
    {
        UpdateVelocities();
        Move();
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