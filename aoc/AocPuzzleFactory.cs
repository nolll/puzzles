using System;
using System.Collections.Generic;
using System.Linq;
using Common.Puzzles;

namespace Aoc;

public class AocPuzzleFactory : PuzzleFactory
{
    public override List<Puzzle> CreatePuzzles() => CreatePuzzles<AocPuzzle>();
}