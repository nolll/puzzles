using NUnit.Framework;

namespace Core.Puzzles.Year2017.Day04
{
    public class Year2017Day04Tests
    {
        [TestCase("aa bb cc dd ee", true)]
        [TestCase("aa bb cc dd aa", false)]
        [TestCase("aa bb cc dd aaa", true)]
        public void ValidatePassword1(string input, bool expected)
        {
            var validator = new PassphraseValidator();
            var coin = validator.IsValid1(input);

            Assert.That(coin, Is.EqualTo(expected));
        }

        [TestCase("abcde fghij", true)]
        [TestCase("abcde xyz ecdab", false)]
        [TestCase("a ab abc abd abf abj", true)]
        [TestCase("iiii oiii ooii oooi oooo", true)]
        [TestCase("oiii ioii iioi iiio", false)]
        public void ValidatePassword2(string input, bool expected)
        {
            var validator = new PassphraseValidator();
            var coin = validator.IsValid2(input);

            Assert.That(coin, Is.EqualTo(expected));
        }
    }
}