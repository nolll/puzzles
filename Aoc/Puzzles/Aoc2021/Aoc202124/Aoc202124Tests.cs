using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202124;

public class Aoc202124Tests
{
    [TestCase(1, -1)]
    [TestCase(2, -2)]
    [TestCase(3, -3)]
    public void TestAlu1(long p, int expected)
    {
        const string input = """
                             inp x
                             mul x -1
                             """;

        var alu = new Alu(input.Trim());
        var result = alu.Process(p);

        result.Memory['x'].Should().Be(expected);
    }

    [TestCase(23, 0)]
    [TestCase(24, 0)]
    [TestCase(25, 0)]
    [TestCase(26, 1)]
    [TestCase(39, 1)]
    public void TestAlu2(long p, int expected)
    {
        const string input = """
                             inp z
                             inp x
                             mul z 3
                             eql z x
                             """;

        var alu = new Alu(input.Trim());
        var result = alu.Process(p);

        result.Memory['z'].Should().Be(expected);
    }

    [TestCase(1, 0, 0, 0, 1)]
    [TestCase(2, 0, 0, 1, 0)]
    [TestCase(3, 0, 0, 1, 1)]
    [TestCase(4, 0, 1, 0, 0)]
    [TestCase(5, 0, 1, 0, 1)]
    [TestCase(6, 0, 1, 1, 0)]
    [TestCase(7, 0, 1, 1, 1)]
    [TestCase(8, 1, 0, 0, 0)]
    [TestCase(9, 1, 0, 0, 1)]
    public void TestAlu2(long p, int expW, int expX, int expY, int expZ)
    {
        const string input = """
                             inp w
                             add z w
                             mod z 2
                             div w 2
                             add y w
                             mod y 2
                             div w 2
                             add x w
                             mod x 2
                             div w 2
                             mod w 2
                             """;

        var alu = new Alu(input.Trim());
        var result = alu.Process(p);

        result.Memory['w'].Should().Be(expW);
        result.Memory['x'].Should().Be(expX);
        result.Memory['y'].Should().Be(expY);
        result.Memory['z'].Should().Be(expZ);
    }
}