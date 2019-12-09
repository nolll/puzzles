using Core.Computer;
using NUnit.Framework;

namespace Tests
{
    public class BoostTest
    {
        //109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99 takes no input and produces a copy of itself as output.
        //1102,34915192,34915192,7,4,7,99,0 should output a 16-digit number.
        //104,1125899906842624,99 should output the large number in the middle.

        [Test]
        public void ReturnsInputMemoryAsOutputMemory()
        {
            const string program = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99";

            var boostTester = new BoostTester();
            var result = boostTester.Run(program);

            Assert.That(result.MemoryString, Is.EqualTo(program));
        }

        [Test]
        public void Outputs16DigitNumber()
        {
            const string program = "1102,34915192,34915192,7,4,7,99,0";

            var boostTester = new BoostTester();
            var result = boostTester.Run(program);

            Assert.That(result.Output.ToString().Length, Is.EqualTo(16));
        }

        [Test]
        public void ReturnsLargeMiddleNumber()
        {
            const string program = "104,1125899906842624,99";
            var expectedNumber = int.Parse(program.Split(',')[1]);

            var boostTester = new BoostTester();
            var result = boostTester.Run(program);

            Assert.That(result.Output, Is.EqualTo(expectedNumber));
        }
    }
}