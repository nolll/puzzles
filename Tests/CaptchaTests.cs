using Core.Captcha;
using NUnit.Framework;

namespace Tests
{
    public class CaptchaTests
    {
        [TestCase("1122", 3)]
        [TestCase("1111", 4)]
        [TestCase("1234", 0)]
        [TestCase("91212129", 9)]
        public void CorrectSumOfMatchingNumbers(string input, int sum)
        {
            var captcha = new CaptchaCalculator(input);

            Assert.That(captcha.Sum, Is.EqualTo(sum));
        }
    }
}