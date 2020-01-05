using Core.Spreadsheets;
using NUnit.Framework;

namespace Tests
{
    public class SpreadsheetTests
    {
        [Test]
        public void ChecksumIsCorrect()
        {
            const string input = @"
5 1 9 5
7 5 3
2 4 6 8";

            var spreadsheet = new Spreadsheet(input);

            Assert.That(spreadsheet.Checksum, Is.EqualTo(18));
        }
    }
}