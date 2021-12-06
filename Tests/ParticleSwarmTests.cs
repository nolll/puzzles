using Core.Puzzles.Year2017.Day20;
using NUnit.Framework;

namespace Tests
{
    public class ParticleSwarmTests
    {
        private const string Input1 = @"
p=<3,0,0>, v=<2,0,0>, a=<-1,0,0>
p=<4,0,0>, v=<0,0,0>, a=<-2,0,0>";

        private const string Input2 = @"
p=<-6,0,0>, v=<3,0,0>, a=<0,0,0>
p=<-4,0,0>, v=<2,0,0>, a=<0,0,0>
p=<-2,0,0>, v=<1,0,0>, a=<0,0,0>
p=<3,0,0>, v=<-1,0,0>, a=<0,0,0>";

        [Test]
        public void After1Step()
        {
            var particleTracker = new ParticleTracker(Input1);
            particleTracker.Run(1);

            Assert.That(particleTracker.Particles[0].X, Is.EqualTo(4));
            Assert.That(particleTracker.Particles[1].X, Is.EqualTo(2));
        }

        [Test]
        public void After2Steps()
        {
            var particleTracker = new ParticleTracker(Input1);
            particleTracker.Run(2);

            Assert.That(particleTracker.Particles[0].X, Is.EqualTo(4));
            Assert.That(particleTracker.Particles[1].X, Is.EqualTo(-2));
        }

        [Test]
        public void After3Steps()
        {
            var particleTracker = new ParticleTracker(Input1);
            particleTracker.Run(3);

            Assert.That(particleTracker.Particles[0].X, Is.EqualTo(3));
            Assert.That(particleTracker.Particles[1].X, Is.EqualTo(-8));
        }

        [Test]
        public void ClosestParticleInTheLongRun()
        {
            var particleTracker = new ParticleTracker(Input1);
            var particle = particleTracker.GetClosestParticleInTheLongRunSimple();

            Assert.That(particle, Is.EqualTo(0));
        }

        [Test]
        public void Collisions()
        {
            var particleTracker = new ParticleTracker(Input2);
            var count = particleTracker.GetRemainingParticleCount();

            Assert.That(count, Is.EqualTo(1));
        }
    }
}