using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day24;

public class Year2022Day24Tests
{
    [Test]
    public void Part1()
    {
        var puzzle = new Year2022Day24();
        var result = puzzle.Part1(Input);

        Assert.That(result, Is.EqualTo(18));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string Input = """
#E######
#>>.<^<#
#.<..<<#
#>v.><>#
#<^v^^>#
######.#
""";
}