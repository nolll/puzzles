using Core.Puzzles.Year2017.Day16;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2017Tests
{
    public class Year2017Day16Tests
    {
        [Test]
        public void CorrectOrderAfterOneDance()
        {
            const string input = "s1,x3/4,pe/b";
            const string programs = "abcde";

            var dancingPrograms = new DancingPrograms(programs);
            dancingPrograms.Dance(input, 1);

            Assert.That(dancingPrograms.Programs, Is.EqualTo("baedc"));
        }

        [Test]
        public void CorrectOrderAfterOneBillionDances()
        {
            const string input = "s1,x3/4,pe/b";
            const string programs = "abcde";

            var dancingPrograms = new DancingPrograms(programs);
            dancingPrograms.Dance(input, 1_000_000_000);

            Assert.That(dancingPrograms.Programs, Is.EqualTo("abcde"));
        }
    }
}