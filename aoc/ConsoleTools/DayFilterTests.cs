using System.Collections.Generic;
using System.Linq;
using Aoc.Platform;
using common.Puzzles;
using NUnit.Framework;

namespace Aoc.ConsoleTools;

public class DayFilterTests
{
    [Test]
    public void FilterSlow()
    {
        var days = new List<PuzzleWrapper>
        {
            new("id", "title", "list-title", new SlowAocPuzzle()),
            new("id", "title", "list-title", new PlainAocPuzzle())
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
        var days = new List<PuzzleWrapper>
        {
            new("id", "title", "list-title", new CommentedAocPuzzle()),
            new("id", "title", "list-title", new PlainAocPuzzle())
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
        var days = new List<PuzzleWrapper>
        {
            new("id", "title", "list-title", new FunAocPuzzle()),
            new("id", "title", "list-title", new PlainAocPuzzle())
        };

        var parameters = new Parameters(runFunOnly: true);
        var filter = new DayFilter(parameters);
        var result = filter.Filter(days);

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.First().Puzzle.IsFunToOptimize, Is.True);
    }

    private class CommentedAocPuzzle : AocPuzzle
    {
        public override string Name => "Commented Puzzle";
        public override string Comment => "Comment";
    }

    private class SlowAocPuzzle : AocPuzzle
    {
        public override string Name => "Slow Puzzle";
        public override bool IsSlow => true;
    }

    private class FunAocPuzzle : AocPuzzle
    {
        public override string Name => "Fun Puzzle";
        public override bool IsFunToOptimize => true;
    }

    private class PlainAocPuzzle : AocPuzzle
    {
        public override string Name => "Plain Puzzle";
    }
}