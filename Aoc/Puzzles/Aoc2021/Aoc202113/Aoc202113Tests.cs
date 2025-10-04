namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202113;

public class Aoc202113Tests
{
    [Fact]
    public void Part1()
    {
        var paper = new TransparentPaper(Input);
        var result = paper.DotCountAfterFirstFold();

        result.Should().Be(17);
    }

    [Fact]
    public void Part2()
    {
        var paper = new TransparentPaper(Input);
        var result = paper.MessageAfterFold().Trim();

        result.Should().Be(Result.Trim());
    }

    private const string Input = """
                                 6,10
                                 0,14
                                 9,10
                                 0,3
                                 10,4
                                 4,11
                                 6,0
                                 6,12
                                 4,1
                                 0,13
                                 10,12
                                 3,4
                                 3,0
                                 8,4
                                 1,10
                                 2,14
                                 8,10
                                 9,0

                                 fold along y=7
                                 fold along x=5
                                 """;

    private const string Result = """
                                  #####
                                  #...#
                                  #...#
                                  #...#
                                  #####
                                  .....
                                  .....
                                  """;
}