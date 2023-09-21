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
            new(1, 1, new SlowAocPuzzle()),
            new(1, 1, new PlainAocPuzzle())
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
            new(1, 1, new CommentedAocPuzzle()),
            new(1, 1, new PlainAocPuzzle())
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
            new(1, 1, new FunAocPuzzle()),
            new(1, 1, new PlainAocPuzzle())
        };

        var parameters = new Parameters(runFunOnly: true);
        var filter = new DayFilter(parameters);
        var result = filter.Filter(days);

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.First().Puzzle.IsFunToOptimize, Is.True);
    }

    private class CommentedAocPuzzle : AocPuzzle
    {
        public override string Title => "Commented Puzzle";
        public override string Comment => "Comment";
    }

    private class SlowAocPuzzle : AocPuzzle
    {
        public override string Title => "Slow Puzzle";
        public override bool IsSlow => true;
    }

    private class FunAocPuzzle : AocPuzzle
    {
        public override string Title => "Fun Puzzle";
        public override bool IsFunToOptimize => true;
    }

    private class PlainAocPuzzle : AocPuzzle
    {
        public override string Title => "Plain Puzzle";
    }
}