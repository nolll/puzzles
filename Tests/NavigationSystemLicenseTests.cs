using ConsoleApp.Puzzles.Year2018.Day08;
using NUnit.Framework;

namespace Tests
{
    public class NavigationSystemLicenseTests
    {
        [Test]
        public void MetaDataEntrySum()
        {
            const string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

            var calculator = new LicenseNumberCalculator(input);

            Assert.That(calculator.MetadataSum, Is.EqualTo(138));
            Assert.That(calculator.RootNodeValue, Is.EqualTo(66));
        }
    }
}