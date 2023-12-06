using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Computers.Operation;

public class OpComputerTests
{
    [Test]
    public void FindThreeMathingOperations()
    {
        var before = new long[] { 3, 2, 1, 1 };
        var after = new long[] { 3, 2, 2, 1 };

        var computer = new OpComputer();
        var matchingOperations = computer.GetMatchingOperations(before, after, 2, 1, 2);

        matchingOperations.Count.Should().Be(3);
    }

    [Test]
    public void CorrectValueInRegister0AfterProgramHalts()
    {
        const string input = """
#ip 0
seti 5 0 1
seti 6 0 2
addi 0 1 0
addr 1 2 3
setr 1 0 0
seti 8 0 4
seti 9 0 5
""";

        var computer = new OpComputer();
        var value = computer.RunInstructionPointerProgram(input, 0, false, false);

        value.Should().Be(6);
    }
}