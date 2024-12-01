using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody04;

[Name("Royal Smith's Puzzle")]
public class Everybody04 : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var result = RunPart1And2(input);

        return new PuzzleResult(result, "eabb36cc8d28867fc0f0d332eda02eb3");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var result = RunPart1And2(input);

        return new PuzzleResult(result, "0a37c73499ec6bdb6af25453b7099e38");
    }

    protected override PuzzleResult RunPart3(string input)
    {
        var result = Part3(input);

        return new PuzzleResult(result, "17d992743f071f1de07d587e4026af89");
    }

    public static int RunPart1And2(string input)
    {
        var list = input.Split(LineBreaks.Single).Select(int.Parse).ToList();
        var smallest = list.Order().First();
        return list.Sum(o => o - smallest);
    }
    
    public static int Part3(string input)
    {
        var list = input.Split(LineBreaks.Single).Select(int.Parse).ToList();
        var ordered = list.Order().ToList();
        var smallest = ordered.First();
        var largest = ordered.Last();

        var smallestDiff = int.MaxValue;
        for (var i = smallest; i <= largest; i++)
        {
            var diff = list.Sum(o => Math.Abs(o - i));
            smallestDiff = Math.Min(smallestDiff, diff);
        }

        return smallestDiff;
    }
}