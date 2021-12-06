using ConsoleApp.Puzzles.Year2018.Day02;
using NUnit.Framework;

namespace Tests
{
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
}