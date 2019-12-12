using System.Collections.Generic;
using Core.Boxes;
using Core.SpaceImages;
using NUnit.Framework;

namespace Tests
{
    public class SpaceImageTests
    {
        [Test]
        public void LayerMatrixIsCorrect()
        {
            const string data = "012011210021";
            const int width = 4;
            var layer = new SpaceImageLayer(data, width);

            Assert.That(layer.GetChar(0, 0), Is.EqualTo('0'));
            Assert.That(layer.GetChar(1, 0), Is.EqualTo('1'));
            Assert.That(layer.GetChar(2, 0), Is.EqualTo('2'));
            Assert.That(layer.GetChar(3, 0), Is.EqualTo('0'));

            Assert.That(layer.GetChar(0, 1), Is.EqualTo('1'));
            Assert.That(layer.GetChar(1, 1), Is.EqualTo('1'));
            Assert.That(layer.GetChar(2, 1), Is.EqualTo('2'));
            Assert.That(layer.GetChar(3, 1), Is.EqualTo('1'));

            Assert.That(layer.GetChar(0, 2), Is.EqualTo('0'));
            Assert.That(layer.GetChar(1, 2), Is.EqualTo('0'));
            Assert.That(layer.GetChar(2, 2), Is.EqualTo('2'));
            Assert.That(layer.GetChar(3, 2), Is.EqualTo('1'));
        }
    }

    public class BoxChecksumTests
    {
        [Test]
        public void HandleProvidedExample()
        {
            const string ids = "abcdef\nbababc\nabbcde\nabcccd\naabcdd\nabcdee\nababab";
            var puzzle = new BoxChecksumPuzzle(ids);
            Assert.AreEqual(12, puzzle.Checksum);
        }
    }

    public class CommonLettersTests
    {
        [Test]
        public void AllLettersCommon()
        {
            const string str = "abcde";
            var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str, str);
            Assert.AreEqual("abcde", commonLetters);
        }

        [Test]
        public void NoLettersCommon()
        {
            const string str1 = "abcde";
            const string str2 = "fghij";
            var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str1, str2);
            Assert.AreEqual("", commonLetters);
        }

        [Test]
        public void ThreeLettersCommon()
        {
            const string str1 = "abcde";
            const string str2 = "aXcYe";
            var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str1, str2);
            Assert.AreEqual("ace", commonLetters);
        }
    }

    public class LevenshteinDistanceTests
    {
        [Test]
        public void NoDifference()
        {
            const string str = "abcde";
            var distance = LevenshteinDistance.Compute(str, str);
            Assert.AreEqual(0, distance);
        }

        [Test]
        public void OneCharDifference()
        {
            const string str1 = "abcde";
            const string str2 = "abcdX";
            var distance = LevenshteinDistance.Compute(str1, str2);
            Assert.AreEqual(1, distance);
        }

        [Test]
        public void TwoCharDifference()
        {
            const string str1 = "abcde";
            const string str2 = "abcXY";
            var distance = LevenshteinDistance.Compute(str1, str2);
            Assert.AreEqual(2, distance);
        }
    }

    public class SimilarIdsTests
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