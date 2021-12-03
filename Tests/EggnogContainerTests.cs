using System.Collections.Generic;
using Core.Eggnog;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;

namespace Tests
{
    public class EggnogContainerTests
    {
        [Test]
        public void NumberOfCombinationsIsCorrect()
        {
            const string input = @"
20
15
10
5
5";

            var containers = new EggnogContainers(input);
            var combinations = containers.GetCombinations(25);

            Assert.That(combinations.Count, Is.EqualTo(4));
        }
    }
}