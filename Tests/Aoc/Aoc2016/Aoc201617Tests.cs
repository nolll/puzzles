using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201617Tests : PuzzleTest<Aoc201617>
{
    [Theory]
    [InlineData("ihgpwlah", "DDRRRD")]
    [InlineData("kglvqrro", "DDUDRLRRUDRD")]
    [InlineData("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")]
    public void FindShortestPath(string passcode, string expectedPath) => Sut.Part1(passcode).Should().Be(expectedPath);
}