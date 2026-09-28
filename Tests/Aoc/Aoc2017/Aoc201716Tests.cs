using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201716Tests
{
    [Fact]
    public void CorrectOrderAfterOneDance()
    {
        const string input = "s1,x3/4,pe/b";
        const string programs = "abcde";

        var dancingPrograms = new Aoc201716.DancingPrograms(programs);
        dancingPrograms.Dance(input, 1);

        dancingPrograms.Programs.Should().Be("baedc");
    }

    [Fact]
    public void CorrectOrderAfterOneBillionDances()
    {
        const string input = "s1,x3/4,pe/b";
        const string programs = "abcde";

        var dancingPrograms = new Aoc201716.DancingPrograms(programs);
        dancingPrograms.Dance(input, 1_000_000_000);

        dancingPrograms.Programs.Should().Be("abcde");
    }
}