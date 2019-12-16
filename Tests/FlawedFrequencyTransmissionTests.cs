using Core.FlawedFrequencyTransmission;
using NUnit.Framework;

namespace Tests
{
    public class FlawedFrequencyTransmissionTests
    {
        [Test]
        public void SimpleAfterOnePhase()
        {
            const string input = "12345678";
            var algorithm = new FrequencyAlgorithm(input);
            var result = algorithm.Run(1);

            Assert.That(result, Is.EqualTo("48226158"));
        }

        [Test]
        public void SimpleAfterTwoPhases()
        {
            const string input = "12345678";
            var algorithm = new FrequencyAlgorithm(input);
            var result = algorithm.Run(2);

            Assert.That(result, Is.EqualTo("34040438"));
        }

        [Test]
        public void SimpleAfterThreePhases()
        {
            const string input = "12345678";
            var algorithm = new FrequencyAlgorithm(input);
            var result = algorithm.Run(3);

            Assert.That(result, Is.EqualTo("03415518"));
        }

        [Test]
        public void SimpleAfterFourPhases()
        {
            const string input = "12345678";
            var algorithm = new FrequencyAlgorithm(input);
            var result = algorithm.Run(4);

            Assert.That(result, Is.EqualTo("01029498"));
        }

        [TestCase("80871224585914546619083218645595", "24176176")]
        [TestCase("19617804207202209144916044189917", "73745418")]
        [TestCase("69317163492948606335995924319873", "52432133")]
        public void FirstEightDigitsAfter100Phases(string input, string expected)
        {
            var algorithm = new FrequencyAlgorithm(input);
            var result = algorithm.Run(100);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("03036732577212944063491565474664", "84462026")]
        [TestCase("02935109699940807407585447034323", "78725270")]
        [TestCase("03081770884921959731165446850517", "53553731")]
        public void MessageAfter100RealPhases(string input, string expected)
        {
            var algorithm = new FrequencyAlgorithm(input);
            var result = algorithm.RunReal(1);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}