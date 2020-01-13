using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class PermutationGeneratorTests
    {
        [Test]
        public void GeneratesAllCombinations()
        {
            var generator = new PermutationGenerator();
            var sequences = generator.GetPermutations(new[] {1, 2, 3}).ToList();

            Assert.That(sequences.Count, Is.EqualTo(6));
        }
    }
}