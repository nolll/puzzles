using Core.PassportProcessing;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class PassportProcessorTests
    {
        [TestCase("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr: 1937 iyr: 2017 cid: 147 hgt: 183cm")]
        [TestCase("hcl:#ae17e1 iyr:2013 eyr:2024 ecl:brn pid:760753108 byr:1931 hgt:179cm")]
        public void IsValid(string input)
        {
            var processor = new PassportProcessor();
            var isValid = processor.IsValid(input);

            Assert.That(isValid, Is.True);
        }

        [TestCase("iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929")]
        [TestCase("hcl:#cfa07d eyr:2025 pid:166559648 iyr:2011 ecl:brn hgt:59in")]
        public void IsInvalid(string input)
        {
            var processor = new PassportProcessor();
            var isValid = processor.IsValid(input);

            Assert.That(isValid, Is.False);
        }

        [Test]
        public void TwoPassportsAreValid()
        {
            var input = @"
ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in";

            var processor = new PassportProcessor();
            var count = processor.GetValidPassportCount(input);

            Assert.That(count, Is.EqualTo(2));
        }


    }
}