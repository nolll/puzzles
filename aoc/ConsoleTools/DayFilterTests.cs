using System.Collections.Generic;
using System.Linq;
using Common.Puzzles;
using NUnit.Framework;

namespace Aoc.ConsoleTools;

public class DayFilterTests
{
    [Test]
    public void FilterSlow()
    {
        var days = new List<PuzzleWrapper>
        {
            AocPuzzleFactory.CreatePuzzle(2000, 1, new SlowAocPuzzle()),
            AocPuzzleFactory.CreatePuzzle(2000, 1, new PlainAocPuzzle())
        };

        var parameters = new Parameters(tags: new List<string> { PuzzleTag.Slow });
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(days);

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.First().Puzzle.IsSlow, Is.True);
    }

    [Test]
    public void FilterCommented()
    {
        var days = new List<PuzzleWrapper>
        {
            AocPuzzleFactory.CreatePuzzle(2000, 1, new CommentedAocPuzzle()),
            AocPuzzleFactory.CreatePuzzle(2000, 1, new PlainAocPuzzle())
        };
        
        var parameters = new Parameters(tags: new List<string> { PuzzleTag.Commented });
        var filter = new PuzzleFilter(parameters);
        var result = filter.Filter(days);

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.First().Puzzle.Comment, Is.EqualTo("Comment"));
    }

    [Test]
    public void FilterFun()
    {
        var days = new List<PuzzleWrapper>
        {
            AocPuzzleFactory.CreatePuzzle(2000, 1, new FunAocPuzzle()),
            AocPuzzleFactory.CreatePuzzle(2000, 1, new PlainAocPuzzle())
        };

        var parameters = new Parameters(tags: new List<string> { PuzzleTag.Fun });
        var filter = new PuzzleFilter(parameters);
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