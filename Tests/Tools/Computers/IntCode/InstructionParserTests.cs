using Pzl.Tools.Computers.IntCode;
using Pzl.Tools.Computers.IntCode.Instructions;

namespace Tests.Tools.Computers.IntCode;

public class InstructionParserTests
{
    [Fact]
    public void ReturnsNull() => InstructionParser.Parse(new List<long>(), 0).Should().BeNull();

    [Fact]
    public void ReturnsAdditionInstruction()
    {
        var result = InstructionParser.Parse(MemoryParser.Parse("1,0,0,0"), 0);

        result.Should().BeOfType<AdditionInstruction>();
        result.Parameters.Count.Should().Be(3);
        result.Parameters[0].Type.Should().Be(ParameterType.Position);
        result.Parameters[1].Type.Should().Be(ParameterType.Position);
        result.Parameters[2].Type.Should().Be(ParameterType.Position);
    }

    [Fact]
    public void ReturnsMultiplicationInstruction()
    {
        var result = InstructionParser.Parse(MemoryParser.Parse("2,0,0,0"), 0);

        result.Should().BeOfType<MultiplicationInstruction>();
        result.Parameters.Count.Should().Be(3);
        result.Parameters[0].Type.Should().Be(ParameterType.Position);
        result.Parameters[1].Type.Should().Be(ParameterType.Position);
        result.Parameters[2].Type.Should().Be(ParameterType.Position);
    }

    [Fact]
    public void ReturnsInputInstruction()
    {
        var result = InstructionParser.Parse(MemoryParser.Parse("3,0,0,0"), 0);

        result!.Type.Should().Be(InstructionType.Input);
        result.Parameters.Count.Should().Be(1);
        result.Parameters[0].Type.Should().Be(ParameterType.Position);
    }

    [Fact]
    public void ReturnsOutputInstruction()
    {
        var result = InstructionParser.Parse(MemoryParser.Parse("4,0,0,0"), 0);

        result.Should().BeOfType<OutputInstruction>();
        result.Parameters.Count.Should().Be(1);
        result.Parameters[0].Type.Should().Be(ParameterType.Position);
    }

    [Fact]
    public void ReturnsHaltInstruction()
    {
        var result = InstructionParser.Parse(MemoryParser.Parse("99,0,0,0"), 0);

        result.Should().BeOfType<HaltInstruction>();
        result.Parameters.Count.Should().Be(0);
    }

    [Fact]
    public void ReturnsAdditionInstructionWithImmediateParameters()
    {
        var result = InstructionParser.Parse(MemoryParser.Parse("01101,0,0,0"), 0);

        result!.Type.Should().Be(InstructionType.Addition);
        result.Parameters.Count.Should().Be(3);
        result.Parameters[0].Type.Should().Be(ParameterType.Immediate);
        result.Parameters[1].Type.Should().Be(ParameterType.Immediate);
        result.Parameters[2].Type.Should().Be(ParameterType.Position);
    }
}