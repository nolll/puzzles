using System.Collections.Generic;
using Core.Puzzles.Year2018.Day02;
using NUnit.Framework;

namespace Tests
{
    public class Year2018Day02Tests
    {
        [Test]
        public void NoSimilarIds()
        {
            var ids = new List<string> { "abcde", "fghij" };
            var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
            Assert.AreEqual(0, similarIds.Count);
        }

        [Test]
        public void EqualIdsIds_ReturnsNoMatch()
        {
            var ids = new List<string> { "abcde", "abcde" };
            var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
            Assert.AreEqual(0, similarIds.Count);
        }

        [Test]
        public void OneSimilarId()
        {
            var ids = new List<string> { "abcde", "abcdX" };
            var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
            Assert.AreEqual(2, similarIds.Count);
        }

        [Test]
        public void TwoSimilarIds_ReturnsOnlyFirstMatch()
        {
            var ids = new List<string> { "abcde", "abcdX", "fghij", "fghiX" };
            var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
            Assert.AreEqual(2, similarIds.Count);
        }
    }
}