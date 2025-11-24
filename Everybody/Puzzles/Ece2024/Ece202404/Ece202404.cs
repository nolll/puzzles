using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202404;

[Name("Royal Smith's Puzzle")]
public class Ece202404 : EverybodyEventPuzzle
{
    public PuzzleResult RunPart1(string input) => new(RunPart1And2(input), "eabb36cc8d28867fc0f0d332eda02eb3");
    public PuzzleResult RunPart2(string input) => new(RunPart1And2(input), "0a37c73499ec6bdb6af25453b7099e38");
    public PuzzleResult RunPart3(string input) => new(Part3(input), "17d992743f071f1de07d587e4026af89");

    private static int RunPart1And2(string input)
    {
        var nails = ParseNails(input);
        var smallest = nails.Order().First();
        return nails.Sum(o => o - smallest);
    }

    private static int Part3(string input)
    {
        var nails = ParseNails(input);
        var smallest = nails.First();
        var largest = nails.Last();

        var smallestDiff = int.MaxValue;
        for (var i = smallest; i <= largest; i++)
        {
            var diff = nails.Sum(o => Math.Abs(o - i));
            smallestDiff = Math.Min(smallestDiff, diff);
        }

        return smallestDiff;
    }

    private static int[] ParseNails(string input)
    {
        var list = input.Split(LineBreaks.Single).Select(int.Parse).ToList();
        var ordered = list.Order().ToArray();
        return ordered;
    }
}