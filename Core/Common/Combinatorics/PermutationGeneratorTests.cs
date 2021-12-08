using System.Linq;
using Core.Common.Combinatorics;
using NUnit.Framework;

namespace Core.CommonTests
{
    public class PermutationGeneratorTests
    {
        [Test]
        public void GeneratesAllCombinations()
        {
            var sequences = PermutationGenerator.GetPermutations(new[] {1, 2, 3}).ToList();

            Assert.That(sequences.Count, Is.EqualTo(6));
        }
    }
}