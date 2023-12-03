using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Common.Computers.IntCode;

public class BoostTests
{
    [Test]
    public void ReturnsInputMemoryAsOutputMemory()
    {
        const string program = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99";

        var boostTester = new BoostRunner(program, 0);
        var result = boostTester.Run();

        string.Join(',', result.AllOutputs).Should().Be(program);
    }

    [Test]
    public void Outputs16DigitNumber()
    {
        const string program = "1102,34915192,34915192,7,4,7,99,0";

        var boostTester = new BoostRunner(program, 0);
        var result = boostTester.Run();

        result.LastOutput.ToString().Length.Should().Be(16);
    }

    [Test]
    public void ReturnsLargeMiddleNumber()
    {
        const string program = "104,1125899906842624,99";
        var expectedNumber = long.Parse(program.Split(',')[1]);

        var boostTester = new BoostRunner(program, 0);
        var result = boostTester.Run();

        result.LastOutput.Should().Be(expectedNumber);
    }
}