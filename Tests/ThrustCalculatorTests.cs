using System.Linq;
using Core.Thrust;
using NUnit.Framework;

namespace Tests
{
    public class ThrustCalculatorTests
    {
        [TestCase("3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0", 4, 3, 2, 1, 0, 43210)]
        [TestCase("3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0", 0, 1, 2, 3, 4, 54321)]
        [TestCase("3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0", 1, 0, 4, 3, 2, 65210)]
        public void ThrustCalculationsAreCorrect(string input, int seq0, int seq1, int seq2, int seq3, int seq4, int expectedThrust)
        {
            var sequence = new [] { seq0, seq1, seq2, seq3, seq4 };
            var calculator = new ThrustCalculator(input);
            var thrust = calculator.GetThrust(sequence);

            Assert.That(thrust, Is.EqualTo(expectedThrust));
        }
    }

    public class SequenceGeneratorTests
    {
        [Test]
        public void GeneratesAllCombinations()
        {
            var generator = new SequenceGenerator();
            var sequences = generator.GetSequences(new[] {1, 2, 3}).ToList();

            Assert.That(sequences.Count, Is.EqualTo(6));
        }
    }
}