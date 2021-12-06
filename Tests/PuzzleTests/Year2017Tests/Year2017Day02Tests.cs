using Core.Puzzles.Year2017.Day02;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2017Tests
{
    public class Year2017Day02Tests
    {
        [Test]
        public void ChecksumMaxMinIsCorrect()
        {
            const string input = @"
5 1 9 5
7 5 3
2 4 6 8";

            var spreadsheet = new Spreadsheet(input);

            Assert.That(spreadsheet.ChecksumMaxMin, Is.EqualTo(18));
        }

        [Test]
        public void ChecksumDivisionIsCorrect()
        {
            const string input = @"
5 9 2 8
9 4 7 3
3 8 6 5";

            var spreadsheet = new Spreadsheet(input);

            Assert.That(spreadsheet.ChecksumDivision, Is.EqualTo(9));
        }
    }
}