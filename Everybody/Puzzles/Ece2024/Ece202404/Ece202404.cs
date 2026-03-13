using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202404;

[Name("Royal Smith's Puzzle")]
public class Ece202404 : EverybodyEventPuzzle
{
    [Puzzle("eabb36cc8d28867fc0f0d332eda02eb3")]
    public int Part1(string input) => SolvePart1And2(input);
    
    [Puzzle("0a37c73499ec6bdb6af25453b7099e38")]
    public int Part2(string input) => SolvePart1And2(input);
    
    [Puzzle("17d992743f071f1de07d587e4026af89")]
    public int Part3(string input) => SolvePart3(input);

    private static int SolvePart1And2(string input)
    {
        var nails = ParseNails(input);
        var smallest = nails.Order().First();
        return nails.Sum(o => o - smallest);
    }

    private static int SolvePart3(string input)
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

    private static int[] ParseNails(string input) => input.Split(LineBreaks.Single).Select(int.Parse).Order().ToArray();
}