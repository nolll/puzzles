using Core.NaughtyOrNice;
using NUnit.Framework;

namespace Tests
{
    public class NaughtyOrNiceTests
    {
        [TestCase("ugknbfddgicrmopn", true)]
        [TestCase("aaa", true)]
        [TestCase("jchzalrnumimnmhp", false)]
        [TestCase("haegwjzuvuyypxyu", false)]
        [TestCase("dvszwmarrgswjxmb", false)]
        public void DeterminesIfStringIsNaughtyOrNice(string input, bool expected)
        {
            var evaluator = new NaughtyOrNiceEvaluator();
            var isNice = evaluator.IsNice(input);

            Assert.That(isNice, Is.EqualTo(expected));
        }
    }
}