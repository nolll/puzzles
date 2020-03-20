using System.Collections.Generic;
using Core.Tools;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class ScrambledLettersTests
    {
        [Test]
        public void CorrectScramble()
        {
            const string input = "abcde";

            var scrambler = new StringScrambler();
            var result = scrambler.Scramble(input);

            Assert.That(result, Is.EqualTo("decab"));
        }
    }

    public class StringScrambler
    {
        private readonly IList<string> _instructions;

        public StringScrambler(string input)
        {
            _instructions = PuzzleInputReader.Read(input);
        }

        public string Scramble(string str)
        {
            foreach (var instruction in _instructions)
            {
                str = RunInstruction(instruction);
            }

            return str;
        }

        private string RunInstruction(string instruction)
        {
            throw new System.NotImplementedException();
        }
    }
}