using NUnit.Framework;

namespace Common.Puzzles;

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

        var parameters = new Parameters(tags: new List<string> { PuzzleTag.Slow });
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(puzzles).ToList();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.First().IsSlow, Is.True);
    }

    [Test]
    public void FilterCommented()
    {
        var puzzles = new List<Puzzle>
        {
            new CommentedPuzzleInTest(),
            new PlainPuzzleInTest()
        };
        
        var parameters = new Parameters(tags: new List<string> { PuzzleTag.Commented });
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(puzzles).ToList();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.First().Comment, Is.EqualTo("Comment"));
    }

    [Test]
    public void FilterFun()
    {
        var puzzles = new List<Puzzle>
        {
            new FunPuzzleInTest(),
            new PlainPuzzleInTest()
        };

        var parameters = new Parameters(tags: new List<string> { PuzzleTag.Fun });
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(puzzles).ToList();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.First().IsFunToOptimize, Is.True);
    }
}