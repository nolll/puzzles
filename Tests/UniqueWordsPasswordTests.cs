using Core.UniqueWordPasswords;
using NUnit.Framework;

namespace Tests
{
    public class UniqueWordsPasswordTests
    {
        [TestCase("aa bb cc dd ee", true)]
        [TestCase("aa bb cc dd aa", false)]
        [TestCase("aa bb cc dd aaa", true)]
        public void ValidatePassword(string input, bool expected)
        {
            var validator = new PassphraseValidator();
            var coin = validator.IsValid(input);

            Assert.That(coin, Is.EqualTo(expected));
        }
    }
}