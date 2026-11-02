using Pzl.Client.Filter;
using Pzl.Client.Params;
using Pzl.Common;

namespace Tests.Client;

public class PuzzleFilterTests
{
    [Fact]
    public void FilterSlow()
    {
        var puzzles = new List<PuzzleDefinition>
        {
            new SlowPuzzleDefinitionInTest(),
            new PlainPuzzleDefinitionInTest()
        };

        new PuzzleFilter(Parameters.Create([PuzzleTag.Slow])).Filter(puzzles).ToList().Count.Should().Be(1);
    }

    [Fact]
    public void FilterCommented()
    {
        var puzzles = new List<PuzzleDefinition>
        {
            new CommentedPuzzleDefinitionInTest(),
            new PlainPuzzleDefinitionInTest()
        };

        var result = new PuzzleFilter(Parameters.Create([PuzzleTag.Commented])).Filter(puzzles).ToList();

        result.Count.Should().Be(1);
        result.First().Comment.Should().Be("Comment");
    }

    [Fact]
    public void FilterRewrite()
    {
        var puzzles = new List<PuzzleDefinition>
        {
            new RewritePuzzleDefinitionInTest(),
            new PlainPuzzleDefinitionInTest()
        };

        new PuzzleFilter(Parameters.Create([PuzzleTag.Rewrite])).Filter(puzzles).ToList().Count.Should().Be(1);
    }
}