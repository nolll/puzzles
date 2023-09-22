using System;
using System.Collections.Generic;
using System.Linq;
using common.Puzzles;

namespace Aoc.Platform;

public class AocPuzzleFactory : PuzzleFactory
{
    public override List<PuzzleWrapper> CreatePuzzles() =>
        GetConcreteSubclassesOf<AocPuzzle>()
            .Where(IsPuzzle)
            .Select(CreateDay)
            .OrderBy(o => o.Id)
            .ToList();

    private static PuzzleWrapper CreateDay(Type t)
    {
        var (year, day) = AocPuzzleParser.GetYearAndDay(t);
        if (Activator.CreateInstance(t) is not AocPuzzle puzzleDay)
            throw new Exception($"Could not create Puzzle for day {day} {year} ");

        var paddedDay = day.ToString().PadLeft(2, '0');
        var id = $"{year}{paddedDay}";
        var title = $"Day {day} {year}";
        var listTitle = $"Day {paddedDay} {year}";
        return new PuzzleWrapper(id, title, listTitle, puzzleDay);
    }
    
    private static bool IsPuzzle(Type type)
    {
        var ns = type.Namespace ?? string.Empty;
        return ns.Contains("Aoc.Puzzles");
    }
}