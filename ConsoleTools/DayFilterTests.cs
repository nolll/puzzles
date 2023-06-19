using System.Collections.Generic;
using System.Linq;
using Aoc.Platform;
using NUnit.Framework;

namespace Aoc.ConsoleTools;

public class DayFilterTests
{
    [Test]
    public void FilterSlow()
    {
        var days = new List<PuzzleDay>
        {
            new(1, 1, new SlowPuzzle()),
            new(1, 1, new PlainPuzzle())
        };

        var parameters = new Parameters(runSlowOnly: true);
        var filter = new DayFilter(parameters);
        var result = filter.Filter(days);

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.First().Puzzle.IsSlow, Is.True);
    }

    [Test]
    public void FilterCommented()
    {
        var days = new List<PuzzleDay>
        {
            new(1, 1, new CommentedPuzzle()),
            new(1, 1, new PlainPuzzle())
        };

        var parameters = new Parameters(runCommentedOnly: true);
        var filter = new DayFilter(parameters);
        var result = filter.Filter(days);

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.First().Puzzle.Comment, Is.EqualTo("Comment"));
    }

    [Test]
    public void FilterFun()
    {
        var days = new List<PuzzleDay>
        {
            new(1, 1, new FunPuzzle()),
            new(1, 1, new PlainPuzzle())
        };

        var parameters = new Parameters(runFunOnly: true);
        var filter = new DayFilter(parameters);
        var result = filter.Filter(days);

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.First().Puzzle.IsFunToOptimize, Is.True);
    }

    private class CommentedPuzzle : Puzzle
    {
        public override string Title => "Commented Puzzle";
        public override string Comment => "Comment";
    }

    private class SlowPuzzle : Puzzle
    {
        public override string Title => "Slow Puzzle";
        public override bool IsSlow => true;
    }

    private class FunPuzzle : Puzzle
    {
        public override string Title => "Fun Puzzle";
        public override bool IsFunToOptimize => true;
    }

    private class PlainPuzzle : Puzzle
    {
        public override string Title => "Plain Puzzle";
    }
}