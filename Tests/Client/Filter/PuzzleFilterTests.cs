using AwesomeAssertions;
using Pzl.Client.Filter;
using Pzl.Client.Params;
using Pzl.Common;

namespace Tests.Client.Filter;

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

        var parameters = new Parameters(tags: [PuzzleTag.Slow]);
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(puzzles).ToList();

        result.Count.Should().Be(1);
    }

    [Fact]
    public void FilterCommented()
    {
        var puzzles = new List<PuzzleDefinition>
        {
            new CommentedPuzzleDefinitionInTest(),
            new PlainPuzzleDefinitionInTest()
        };
        
        var parameters = new Parameters(tags: [PuzzleTag.Commented]);
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(puzzles).ToList();

        result.Count.Should().Be(1);
        result.First().Comment.Should().Be("Comment");
    }

    [Fact]
    public void FilterFun()
    {
        var puzzles = new List<PuzzleDefinition>
        {
            new FunPuzzleDefinitionInTest(),
            new PlainPuzzleDefinitionInTest()
        };

        var parameters = new Parameters(tags: [PuzzleTag.Fun]);
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(puzzles).ToList();

        result.Count.Should().Be(1);
    }
}