using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2021.Aoc202113;

public class Aoc202113Tests
{
    [Test]
    public void Part1()
    {
        var paper = new TransparentPaper(Input);
        var result = paper.DotCountAfterFirstFold();

        Assert.That(result, Is.EqualTo(17));
    }

    [Test]
    public void Part2()
    {
        var paper = new TransparentPaper(Input);
        var result = paper.MessageAfterFold().Trim();

        Assert.That(result, Is.EqualTo(Result.Trim()));
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