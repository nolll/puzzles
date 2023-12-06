using FluentAssertions;
using NUnit.Framework;
using Pzl.Tools.Computers.IntCode.Instructions;

namespace Pzl.Tools.Computers.IntCode;

public class InstructionParserTests
{
    [Test]
    public void ReturnsNull()
    {
        var result = InstructionParser.Parse(new List<long>(), 0, 0);

        result.Should().BeNull();
    }

    [Test]
    public void ReturnsAdditionInstruction()
    {
        const string input = "1,0,0,0";
        var memory = MemoryParser.Parse(input);
        var result = InstructionParser.Parse(memory, 0, 0);

        result.Should().BeOfType<AdditionInstruction>();
        result!.Parameters.Count.Should().Be(3);
        result.Parameters[0].Type.Should().Be(ParameterType.Position);
        result.Parameters[1].Type.Should().Be(ParameterType.Position);
        result.Parameters[2].Type.Should().Be(ParameterType.Position);
    }

    [Test]
    public void ReturnsMultiplicationInstruction()
    {
        const string input = "2,0,0,0";
        var memory = MemoryParser.Parse(input);
        var result = InstructionParser.Parse(memory, 0, 0);

        result.Should().BeOfType<MultiplicationInstruction>();
        result!.Parameters.Count.Should().Be(3);
        result.Parameters[0].Type.Should().Be(ParameterType.Position);
        result.Parameters[1].Type.Should().Be(ParameterType.Position);
        result.Parameters[2].Type.Should().Be(ParameterType.Position);
    }

    [Test]
    public void ReturnsInputInstruction()
    {
        const string input = "3,0,0,0";
        var memory = MemoryParser.Parse(input);
        var result = InstructionParser.Parse(memory, 0, 0);

        result!.Type.Should().Be(InstructionType.Input);
        result.Parameters.Count.Should().Be(1);
        result.Parameters[0].Type.Should().Be(ParameterType.Position);
    }

    [Test]
    public void ReturnsOutputInstruction()
    {
        const string input = "4,0,0,0";
        var memory = MemoryParser.Parse(input);
        var result = InstructionParser.Parse(memory, 0, 0);

        result.Should().BeOfType<OutputInstruction>();
        result!.Parameters.Count.Should().Be(1);
        result.Parameters[0].Type.Should().Be(ParameterType.Position);
    }

    [Test]
    public void ReturnsHaltInstruction()
    {
        const string input = "99,0,0,0";
        var memory = MemoryParser.Parse(input);
        var result = InstructionParser.Parse(memory, 0, 0);

        result.Should().BeOfType<HaltInstruction>();
        result!.Parameters.Count.Should().Be(0);
    }

    [Test]
    public void ReturnsAdditionInstructionWithImmediateParameters()
    {
        const string input = "01101,0,0,0";
        var memory = MemoryParser.Parse(input);
        var result = InstructionParser.Parse(memory, 0, 0);

        result!.Type.Should().Be(InstructionType.Addition);
        result.Parameters.Count.Should().Be(3);
        result.Parameters[0].Type.Should().Be(ParameterType.Immediate);
        result.Parameters[1].Type.Should().Be(ParameterType.Immediate);
        result.Parameters[2].Type.Should().Be(ParameterType.Position);
    }
}