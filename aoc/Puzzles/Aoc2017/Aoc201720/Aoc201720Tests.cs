using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2017.Aoc201720;

public class Aoc201720Tests
{
    private const string Input1 = """
p=<3,0,0>, v=<2,0,0>, a=<-1,0,0>
p=<4,0,0>, v=<0,0,0>, a=<-2,0,0>
""";

    private const string Input2 = """
p=<-6,0,0>, v=<3,0,0>, a=<0,0,0>
p=<-4,0,0>, v=<2,0,0>, a=<0,0,0>
p=<-2,0,0>, v=<1,0,0>, a=<0,0,0>
p=<3,0,0>, v=<-1,0,0>, a=<0,0,0>
""";

    [Test]
    public void After1Step()
    {
        var particleTracker = new ParticleTracker(Input1.Trim());
        particleTracker.Run(1);

        particleTracker.Particles[0].X.Should().Be(4);
        particleTracker.Particles[1].X.Should().Be(2);
    }

    [Test]
    public void After2Steps()
    {
        var particleTracker = new ParticleTracker(Input1.Trim());
        particleTracker.Run(2);

        particleTracker.Particles[0].X.Should().Be(4);
        particleTracker.Particles[1].X.Should().Be(-2);
    }

    [Test]
    public void After3Steps()
    {
        var particleTracker = new ParticleTracker(Input1.Trim());
        particleTracker.Run(3);

        particleTracker.Particles[0].X.Should().Be(3);
        particleTracker.Particles[1].X.Should().Be(-8);
    }

    [Test]
    public void ClosestParticleInTheLongRun()
    {
        var particleTracker = new ParticleTracker(Input1.Trim());
        var particle = particleTracker.GetClosestParticleInTheLongRunSimple();

        particle.Should().Be(0);
    }

    [Test]
    public void Collisions()
    {
        var particleTracker = new ParticleTracker(Input2.Trim());
        var count = particleTracker.GetRemainingParticleCount();

        count.Should().Be(1);
    }
}