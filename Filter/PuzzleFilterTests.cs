using FluentAssertions;
using NUnit.Framework;
using Pzl.Common;

namespace Pzl.Client.Filter;

public class PuzzleFilterTests
{
    [Test]
    public void FilterSlow()
    {
        var puzzles = new List<Puzzle>
        {
            new SlowPuzzleInTest(),
            new PlainPuzzleInTest()
        };

        var parameters = new Parameters.Parameters(tags: new List<string> { PuzzleTag.Slow });
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(puzzles).ToList();

        result.Count.Should().Be(1);
        result.First().IsSlow.Should().BeTrue();
    }

    [Test]
    public void FilterCommented()
    {
        var puzzles = new List<Puzzle>
        {
            new CommentedPuzzleInTest(),
            new PlainPuzzleInTest()
        };
        
        var parameters = new Parameters.Parameters(tags: new List<string> { PuzzleTag.Commented });
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(puzzles).ToList();

        result.Count.Should().Be(1);
        result.First().Comment.Should().Be("Comment");
    }

    [Test]
    public void FilterFun()
    {
        var puzzles = new List<Puzzle>
        {
            new FunPuzzleInTest(),
            new PlainPuzzleInTest()
        };

        var parameters = new Parameters.Parameters(tags: new List<string> { PuzzleTag.Fun });
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(puzzles).ToList();

        result.Count.Should().Be(1);
        result.First().IsFunToOptimize.Should().BeTrue();
    }
}