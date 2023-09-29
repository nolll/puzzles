using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2017.Aoc201716;

public class Aoc201716Tests
{
    [Test]
    public void CorrectOrderAfterOneDance()
    {
        const string input = "s1,x3/4,pe/b";
        const string programs = "abcde";

        var dancingPrograms = new DancingPrograms(programs);
        dancingPrograms.Dance(input, 1);

        Assert.That(dancingPrograms.Programs, Is.EqualTo("baedc"));
    }

    [Test]
    public void CorrectOrderAfterOneBillionDances()
    {
        const string input = "s1,x3/4,pe/b";
        const string programs = "abcde";

        var dancingPrograms = new DancingPrograms(programs);
        dancingPrograms.Dance(input, 1_000_000_000);

        Assert.That(dancingPrograms.Programs, Is.EqualTo("abcde"));
    }
}