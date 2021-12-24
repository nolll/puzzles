using App.Common.Strings;
using NUnit.Framework;

namespace App.Puzzles.Year2021.Day24;

public class Year2021Day24Tests
{
    [Test]
    public void TestAlu()
    {
        const string input = @"
inp x
mul x -1";

        var alu = new Alu(input);
        var result = alu.Process();

        Assert.That(result.x, Is.EqualTo(0));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string Input = @"
";
}

public class Alu
{
    public Alu(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input);
    }

    public (int w, int x, int y, int z) Process()
    {
        return (0, 0, 0, 0);
    }
}