using FluentAssertions;
using NUnit.Framework;
using Pzl.Client.Params;
using Pzl.Common;

namespace Pzl.Client.Filter;

public class PuzzleFilterTests
{
    [Test]
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

    [Test]
    public void FilterCommented()
    {
        var puzzles = new List<PuzzleDefinition>
        {
            new CommentedPuzzleDefinitionInTest(),
            new PlainPuzzleDefinitionInTest()
        };
        
        var parameters = new Parameters(tags: new List<string> { PuzzleTag.Commented });
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(puzzles).ToList();

        result.Count.Should().Be(1);
        result.First().Comment.Should().Be("Comment");
    }

    [Test]
    public void FilterFun()
    {
        var puzzles = new List<PuzzleDefinition>
        {
            new FunPuzzleDefinitionInTest(),
            new PlainPuzzleDefinitionInTest()
        };

        var parameters = new Parameters(tags: new List<string> { PuzzleTag.Fun });
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(puzzles).ToList();

        result.Count.Should().Be(1);
    }
}

public class PuzzleDefinitionInTest(
    IEnumerable<string>? tags = null,
    string? sortId = null,
    string? title = null,
    string? listTitle = null,
    string? name = null,
    string? comment = null,
    int? numberOfParts = null)
    : PuzzleDefinition(typeof(Puzzle),
        tags ?? [],
        sortId ?? "",
        title ?? "",
        listTitle ?? "",
        name ?? "",
        comment,
        numberOfParts ?? 1);

public class PlainPuzzleDefinitionInTest() : PuzzleDefinitionInTest(name: "Plain Puzzle");

public class CommentedPuzzleDefinitionInTest() : PuzzleDefinitionInTest(
    tags: [PuzzleTag.Commented],
    name: "Commented Puzzle",
    comment: "Comment");

public class FunPuzzleDefinitionInTest() : PuzzleDefinitionInTest(
    tags: [PuzzleTag.Fun],
    name: "Fun Puzzle");

public class SlowPuzzleDefinitionInTest() : PuzzleDefinitionInTest(
    tags: [PuzzleTag.Slow],
    name: "Slow Puzzle");