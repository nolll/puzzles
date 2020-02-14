using Core.ChronalClassification;
using NUnit.Framework;

namespace Tests
{
    public class ChronalClassificationTests
    {
        [Test]
        public void FindThreeMathingOperations()
        {
            var before = new[] { 3, 2, 1, 1 };
            var after = new[] { 3, 2, 2, 1 };

            var finder = new OperationFinder();
            var matchingOperations = finder.GetMatchingOperations(before, after, 2, 1, 2);

            Assert.That(matchingOperations.Count, Is.EqualTo(3));
        }
    }
}