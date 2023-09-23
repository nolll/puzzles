using System;
using System.Collections.Generic;
using System.Linq;
using Common.Puzzles;

namespace Aoc;

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
        if (Activator.CreateInstance(t) is not AocPuzzle puzzle)
            throw new Exception($"Could not create Puzzle for day {day} {year} ");

        return CreatePuzzle(year, day, puzzle);
    }

    public static PuzzleWrapper CreatePuzzle(int year, int day, AocPuzzle puzzle)
    {
        return new PuzzleWrapper(puzzle.Id, puzzle.Title, puzzle.ListTitle, puzzle.GetTags().ToList(), puzzle);
    }

    private static bool IsPuzzle(Type type)
    {
        var ns = type.Namespace ?? string.Empty;
        return ns.Contains("Aoc.Puzzles");
    }
}