using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class CustomsDeclarationFormTests
    {
        [Test]
        public void GroupAnswerCounts()
        {
            var reader = new DeclarationFormReader(Input);
            var sum = reader.SumOfYesAnswers;

            Assert.That(sum, Is.EqualTo(11));
        }

        private const string Input = @"
abc

a
b
c

ab
ac

a
a
a
a

b";
    }

    public class DeclarationFormReader
    {
        public int SumOfYesAnswers { get; }

        public DeclarationFormReader(string input)
        {
            var groups = PuzzleInputReader.ReadGroups(input);
            var lettersByGroup = groups.Select(GetGroupLetters);
            var groupCounts = lettersByGroup.Select(o => o.Length);
            SumOfYesAnswers = groupCounts.Sum();
        }

        private static char[] GetGroupLetters(IList<string> group)
        {
            var allAnswers = string.Join("", group);
            return allAnswers.ToCharArray().Distinct().OrderBy(o => o).ToArray();
        }
    }
}