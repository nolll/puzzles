using System;
using System.Collections.Generic;
using System.Linq;
using Common.Puzzles;

namespace Aoc;

public class AocPuzzleFactory : PuzzleFactory
{
    public override List<Puzzle> CreatePuzzles() =>
        GetConcreteSubclassesOf<AocPuzzle>()
            .Where(IsPuzzle)
            .Select(CreatePuzzle)
            .OrderBy(o => o.Id)
            .ToList();

    private static Puzzle CreatePuzzle(Type t)
    {
        if (Activator.CreateInstance(t) is not AocPuzzle puzzle)
            throw new Exception($"Could not create puzzle: {t} ");

        return puzzle;
    }

    private static bool IsPuzzle(Type type)
    {
        var ns = type.Namespace ?? string.Empty;
        return ns.Contains("Aoc.Puzzles");
    }
}