namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201803;

public class Aoc201803Tests
{
    [Fact]
    public void NoOverlap()
    {
        const string claims = """
                              #1 @ 1,1: 1x1
                              #2 @ 3,3: 1x1
                              #3 @ 5,5: 1x1
                              """;

        var puzzle = new ClaimsOverlapCountPuzzle(claims);
        puzzle.OverlapCount.Should().Be(0);
    }

    [Fact]
    public void Overlap()
    {
        const string claims = """
                              #1 @ 1,3: 4x4
                              #2 @ 3,1: 4x4
                              #3 @ 5,5: 2x2
                              """;

        var puzzle = new ClaimsOverlapCountPuzzle(claims);
        puzzle.OverlapCount.Should().Be(4);
    }

    [Fact]
    public void IdWithNoOverlap()
    {
        const string claims = """
                              #1 @ 1,3: 4x4
                              #2 @ 3,1: 4x4
                              #3 @ 5,5: 2x2
                              """;
        var puzzle = new ClaimThatDoesNotOverlapPuzzle(claims);
        puzzle.ClaimId.Should().Be(3);
    }
}