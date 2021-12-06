using System.Linq;
using Core.Puzzles.Year2015.Day24;
using NUnit.Framework;

namespace Tests
{
    public class BalancedPresentsTests
    {
        [Test]
        public void QuantumEntanglementOfFirstGroupIsCorrect()
        {
            const string input = @"
1
2
3
4
5
7
8
9
10
11";

            var balancer = new PresentBalancer(input, 3);

            Assert.That(balancer.QuantumEntanglementOfFirstGroup, Is.EqualTo(99));
        }
    }
}