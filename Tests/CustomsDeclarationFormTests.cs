using Core.CustomDeclarations;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class CustomsDeclarationFormTests
    {
        [Test]
        public void SumOfAtLeastYesAnswerCounts()
        {
            var reader = new DeclarationFormReader(Input);
            var sum = reader.SumOfAtLeastOneYes;

            Assert.That(sum, Is.EqualTo(11));
        }

        [Test]
        public void SumOfAllAnswerCounts()
        {
            var reader = new DeclarationFormReader(Input);
            var sum = reader.SumOfAllYes;

            Assert.That(sum, Is.EqualTo(6));
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
}