using ConsoleApp.Puzzles.Year2020.Day18;
using NUnit.Framework;

namespace Tests
{
    public class HomeworkMathTests
    {
        [TestCase("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [TestCase("2 * 3 + (4 * 5)", 26)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12_240)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13_632)]
        [TestCase("(3 * (6 * 4 * 2 * 2 + 3) + 9) + 4 + (6 * 2 + (8 + 4 * 8 * 4 + 8)) + 5", 719)]
        [TestCase("(5 + (2 + 9 * 2) * 3) * (6 * 3 * 4 * 3 * 9 + (6 + 3 * 8 + 9 + 6 + 2)) + 8 * (7 * 3 + 3 * 9) * (6 + 6)", 426_853_152)]
        public void SumIsCorrect(string input, long expected)
        {
            var calculator = new HomeworkCalculator();
            var sum = calculator.Sum(input, MathPrecedence.Order);

            Assert.That(sum, Is.EqualTo(expected));
        }

        [Test]
        public void SumofAllIsCorrect()
        {
            const string input = @"
1 + 2 * 3 + 4 * 5 + 6
1 + (2 * 3) + (4 * (5 + 6))
2 * 3 + (4 * 5)
5 + (8 * 3 + 9 + 3 * 4 * 3)
5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))
((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";

            const int expected = 26_457;

            var calculator = new HomeworkCalculator();
            var sum = calculator.SumOfAll(input, MathPrecedence.Order);

            Assert.That(sum, Is.EqualTo(expected));
        }

        [TestCase("1 + 2 * 3 + 4 * 5 + 6", 231)]
        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [TestCase("2 * 3 + (4 * 5)", 46)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        public void SumWithAdditionPrecedenceIsCorrect(string input, long expected)
        {
            var calculator = new HomeworkCalculator();
            var sum = calculator.Sum(input, MathPrecedence.Addition);

            Assert.That(sum, Is.EqualTo(expected));
        }
    }
}