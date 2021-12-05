using ConsoleApp.Puzzles.Year2017.Day01;
using NUnit.Framework;

namespace Tests
{
    public class CaptchaTests
    {
        [TestCase("1122", 3)]
        [TestCase("1111", 4)]
        [TestCase("1234", 0)]
        [TestCase("91212129", 9)]
        public void CorrectSumOfMatchingNumbers_Sum1(string input, int sum)
        {
            var captcha = new CaptchaCalculator(input);

            Assert.That(captcha.Sum1, Is.EqualTo(sum));
        }

        [TestCase("1212", 6)]
        [TestCase("1221", 0)]
        [TestCase("123425", 4)]
        [TestCase("123123", 12)]
        [TestCase("12131415", 4)]
        public void CorrectSumOfMatchingNumbers_Sum2(string input, int sum)
        {
            var captcha = new CaptchaCalculator(input);

            Assert.That(captcha.Sum2, Is.EqualTo(sum));
        }
    }
}