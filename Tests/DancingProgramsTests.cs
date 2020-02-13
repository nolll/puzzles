using Core.LineDance;
using NUnit.Framework;

namespace Tests
{
    public class LineDance
    {
        [Test]
        public void CorrectOrderAfterDance()
        {
            const string input = "s1,x3/4,pe/b";
            const string programs = "abcde";

            var dancingPrograms = new DancingPrograms(programs);
            dancingPrograms.Dance(input);

            Assert.That(dancingPrograms.Programs, Is.EqualTo("baedc"));
        }
    }
}